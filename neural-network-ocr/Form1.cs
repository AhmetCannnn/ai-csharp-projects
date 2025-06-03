using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OCR
{
    public partial class Form1 : Form
    {
        // Sinir ağı
        private MLP network;
        
        // Grid butonları ve durumları
        private Button[,] gridButtons;
        private bool[,] gridStates;
        
        // Grid boyutları ve görünüm sabitleri
        private const int GRID_ROWS = 7;
        private const int GRID_COLS = 5;
        private const int BUTTON_SIZE = 40;
        private const int GRID_MARGIN = 20;
        
        // Arayüz elemanları
        private Label[] outputLabels;
        private Label errorLabel;
        private Button recognizeButton;
        private double lastError = 0.0;
        private Panel rightPanel;
        
        // Renk teması
        private Color gridButtonDefault = Color.White;
        private Color gridButtonActive = Color.DodgerBlue;
        private Color primaryColor = Color.FromArgb(65, 105, 225); // Royal Blue
        private Color accentColor = Color.FromArgb(0, 150, 136);   // Teal
        private Color backgroundColor = Color.FromArgb(245, 245, 245);
        
        // Yazı tipleri
        private Font modernFont = new Font("Segoe UI", 11, FontStyle.Regular);
        private Font modernFontBold = new Font("Segoe UI", 11, FontStyle.Bold);
        private Font titleFont = new Font("Segoe UI", 14, FontStyle.Bold);
        
        // Kullanıcı girişi kontrolleri
        private NumericUpDown numericTargetError;
        private ComboBox comboReferenceLetter;
        private Button[,] referenceGridButtons;

        /// <summary>
        /// Form yapıcı metodu
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            InitializeGrid(); // Arayüz elemanlarını oluştur
            InitializeNetwork(); // Sinir ağını başlat
        }

        /// <summary>
        /// Arayüz elemanlarını ve grid'leri oluşturan metod
        /// </summary>
        private void InitializeGrid()
        {
            // Form özelliklerini ayarla
            this.BackColor = backgroundColor;
            this.Font = modernFont;
            this.Size = new Size(1000, 600);
            this.Text = "OCR - Harf Tanıma (A-E)";
            gridButtons = new Button[GRID_ROWS, GRID_COLS];
            gridStates = new bool[GRID_ROWS, GRID_COLS];

            // Ana başlık
            Label titleLabel = new Label
            {
                Text = "OCR - Yapay Sinir Ağı ile Harf Tanıma",
                Location = new Point(GRID_MARGIN, 15),
                Size = new Size(400, 30),
                Font = titleFont,
                ForeColor = primaryColor
            };
            this.Controls.Add(titleLabel);

            // Referans harf seçim alanı
            Label refLabel = new Label
            {
                Text = "Referans Harf:",
                Location = new Point(GRID_MARGIN, 60),
                Size = new Size(120, 25),
                Font = modernFont
            };
            this.Controls.Add(refLabel);

            // Referans harf için açılır kutu
            comboReferenceLetter = new ComboBox
            {
                Location = new Point(refLabel.Right + 10, refLabel.Top - 2),
                Size = new Size(80, 28),
                Font = modernFont,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboReferenceLetter.Items.AddRange(new object[] { "A", "B", "C", "D", "E" });
            comboReferenceLetter.SelectedIndex = 0;
            comboReferenceLetter.SelectedIndexChanged += ComboReferenceLetter_SelectedIndexChanged;
            this.Controls.Add(comboReferenceLetter);

            // Referans grid paneli (seçilen harfi gösterir)
            Panel refPanel = new Panel
            {
                Location = new Point(GRID_MARGIN, 90),
                Size = new Size(GRID_COLS * (BUTTON_SIZE + 6) + 20, GRID_ROWS * (BUTTON_SIZE + 6) + 40),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };
            refPanel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, refPanel.ClientRectangle,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid);
            };
            this.Controls.Add(refPanel);

            // Referans grid başlığı
            Label refGridLabel = new Label
            {
                Text = "Referans Harf Matrisi",
                Location = new Point(10, 10),
                Size = new Size(200, 25),
                Font = modernFontBold,
                ForeColor = primaryColor
            };
            refPanel.Controls.Add(refGridLabel);

            // Referans grid butonları (tıklanamaz, sadece gösterim amaçlı)
            referenceGridButtons = new Button[GRID_ROWS, GRID_COLS];
            int refGridStartX = 20;
            int refGridStartY = refGridLabel.Bottom + 5;
            for (int i = 0; i < GRID_ROWS; i++)
            {
                for (int j = 0; j < GRID_COLS; j++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(BUTTON_SIZE, BUTTON_SIZE),
                        Location = new Point(refGridStartX + j * (BUTTON_SIZE + 6), refGridStartY + i * (BUTTON_SIZE + 6)),
                        BackColor = gridButtonDefault,
                        FlatStyle = FlatStyle.Flat,
                        Font = modernFont,
                        TabStop = false,
                        Enabled = false
                    };
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Paint += (s, e) =>
                    {
                        var b = (Button)s;
                        b.Region = System.Drawing.Region.FromHrgn(
                            NativeMethods.CreateRoundRectRgn(0, 0, b.Width, b.Height, 12, 12));
                    };
                    referenceGridButtons[i, j] = btn;
                    refPanel.Controls.Add(btn);
                }
            }
            UpdateReferenceGrid(0); // Başlangıçta A harfi göster

            // Çizim grid paneli (kullanıcının harf çizeceği alan)
            Panel drawingPanel = new Panel
            {
                Location = new Point(refPanel.Right + 20, 90),
                Size = new Size(GRID_COLS * (BUTTON_SIZE + 6) + 20, GRID_ROWS * (BUTTON_SIZE + 6) + 40),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };
            drawingPanel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, drawingPanel.ClientRectangle,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid);
            };
            this.Controls.Add(drawingPanel);

            // Çizim grid başlığı
            Label drawingLabel = new Label
            {
                Text = "Tanınacak Harf Matrisi",
                Location = new Point(10, 10),
                Size = new Size(200, 25),
                Font = modernFontBold,
                ForeColor = accentColor
            };
            drawingPanel.Controls.Add(drawingLabel);

            // Çizim grid butonları (kullanıcı tıklayarak harf çizebilir)
            int drawGridStartX = 20;
            int drawGridStartY = drawingLabel.Bottom + 5;
            for (int i = 0; i < GRID_ROWS; i++)
            {
                for (int j = 0; j < GRID_COLS; j++)
                {
                    gridStates[i, j] = false;
                    Button btn = new Button
                    {
                        Size = new Size(BUTTON_SIZE, BUTTON_SIZE),
                        Location = new Point(drawGridStartX + j * (BUTTON_SIZE + 6), drawGridStartY + i * (BUTTON_SIZE + 6)),
                        BackColor = gridButtonDefault,
                        FlatStyle = FlatStyle.Flat,
                        Font = modernFont,
                        Tag = new Point(i, j),
                        TabStop = false
                    };
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseOverBackColor = Color.LightSkyBlue;
                    btn.FlatAppearance.MouseDownBackColor = Color.DeepSkyBlue;
                    btn.Click += GridButton_Click;
                    btn.Paint += (s, e) =>
                    {
                        var b = (Button)s;
                        b.Region = System.Drawing.Region.FromHrgn(
                            NativeMethods.CreateRoundRectRgn(0, 0, b.Width, b.Height, 12, 12));
                    };
                    gridButtons[i, j] = btn;
                    drawingPanel.Controls.Add(btn);
                }
            }

            // Temizle butonu (çizim gridini temizler)
            Button clearButton = new Button
            {
                Text = "Temizle",
                Size = new Size(120, 32),
                Location = new Point(drawingPanel.Right - 130, drawingPanel.Bottom + 15),
                BackColor = Color.White,
                ForeColor = Color.DimGray,
                FlatStyle = FlatStyle.Flat,
                Font = modernFont
            };
            clearButton.FlatAppearance.BorderColor = Color.LightGray;
            clearButton.FlatAppearance.BorderSize = 1;
            clearButton.Click += ClearButton_Click;
            this.Controls.Add(clearButton);

            // Sonuçlar paneli (çıkış değerlerini gösterir)
            rightPanel = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Size = new Size(260, 210),
                Location = new Point(drawingPanel.Right + 20, 90)
            };
            rightPanel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, rightPanel.ClientRectangle,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid);
            };
            this.Controls.Add(rightPanel);

            // Çıkışlar başlığı
            Label panelTitle = new Label
            {
                Text = "Çıkışlar",
                Font = modernFontBold,
                ForeColor = primaryColor,
                Location = new Point(20, 10),
                Size = new Size(220, 28)
            };
            rightPanel.Controls.Add(panelTitle);

            // Çıkışlar için iç panel
            Panel outputPanel = new Panel
            {
                Location = new Point(10, 45),
                Size = new Size(240, 5 * 32),
                BackColor = Color.White
            };
            rightPanel.Controls.Add(outputPanel);

            // Çıkış etiketleri (her harf için bir çıkış değeri gösterir)
            outputLabels = new Label[5];
            string[] harfler = { "E", "D", "C", "B", "A" };
            for (int i = 0; i < 5; i++)
            {
                outputLabels[i] = new Label
                {
                    Text = $"{harfler[i]} çıkışı = 0.0",
                    Size = new Size(220, 25),
                    Location = new Point(10, i * 32),
                    Font = modernFont
                };
                outputPanel.Controls.Add(outputLabels[i]);
            }

            // Eğitim parametreleri paneli
            Panel errorPanel = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Size = new Size(260, 120),
                Location = new Point(rightPanel.Left, rightPanel.Bottom + 20)
            };
            errorPanel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, errorPanel.ClientRectangle,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid);
            };
            this.Controls.Add(errorPanel);

            // Eğitim parametreleri başlığı
            Label errorTitle = new Label
            {
                Text = "Eğitim Parametreleri",
                Font = modernFontBold,
                ForeColor = primaryColor,
                Location = new Point(20, 10),
                Size = new Size(220, 28)
            };
            errorPanel.Controls.Add(errorTitle);

            // Hedef hata oranı etiketi
            Label targetErrorLabel = new Label
            {
                Text = "Hedef Hata Oranı:",
                Location = new Point(20, 45),
                Size = new Size(140, 28),
                Font = modernFont
            };
            errorPanel.Controls.Add(targetErrorLabel);

            // Hedef hata oranı kontrol elemanı
            numericTargetError = new NumericUpDown
            {
                DecimalPlaces = 3,
                Increment = 0.001M,
                Minimum = 0.001M,
                Maximum = 1.0M,
                Value = 0.01M,
                Size = new Size(80, 28),
                Location = new Point(targetErrorLabel.Right, 45),
                Font = modernFont
            };
            errorPanel.Controls.Add(numericTargetError);

            // Güncel hata oranı göstergesi
            errorLabel = new Label
            {
                Text = "Hata oranı : 0.00",
                Size = new Size(220, 30),
                Location = new Point(20, 80),
                Font = modernFont,
                ForeColor = Color.OrangeRed
            };
            errorPanel.Controls.Add(errorLabel);

            // Eğit butonu (sinir ağını eğitmek için)
            Button trainButton = new Button
            {
                Text = "Eğit",
                Size = new Size(125, 38),
                Location = new Point(refPanel.Left, drawingPanel.Bottom + 15),
                BackColor = primaryColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = modernFontBold
            };
            trainButton.FlatAppearance.BorderSize = 0;
            trainButton.Click += TrainButton_Click;
            this.Controls.Add(trainButton);

            // Tanımla butonu (çizilen harfi tanımak için)
            recognizeButton = new Button
            {
                Text = "Tanımla",
                Size = new Size(125, 38),
                Location = new Point(trainButton.Right + 15, drawingPanel.Bottom + 15),
                BackColor = accentColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = modernFontBold
            };
            recognizeButton.FlatAppearance.BorderSize = 0;
            recognizeButton.Click += TestButton_Click;
            this.Controls.Add(recognizeButton);
        }

        /// <summary>
        /// Sinir ağı yapısını oluşturur
        /// </summary>
        private void InitializeNetwork()
        {
            // 35 nöron (7x5 grid) girişli, 20 nöronlu gizli katman, 5 nöron (5 harf) çıkışlı MLP yapısı
            network = new MLP(GRID_ROWS * GRID_COLS, 20, 5);
        }

        /// <summary>
        /// Grid butonlarına tıklama olayını yönetir
        /// </summary>
        private void GridButton_Click(object sender, EventArgs e)
        {
            // Tıklanan butonun koordinatlarını al
            Button btn = (Button)sender;
            Point p = (Point)btn.Tag;
            int i = p.X, j = p.Y;
            
            // Durumu tersine çevir (aktif-pasif)
            gridStates[i, j] = !gridStates[i, j];
            
            // Buton rengini güncelle
            btn.BackColor = gridStates[i, j] ? gridButtonActive : gridButtonDefault;
        }

        /// <summary>
        /// Sinir ağını eğitmek için kullanılır
        /// </summary>
        private void TrainButton_Click(object sender, EventArgs e)
        {
            // Eğitim parametrelerini al
            double targetError = (double)numericTargetError.Value;
            double error = 1.0;
            int iterations = 0;
            int selectedLetterIndex = comboReferenceLetter.SelectedIndex;

            // Hedef hata oranına ulaşana kadar veya maksimum iterasyon sayısına kadar eğitim yap
            while (error > targetError && iterations < 10000)
            {
                error = 0;
                
                // Tüm harfler için eğitim yap
                for (int i = 0; i < 5; i++)
                {
                    // Harfin girdi ve beklenen çıktı değerlerini al
                    var input = TrainingData.GetFlattenedInput(i);
                    var target = TrainingData.GetExpectedOutput(i);
                    
                    // Sinir ağını bu harf için eğit
                    network.Train(input, target);

                    // Eğitim hatasını hesapla
                    var output = network.Forward(input);
                    for (int j = 0; j < 5; j++)
                    {
                        error += Math.Pow(target[j] - output[j], 2);
                    }
                }
                
                // Toplam hata ortalamasını hesapla
                error /= 5;
                iterations++;

                // Her 100 iterasyonda arayüzü güncelle
                if (iterations % 100 == 0 || error <= targetError)
                {
                    this.errorLabel.Text = $"Hata: {error:F5}";
                    this.errorLabel.Update();
                    lastError = error;
                }
            }

            // Eğitim sonucu hakkında bilgi ver
            MessageBox.Show($"Eğitim tamamlandı!\nİterasyonlar: {iterations}\nSon hata: {error:F5}");
        }

        /// <summary>
        /// Çizilen harfi tanımlamak için kullanılır
        /// </summary>
        private void TestButton_Click(object sender, EventArgs e)
        {
            // Grid'den kullanıcının çizdiği harfin girdilerini al
            var inputs = GetCurrentGridInput();
            
            // Sinir ağı ile ileri yayılım yaparak çıktıları hesapla
            var outputs = network.Forward(inputs);

            // Tüm harfler için çıkış değerlerini göster
            for (int i = 0; i < 5; i++)
            {
                outputLabels[i].Text = $"{GetLetterFromIndex(4 - i)} çıkışı = {outputs[i]:F3}";
            }
            
            // En yüksek çıkışa sahip harfi belirle ve göster
            int prediction = outputs.IndexOf(outputs.Max());
            MessageBox.Show($"Tahmin edilen harf: {GetLetterFromIndex(prediction)}");
        }

        /// <summary>
        /// Grid'i ve çıkış değerlerini temizler
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            string[] harfler = { "E", "D", "C", "B", "A" };
            
            // Grid'i temizle
            for (int i = 0; i < GRID_ROWS; i++)
            {
                for (int j = 0; j < GRID_COLS; j++)
                {
                    gridStates[i, j] = false;
                    gridButtons[i, j].BackColor = gridButtonDefault;
                }
            }
            
            // Çıkış değerlerini sıfırla
            for (int i = 0; i < 5; i++)
            {
                outputLabels[i].Text = $"{harfler[i]} çıkışı = 0.0";
            }
            
            // Hata etiketini sıfırla
            errorLabel.Text = "Hata oranı : 0.00";
        }

        /// <summary>
        /// Kullanıcının çizdiği grid'den sinir ağı için girdi vektörü oluşturur
        /// </summary>
        /// <returns>Grid durumlarını içeren girdi listesi</returns>
        private List<double> GetCurrentGridInput()
        {
            var input = new List<double>();
            
            // Grid durumlarını bir liste olarak oluştur (1: aktif, 0: pasif)
            for (int i = 0; i < GRID_ROWS; i++)
            {
                for (int j = 0; j < GRID_COLS; j++)
                {
                    input.Add(gridStates[i, j] ? 1.0 : 0.0);
                }
            }
            return input;
        }

        /// <summary>
        /// İndeksten harf değerini elde eder (0=A, 1=B, ...)
        /// </summary>
        /// <param name="index">Harf indeksi</param>
        /// <returns>Harf stringi</returns>
        private string GetLetterFromIndex(int index)
        {
            return ((char)('A' + index)).ToString();
        }

        /// <summary>
        /// Referans harf değiştiğinde çağrılır
        /// </summary>
        private void ComboReferenceLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen harfin indeksini al ve referans grid'i güncelle
            int letterIndex = comboReferenceLetter.SelectedIndex;
            UpdateReferenceGrid(letterIndex);
        }

        /// <summary>
        /// Referans grid'i seçilen harfe göre günceller
        /// </summary>
        /// <param name="letterIndex">Gösterilecek harfin indeksi</param>
        private void UpdateReferenceGrid(int letterIndex)
        {
            if (letterIndex < 0 || letterIndex >= 5)
                return;

            // TrainingData'dan seçilen harfin matrisini al ve referans grid'e yansıt
            for (int i = 0; i < GRID_ROWS; i++)
            {
                for (int j = 0; j < GRID_COLS; j++)
                {
                    referenceGridButtons[i, j].BackColor = 
                        TrainingData.TrainingInputs[letterIndex, i, j] == 1 ? 
                        gridButtonActive : gridButtonDefault;
                }
            }
        }

        /// <summary>
        /// Yuvarlak köşeli butonlar için gerekli native metod
        /// </summary>
        internal static class NativeMethods
        {
            [DllImport("gdi32.dll", SetLastError = true)]
            public static extern IntPtr CreateRoundRectRgn(
                int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        }
    }
}
