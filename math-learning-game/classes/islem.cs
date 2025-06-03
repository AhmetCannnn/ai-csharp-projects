using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static homework1.classes.puans;

namespace homework1.classes
{
    internal class islem
    {

        public static Dictionary<string, string> soruOlustur(Dictionary<string, string> sorularVeCevaplar, int kullaniciPuan)
        {

            // Yeni form oluşturuluyor
            Form newForm = new Form();
            newForm.Size = new Size(400, 400);

            // Her bir soru için bir label oluşturuyoruz
            int labelYuksekligi = 30; // İlk label için Y konumu
            Dictionary<string, string> gecilenSorular = new Dictionary<string, string>(); // Geçilen sorular için sözlük

            foreach (var soru in sorularVeCevaplar)
            {
                int n = 1;
                // Soru için yeni bir label oluşturuluyor
                Label label = new Label();
                label.Text = soru.Key; // Sözlükten anahtar (soru) alınıyor
                label.Location = new Point(50, labelYuksekligi);
                label.AutoSize = true;
                newForm.Controls.Add(label);

                // Cevap için yeni bir textbox oluşturuluyor
                TextBox textBox = new TextBox();
                textBox.Name = "txt_" + n; // TextBox'a benzersiz bir isim veriyoruz
                textBox.Location = new Point(120, labelYuksekligi); // Label'ın yanına yerleştiriliyor
                newForm.Controls.Add(textBox);

                // PASS butonu oluşturuluyor
                Button passButton = new Button();
                passButton.Text = "PASS"; // Butonun metni
                passButton.Location = new Point(270, labelYuksekligi); // TextBox'ın yanına yerleştiriliyor
                passButton.BackColor = Color.LightGray; // Başlangıç rengi

                passButton.Click += (sender, e) =>
                {
                    passButton.BackColor = Color.Green; // Tıklandığında butonun arka plan rengi değişiyor
                    passButton.ForeColor = Color.White; // Yazı rengi değişiyor
                    gecilenSorular[soru.Key] = soru.Value; // Geçilen soruyu ve cevabını sözlüğe ekle
                };

                newForm.Controls.Add(passButton); // Butonu forma ekle

                // Y konumunu güncelleyerek bir sonraki label ve textbox için yukarıda yer açıyoruz
                labelYuksekligi += 40; // Her label ve textbox arasında 40 piksel boşluk bırakılıyor

                n++;
            }

            // Tüm label, textbox ve pass butonları eklendikten sonra devam et butonunu ekle
            Button devamEtButton = new Button();
            devamEtButton.Text = "Devam Et"; // Butonun metni
            devamEtButton.Size = new Size(100, 30); // Butonun boyutunu ayarlıyoruz (Genişlik, Yükseklik)
            devamEtButton.Location = new Point(newForm.ClientSize.Width - 100, newForm.ClientSize.Height - 50); // Sağ alt köşe
            newForm.Controls.Add(devamEtButton); // Butonu forma ekle


            // Devam Et butonuna tıklama olayı ekleniyor
            devamEtButton.Click += (sender, e) =>
            {
                // Sözlükteki cevapları sıralı bir şekilde elde etmek için ToList() kullanıyoruz
                var cevaplarListesi = sorularVeCevaplar.Values.ToList();
                // TextBox isimleri txt_1, txt_2, ..., txt_5 olacak şekilde 5 adet TextBox üzerinden işlem yapıyoruz
                for (int i = 1; i <= 5; i++)
                {
                    // TextBox adını dinamik olarak oluşturuyoruz
                    string textBoxAdi = "txt_" + i;

                    // Formda bu isimle bir TextBox olup olmadığını buluyoruz
                    var textBox = newForm.Controls.Find(textBoxAdi, true).FirstOrDefault() as TextBox;

                    if (textBox != null)
                    {
                        // TextBox içindeki değeri alıyoruz
                        string kullaniciCevabi = textBox.Text.Trim();


                        // Sözlükten sıradaki doğru cevabı alıyoruz (i-1, index 0'dan başladığı için)
                        string dogruCevap = cevaplarListesi[i - 1];



                        // Kullanıcının cevabını doğru cevap ile karşılaştırıyoruz
                        if (kullaniciCevabi == dogruCevap)
                        {
                            kullaniciPuan += 3; // Doğru ise 3 puan artır
                        }
                    }
                }

                newForm.Close(); // Formu kapat
            };

            newForm.ShowDialog(); // Formu göster (modal olarak)

            

            // Geçilen sorular sözlüğünü döndür
            return gecilenSorular;
        }
        


    }
}
