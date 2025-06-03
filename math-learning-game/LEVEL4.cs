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
    public partial class LEVEL4 : Form
    {
        Dictionary<string, string> toplamaSorulari = new Dictionary<string, string>
    {
        { "1234 + 5678", "6912" },
        { "4321 + 8765", "13086" },
        { "6789 + 2345", "9134" },
        { "9876 + 5432", "15308" },
        { "1000 + 9000", "10000" }
    };

        Dictionary<string, string> cikarmaSorulari = new Dictionary<string, string>
    {
        { "8765 - 1234", "7531" },
        { "5432 - 4321", "1111" },
        { "9123 - 4567", "4556" },
        { "7000 - 1234", "5766" },
        { "8500 - 2500", "6000" }
    };

        Dictionary<string, string> carpmaSorulari = new Dictionary<string, string>
    {
        { "1000 * 2", "2000" },
        { "1500 * 4", "6000" },
        { "2500 * 3", "7500" },
        { "3000 * 5", "15000" },
        { "1234 * 9", "11106" }
    };

        Dictionary<string, string> bolmeSorulari = new Dictionary<string, string>
    {
        { "8640 / 2", "4320" },
        { "9000 / 3", "3000" },
        { "7500 / 5", "1500" },
        { "9996 / 9", "1111" },
        { "8400 / 7", "1200" }
    };

        public LEVEL4()
        {
            InitializeComponent();
        }

        private void LEVEL4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> passedToplama = soruOlustur(toplamaSorulari, level4Puan);
            if (passedToplama.Count > 0)
            {
                soruOlustur(passedToplama, level4Puan);
            }

            Dictionary<string, string> passedCikarma = soruOlustur(cikarmaSorulari, level4Puan);
            if (passedCikarma.Count > 0)
            {
                soruOlustur(passedCikarma, level4Puan);
            }

            Dictionary<string, string> passedcarpma = soruOlustur(carpmaSorulari, level4Puan);
            if (passedcarpma.Count > 0)
            {
                soruOlustur(passedcarpma, level4Puan);
            }

            Dictionary<string, string> passedbolme = soruOlustur(bolmeSorulari, level4Puan);
            if (passedbolme.Count > 0)
            {
                soruOlustur(passedbolme, level4Puan);
            }

            string starIcon = "";


            if (level4Puan == 0)
            {

                starIcon = "";
            }
            else if (level4Puan >= 3 && level4Puan < 20)
            {
                starIcon = "*";
            }
            else if (level4Puan >= 20 && level4Puan < 40)
            {
                starIcon = "**";
            }
            else if (level4Puan >= 40 && level4Puan < 60)
            {
                starIcon = "***";
            }

            MessageBox.Show($"{starIcon}\n4.SEVİYE İÇİN PUANINIZ: {level4Puan}", "Puan Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (level4Puan >= 33)
            {
                LEVEL5 levelForm = new LEVEL5();
                this.Hide();
                levelForm.Show();
            }
            else
            {
                MessageBox.Show($"\"5.SEVİYEYE GEÇMEK İÇİN YETERLİ PUANA ULAŞAMADINIZ.TEKRAR DENEYİNİZ.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
