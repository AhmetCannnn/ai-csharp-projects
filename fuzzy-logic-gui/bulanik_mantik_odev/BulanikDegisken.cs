using System;
using System.Collections.Generic;

namespace bulanik_mantik_odev
{
    public class BulanikDegisken
    {
        public string Isim { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public List<IUyelikFonksiyonu> UyelikFonksiyonlari { get; set; }

        public BulanikDegisken(string isim, double min, double max)
        {
            Isim = isim;
            Min = min;
            Max = max;
            UyelikFonksiyonlari = new List<IUyelikFonksiyonu>();
        }

        // Bir değerin tüm üyelik fonksiyonlarındaki karşılıklarını döndürür
        public Dictionary<string, double> Bulaniklastir(double x)
        {
            var sonuc = new Dictionary<string, double>();
            foreach (var fonk in UyelikFonksiyonlari)
            {
                sonuc[fonk.Isim] = fonk.DegerHesapla(x);
            }
            return sonuc;
        }
    }
} 