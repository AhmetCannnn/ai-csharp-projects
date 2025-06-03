using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_MainSubjects
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region YazdırmaKomutları
            //Console.Write("Merhaba Dünya");
            //Console.WriteLine("Merhaba Dünya");

            //Console.WriteLine("***** Yemeek Kategorileri *****");
            //Console.WriteLine();
            //Console.WriteLine("1-Çorbalar");
            //Console.WriteLine("2-Ana Yemekler");
            //Console.WriteLine("3-Soğuk Başlangıçlar");
            //Console.WriteLine("4-Salatalar");
            //Console.WriteLine("5-Tatlılar");
            //Console.WriteLine("6-İçecekler");
            //Console.WriteLine();
            //Console.WriteLine("***** Yemeek Kategorileri *****");
            #endregion

            #region String Değişkenler

            //string 
            //Değişken türü

            //string name;
            //name = "Ahmet Can";
            //Console.Write(name);

            //string customerName;
            //string customerSurname;
            //string customerPhone;
            //string custormerEmail, distrcit, city;

            //customerName = "Ali";
            //customerSurname = "Çınar";
            //customerPhone = "+90 500 400 30 20";
            //custormerEmail = "deneme@gmail.com";
            //distrcit = "Kadıköy";
            //city = "İstanbul";

            //Console.WriteLine("***** Rezervasyon Karı *****");
            //Console.WriteLine();
            //Console.WriteLine("--------------------------------------------------");
            //Console.WriteLine("Müşteri: " + customerName + " " + customerSurname);
            //Console.WriteLine("İletişim: " + customerPhone);
            //Console.WriteLine("Email Adresi: " + custormerEmail);
            //Console.WriteLine("Adres: " + distrcit + "/" + city);
            //Console.WriteLine("--------------------------------------------------");

            //Console.WriteLine();

            //customerName = "Aynur";
            //customerSurname = "Kaya";
            //customerPhone = "+90 500 400 80 70";
            //custormerEmail = "deneme1@gmail.com";
            //distrcit = "Sapanca";
            //city = "Sakarya";
            //Console.WriteLine("--------------------------------------------------");
            //Console.WriteLine("Müşteri: " + customerName + " " + customerSurname);
            //Console.WriteLine("İletişim: " + customerPhone);
            //Console.WriteLine("Email Adresi: " + custormerEmail);
            //Console.WriteLine("Adres: " + distrcit + "/" + city);
            //Console.WriteLine("--------------------------------------------------");

            #endregion

            #region Int Değişkenler

            //int
            //int number = 0;
            //Console.WriteLine(number);

            int hamburgerPrice = 300;
            int cokePrice = 35;
            int waterPrice = 10;
            int friesPrice = 50;
            int pizzaPrice = 250;
            int lemonadıPrice = 30;

            Console.WriteLine("***** Restoran Menü Fiıyatları *****");
            Console.WriteLine();
            Console.WriteLine("----Hamburger: " + hamburgerPrice + " TL");
            Console.WriteLine("----Pizza: " + pizzaPrice + " TL");
            Console.WriteLine("----Kola: " + cokePrice + " TL");
            Console.WriteLine("----Limonata: " + lemonadıPrice + " TL");
            Console.WriteLine("----Kızartma: " + friesPrice + " TL");
            Console.WriteLine("----Su: " + waterPrice + " TL");
            Console.WriteLine();
            Console.WriteLine("***** Restoran Menü Fiıyatları *****");

            Console.WriteLine();
            int totalHamburgerPrice;
            int totalPizzaPrice = 0;
            int totalCokePrice;
            int totalWaterPrice;
            int totalFriesPrice = 0;
            int totalLemonadePrice = 0;

            int hamburgerCount = 3;
            int cokeCount = 3;
            int waterCount = 3;
            int friesCount = 1;
            int pizzaCount = 0;
            int lemonadCount = 0;

            totalHamburgerPrice = hamburgerCount * hamburgerPrice;
            totalPizzaPrice = pizzaCount * pizzaPrice;
            totalCokePrice = cokeCount * cokePrice;
            totalWaterPrice = waterCount * waterPrice;
            totalFriesPrice = friesCount * friesPrice;
            totalLemonadePrice = lemonadCount * lemonadıPrice;

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Hamburger Tutarı: " + totalHamburgerPrice +" TL");
            Console.WriteLine("Pizza Tutarı: " + totalPizzaPrice +" TL");
            Console.WriteLine("Kola Tutarı: " + totalCokePrice +" TL");
            Console.WriteLine("KIzartma Tutarı: " + totalFriesPrice +" TL");
            Console.WriteLine("Limonata Tutarı: " + totalLemonadePrice +" TL");
            Console.WriteLine("Su Tutarı: " + totalWaterPrice +" TL");

            Console.WriteLine();

            int totalPrice = totalHamburgerPrice + totalPizzaPrice + totalCokePrice + totalFriesPrice + totalWaterPrice + totalLemonadePrice;
            Console.WriteLine("Toplam ödenecek tutar: " + totalPrice + " TL");

            #endregion

            Console.Read();
        }
    }
}
