using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using odev2_genetik_algoritma;


namespace odev2_genetik_algoritma
{
    public class Populasyon
    {
        public int Boyut { get; set; }
        public List<Birey> Bireyler { get; set; }

        // Parametreli yapıcı
        public Populasyon(int boyut)
        {
            Boyut = boyut;
            Bireyler = new List<Birey>();

            // Popülasyonu rastgele oluştur
            Random rastgele = new Random();
            for (int i = 0; i < Boyut; i++)
            {
                double x = rastgele.NextDouble() * 20 - 10; // -10 ile 10 arasında X
                double y = rastgele.NextDouble() * 20 - 10; // -10 ile 10 arasında Y
                Birey birey = new Birey(x, y);
                birey.FitnessHesapla();  // Fitness hesapla
                Bireyler.Add(birey);
            }
        }

        // g1(x, y) -> x değerinin alt ve üst sınırlarını kontrol eder
        public double g1(double x, double y)
        {
            if (x < -10) return Math.Abs(x + 10);  // x, -10'dan küçükse, ceza olarak |x + 10|
            if (x > 10) return x - 10;  // x, 10'dan büyükse, ceza olarak (x - 10)
            return 0;
        }

        // g2(x, y) -> y değerinin alt ve üst sınırlarını kontrol eder
        public double g2(double x, double y)
        {
            if (y < -10) return Math.Abs(y + 10);  // y, -10'dan küçükse, ceza olarak |y + 10|
            if (y > 10) return y - 10;  // y, 10'dan büyükse, ceza olarak (y - 10)
            return 0;
        }

        // Penalty fonksiyonu
        public double HesaplaPenalty(Birey birey)
        {
            double penalty = 0;

            // g1 ve g2 fonksiyonlarını çağırarak ceza hesapla
            penalty += Math.Pow(g1(birey.X, birey.Y), 2);  // x'in sınırına ceza
            penalty += Math.Pow(g2(birey.X, birey.Y), 2);  // y'nin sınırına ceza

            return penalty;
        }

        public Birey TurnuvaSec(List<Birey> bireyler)
        {
            Random rand = new Random();
            int turnuvaBoyutu = 10; // Daha büyük bir turnuva boyutu
            List<Birey> turnuvaBireyleri = new List<Birey>();

            // Rastgele turnuvaBireyleri seç
            for (int i = 0; i < turnuvaBoyutu; i++)
            {
                int secilenIndex = rand.Next(bireyler.Count);
                turnuvaBireyleri.Add(bireyler[secilenIndex]);
            }

            // En iyi bireyi seç
            Birey enIyiBirey = turnuvaBireyleri.OrderByDescending(b => b.Fitness).First();
            return enIyiBirey;
        }

        // Popülasyonun en iyi bireyini seçen metod
        public Birey EnIyiBireyiSec()
        {
            // Bireylerin fitness değerine göre en iyi bireyi seçiyoruz
            return Bireyler.OrderByDescending(b => b.Fitness).First();
        }
        public Populasyon CaprazlamaUygula(List<Birey> bireyler, double caprazlamaOrani)
        {
            Random rand = new Random();
            List<Birey> yeniBireyler = new List<Birey>();

            // Çiftler halinde işlem yapıyoruz
            for (int i = 0; i < bireyler.Count; i += 2)
            {
                if (i + 1 < bireyler.Count)
                {
                    // İki birey seçiyoruz
                    Birey birey1 = bireyler[i];
                    Birey birey2 = bireyler[i + 1];

                    // Çaprazlama oranına göre çaprazlama yapıyoruz
                    double rho = rand.NextDouble();  // [0,1] arasında rastgele bir değer
                    if (rho <= caprazlamaOrani)
                    {
                        // Aritmetik çaprazlama işlemi
                        double newX1 = rho * birey1.X + (1 - rho) * birey2.X;
                        double newX2 = rho * birey2.X + (1 - rho) * birey1.X;
                        double newY1 = rho * birey1.Y + (1 - rho) * birey2.Y;
                        double newY2 = rho * birey2.Y + (1 - rho) * birey1.Y;

                        // Yeni bireyleri oluştur
                        Birey yeniBirey1 = new Birey(newX1, newY1);
                        Birey yeniBirey2 = new Birey(newX2, newY2);

                        // Fitness hesapla
                        yeniBirey1.FitnessHesapla();
                        yeniBirey2.FitnessHesapla();

                        // Yeni bireyleri ekle
                        yeniBireyler.Add(yeniBirey1);
                        yeniBireyler.Add(yeniBirey2);
                    }
                    else
                    {
                        // Çaprazlama yapılmadıysa mevcut bireyleri olduğu gibi ekle
                        yeniBireyler.Add(birey1);
                        yeniBireyler.Add(birey2);
                    }
                }
            }

            // Yeni populasyonu oluştur
            Populasyon yeniPopulasyon = new Populasyon(yeniBireyler.Count);
            yeniPopulasyon.Bireyler = yeniBireyler;
            return yeniPopulasyon;
        }


        public Populasyon MutasyonUygula(List<Birey> bireyler, double mutasyonOrani)
        {
            Random rand = new Random();
            List<Birey> yeniBireyler = new List<Birey>();

            foreach (var birey in bireyler)
            {
                Birey yeniBirey = new Birey
                {
                    X = birey.X,  // Eski bireyden X değerini kopyala
                    Y = birey.Y,  // Eski bireyden Y değerini kopyala
                    Fitness = birey.Fitness  // Fitness değeri değişmeyecek
                };

                // X geninin mutasyona uğrayıp uğramadığını kontrol et
                if (rand.NextDouble() < mutasyonOrani)
                {
                    yeniBirey.X = rand.NextDouble();  // X genini rastgele değiştir
                }

                // Y geninin mutasyona uğrayıp uğramadığını kontrol et
                if (rand.NextDouble() < mutasyonOrani)
                {
                    yeniBirey.Y = rand.NextDouble();  // Y genini rastgele değiştir
                }

                // Yeni bireyi listeye ekle
                yeniBireyler.Add(yeniBirey);
            }

            // Yeni popülasyonu oluştur ve döndür
            return new Populasyon(yeniBireyler.Count) { Bireyler = yeniBireyler };

        }
    }
}
