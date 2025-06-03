using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bulanik_mantik_odev
{
    public partial class Form1 : Form
    {
        private BasitBulanikCikarim bulaniksistem;
        private bool updatingControls = false;

        public Form1()
        {
            InitializeComponent();
            bulaniksistem = new BasitBulanikCikarim();

            // TrackBar ve NumericUpDown eşleştirmeleri
            trackHassaslik.ValueChanged += (s, e) => 
            {
                if (!updatingControls)
                {
                    updatingControls = true;
                    numHassaslik.Value = trackHassaslik.Value / 10.0m;
                    updatingControls = false;
                }
            };
            numHassaslik.ValueChanged += (s, e) => 
            {
                if (!updatingControls)
                {
                    updatingControls = true;
                    trackHassaslik.Value = (int)(numHassaslik.Value * 10);
                    updatingControls = false;
                }
            };

            trackKirlilik.ValueChanged += (s, e) => 
            {
                if (!updatingControls)
                {
                    updatingControls = true;
                    numKirlilik.Value = trackKirlilik.Value / 10.0m;
                    updatingControls = false;
                }
            };
            numKirlilik.ValueChanged += (s, e) => 
            {
                if (!updatingControls)
                {
                    updatingControls = true;
                    trackKirlilik.Value = (int)(numKirlilik.Value * 10);
                    updatingControls = false;
                }
            };

            trackMiktar.ValueChanged += (s, e) => 
            {
                if (!updatingControls)
                {
                    updatingControls = true;
                    numMiktar.Value = trackMiktar.Value / 10.0m;
                    updatingControls = false;
                }
            };
            numMiktar.ValueChanged += (s, e) => 
            {
                if (!updatingControls)
                {
                    updatingControls = true;
                    trackMiktar.Value = (int)(numMiktar.Value * 10);
                    updatingControls = false;
                }
            };

            // DataGridView sütun ayarları
            dgvKurallar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvKurallar.Columns[0].HeaderText = "Kural";
            dgvKurallar.Columns[0].Width = 400;
            dgvKurallar.Columns[1].HeaderText = "Tetiklenme Derecesi";
            dgvKurallar.Columns[1].Width = 150;
            dgvKurallar.ReadOnly = true;
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                // Giriş değerlerini oku
                double hassaslik = (double)numHassaslik.Value;
                double kirlilik = (double)numKirlilik.Value;
                double miktar = (double)numMiktar.Value;

                // Girişleri dictionary olarak hazırla
                var girisler = new Dictionary<string, double>
                {
                    { "Hassaslik", hassaslik },
                    { "Kirlilik", kirlilik },
                    { "Miktar", miktar }
                };

                // Çıkış değerlerini hesapla
                double donusHizi = bulaniksistem.Hesapla(girisler, BulanikSistemOrnekDegiskenler.DonusHizi);
                double sure = bulaniksistem.Hesapla(girisler, BulanikSistemOrnekDegiskenler.Sure);
                double deterjan = bulaniksistem.Hesapla(girisler, BulanikSistemOrnekDegiskenler.Deterjan);

                // Sonuçları göster
                lblDonusHizi.Text = $"{donusHizi:F2} rpm";
                lblSure.Text = $"{sure:F2} dk";
                lblDeterjan.Text = $"{deterjan:F2} ml";

                // Tetiklenen kuralları göster
                dgvKurallar.Rows.Clear();
                var girisBulanikDegerleri = new Dictionary<string, Dictionary<string, double>>
                {
                    { "Hassaslik", BulanikSistemOrnekDegiskenler.Hassaslik.Bulaniklastir(hassaslik) },
                    { "Kirlilik", BulanikSistemOrnekDegiskenler.Kirlilik.Bulaniklastir(kirlilik) },
                    { "Miktar", BulanikSistemOrnekDegiskenler.Miktar.Bulaniklastir(miktar) }
                };

                foreach (var kural in bulaniksistem.Kurallar)
                {
                    double tetik = kural.TetiklenmeDegeri(girisBulanikDegerleri);
                    if (tetik > 0)
                    {
                        string kuralMetni = "Eğer ";
                        for (int i = 0; i < kural.Girisler.Count; i++)
                        {
                            var g = kural.Girisler[i];
                            kuralMetni += $"{g.Degisken.Isim} {g.UyelikIsmi}";
                            if (i < kural.Girisler.Count - 1) kuralMetni += " ve ";
                        }
                        kuralMetni += $" ise {kural.Cikis.degisken.Isim} {kural.Cikis.uyelikIsmi}";
                        dgvKurallar.Rows.Add(kuralMetni, $"{tetik:F2}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hesaplama sırasında bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
