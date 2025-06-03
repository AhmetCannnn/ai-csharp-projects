using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework1.classes;
using static homework1.classes.islem;
using static homework1.classes.puans;


namespace homework1
{
    public partial class LEVEL1 : Form
    {
        // Sorularý ve cevaplarý içeren bir sözlük oluþturuyoruz
        Dictionary<string, string> toplamaSorulari = new Dictionary<string, string>
    {
        { "1 + 2 ", "3" },
        { "3 + 5 ", "8" },
        { "6 + 3 ", "9" },
        { "4 + 1 ", "5" },
        { "9 + 1", "10" }
    };
        Dictionary<string, string> cikarmaSorulari = new Dictionary<string, string>
    {
        { "4 - 2", "2" },
        { "7 - 3", "4" },
        { "6 - 5", "1" },
        { "8 - 5", "3" },
        { "9 - 1", "8" }
    };

        Dictionary<string, string> carpmaSorulari = new Dictionary<string, string>
    {
        { "1 * 1", "1" },
        { "2 * 3", "6" },
        { "4 * 2", "8" },
        { "5 * 2", "10" },
        { "3 * 3", "9" }
    };

        Dictionary<string, string> bolmeSorulari = new Dictionary<string, string>
    {
        { "8 / 2", "4" },
        { "6 / 3", "2" },
        { "9 / 3", "3" },
        { "10 / 2", "5" },
        { "7 / 1", "7" }
    };

        public LEVEL1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            Dictionary<string, string> passedToplama = soruOlustur(toplamaSorulari, level1Puan);
            if (passedToplama.Count > 0)
            {
                soruOlustur(passedToplama, level1Puan);
            }

            Dictionary<string, string> passedCikarma = soruOlustur(cikarmaSorulari, level1Puan);
            if (passedCikarma.Count > 0)
            {
                soruOlustur(passedCikarma, level1Puan);
            }

            Dictionary<string, string> passedcarpma = soruOlustur(carpmaSorulari, level1Puan);
            if (passedcarpma.Count > 0)
            {
                soruOlustur(passedcarpma, level1Puan);
            }

            Dictionary<string, string> passedbolme = soruOlustur(bolmeSorulari, level1Puan);
            if (passedbolme.Count > 0)
            {
                soruOlustur(passedbolme, level1Puan);
            }

            string starIcon = "";

            // Puan kontrolü
            if (level1Puan == 0)
            {
                // Hiçbir þey döndürülmüyor
                starIcon = "";
            }
            else if (level1Puan >= 3 && level1Puan < 20)
            {
                starIcon = "*"; // 1 yýldýz
            }
            else if (level1Puan >= 20 && level1Puan < 40)
            {
                starIcon = "**"; // 2 yýldýz
            }
            else if (level1Puan >= 40 && level1Puan < 60)
            {
                starIcon = "***"; // 3 yýldýz
            }

            MessageBox.Show($"{starIcon}\n1.SEVÝYE ÝÇÝN PUANINIZ: {level1Puan}", "Puan Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (level1Puan >= 33)
            {    LEVEL2 levelForm = new LEVEL2();
                this.Hide();
                levelForm.Show();
            }
            else
            {
                MessageBox.Show($"2.SEVÝYEYE GEÇMEK ÝÇÝN YETERLÝ PUANA ULAÞAMADINIZ.TEKRAR DENEYÝNÝZ.", "Baþarýsýz", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void LEVEL1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
