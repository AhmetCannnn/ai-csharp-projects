using System;
using System.Collections.Generic;
using System.Linq;

namespace bulanik_mantik_odev
{
    public class BasitBulanikCikarim
    {
        public List<BulanikKural> Kurallar { get; private set; }

        public BasitBulanikCikarim()
        {
            Kurallar = new List<BulanikKural>();
            KurallariOlustur();
        }

        private void KurallariOlustur()
        {
            // Kural 1
            Kurallar.Add(new BulanikKural(
                new List<BulanikGiris> {
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Hassaslik, "hassas"),
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Miktar, "küçük"),
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Kirlilik, "küçük")
                },
                new BulanikCikis(BulanikSistemOrnekDegiskenler.DonusHizi, "hassas"),
                new BulanikCikis(BulanikSistemOrnekDegiskenler.Sure, "kısa"),
                new BulanikCikis(BulanikSistemOrnekDegiskenler.Deterjan, "çok_az")
            ));

            // Kural 2
            Kurallar.Add(new BulanikKural(
                new List<BulanikGiris> {
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Hassaslik, "hassas"),
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Miktar, "küçük"),
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Kirlilik, "orta")
                },
                new BulanikCikis(BulanikSistemOrnekDegiskenler.DonusHizi, "normal_hassas"),
                new BulanikCikis(BulanikSistemOrnekDegiskenler.Sure, "kısa"),
                new BulanikCikis(BulanikSistemOrnekDegiskenler.Deterjan, "az")
            ));

            // Kural 3-27 arası tüm kurallar benzer şekilde eklenir
            // Örnek olarak son kural:
            Kurallar.Add(new BulanikKural(
                new List<BulanikGiris> {
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Hassaslik, "sağlam"),
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Miktar, "büyük"),
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Kirlilik, "büyük")
                },
                new BulanikCikis(BulanikSistemOrnekDegiskenler.DonusHizi, "güçlü"),
                new BulanikCikis(BulanikSistemOrnekDegiskenler.Sure, "uzun"),
                new BulanikCikis(BulanikSistemOrnekDegiskenler.Deterjan, "çok_fazla")
            ));

            // Diğer tüm kuralları da ekleyelim
            // Kural 3
            Kurallar.Add(new BulanikKural(
                new List<BulanikGiris> {
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Hassaslik, "hassas"),
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Miktar, "küçük"),
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Kirlilik, "büyük")
                },
                new BulanikCikis(BulanikSistemOrnekDegiskenler.DonusHizi, "orta"),
                new BulanikCikis(BulanikSistemOrnekDegiskenler.Sure, "normal_kısa"),
                new BulanikCikis(BulanikSistemOrnekDegiskenler.Deterjan, "orta")
            ));

            // Kural 4
            Kurallar.Add(new BulanikKural(
                new List<BulanikGiris> {
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Hassaslik, "hassas"),
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Miktar, "orta"),
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Kirlilik, "küçük")
                },
                new BulanikCikis(BulanikSistemOrnekDegiskenler.DonusHizi, "hassas"),
                new BulanikCikis(BulanikSistemOrnekDegiskenler.Sure, "kısa"),
                new BulanikCikis(BulanikSistemOrnekDegiskenler.Deterjan, "orta")
            ));

            // Kural 5
            Kurallar.Add(new BulanikKural(
                new List<BulanikGiris> {
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Hassaslik, "hassas"),
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Miktar, "orta"),
                    new BulanikGiris(BulanikSistemOrnekDegiskenler.Kirlilik, "orta")
                },
                new BulanikCikis(BulanikSistemOrnekDegiskenler.DonusHizi, "normal_hassas"),
                new BulanikCikis(BulanikSistemOrnekDegiskenler.Sure, "normal_kısa"),
                new BulanikCikis(BulanikSistemOrnekDegiskenler.Deterjan, "orta")
            ));

            // Kural 6-27 arası
            // ... Tüm kurallar benzer şekilde eklenir
        }

        public double Hesapla(Dictionary<string, double> girisler, BulanikDegisken cikisDegiskeni)
        {
            double payToplam = 0;
            double paydaToplam = 0;

            foreach (var kural in Kurallar)
            {
                double tetikleme = kural.TetiklenmeDegeri(girisler);
                if (tetikleme > 0)
                {
                    var cikis = kural.Cikislar.Find(c => c.degisken == cikisDegiskeni);
                    if (cikis != null)
                    {
                        var uyelikFonk = cikisDegiskeni.UyelikFonksiyonlari.Find(u => u.Isim == cikis.uyelikIsmi);
                        if (uyelikFonk != null)
                        {
                            double merkez = uyelikFonk.Merkez;
                            payToplam += tetikleme * merkez;
                            paydaToplam += tetikleme;
                        }
                    }
                }
            }

            return paydaToplam > 0 ? payToplam / paydaToplam : 0;
        }
    }

    public class BulanikKural
    {
        public List<BulanikGiris> Girisler { get; private set; }
        public List<BulanikCikis> Cikislar { get; private set; }

        public BulanikKural(List<BulanikGiris> girisler, params BulanikCikis[] cikislar)
        {
            Girisler = girisler;
            Cikislar = new List<BulanikCikis>(cikislar);
        }

        public double TetiklenmeDegeri(Dictionary<string, double> girisler)
        {
            var bulanikDegerler = new Dictionary<string, Dictionary<string, double>>();
            foreach (var giris in girisler)
            {
                var degisken = BulanikSistemOrnekDegiskenler.GetType().GetProperty(giris.Key)?.GetValue(null) as BulanikDegisken;
                if (degisken != null)
                {
                    bulanikDegerler[giris.Key] = degisken.Bulaniklastir(giris.Value);
                }
            }
            return TetiklenmeDegeri(bulanikDegerler);
        }

        public double TetiklenmeDegeri(Dictionary<string, Dictionary<string, double>> bulanikDegerler)
        {
            double minTetikleme = 1.0;
            foreach (var giris in Girisler)
            {
                if (bulanikDegerler.ContainsKey(giris.Degisken.Isim) &&
                    bulanikDegerler[giris.Degisken.Isim].ContainsKey(giris.UyelikIsmi))
                {
                    double uyelikDerecesi = bulanikDegerler[giris.Degisken.Isim][giris.UyelikIsmi];
                    minTetikleme = System.Math.Min(minTetikleme, uyelikDerecesi);
                }
                else
                {
                    return 0;
                }
            }
            return minTetikleme;
        }
    }

    public class BulanikGiris
    {
        public BulanikDegisken Degisken { get; private set; }
        public string UyelikIsmi { get; private set; }

        public BulanikGiris(BulanikDegisken degisken, string uyelikIsmi)
        {
            Degisken = degisken;
            UyelikIsmi = uyelikIsmi;
        }
    }

    public class BulanikCikis
    {
        public BulanikDegisken degisken { get; private set; }
        public string uyelikIsmi { get; private set; }

        public BulanikCikis(BulanikDegisken degisken, string uyelikIsmi)
        {
            this.degisken = degisken;
            this.uyelikIsmi = uyelikIsmi;
        }
    }
} 