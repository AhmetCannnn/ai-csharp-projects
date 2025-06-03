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
    public partial class LEVEL5 : Form
    {
        Dictionary<string, string> toplamaSorulari = new Dictionary<string, string>
    {
        { "12345 + 67890", "80235" },
        { "54321 + 98765", "153086" },
        { "67890 + 23456", "91346" },
        { "98765 + 43210", "141975" },
        { "10000 + 90000", "100000" }
    };

        Dictionary<string, string> cikarmaSorulari = new Dictionary<string, string>
    {
        { "87654 - 12345", "75309" },
        { "54321 - 43210", "11111" },
        { "91234 - 56789", "34445" },
        { "70000 - 12345", "57655" },
        { "85000 - 25000", "60000" }
    };

        Dictionary<string, string> carpmaSorulari = new Dictionary<string, string>
    {
        { "10000 * 2", "20000" },
        { "15000 * 4", "60000" },
        { "25000 * 3", "75000" },
        { "30000 * 5", "150000" },
        { "12345 * 9", "111105" }
    };

        Dictionary<string, string> bolmeSorulari = new Dictionary<string, string>
    {
        { "86400 / 2", "43200" },
        { "90000 / 3", "30000" },
        { "75000 / 5", "15000" },
        { "99999 / 9", "11111" },
        { "84000 / 7", "12000" }
    };

        public LEVEL5()
        {
            InitializeComponent();
        }

        private void LEVEL5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> passedToplama = soruOlustur(toplamaSorulari, level5Puan);
            if (passedToplama.Count > 0)
            {
                soruOlustur(passedToplama, level5Puan);
            }

            Dictionary<string, string> passedCikarma = soruOlustur(cikarmaSorulari, level5Puan);
            if (passedCikarma.Count > 0)
            {
                soruOlustur(passedCikarma, level5Puan);
            }

            Dictionary<string, string> passedcarpma = soruOlustur(carpmaSorulari, level5Puan);
            if (passedcarpma.Count > 0)
            {
                soruOlustur(passedcarpma, level5Puan);
            }

            Dictionary<string, string> passedbolme = soruOlustur(bolmeSorulari, level5Puan);
            if (passedbolme.Count > 0)
            {
                soruOlustur(passedbolme, level5Puan);
            }

            string starIcon = "";


            if (level5Puan == 0)
            {

                starIcon = "";
            }
            else if (level5Puan >= 3 && level5Puan < 20)
            {
                starIcon = "*";
            }
            else if (level5Puan >= 20 && level5Puan < 40)
            {
                starIcon = "**";
            }
            else if (level5Puan >= 40 && level5Puan < 60)
            {
                starIcon = "***";
            }

            MessageBox.Show($"{starIcon}\n5.SEVİYE İÇİN PUANINIZ: {level5Puan}", "Puan Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (level5Puan >= 33)
            {
                FINAL levelForm = new FINAL();
                levelForm.Show();
            }
            else
            {
                MessageBox.Show($"\"5.SEVİYEYİ TAMAMLAMAK İÇİN YETERLİ PUANA ULAŞAMADINIZ.TEKRAR DENEYİNİZ.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
