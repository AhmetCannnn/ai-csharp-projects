using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev2_genetik_algoritma
{
    public class GenetikAlgoritma
    {
        public List<Birey> populasyon;

        // Constructor: Popülasyonu alarak başlatıyoruz.
        public GenetikAlgoritma(List<Birey> populasyon)
        {
            this.populasyon = populasyon;
        }

        // En düşük fitness değerine sahip en iyi bireyi seçen fonksiyon
        public Birey EnIyiBireyiSec()
        {
            return populasyon.OrderBy(b => b.Fitness).First();
        }
    }

}
