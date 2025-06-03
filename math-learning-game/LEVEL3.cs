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
    public partial class LEVEL3 : Form
    {
        Dictionary<string, string> toplamaSorulari = new Dictionary<string, string>
    {
        { "123 + 234", "357" },
        { "456 + 345", "801" },
        { "678 + 122", "800" },
        { "789 + 210", "999" },
        { "999 + 1", "1000" }
    };

        Dictionary<string, string> cikarmaSorulari = new Dictionary<string, string>
    {
        { "876 - 234", "642" },
        { "543 - 123", "420" },
        { "912 - 256", "656" },
        { "700 - 123", "577" },
        { "850 - 750", "100" }
    };

        Dictionary<string, string> carpmaSorulari = new Dictionary<string, string>
    {
        { "100 * 2", "200" },
        { "150 * 3", "450" },
        { "250 * 4", "1000" },
        { "300 * 5", "1500" },
        { "123 * 9", "1107" }
    };

        Dictionary<string, string> bolmeSorulari = new Dictionary<string, string>
    {
        { "864 / 2", "432" },
        { "900 / 3", "300" },
        { "750 / 5", "150" },
        { "999 / 9", "111" },
        { "840 / 7", "120" }
    };

        public LEVEL3()
        {
            InitializeComponent();
        }

        private void LEVEL3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> passedToplama = soruOlustur(toplamaSorulari, level3Puan);
            if (passedToplama.Count > 0)
            {
                soruOlustur(passedToplama, level3Puan);
            }

            Dictionary<string, string> passedCikarma = soruOlustur(cikarmaSorulari, level3Puan);
            if (passedCikarma.Count > 0)
            {
                soruOlustur(passedCikarma, level3Puan);
            }

            Dictionary<string, string> passedcarpma = soruOlustur(carpmaSorulari, level3Puan);
            if (passedcarpma.Count > 0)
            {
                soruOlustur(passedcarpma, level3Puan);
            }

            Dictionary<string, string> passedbolme = soruOlustur(bolmeSorulari, level3Puan);
            if (passedbolme.Count > 0)
            {
                soruOlustur(passedbolme, level3Puan);
            }

            string starIcon = "";


            if (level3Puan == 0)
            {

                starIcon = "";
            }
            else if (level3Puan >= 3 && level3Puan < 20)
            {
                starIcon = "*";
            }
            else if (level3Puan >= 20 && level3Puan < 40)
            {
                starIcon = "**";
            }
            else if (level3Puan >= 40 && level3Puan < 60)
            {
                starIcon = "***";
            }

            MessageBox.Show($"{starIcon}\n3.SEVİYE İÇİN PUANINIZ: {level3Puan}", "Puan Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (level3Puan >= 33)
            {
                LEVEL4 levelForm = new LEVEL4();
                this.Hide();
                levelForm.Show();
            }
            else
            {
                MessageBox.Show($"\"4.SEVİYEYE GEÇMEK İÇİN YETERLİ PUANA ULAŞAMADINIZTEKRAR DENEYİNİZ.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
