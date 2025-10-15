# Hafta 6: Sınıflar ve Nesneler - Bölüm 1

## Teorik Bilgiler

### Nesne Yönelimli Programlama (OOP) Nedir?
Nesne Yönelimli Programlama, gerçek dünya nesnelerini modelleyerek program geliştirme yaklaşımıdır. OOP'nin dört temel prensibi vardır:
1. **Encapsulation (Kapsülleme):** Veri gizleme
2. **Inheritance (Kalıtım):** Kod yeniden kullanımı
3. **Polymorphism (Çok biçimlilik):** Aynı arayüz, farklı davranışlar
4. **Abstraction (Soyutlama):** Gereksiz detayları gizleme

### Sınıf (Class) Nedir?
Sınıf, nesnelerin şablonudur. Özellikleri (properties/fields) ve davranışları (methods) tanımlar.

### Nesne (Object) Nedir?
Nesne, bir sınıfın somut bir örneğidir (instance). Sınıf taslak, nesne ise o taslaktan üretilen gerçek varlıktır.

### Sınıf Tanımlama
```csharp
class SinifAdi
{
    // Alanlar (Fields)
    // Özellikler (Properties)
    // Metotlar (Methods)
    // Constructor (Yapıcı metot)
}
```

### Field vs Property
- **Field:** Sınıfın doğrudan değişkeni
- **Property:** Kontrollü erişim sağlayan özel yapı (get/set)

## Örnekler

### Örnek 1: İlk Sınıf ve Nesne
```csharp
using System;

namespace IlkSinif
{
    // Sınıf tanımlama
    class Ogrenci
    {
        // Alanlar (Fields)
        public string ad;
        public string soyad;
        public int yas;
        public string bolum;
        
        // Metot
        public void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {ad} {soyad}");
            Console.WriteLine($"Yaş: {yas}");
            Console.WriteLine($"Bölüm: {bolum}");
        }
    }
    
    class Program
    {
        static void Main()
        {
            // Nesne oluşturma (Instantiation)
            Ogrenci ogrenci1 = new Ogrenci();
            
            // Özelliklere değer atama
            ogrenci1.ad = "Ahmet";
            ogrenci1.soyad = "Yılmaz";
            ogrenci1.yas = 20;
            ogrenci1.bolum = "Bilgisayar Mühendisliği";
            
            // Metot çağırma
            Console.WriteLine("=== Öğrenci 1 Bilgileri ===");
            ogrenci1.BilgiYazdir();
            
            Console.WriteLine();
            
            // İkinci nesne
            Ogrenci ogrenci2 = new Ogrenci();
            ogrenci2.ad = "Ayşe";
            ogrenci2.soyad = "Demir";
            ogrenci2.yas = 22;
            ogrenci2.bolum = "Elektrik Mühendisliği";
            
            Console.WriteLine("=== Öğrenci 2 Bilgileri ===");
            ogrenci2.BilgiYazdir();
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- `class Ogrenci` ile sınıf tanımlandı
- `new` anahtar kelimesi ile nesneler oluşturuldu
- Her nesne bağımsız veri taşıyor
- Nokta (.) operatörü ile üyelere erişildi

### Örnek 2: Daha Karmaşık Sınıf - Araba
```csharp
using System;

namespace ArabaSinifi
{
    class Araba
    {
        // Alanlar
        public string marka;
        public string model;
        public int yil;
        public string renk;
        public double kilometresi;
        
        // Araba çalıştırma
        public void Calistir()
        {
            Console.WriteLine($"{marka} {model} çalıştırıldı. Vroom!");
        }
        
        // Kilometre artırma
        public void YolAl(double km)
        {
            kilometresi += km;
            Console.WriteLine($"{km} km yol alındı. Toplam: {kilometresi} km");
        }
        
        // Araba bilgilerini göster
        public void BilgiGoster()
        {
            Console.WriteLine("--- Araba Bilgileri ---");
            Console.WriteLine($"Marka: {marka}");
            Console.WriteLine($"Model: {model}");
            Console.WriteLine($"Yıl: {yil}");
            Console.WriteLine($"Renk: {renk}");
            Console.WriteLine($"Kilometre: {kilometresi} km");
        }
        
        // Arabanın yaşını hesapla
        public int YasiniBul()
        {
            int mevcutYil = DateTime.Now.Year;
            return mevcutYil - yil;
        }
    }
    
    class Program
    {
        static void Main()
        {
            // Araba nesnesi oluşturma
            Araba araba1 = new Araba();
            araba1.marka = "Toyota";
            araba1.model = "Corolla";
            araba1.yil = 2018;
            araba1.renk = "Beyaz";
            araba1.kilometresi = 50000;
            
            araba1.BilgiGoster();
            Console.WriteLine($"Arabanın yaşı: {araba1.YasiniBul()} yıl");
            Console.WriteLine();
            
            araba1.Calistir();
            araba1.YolAl(150);
            araba1.YolAl(200);
            
            Console.WriteLine();
            
            // İkinci araba
            Araba araba2 = new Araba();
            araba2.marka = "BMW";
            araba2.model = "3.20i";
            araba2.yil = 2020;
            araba2.renk = "Siyah";
            araba2.kilometresi = 25000;
            
            Console.WriteLine();
            araba2.BilgiGoster();
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Gerçek dünya nesnesi (Araba) modellendi
- Durum (state) ve davranış (behavior) birleştirildi
- Her nesne kendi verilerini taşıyor
- Metotlar nesne üzerinde işlem yapıyor

### Örnek 3: Hesap Makinesi Sınıfı
```csharp
using System;

namespace HesapMakinesi
{
    class Hesaplayici
    {
        // Alan - işlem geçmişi için
        public int islemSayisi = 0;
        
        // Toplama
        public double Topla(double a, double b)
        {
            islemSayisi++;
            return a + b;
        }
        
        // Çıkarma
        public double Cikar(double a, double b)
        {
            islemSayisi++;
            return a - b;
        }
        
        // Çarpma
        public double Carp(double a, double b)
        {
            islemSayisi++;
            return a * b;
        }
        
        // Bölme
        public double Bol(double a, double b)
        {
            islemSayisi++;
            if (b == 0)
            {
                Console.WriteLine("HATA: Sıfıra bölme!");
                return 0;
            }
            return a / b;
        }
        
        // Üs alma
        public double UsAl(double taban, double us)
        {
            islemSayisi++;
            return Math.Pow(taban, us);
        }
        
        // Karekök
        public double Karekok(double sayi)
        {
            islemSayisi++;
            if (sayi < 0)
            {
                Console.WriteLine("HATA: Negatif sayının karekökü alınamaz!");
                return 0;
            }
            return Math.Sqrt(sayi);
        }
        
        // İstatistik göster
        public void IstatistikGoster()
        {
            Console.WriteLine($"Toplam {islemSayisi} işlem yapıldı.");
        }
    }
    
    class Program
    {
        static void Main()
        {
            Hesaplayici calc = new Hesaplayici();
            
            Console.WriteLine("=== Hesap Makinesi ===");
            Console.WriteLine($"10 + 5 = {calc.Topla(10, 5)}");
            Console.WriteLine($"10 - 5 = {calc.Cikar(10, 5)}");
            Console.WriteLine($"10 * 5 = {calc.Carp(10, 5)}");
            Console.WriteLine($"10 / 5 = {calc.Bol(10, 5)}");
            Console.WriteLine($"2^8 = {calc.UsAl(2, 8)}");
            Console.WriteLine($"√16 = {calc.Karekok(16)}");
            
            Console.WriteLine();
            calc.IstatistikGoster();
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Fonksiyonel sınıf örneği
- Durum takibi (işlem sayısı)
- Hata kontrolleri metot içinde
- İstatistik tutma yeteneği

### Örnek 4: Banka Hesabı Sınıfı
```csharp
using System;

namespace BankaHesabi
{
    class BankaHesap
    {
        // Alanlar
        public string hesapSahibi;
        public string hesapNo;
        public double bakiye;
        public string hesapTuru;
        
        // Para yatırma
        public void ParaYatir(double miktar)
        {
            if (miktar <= 0)
            {
                Console.WriteLine("HATA: Geçersiz miktar!");
                return;
            }
            
            bakiye += miktar;
            Console.WriteLine($"{miktar} TL yatırıldı.");
            Console.WriteLine($"Yeni bakiye: {bakiye} TL");
        }
        
        // Para çekme
        public void ParaCek(double miktar)
        {
            if (miktar <= 0)
            {
                Console.WriteLine("HATA: Geçersiz miktar!");
                return;
            }
            
            if (miktar > bakiye)
            {
                Console.WriteLine("HATA: Yetersiz bakiye!");
                return;
            }
            
            bakiye -= miktar;
            Console.WriteLine($"{miktar} TL çekildi.");
            Console.WriteLine($"Kalan bakiye: {bakiye} TL");
        }
        
        // Bakiye sorgulama
        public void BakiyeSorgula()
        {
            Console.WriteLine($"Mevcut bakiye: {bakiye} TL");
        }
        
        // Hesap bilgileri
        public void HesapBilgileri()
        {
            Console.WriteLine("--- Hesap Bilgileri ---");
            Console.WriteLine($"Hesap Sahibi: {hesapSahibi}");
            Console.WriteLine($"Hesap No: {hesapNo}");
            Console.WriteLine($"Hesap Türü: {hesapTuru}");
            Console.WriteLine($"Bakiye: {bakiye} TL");
        }
        
        // Havale/EFT
        public void HavaleYap(BankaHesap hedefHesap, double miktar)
        {
            if (miktar > bakiye)
            {
                Console.WriteLine("HATA: Yetersiz bakiye!");
                return;
            }
            
            bakiye -= miktar;
            hedefHesap.bakiye += miktar;
            Console.WriteLine($"{miktar} TL, {hedefHesap.hesapSahibi} hesabına transfer edildi.");
        }
    }
    
    class Program
    {
        static void Main()
        {
            // İlk hesap
            BankaHesap hesap1 = new BankaHesap();
            hesap1.hesapSahibi = "Ahmet Yılmaz";
            hesap1.hesapNo = "TR123456789";
            hesap1.hesapTuru = "Vadesiz";
            hesap1.bakiye = 5000;
            
            Console.WriteLine("=== Hesap 1 ===");
            hesap1.HesapBilgileri();
            Console.WriteLine();
            
            hesap1.ParaYatir(1000);
            hesap1.ParaCek(500);
            hesap1.BakiyeSorgula();
            
            Console.WriteLine();
            
            // İkinci hesap
            BankaHesap hesap2 = new BankaHesap();
            hesap2.hesapSahibi = "Ayşe Demir";
            hesap2.hesapNo = "TR987654321";
            hesap2.hesapTuru = "Vadeli";
            hesap2.bakiye = 3000;
            
            Console.WriteLine("=== Hesap 2 ===");
            hesap2.HesapBilgileri();
            Console.WriteLine();
            
            // Havale işlemi
            Console.WriteLine("=== Havale İşlemi ===");
            hesap1.HavaleYap(hesap2, 1000);
            Console.WriteLine();
            
            Console.WriteLine("Güncel bakiyeler:");
            hesap1.BakiyeSorgula();
            hesap2.BakiyeSorgula();
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Gerçek dünya uygulaması (Banka hesabı)
- Veri doğrulama (validasyon)
- Nesneler arası etkileşim (havale)
- İş kuralları uygulaması

### Örnek 5: Kitap Kütüphanesi Sistemi
```csharp
using System;

namespace KutuphaneSistemi
{
    class Kitap
    {
        // Alanlar
        public string baslik;
        public string yazar;
        public string isbn;
        public int sayfaSayisi;
        public int yayinYili;
        public bool oduncVerildiMi;
        public string oduncAlan;
        
        // Kitap bilgilerini göster
        public void BilgiGoster()
        {
            Console.WriteLine($"Başlık: {baslik}");
            Console.WriteLine($"Yazar: {yazar}");
            Console.WriteLine($"ISBN: {isbn}");
            Console.WriteLine($"Sayfa: {sayfaSayisi}");
            Console.WriteLine($"Yayın Yılı: {yayinYili}");
            Console.WriteLine($"Durum: {(oduncVerildiMi ? "Ödünç verildi" : "Kütüphanede")}");
            if (oduncVerildiMi)
                Console.WriteLine($"Ödünç Alan: {oduncAlan}");
        }
        
        // Ödünç ver
        public void OduncVer(string kisi)
        {
            if (oduncVerildiMi)
            {
                Console.WriteLine($"HATA: Kitap zaten {oduncAlan} tarafından ödünç alınmış!");
                return;
            }
            
            oduncVerildiMi = true;
            oduncAlan = kisi;
            Console.WriteLine($"'{baslik}' kitabı {kisi} tarafından ödünç alındı.");
        }
        
        // İade al
        public void IadeAl()
        {
            if (!oduncVerildiMi)
            {
                Console.WriteLine("HATA: Kitap zaten kütüphanede!");
                return;
            }
            
            Console.WriteLine($"'{baslik}' kitabı {oduncAlan} tarafından iade edildi.");
            oduncVerildiMi = false;
            oduncAlan = "";
        }
        
        // Kitabın yaşı
        public int KitapYasi()
        {
            return DateTime.Now.Year - yayinYili;
        }
        
        // Kısa bilgi
        public string KisaBilgi()
        {
            return $"{baslik} - {yazar} ({yayinYili})";
        }
    }
    
    class Program
    {
        static void Main()
        {
            // Kitap 1
            Kitap kitap1 = new Kitap();
            kitap1.baslik = "Suç ve Ceza";
            kitap1.yazar = "Dostoyevski";
            kitap1.isbn = "978-1234567890";
            kitap1.sayfaSayisi = 671;
            kitap1.yayinYili = 1866;
            kitap1.oduncVerildiMi = false;
            
            Console.WriteLine("=== Kitap 1 ===");
            kitap1.BilgiGoster();
            Console.WriteLine($"Kitabın yaşı: {kitap1.KitapYasi()} yıl");
            Console.WriteLine();
            
            // Ödünç verme
            kitap1.OduncVer("Ahmet Yılmaz");
            Console.WriteLine();
            kitap1.BilgiGoster();
            Console.WriteLine();
            
            // Tekrar ödünç verme denemesi
            kitap1.OduncVer("Mehmet Demir");
            Console.WriteLine();
            
            // İade alma
            kitap1.IadeAl();
            Console.WriteLine();
            
            // Kitap 2
            Kitap kitap2 = new Kitap();
            kitap2.baslik = "1984";
            kitap2.yazar = "George Orwell";
            kitap2.isbn = "978-0987654321";
            kitap2.sayfaSayisi = 328;
            kitap2.yayinYili = 1949;
            kitap2.oduncVerildiMi = false;
            
            Console.WriteLine("=== Kitap 2 ===");
            Console.WriteLine(kitap2.KisaBilgi());
            
            Console.WriteLine();
            
            // Kitap 3
            Kitap kitap3 = new Kitap();
            kitap3.baslik = "Simyacı";
            kitap3.yazar = "Paulo Coelho";
            kitap3.isbn = "978-1122334455";
            kitap3.sayfaSayisi = 208;
            kitap3.yayinYili = 1988;
            kitap3.oduncVerildiMi = false;
            
            Console.WriteLine("=== Kütüphane Kitapları ===");
            Console.WriteLine($"1. {kitap1.KisaBilgi()}");
            Console.WriteLine($"2. {kitap2.KisaBilgi()}");
            Console.WriteLine($"3. {kitap3.KisaBilgi()}");
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Kütüphane yönetim sistemi
- Durum yönetimi (ödünç verme/iade)
- İş mantığı kontrolü
- Çoklu nesne yönetimi

## Alıştırmalar

1. `Telefon` sınıfı oluşturun (marka, model, fiyat, depolama)
2. `Ogrenci` sınıfına not ekleme ve ortalama hesaplama metodu ekleyin
3. `Dikdörtgen` sınıfı yapın (alan ve çevre hesaplama metotlarıyla)
4. `Calisan` sınıfı oluşturun (maaş zammı yapabilen)
5. `SepetUrunu` sınıfı ile basit bir alışveriş sepeti yapın

## Önemli Notlar

- Sınıf ismleri PascalCase ile yazılır
- Field isimleri camelCase ile yazılır
- Her sınıf tek sorumluluğa sahip olmalı
- Public alanlar yerine property kullanımı tercih edilmeli
- Sınıflar gerçek dünya nesnelerini modeller

## Ek Kaynaklar

- [C# Sınıflar](https://docs.microsoft.com/tr-tr/dotnet/csharp/fundamentals/types/classes)
- [C# Nesneler](https://docs.microsoft.com/tr-tr/dotnet/csharp/fundamentals/object-oriented/)

## Sonraki Hafta

Hafta 7'de Constructor, Properties ve daha gelişmiş sınıf özellikleri konusunu işleyeceğiz.
