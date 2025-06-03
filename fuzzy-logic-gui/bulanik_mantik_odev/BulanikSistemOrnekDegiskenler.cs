using System.Collections.Generic;

namespace bulanik_mantik_odev
{
    public static class BulanikSistemOrnekDegiskenler
    {
        public static BulanikDegisken Hassaslik => new BulanikDegisken("Hassaslık", 0, 10)
        {
            UyelikFonksiyonlari = new List<IUyelikFonksiyonu>
            {
                new UcgenUyelikFonksiyonu("hassas", 0, 0, 3),
                new UcgenUyelikFonksiyonu("orta", 2, 5, 8),
                new UcgenUyelikFonksiyonu("sağlam", 7, 10, 10)
            }
        };

        public static BulanikDegisken Kirlilik => new BulanikDegisken("Kirlilik", 0, 10)
        {
            UyelikFonksiyonlari = new List<IUyelikFonksiyonu>
            {
                new UcgenUyelikFonksiyonu("küçük", 0, 0, 3),
                new UcgenUyelikFonksiyonu("orta", 2, 5, 8),
                new UcgenUyelikFonksiyonu("büyük", 7, 10, 10)
            }
        };

        public static BulanikDegisken Miktar => new BulanikDegisken("Miktar", 0, 10)
        {
            UyelikFonksiyonlari = new List<IUyelikFonksiyonu>
            {
                new UcgenUyelikFonksiyonu("küçük", 0, 0, 3),
                new UcgenUyelikFonksiyonu("orta", 2, 5, 8),
                new UcgenUyelikFonksiyonu("büyük", 7, 10, 10)
            }
        };

        public static BulanikDegisken Deterjan => new BulanikDegisken("Deterjan", 0, 100)
        {
            UyelikFonksiyonlari = new List<IUyelikFonksiyonu>
            {
                new UcgenUyelikFonksiyonu("çok_az", 0, 0, 15),
                new UcgenUyelikFonksiyonu("az", 10, 25, 40),
                new UcgenUyelikFonksiyonu("orta", 35, 50, 65),
                new UcgenUyelikFonksiyonu("fazla", 60, 75, 90),
                new UcgenUyelikFonksiyonu("çok_fazla", 85, 100, 100)
            }
        };

        public static BulanikDegisken Sure => new BulanikDegisken("Süre", 0, 120)
        {
            UyelikFonksiyonlari = new List<IUyelikFonksiyonu>
            {
                new UcgenUyelikFonksiyonu("kısa", 0, 0, 30),
                new UcgenUyelikFonksiyonu("normal_kısa", 20, 40, 60),
                new UcgenUyelikFonksiyonu("orta", 50, 70, 90),
                new UcgenUyelikFonksiyonu("normal_uzun", 80, 90, 100),
                new UcgenUyelikFonksiyonu("uzun", 90, 120, 120)
            }
        };

        public static BulanikDegisken DonusHizi => new BulanikDegisken("Dönüş Hızı", 0, 1200)
        {
            UyelikFonksiyonlari = new List<IUyelikFonksiyonu>
            {
                new UcgenUyelikFonksiyonu("hassas", 0, 0, 300),
                new UcgenUyelikFonksiyonu("normal_hassas", 200, 400, 600),
                new UcgenUyelikFonksiyonu("orta", 500, 700, 900),
                new UcgenUyelikFonksiyonu("normal_güçlü", 800, 900, 1000),
                new UcgenUyelikFonksiyonu("güçlü", 900, 1200, 1200)
            }
        };
    }
} 