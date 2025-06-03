using System;

namespace bulanik_mantik_odev
{
    // Temel üyelik fonksiyonu arayüzü
    public interface IUyelikFonksiyonu
    {
        double DegerHesapla(double x);
        string Isim { get; }
    }

    // Üçgensel üyelik fonksiyonu
    public class UcgenUyelikFonksiyonu : IUyelikFonksiyonu
    {
        public string Isim { get; }
        public double A { get; }
        public double B { get; }
        public double C { get; }

        public UcgenUyelikFonksiyonu(string isim, double a, double b, double c)
        {
            Isim = isim;
            A = a;
            B = b;
            C = c;
        }

        public double DegerHesapla(double x)
        {
            if (x <= A || x >= C) return 0;
            else if (x == B) return 1;
            else if (x > A && x < B) return (x - A) / (B - A);
            else return (C - x) / (C - B);
        }
    }

    // Yamuksal üyelik fonksiyonu
    public class YamukUyelikFonksiyonu : IUyelikFonksiyonu
    {
        public string Isim { get; }
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public double D { get; }

        public YamukUyelikFonksiyonu(string isim, double a, double b, double c, double d)
        {
            Isim = isim;
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public double DegerHesapla(double x)
        {
            if (x <= A || x >= D) return 0;
            else if (x >= B && x <= C) return 1;
            else if (x > A && x < B) return (x - A) / (B - A);
            else return (D - x) / (D - C);
        }
    }
} 