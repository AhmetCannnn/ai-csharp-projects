using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace odev2_genetik_algoritma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // DataGridView'e kolonları ekleyelim
            dataGridView1.Columns.Add("X", "X");
            dataGridView1.Columns.Add("Y", "Y");
            dataGridView1.Columns.Add("Fitness", "Fitness");

            // İsteğe bağlı olarak, DataGridView'de satır eklemeden önce en iyi görünüm için bazı ayarlar
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  // Sütunları doldurur
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;     // Satır seçimi yapabilmesi için
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double crossoverRate = trackCaprazlama.Value / 10.0; // 1 ile 10 arasında -> 0.1 ile 1.0 arasında
            lbl_trcbar_caprazlama.Text = crossoverRate.ToString("0.0"); // Virgülden sonra 1 basamak göster
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            double crossoverRate = trackMutasyon.Value / 10.0; // 1 ile 10 arasında -> 0.1 ile 1.0 arasında
            lbl_trcbar_mutasyon.Text = crossoverRate.ToString("0.0"); // Virgülden sonra 1 basamak göster
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void trackSeckinlik_Scroll(object sender, EventArgs e)
        {
            // TrackBar'dan alınan değeri yüzdeye dönüştür.
            double elitismRate = trackSeckinlik.Value / 100.0;

            // Label'ı güncelle.
            lbl_trcbar_seckinlik.Text =  elitismRate.ToString("0.00");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Test için Birey nesnesi oluştur
            Birey birey = new Birey(3, 2);  // X=3, Y=2

            // Fitness hesapla
            birey.FitnessHesapla();

            // Sonucu ekrana yazdır
            MessageBox.Show($"X: {birey.X}, Y: {birey.Y}, Fitness: {birey.Fitness}");
        }

        

        

        // Popülasyon objesini form seviyesinde tanımlıyoruz
        private Populasyon sonPopulasyon;  // Son popülasyon bilgisini tutan değişken
        public void baslangıc_populasyonu_Click(object sender, EventArgs e)
        {
            int populasyonBoyutu = 0;

            // Boyutun geçerli olup olmadığını kontrol et
            if (int.TryParse(numericUpDown1.Text, out populasyonBoyutu))
            {
                // Popülasyonu oluşturuyoruz
                sonPopulasyon = new Populasyon(populasyonBoyutu);

                // DataGridView'i sıfırlıyoruz
                dataGridView1.Rows.Clear();

                // Popülasyondaki her bireyi DataGridView'e ekliyoruz
                foreach (var birey in sonPopulasyon.Bireyler)
                {
                    dataGridView1.Rows.Add(birey.X, birey.Y, birey.Fitness);
                }
            }
            else
            {
                MessageBox.Show("Geçerli bir boyut girin.");
            }

        }

        private void dogal_secilim_Click(object sender, EventArgs e)
        {

            // Yeni popülasyon listesi oluşturuluyor
            List<Birey> yeniPopulasyon = new List<Birey>();

            // Popülasyondaki her bireyi turnuva seçimi ile seçiyoruz
            for (int i = 0; i < sonPopulasyon.Boyut; i++)
            {
                // Turnuva ile seçilen bireyi al
                Birey secilenBirey = sonPopulasyon.TurnuvaSec(sonPopulasyon.Bireyler);
                yeniPopulasyon.Add(secilenBirey);
            }

            // Yeni popülasyonu mevcut populasyonla güncelle
            sonPopulasyon.Bireyler = yeniPopulasyon;

            // DataGridView'i sıfırlıyoruz
            dataGridView1.Rows.Clear();

            // Popülasyondaki her birey için verileri ekleyelim
            foreach (var birey in sonPopulasyon.Bireyler)
            {
                // Penaltıyı hesapla (penaltı fonksiyonu örnek)
                double penalty = sonPopulasyon.HesaplaPenalty(birey);

                // Fitness + Penaltıyı hesapla
                double fitnessWithPenalty = birey.Fitness + penalty;

                // Yeni veriyi DataGridView'e ekle
                dataGridView1.Rows.Add(birey.X, birey.Y, birey.Fitness, fitnessWithPenalty);
            }



        }

        private void caprazla_Click(object sender, EventArgs e)
        {
            if (sonPopulasyon != null)
            {
                // Çaprazlama oranını al
                double caprazlamaOrani = Convert.ToDouble(lbl_trcbar_caprazlama.Text) / 100.0; // Yüzdelik değeri 0-1 aralığına çeviriyoruz

                // Çaprazlama uygula ve yeni popülasyonu al
                sonPopulasyon = sonPopulasyon.CaprazlamaUygula(sonPopulasyon.Bireyler, caprazlamaOrani);

                // DataGridView'i sıfırlıyoruz
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("X", "X");
                dataGridView1.Columns.Add("Y", "Y");
                dataGridView1.Columns.Add("Fitness", "Fitness");

                // Popülasyondaki her birey için verileri ekleyelim
                foreach (var birey in sonPopulasyon.Bireyler)
                {
                    // Yeni veriyi DataGridView'e ekle
                    dataGridView1.Rows.Add(birey.X.ToString(), birey.Y.ToString(), birey.Fitness.ToString());
                }
            }
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void mutasyonla_Click(object sender, EventArgs e)
        {
            if (sonPopulasyon != null)
            {
                // Mutasyon oranını al
                double mutasyonOrani = Convert.ToDouble(lbl_trcbar_mutasyon.Text) / 100.0; // Yüzdelik değeri 0-1 aralığına çeviriyoruz

                // Mutasyon uygula ve yeni popülasyonu al
                sonPopulasyon = sonPopulasyon.MutasyonUygula(sonPopulasyon.Bireyler, mutasyonOrani);

                // DataGridView'i sıfırlıyoruz
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("X", "X");
                dataGridView1.Columns.Add("Y", "Y");
                dataGridView1.Columns.Add("Fitness", "Fitness");

                // Popülasyondaki her birey için verileri ekleyelim
                foreach (var birey in sonPopulasyon.Bireyler)
                {
                    // Yeni veriyi DataGridView'e ekle
                    dataGridView1.Rows.Add(birey.X.ToString(), birey.Y.ToString(), birey.Fitness.ToString());
                }
            }
        }

        private void genetik_algoritma_Click(object sender, EventArgs e)
        {
            if (sonPopulasyon != null && sonPopulasyon.Bireyler.Count > 0)
            {
                // En iyi bireyi seç
                Birey enIyiBirey = sonPopulasyon.EnIyiBireyiSec();

                // Sonucu MessageBox ile göster
                MessageBox.Show($"En iyi birey:\nX: {enIyiBirey.X}\nY: {enIyiBirey.Y}\nFitness: {enIyiBirey.Fitness}",
                                "En İyi Birey", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Popülasyon mevcut değil veya boş!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
