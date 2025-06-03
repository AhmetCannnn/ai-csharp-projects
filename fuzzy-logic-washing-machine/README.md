# Fuzzy Logic Washing Machine

This project is a Windows Forms application that simulates a fuzzy logic control system for a washing machine in C#.

## How It Works
- The user can define fuzzy variables, sets, and rules for the washing machine.
- The application performs fuzzy inference to determine optimal washing parameters.

## How to Run
1. Open the `BulanikCamasirMakinesi.sln` file with Visual Studio.
2. Build and run the project.
3. Use the interface to experiment with fuzzy logic control for the washing machine.

> Note: This project targets .NET Framework 4.7.2 and uses Windows Forms.

## Proje Özellikleri

- Bulanık küme ve bulanık mantık sistemi tamamen sıfırdan kodlanmıştır
- Windows Forms arayüzü ile kullanıcı dostu bir arayüz sunulmuştur
- Giriş değişkenleri (Hassaslık, Miktar, Kirlilik) kullanıcı tarafından ayarlanabilir
- Çıkış değişkenleri (Dönüş Hızı, Süre, Deterjan Miktarı) bulanık mantık ile hesaplanır
- Tetiklenen kurallar ve kuralların ateşleme dereceleri gösterilir
- Hem ağırlıklı ortalama hem de ağırlık merkezi (centroid) durulaştırma yöntemleri uygulanmıştır
- Tüm değişken değerlerinin grafikle gösterimi yapılmıştır

## Kullanılan Bulanık Mantık Bileşenleri

- Üyelik Fonksiyonları: Üçgen ve Yamuk
- Çıkarım Mekanizması: Mamdani (min-max)
- Durulaştırma Yöntemleri: 
  - Ağırlıklı Ortalama (Weighted Average)
  - Ağırlık Merkezi (Centroid)

## Çalıştırma

Proje bir Windows Forms uygulamasıdır. Visual Studio ile açarak doğrudan çalıştırabilirsiniz.

## Geliştirme

Bu proje nesne yönelimli programlama prensipleri dikkate alınarak geliştirilmiştir. Ana bileşenler:

- `FuzzySet.cs`: Bulanık küme sınıfı
- `FuzzyVariable.cs`: Bulanık değişken sınıfı
- `FuzzyRule.cs`: Bulanık kural sınıfı
- `FuzzyLogicSystem.cs`: Bulanık mantık sistemi
- `WashingMachineFuzzySystem.cs`: Çamaşır makinesi için özelleştirilmiş bulanık sistem
- `GraphManager.cs`: Grafik çizim işlemleri
- `MainForm.cs`: Kullanıcı arayüzü 