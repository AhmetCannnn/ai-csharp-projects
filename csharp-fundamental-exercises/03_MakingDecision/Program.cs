using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_MakingDecision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region If Else

            //Console.Write("Lütfen Şifreyi Giriniz: ");
            //string password;
            //password = Console.ReadLine();
            //if (password == "abcd")
            //{
            //    Console.WriteLine("Şifre Doğru");
            //}
            //else
            //{
            //    Console.WriteLine("Şifre Yanlış");
            //}

            //string capital, country;
            //Console.Write("Başkenti Giriniz: ");
            //capital = Console.ReadLine();

            //Console.Write("Ülkeyi Giriniz: ");
            //country = Console.ReadLine();

            //if(capital=="ankara" & country == "türkiye")
            //{
            //    Console.Write("Veriler Doğrulandı");
            //}
            //else
            //{
            //    Console.Write("Hatalı bilgi");
            //}

            //int number;
            //Console.Write("Sayıyı giriniz");
            //number = int.Parse(Console.ReadLine());
            //if (number == 5) 
            //{
            //    Console.WriteLine("Sayı doğru.");
            //}
            //else
            //{
            //    Console.WriteLine("Sayı hatalı.");
            //}

            //int exam1, exam2, exam3, average;
            //string result= "Hata!";

            //Console.Write("Sınav1: ");
            //exam1 = int.Parse(Console.ReadLine());
            //Console.Write("Sınav2: ");
            //exam2 = int.Parse(Console.ReadLine());
            //Console.Write("Sınav3: ");
            //exam3 = int.Parse(Console.ReadLine());


            //average = (exam1 + exam2 + exam3) / 3;
            //Console.WriteLine("Saınavların ortalaması: " + average);

            //if (average > 0 & average <= 50)
            //{
            //    result = "Sonuç vasat";
            //}
            //if (average > 50 & average <= 70)
            //{
            //    result = "Sonuç orta";
            //}
            //if (average > 70 & average <= 84)
            //{
            //    result = "Sonuç iyi";
            //}
            //if (average > 84)
            //{
            //    result = "Sonuç çok iyi";
            //}

            //Console.WriteLine(result);

            //string city;
            //Console.Write("Lütfen şehir giriniz: ");
            //city = Console.ReadLine();

            //if (city == "adana" | city == "ankara" | city == "bursa" | city == "trabzon")
            //{
            //    Console.WriteLine("Şehir mevcut");
            //}
            //else
            //{
            //    Console.WriteLine("Şehir mevcut değil.");
            //}

            //Console.Write("Lütfen kullanıcı adını giriniz:");
            //string username = Console.ReadLine();
            //if ( username != "admin")
            //{
            //    Console.Write("Bu kullanıcı adı kabul edilemez.");
            //}
            //else
            //{
            //    Console.Write("Hoş geldiniz");
            //}



            #endregion

            #region Mod işlemleri

            //int number;
            //number = 26;
            //int result = number % 5;
            //Console.WriteLine(result);

            //Console.Write("Lütfen birinci sayıyı giriniz.");
            //int number1 = int.Parse(Console.ReadLine());

            //Console.Write("Lütfen ikinci sayıyı giriniz.");
            //int number2 = int.Parse(Console.ReadLine());

            //int result = number1 % number2;

            //Console.Write("Birinci sayının ikinci sayıya bölümünden kalan " + result);


            //Console.Write("Lütfen sayıyı giriniz: ");
            //int number = int.Parse(Console.ReadLine());

            //if(number % 2 ==0)
            //{
            //    Console.Write("Sayı çifttir.");
            //}
            //else
            //{
            //    Console.Write("Sayı tektir.");
            //}

            #endregion

            #region Char Değişkenler ile Karar Yapıları

            //char team;
            //Console.WriteLine("Lütfen takım sembolünü girininz.");
            //team = char.Parse(Console.ReadLine());  

            //if (team == 'g' | team == 'G')
            //{
            //    Console.Write("Galatasaray");
            //}
            //if (team == 'f' | team == 'F')
            //{
            //    Console.Write("FENERBAHÇE");
            //}
            //if (team == 'b' | team == 'B')
            //{
            //    Console.Write("Beşiktaş");
            //}

            #endregion

            #region Örnek Proje Uygulaması

            //Console.WriteLine("****** C# Eğitim Kampı Restoranı ******");
            //Console.WriteLine();
            //Console.WriteLine("--------------------------------------");
            //Console.WriteLine("1- Ana Yemekler");
            //Console.WriteLine("2- Çorbalar");
            //Console.WriteLine("3- Pizzalar");
            //Console.WriteLine("4- İçecekler");
            //Console.WriteLine("5- Tatlılar");
            //Console.WriteLine("--------------------------------------");
            //Console.WriteLine();

            //string menuItem;

            //Console.WriteLine("Detayını görmek istediğiniz menü: ");
            //menuItem = Console.ReadLine();  

            //if (menuItem == "1")
            //{
            //    Console.WriteLine("------------ Ana Yemekler ------------");
            //    Console.WriteLine("1- Köri Soslu Tavuk ");
            //    Console.WriteLine("2- Kızartma Tabağı ");
            //    Console.WriteLine("3- Fasulye Pilav ");
            //    Console.WriteLine("4- Fırında Somon ");
            //    Console.WriteLine("5- Patlıcan Musakka ");
            //    Console.WriteLine("------------ Ana Yemekler ------------");
            //}
            //if (menuItem == "2")
            //{
            //    Console.WriteLine("------------ Çorbalar ------------");
            //    Console.WriteLine("1- Mercimek Çorbası ");
            //    Console.WriteLine("2- Yayla Çorbası ");
            //    Console.WriteLine("3- Ezogelin Çorbası ");
            //    Console.WriteLine("------------ Çorbalar ------------");
            //}
            //if (menuItem == "3")
            //{
            //    Console.WriteLine("------------ Pizzalar ------------");
            //    Console.WriteLine("1- Karışık Pizza ");
            //    Console.WriteLine("2- Akdeniz Pizza ");
            //    Console.WriteLine("3- Margarita Pizza ");
            //    Console.WriteLine("4- Tavuklu Pizza ");
            //    Console.WriteLine("------------ Pizzalar ------------");
            //}
            //if (menuItem == "4")
            //{
            //    Console.WriteLine("------------ İçecekler ------------");
            //    Console.WriteLine("1- Kola ");
            //    Console.WriteLine("2- Ayran ");
            //    Console.WriteLine("3- Limonata");
            //    Console.WriteLine("3- Fuse Tea");
            //    Console.WriteLine("------------ İçeekler ------------");
            //}
            //if (menuItem == "5")
            //{
            //    Console.WriteLine("------------ Tatlılar ------------");
            //    Console.WriteLine("1- Kazandibi ");
            //    Console.WriteLine("2- Sütlaç ");
            //    Console.WriteLine("3- Baklava ");
            //    Console.WriteLine("------------ Tatlılar ------------");
            //}

            #endregion

            #region Switch Case

            //Console.WriteLine("Lütfen ay girişi yapınız.");
            //int monthNumber = int.Parse(Console.ReadLine());

            //switch (monthNumber)
            //{
            //    case 1:Console.WriteLine("Ocak");break;
            //    case 2:Console.WriteLine("Şubar");break;
            //    case 3:Console.WriteLine("Mart");break;
            //    case 4:Console.WriteLine("Nisan");break;
            //    case 5:Console.WriteLine("Mayıs");break;
            //    case 6:Console.WriteLine("Haziran");break;
            //    case 7:Console.WriteLine("Temmuz");break;
            //    case 8:Console.WriteLine("Ağustos");break;
            //    case 9:Console.WriteLine("Eylül");break;
            //    case 10:Console.WriteLine("Ekim");break;
            //    case 11:Console.WriteLine("Kasım");break;
            //    case 12:Console.WriteLine("Aralık");break;
            //    default:Console.WriteLine("Hatalı veri girişi."); break;
            //}

            #endregion

            #region Switch Case Hesap Makinesi

            //int number1, number2, result;
            //char symbol;

            //Console.Write("1.Sayıyı giriniz: ");
            //number1 = int.Parse(Console.ReadLine());

            //Console.Write("2.Sayıyı giriniz: ");
            //number2 = int.Parse(Console.ReadLine());

            //Console.Write("Lütfen yapmak istediğiniz işlemi giriniz: ");
            //symbol = char.Parse(Console.ReadLine());    

            //switch (symbol)
            //    {
            //        case '+':
            //            result = number1 + number2;
            //            Console.WriteLine("Toplam: " + result);
            //            break;

            //        case '-':
            //            result = number1 - number2;
            //            Console.WriteLine("Fark: " + result);
            //            break;

            //        case '*':
            //            result = number1 * number2;
            //            Console.WriteLine("Çarpım: " + result);
            //            break;

            //        case '/':
            //            result = number1 / number2;
            //            Console.WriteLine("Bölüm: " + result);
            //            break;
            //    }

            #endregion

            Console.Read();
        }
    }
}
