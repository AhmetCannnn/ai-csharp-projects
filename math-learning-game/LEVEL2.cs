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
    public partial class LEVEL2 : Form
    {
        Dictionary<string, string> toplamaSorulari = new Dictionary<string, string>
    {
        { "12 + 23", "35" },
        { "34 + 45", "79" },
        { "67 + 22", "89" },
        { "54 + 17", "71" },
        { "99 + 1", "100" }
    };

        Dictionary<string, string> cikarmaSorulari = new Dictionary<string, string>
    {
        { "56 - 23", "33" },
        { "78 - 34", "44" },
        { "65 - 15", "50" },
        { "89 - 12", "77" },
        { "91 - 9", "82" }
    };

        Dictionary<string, string> carpmaSorulari = new Dictionary<string, string>
    {
        { "12 * 2", "24" },
        { "15 * 3", "45" },
        { "24 * 4", "96" },
        { "10 * 6", "60" },
        { "11 * 9", "99" }
    };

        Dictionary<string, string> bolmeSorulari = new Dictionary<string, string>
    {
        { "84 / 2", "42" },
        { "66 / 3", "22" },
        { "90 / 5", "18" },
        { "100 / 4", "25" },
        { "56 / 7", "8" }
    };

        public LEVEL2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> passedToplama = soruOlustur(toplamaSorulari, level2Puan);
            if (passedToplama.Count > 0)
            {
                soruOlustur(passedToplama, level2Puan);
            }

            Dictionary<string, string> passedCikarma = soruOlustur(cikarmaSorulari, level2Puan);
            if (passedCikarma.Count > 0)
            {
                soruOlustur(passedCikarma, level2Puan);
            }

            Dictionary<string, string> passedcarpma = soruOlustur(carpmaSorulari, level2Puan);
            if (passedcarpma.Count > 0)
            {
                soruOlustur(passedcarpma, level2Puan);
            }

            Dictionary<string, string> passedbolme = soruOlustur(bolmeSorulari, level2Puan);
            if (passedbolme.Count > 0)
            {
                soruOlustur(passedbolme, level2Puan);
            }

            string starIcon = "";


            if (level2Puan == 0)
            {

                starIcon = "";
            }
            else if (level2Puan >= 3 && level2Puan < 20)
            {
                starIcon = "*";
            }
            else if (level2Puan >= 20 && level2Puan < 40)
            {
                starIcon = "**";
            }
            else if (level2Puan >= 40 && level2Puan < 60)
            {
                starIcon = "***";
            }

            MessageBox.Show($"{starIcon}\n2.SEVİYE İÇİN PUANINIZ: {level2Puan}", "Puan Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (level2Puan >= 33)
            {
                LEVEL3 levelForm = new LEVEL3();
                this.Hide();
                levelForm.Show();
            }
            else
            {
                MessageBox.Show($"\"3.SEVİYEYE GEÇMEK İÇİN YETERLİ PUANA ULAŞAMADINIZ.TEKRAR DENEYİNİZ.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LEVEL2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
