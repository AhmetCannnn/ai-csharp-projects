using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev2_genetik_algoritma
{
    public class Birey
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Fitness { get; set; }

        // Parametresiz yapıcı
        public Birey()
        {
            // Varsayılan değerler atanabilir
            X = 0.0;
            Y = 0.0;
            Fitness = 0.0;
        }

        // Parametreli yapıcı (mevcut olan)
        public Birey(double x, double y)
        {
            X = x;
            Y = y;
            Fitness = 0.0; // Başlangıçta fitness hesaplanabilir
        }

        // Fitness hesaplamak için fonksiyon ekleyebiliriz (isteğe bağlı)
        public void FitnessHesapla()
        {
            // Burada hedef fonksiyon: f(x, y) = (x + 2y - 7)^2 + (2x + y - 5)^2
            Fitness = Math.Pow(X + 2 * Y - 7, 2) + Math.Pow(2 * X + Y - 5, 2);
        }
    }
}
