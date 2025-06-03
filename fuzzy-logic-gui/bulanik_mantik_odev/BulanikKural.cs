using System;
using System.Collections.Generic;
using System.Linq;

namespace bulanik_mantik_odev
{
    // Bir kuralın bir giriş değişkeni için koşulu
    public class KuralGirisKosulu
    {
        public BulanikDegisken Degisken { get; set; }
        public string UyelikIsmi { get; set; }
        public KuralGirisKosulu(BulanikDegisken degisken, string uyelikIsmi)
        {
            Degisken = degisken;
            UyelikIsmi = uyelikIsmi;
        }
    }

    // Basit bir bulanık kural: Eğer ... ve ... ise ...
    public class BulanikKural
    {
        public List<KuralGirisKosulu> Girisler { get; set; } // IF kısmı
        public (BulanikDegisken degisken, string uyelikIsmi) Cikis { get; set; } // THEN kısmı

        public BulanikKural(List<KuralGirisKosulu> girisler, (BulanikDegisken, string) cikis)
        {
            Girisler = girisler;
            Cikis = cikis;
        }

        // Kuralın tetiklenme derecesini hesaplar (min-AND)
        public double TetiklenmeDegeri(Dictionary<string, Dictionary<string, double>> girisBulanikDegerleri)
        {
            // Her giriş için uygun üyelik derecesini bul
            var degerler = new List<double>();
            foreach (var kosul in Girisler)
            {
                var degiskenAdi = kosul.Degisken.Isim;
                var uyelikAdi = kosul.UyelikIsmi;
                if (girisBulanikDegerleri.ContainsKey(degiskenAdi) && girisBulanikDegerleri[degiskenAdi].ContainsKey(uyelikAdi))
                {
                    degerler.Add(girisBulanikDegerleri[degiskenAdi][uyelikAdi]);
                }
                else
                {
                    degerler.Add(0);
                }
            }
            // Mamdani için AND: minimum değer
            return degerler.Min();
        }
    }
} 