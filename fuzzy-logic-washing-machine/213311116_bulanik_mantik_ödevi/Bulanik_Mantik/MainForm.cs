using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace BulanikCamasirMakinesi
{
    public partial class MainForm : Form
    {
        private WashingMachineFuzzySystem fuzzySystem;
        private Dictionary<string, double> results;
        private Dictionary<string, double> centroidResults;
        private Dictionary<FuzzyRule, double> activatedRules;
        private Dictionary<string, Dictionary<string, double>> outputActivationLevels;

        public MainForm()
        {
            InitializeComponent();
            fuzzySystem = new WashingMachineFuzzySystem();
            ConfigureTrackBars();
            SetInitialValues();
            txtHassaslik.TextChanged += InputText_TextChanged;
            txtMiktar.TextChanged += InputText_TextChanged;
            txtKirlilik.TextChanged += InputText_TextChanged;
        }

        // Trackbar kontrollerini yapılandırır
        private void ConfigureTrackBars()
        {
            trkHassaslik.Minimum = 0;
            trkHassaslik.Maximum = 100;
            trkHassaslik.TickFrequency = 5;
            trkHassaslik.ValueChanged += Trackbar_ValueChanged;

            trkMiktar.Minimum = 0;
            trkMiktar.Maximum = 100;
            trkMiktar.TickFrequency = 5;
            trkMiktar.ValueChanged += Trackbar_ValueChanged;

            trkKirlilik.Minimum = 0;
            trkKirlilik.Maximum = 100;
            trkKirlilik.TickFrequency = 5;
            trkKirlilik.ValueChanged += Trackbar_ValueChanged;
        }

        // Başlangıç değerlerini ayarlar
        private void SetInitialValues()
        {
            trkHassaslik.Value = 50;
            trkMiktar.Value = 30;
            trkKirlilik.Value = 50;
            UpdateTextBoxesFromTrackbars();
        }

        // Metin kutuları değiştiğinde trackbarları günceller
        private void InputText_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            if (double.TryParse(textBox.Text, out double value))
            {
                if (value < 0) value = 0;
                if (value > 10) value = 10;

                int trackbarValue = (int)(value * 10);

                if (textBox == txtHassaslik)
                    trkHassaslik.Value = trackbarValue;
                else if (textBox == txtMiktar)
                    trkMiktar.Value = trackbarValue;
                else if (textBox == txtKirlilik)
                    trkKirlilik.Value = trackbarValue;
            }
        }

        // Trackbarlar değiştiğinde metin kutularını ve diğer görüntüleri günceller
        private void Trackbar_ValueChanged(object sender, EventArgs e)
        {
            UpdateTextBoxesFromTrackbars();
            CalculateOutputs();
            UpdateResultLabels();
            RenderGraphs();
            UpdateActivatedRulesList();
        }

        // Trackbar değerlerinden metin kutularını günceller
        private void UpdateTextBoxesFromTrackbars()
        {
            txtHassaslik.Text = (trkHassaslik.Value / 10.0).ToString("0.0");
            txtMiktar.Text = (trkMiktar.Value / 10.0).ToString("0.0");
            txtKirlilik.Text = (trkKirlilik.Value / 10.0).ToString("0.0");
        }

        // Hesaplama butonuna basıldığında tüm hesaplamaları yapar
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            CalculateOutputs();
            UpdateResultLabels();
            RenderGraphs();
            UpdateActivatedRulesList();
        }

        // Bulanık mantık sisteminden çıkışları hesaplar
        private void CalculateOutputs()
        {
            double hassaslik = Convert.ToDouble(txtHassaslik.Text);
            double miktar = Convert.ToDouble(txtMiktar.Text);
            double kirlilik = Convert.ToDouble(txtKirlilik.Text);

            // Ağırlıklı ortalama sonuçları
            results = fuzzySystem.CalculateOutputs(hassaslik, miktar, kirlilik);
            
            // Centroid sonuçları
            centroidResults = fuzzySystem.CalculateOutputsCentroid(hassaslik, miktar, kirlilik);
            
            // Aktif kurallar
            activatedRules = fuzzySystem.GetActivatedRules(hassaslik, miktar, kirlilik);
            
            // Çıkış aktivasyonları
            outputActivationLevels = fuzzySystem.GetOutputActivationLevels(hassaslik, miktar, kirlilik);
        }

        // Sonuç etiketlerini günceller
        private void UpdateResultLabels()
        {
            if (results != null)
            {
                // Ağırlıklı ortalama sonuçları
                lblDonusHizi.Text = results["Dönüş Hızı"].ToString("0.00");
                lblSure.Text = results["Süre"].ToString("0.00");
                lblDeterjan.Text = results["Deterjan Miktarı"].ToString("0.00");

                // Centroid sonuçları
                lblCentroidDonusHizi.Text = centroidResults["Dönüş Hızı"].ToString("0.00");
                lblCentroidSure.Text = centroidResults["Süre"].ToString("0.00");
                lblCentroidDeterjan.Text = centroidResults["Deterjan Miktarı"].ToString("0.00");
            }
        }

        // Aktif kurallar listesini günceller
        private void UpdateActivatedRulesList()
        {
            lstActiveRules.Items.Clear();
            
            if (activatedRules != null && activatedRules.Count > 0)
            {
                foreach (var rule in activatedRules.OrderBy(r => r.Key.RuleNumber))
                {
                    lstActiveRules.Items.Add($"Kural {rule.Key.RuleNumber}: {rule.Value:0.00}");
                }
            }
        }

        // Tüm grafikleri yeniden çizer
        private void RenderGraphs()
        {
            // Grafik panellerini yeniden çiz
            pnlHassaslik.Invalidate();
            pnlMiktar.Invalidate();
            pnlKirlilik.Invalidate();
            pnlDonusHizi.Invalidate();
            pnlSure.Invalidate();
            pnlDeterjan.Invalidate();
        }

        // Giriş değişkenleri grafiklerini çiz
        private void pnlHassaslik_Paint(object sender, PaintEventArgs e)
        {
            if (fuzzySystem != null)
            {
                double hassaslik = Convert.ToDouble(txtHassaslik.Text);
                DrawVariablePanel(e.Graphics, fuzzySystem.Hassaslik, pnlHassaslik.ClientRectangle, hassaslik);
            }
        }

        private void pnlMiktar_Paint(object sender, PaintEventArgs e)
        {
            if (fuzzySystem != null)
            {
                double miktar = Convert.ToDouble(txtMiktar.Text);
                DrawVariablePanel(e.Graphics, fuzzySystem.Miktar, pnlMiktar.ClientRectangle, miktar);
            }
        }

        private void pnlKirlilik_Paint(object sender, PaintEventArgs e)
        {
            if (fuzzySystem != null)
            {
                double kirlilik = Convert.ToDouble(txtKirlilik.Text);
                DrawVariablePanel(e.Graphics, fuzzySystem.Kirlilik, pnlKirlilik.ClientRectangle, kirlilik);
            }
        }

        // Çıkış değişkenleri grafiklerini çiz
        private void pnlDonusHizi_Paint(object sender, PaintEventArgs e)
        {
            if (fuzzySystem != null && outputActivationLevels != null)
            {
                DrawOutputPanel(e.Graphics, fuzzySystem.DonusHizi, pnlDonusHizi.ClientRectangle, 
                    outputActivationLevels["Dönüş Hızı"], results["Dönüş Hızı"]);
            }
        }

        private void pnlSure_Paint(object sender, PaintEventArgs e)
        {
            if (fuzzySystem != null && outputActivationLevels != null)
            {
                DrawOutputPanel(e.Graphics, fuzzySystem.Sure, pnlSure.ClientRectangle, 
                    outputActivationLevels["Süre"], results["Süre"]);
            }
        }

        private void pnlDeterjan_Paint(object sender, PaintEventArgs e)
        {
            if (fuzzySystem != null && outputActivationLevels != null)
            {
                DrawOutputPanel(e.Graphics, fuzzySystem.DeterjanMiktari, pnlDeterjan.ClientRectangle, 
                    outputActivationLevels["Deterjan Miktarı"], results["Deterjan Miktarı"]);
            }
        }

        // Değişken panelini çizer
        private void DrawVariablePanel(Graphics g, FuzzyVariable variable, Rectangle bounds, double currentValue)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            // Panel başlığını çiz
            using (Font titleFont = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            {
                g.DrawString(variable.Name, titleFont, Brushes.DarkBlue, new PointF(5, 5));
            }

            RectangleF graphRect = new RectangleF(bounds.Left + 10, bounds.Top + 25, bounds.Width - 20, bounds.Height - 45);
            
            // Arka plan çizgileri çiz
            using (Pen gridPen = new Pen(Color.LightGray, 1))
            {
                gridPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                // Yatay çizgiler
                for (int i = 1; i < 4; i++)
                {
                    float y = graphRect.Top + (graphRect.Height * i / 4);
                    g.DrawLine(gridPen, graphRect.Left, y, graphRect.Right, y);
                }
                
                // Dikey çizgiler
                for (int i = 1; i < 5; i++)
                {
                    float x = graphRect.Left + (graphRect.Width * i / 5);
                    g.DrawLine(gridPen, x, graphRect.Top, x, graphRect.Bottom);
                }
            }
            
            // Değişken grafiğini çiz
            GraphManager.DrawFuzzyVariable(g, variable, graphRect);
            
            // Mevcut değeri göster
            float xPos = (float)((currentValue - variable.MinValue) / (variable.MaxValue - variable.MinValue) * graphRect.Width + graphRect.Left);
            using (Pen valuePen = new Pen(Color.Red, 2))
            {
                g.DrawLine(valuePen, xPos, graphRect.Top, xPos, graphRect.Bottom);
                
                // Ok başı
                const float arrowSize = 5;
                PointF[] arrowHead = new PointF[]
                {
                    new PointF(xPos, graphRect.Top),
                    new PointF(xPos - arrowSize, graphRect.Top + arrowSize * 2),
                    new PointF(xPos + arrowSize, graphRect.Top + arrowSize * 2)
                };
                g.FillPolygon(Brushes.Red, arrowHead);
            }
            
            // Değer etiketini çiz
            using (Font valueFont = new Font("Segoe UI", 8.5f))
            {
                string valueText = currentValue.ToString("0.0");
                SizeF textSize = g.MeasureString(valueText, valueFont);
                PointF textPos = new PointF(xPos - textSize.Width / 2, graphRect.Bottom + 3);
                
                // Metin sınırlardan çıkmasın
                if (textPos.X < graphRect.Left)
                    textPos.X = graphRect.Left;
                else if (textPos.X + textSize.Width > graphRect.Right)
                    textPos.X = graphRect.Right - textSize.Width;
                
                g.DrawString(valueText, valueFont, Brushes.Blue, textPos);
            }
            
            // Çerçeve çiz
            g.DrawRectangle(Pens.DarkGray, graphRect.X, graphRect.Y, graphRect.Width, graphRect.Height);
        }

        // Çıkış panelini çizer
        private void DrawOutputPanel(Graphics g, FuzzyVariable variable, Rectangle bounds, Dictionary<string, double> activationLevels, double crispOutput)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            // Panel başlığını çiz
            using (Font titleFont = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            {
                g.DrawString(variable.Name, titleFont, Brushes.DarkBlue, new PointF(5, 5));
            }

            RectangleF graphRect = new RectangleF(bounds.Left + 10, bounds.Top + 25, bounds.Width - 20, bounds.Height - 45);
            
            // Arka plan çizgileri çiz
            using (Pen gridPen = new Pen(Color.LightGray, 1))
            {
                gridPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                // Yatay çizgiler
                for (int i = 1; i < 4; i++)
                {
                    float y = graphRect.Top + (graphRect.Height * i / 4);
                    g.DrawLine(gridPen, graphRect.Left, y, graphRect.Right, y);
                }
                
                // Dikey çizgiler
                for (int i = 1; i < 5; i++)
                {
                    float x = graphRect.Left + (graphRect.Width * i / 5);
                    g.DrawLine(gridPen, x, graphRect.Top, x, graphRect.Bottom);
                }
            }
            
            // Çıkış değişkeni grafiğini çiz
            GraphManager.DrawFuzzyOutputVariable(g, variable, graphRect, activationLevels);
            
            // Duru çıkış değerini göster
            float xPos = (float)((crispOutput - variable.MinValue) / (variable.MaxValue - variable.MinValue) * graphRect.Width + graphRect.Left);
            using (Pen valuePen = new Pen(Color.Red, 2))
            {
                g.DrawLine(valuePen, xPos, graphRect.Top, xPos, graphRect.Bottom);
                
                // Ok başı
                const float arrowSize = 5;
                PointF[] arrowHead = new PointF[]
                {
                    new PointF(xPos, graphRect.Bottom),
                    new PointF(xPos - arrowSize, graphRect.Bottom - arrowSize * 2),
                    new PointF(xPos + arrowSize, graphRect.Bottom - arrowSize * 2)
                };
                g.FillPolygon(Brushes.Red, arrowHead);
            }
            
            // Değer etiketini çiz
            using (Font valueFont = new Font("Segoe UI", 8.5f))
            {
                string valueText = crispOutput.ToString("0.00");
                SizeF textSize = g.MeasureString(valueText, valueFont);
                PointF textPos = new PointF(xPos - textSize.Width / 2, graphRect.Bottom + 3);
                
                // Metin sınırlardan çıkmasın
                if (textPos.X < graphRect.Left)
                    textPos.X = graphRect.Left;
                else if (textPos.X + textSize.Width > graphRect.Right)
                    textPos.X = graphRect.Right - textSize.Width;
                
                g.DrawString(valueText, valueFont, Brushes.Blue, textPos);
            }
            
            // Çerçeve çiz
            g.DrawRectangle(Pens.DarkGray, graphRect.X, graphRect.Y, graphRect.Width, graphRect.Height);
        }
    }
} 