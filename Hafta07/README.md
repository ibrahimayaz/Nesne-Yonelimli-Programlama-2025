# Hafta 7: Sınıflar ve Nesneler - Bölüm 2 (Constructor, Properties)

## Teorik Bilgiler

### Constructor (Yapıcı Metot) Nedir?
Constructor, bir nesne oluşturulduğunda otomatik olarak çağrılan özel bir metottur. Nesnenin başlangıç değerlerini ayarlamak için kullanılır.

**Özellikleri:**
- Sınıf ile aynı ada sahiptir
- Geri dönüş tipi yoktur (void bile yazılmaz)
- Overload edilebilir (birden fazla constructor)
- Tanımlanmazsa, default constructor otomatik oluşturulur

### Property (Özellik) Nedir?
Property, field'lara kontrollü erişim sağlayan özel yapılardır. Get ve set accessor'ları içerir.

**Avantajları:**
- Veri doğrulama (validation)
- Veri gizleme (encapsulation)
- Read-only veya write-only yapılabilir
- Hesaplanmış değerler döndürebilir

### Auto-Property
C# 3.0 ile gelen kısa property tanımlama yöntemi.

```csharp
public string Ad { get; set; }
```

### this Anahtar Kelimesi
Mevcut nesneye referans verir. Parametre isimleri ile field isimleri aynı olduğunda kullanılır.

## Örnekler

### Örnek 1: Constructor Kullanımı
```csharp
using System;

namespace ConstructorOrnegi
{
    class Kitap
    {
        // Fields
        public string baslik;
        public string yazar;
        public int sayfa;
        public double fiyat;
        
        // Default Constructor
        public Kitap()
        {
            Console.WriteLine("Kitap nesnesi oluşturuldu (default constructor)");
            baslik = "Bilinmeyen";
            yazar = "Bilinmeyen";
            sayfa = 0;
            fiyat = 0.0;
        }
        
        // Parametreli Constructor
        public Kitap(string baslik, string yazar)
        {
            Console.WriteLine("Kitap nesnesi oluşturuldu (2 parametre)");
            this.baslik = baslik;
            this.yazar = yazar;
            this.sayfa = 0;
            this.fiyat = 0.0;
        }
        
        // Tam parametreli Constructor
        public Kitap(string baslik, string yazar, int sayfa, double fiyat)
        {
            Console.WriteLine("Kitap nesnesi oluşturuldu (4 parametre)");
            this.baslik = baslik;
            this.yazar = yazar;
            this.sayfa = sayfa;
            this.fiyat = fiyat;
        }
        
        public void BilgiGoster()
        {
            Console.WriteLine($"{baslik} - {yazar} ({sayfa} sayfa, {fiyat} TL)");
        }
    }
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Constructor Örnekleri ===\n");
            
            // Default constructor
            Kitap kitap1 = new Kitap();
            kitap1.BilgiGoster();
            Console.WriteLine();
            
            // 2 parametreli constructor
            Kitap kitap2 = new Kitap("1984", "George Orwell");
            kitap2.sayfa = 328;
            kitap2.fiyat = 25.50;
            kitap2.BilgiGoster();
            Console.WriteLine();
            
            // Tam parametreli constructor
            Kitap kitap3 = new Kitap("Suç ve Ceza", "Dostoyevski", 671, 35.00);
            kitap3.BilgiGoster();
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Üç farklı constructor overload'ı
- `this` anahtar kelimesi kullanımı
- Constructor'da başlangıç değerleri atama

### Örnek 2: Property Kullanımı
```csharp
using System;

namespace PropertyOrnegi
{
    class Ogrenci
    {
        // Private fields
        private string ad;
        private string soyad;
        private int yas;
        private double not;
        
        // Property - Get ve Set ile kontrollü erişim
        public string Ad
        {
            get { return ad; }
            set 
            { 
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Ad boş olamaz!");
                    return;
                }
                ad = value; 
            }
        }
        
        public string Soyad
        {
            get { return soyad; }
            set 
            { 
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Soyad boş olamaz!");
                    return;
                }
                soyad = value; 
            }
        }
        
        public int Yas
        {
            get { return yas; }
            set 
            { 
                if (value < 0 || value > 120)
                {
                    Console.WriteLine("Geçersiz yaş!");
                    return;
                }
                yas = value; 
            }
        }
        
        public double Not
        {
            get { return not; }
            set 
            { 
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("Not 0-100 arasında olmalı!");
                    return;
                }
                not = value; 
            }
        }
        
        // Read-only property (sadece get)
        public string TamAd
        {
            get { return $"{ad} {soyad}"; }
        }
        
        // Hesaplanmış property
        public string HarfNotu
        {
            get
            {
                if (not >= 90) return "AA";
                else if (not >= 80) return "BA";
                else if (not >= 70) return "BB";
                else if (not >= 60) return "CB";
                else if (not >= 50) return "CC";
                else return "FF";
            }
        }
        
        public void BilgiGoster()
        {
            Console.WriteLine($"Öğrenci: {TamAd}");
            Console.WriteLine($"Yaş: {Yas}");
            Console.WriteLine($"Not: {Not} ({HarfNotu})");
        }
    }
    
    class Program
    {
        static void Main()
        {
            Ogrenci ogr = new Ogrenci();
            
            // Property set (atama)
            ogr.Ad = "Ahmet";
            ogr.Soyad = "Yılmaz";
            ogr.Yas = 20;
            ogr.Not = 85;
            
            // Property get (okuma)
            Console.WriteLine($"Ad: {ogr.Ad}");
            Console.WriteLine($"Tam Ad: {ogr.TamAd}");
            Console.WriteLine($"Harf Notu: {ogr.HarfNotu}");
            Console.WriteLine();
            
            ogr.BilgiGoster();
            Console.WriteLine();
            
            // Geçersiz değer denemeleri
            Console.WriteLine("=== Validasyon Testleri ===");
            ogr.Yas = -5;  // Hata mesajı verir
            ogr.Not = 150; // Hata mesajı verir
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Private field, public property kullanımı
- Get/Set ile veri doğrulama
- Read-only property (TamAd)
- Hesaplanmış property (HarfNotu)

### Örnek 3: Auto-Property ve Constructor
```csharp
using System;

namespace AutoPropertyOrnegi
{
    class Urun
    {
        // Auto-properties
        public string Ad { get; set; }
        public string Kategori { get; set; }
        public double Fiyat { get; set; }
        public int StokMiktari { get; set; }
        
        // Read-only auto-property
        public DateTime EklenmeTarihi { get; }
        
        // Property with private set
        public string Barkod { get; private set; }
        
        // Hesaplanmış property
        public double KDVliFiyat
        {
            get { return Fiyat * 1.18; }
        }
        
        public bool StokVarMi
        {
            get { return StokMiktari > 0; }
        }
        
        // Constructor
        public Urun(string ad, string kategori, double fiyat, int stok)
        {
            Ad = ad;
            Kategori = kategori;
            Fiyat = fiyat;
            StokMiktari = stok;
            EklenmeTarihi = DateTime.Now;
            Barkod = GenerateBarkod();
        }
        
        private string GenerateBarkod()
        {
            Random rnd = new Random();
            return $"BR{rnd.Next(100000, 999999)}";
        }
        
        public void BilgiGoster()
        {
            Console.WriteLine($"Ürün: {Ad}");
            Console.WriteLine($"Kategori: {Kategori}");
            Console.WriteLine($"Fiyat: {Fiyat:C}");
            Console.WriteLine($"KDV'li Fiyat: {KDVliFiyat:C}");
            Console.WriteLine($"Stok: {StokMiktari} ({(StokVarMi ? "Mevcut" : "Tükendi")})");
            Console.WriteLine($"Barkod: {Barkod}");
            Console.WriteLine($"Eklenme: {EklenmeTarihi:dd.MM.yyyy HH:mm}");
        }
        
        public void StokEkle(int miktar)
        {
            StokMiktari += miktar;
            Console.WriteLine($"{miktar} adet stok eklendi. Yeni stok: {StokMiktari}");
        }
        
        public void StokCikar(int miktar)
        {
            if (miktar > StokMiktari)
            {
                Console.WriteLine("Yetersiz stok!");
                return;
            }
            StokMiktari -= miktar;
            Console.WriteLine($"{miktar} adet satıldı. Kalan stok: {StokMiktari}");
        }
    }
    
    class Program
    {
        static void Main()
        {
            Urun urun1 = new Urun("Laptop", "Elektronik", 15000, 10);
            urun1.BilgiGoster();
            Console.WriteLine();
            
            urun1.StokCikar(3);
            urun1.StokEkle(5);
            Console.WriteLine();
            
            Urun urun2 = new Urun("Mouse", "Elektronik", 150, 50);
            urun2.BilgiGoster();
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Auto-property kullanımı (kısa sözdizimi)
- Read-only property (EklenmeTarihi)
- Private set property (Barkod)
- Constructor ile başlangıç değerleri

### Örnek 4: Banka Hesabı - Gelişmiş Örnek
```csharp
using System;
using System.Collections.Generic;

namespace BankaHesabiGelismis
{
    class BankaHesap
    {
        // Private fields
        private double bakiye;
        private List<string> islemGecmisi;
        
        // Auto-properties
        public string HesapNo { get; private set; }
        public string HesapSahibi { get; set; }
        public string HesapTuru { get; set; }
        public DateTime AcilisTarihi { get; }
        
        // Property with validation
        public double Bakiye
        {
            get { return bakiye; }
            private set { bakiye = value; }
        }
        
        // Read-only hesaplanmış property
        public int HesapYasi
        {
            get 
            { 
                return (DateTime.Now - AcilisTarihi).Days / 365; 
            }
        }
        
        // Constructor
        public BankaHesap(string hesapSahibi, string hesapTuru, double ilkBakiye = 0)
        {
            HesapNo = GenerateHesapNo();
            HesapSahibi = hesapSahibi;
            HesapTuru = hesapTuru;
            Bakiye = ilkBakiye;
            AcilisTarihi = DateTime.Now;
            islemGecmisi = new List<string>();
            
            if (ilkBakiye > 0)
            {
                IslemKaydet($"Hesap açılış bakiyesi: {ilkBakiye:C}");
            }
        }
        
        private string GenerateHesapNo()
        {
            Random rnd = new Random();
            return $"TR{rnd.Next(10000000, 99999999)}";
        }
        
        private void IslemKaydet(string islem)
        {
            string zaman = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            islemGecmisi.Add($"[{zaman}] {islem}");
        }
        
        public void ParaYatir(double miktar)
        {
            if (miktar <= 0)
            {
                Console.WriteLine("Geçersiz miktar!");
                return;
            }
            
            Bakiye += miktar;
            IslemKaydet($"Para yatırma: +{miktar:C} (Bakiye: {Bakiye:C})");
            Console.WriteLine($"{miktar:C} yatırıldı.");
        }
        
        public void ParaCek(double miktar)
        {
            if (miktar <= 0)
            {
                Console.WriteLine("Geçersiz miktar!");
                return;
            }
            
            if (miktar > Bakiye)
            {
                Console.WriteLine("Yetersiz bakiye!");
                IslemKaydet($"Başarısız para çekme: {miktar:C} (Yetersiz bakiye)");
                return;
            }
            
            Bakiye -= miktar;
            IslemKaydet($"Para çekme: -{miktar:C} (Bakiye: {Bakiye:C})");
            Console.WriteLine($"{miktar:C} çekildi.");
        }
        
        public void HesapOzeti()
        {
            Console.WriteLine("=== HESAP ÖZETİ ===");
            Console.WriteLine($"Hesap No: {HesapNo}");
            Console.WriteLine($"Hesap Sahibi: {HesapSahibi}");
            Console.WriteLine($"Hesap Türü: {HesapTuru}");
            Console.WriteLine($"Açılış: {AcilisTarihi:dd.MM.yyyy}");
            Console.WriteLine($"Hesap Yaşı: {HesapYasi} yıl");
            Console.WriteLine($"Güncel Bakiye: {Bakiye:C}");
        }
        
        public void IslemGecmisiGoster()
        {
            Console.WriteLine("\n=== İŞLEM GEÇMİŞİ ===");
            if (islemGecmisi.Count == 0)
            {
                Console.WriteLine("Henüz işlem yapılmamış.");
                return;
            }
            
            foreach (string islem in islemGecmisi)
            {
                Console.WriteLine(islem);
            }
        }
    }
    
    class Program
    {
        static void Main()
        {
            // Hesap oluşturma
            BankaHesap hesap = new BankaHesap("Ahmet Yılmaz", "Vadesiz", 1000);
            
            hesap.HesapOzeti();
            Console.WriteLine();
            
            // İşlemler
            hesap.ParaYatir(500);
            hesap.ParaCek(200);
            hesap.ParaCek(2000); // Yetersiz bakiye
            hesap.ParaYatir(300);
            
            Console.WriteLine();
            hesap.HesapOzeti();
            hesap.IslemGecmisiGoster();
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Gelişmiş property kullanımı
- Private set ile güvenli veri
- Constructor ile başlangıç kurulumu
- İşlem geçmişi takibi

### Örnek 5: Tarih ve Çalışan Sınıfı
```csharp
using System;

namespace CalisanYonetimi
{
    class Calisan
    {
        // Auto-properties
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Pozisyon { get; set; }
        public DateTime IseBaslamaTarihi { get; set; }
        
        // Private field with public property
        private double maas;
        public double Maas
        {
            get { return maas; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Maaş negatif olamaz!");
                    return;
                }
                maas = value;
            }
        }
        
        // Read-only properties
        public string TamAd
        {
            get { return $"{Ad} {Soyad}"; }
        }
        
        public int CalismaSuresi
        {
            get
            {
                TimeSpan sure = DateTime.Now - IseBaslamaTarihi;
                return (int)(sure.TotalDays / 365);
            }
        }
        
        public double YillikMaas
        {
            get { return Maas * 12; }
        }
        
        // Constructors
        public Calisan()
        {
            Ad = "Bilinmeyen";
            Soyad = "Bilinmeyen";
            Pozisyon = "Belirtilmemiş";
            IseBaslamaTarihi = DateTime.Now;
            Maas = 0;
        }
        
        public Calisan(string ad, string soyad, string pozisyon, double maas)
        {
            Ad = ad;
            Soyad = soyad;
            Pozisyon = pozisyon;
            Maas = maas;
            IseBaslamaTarihi = DateTime.Now;
        }
        
        public Calisan(string ad, string soyad, string pozisyon, double maas, DateTime baslangic)
        {
            Ad = ad;
            Soyad = soyad;
            Pozisyon = pozisyon;
            Maas = maas;
            IseBaslamaTarihi = baslangic;
        }
        
        // Methods
        public void ZamYap(double yuzde)
        {
            double eskiMaas = Maas;
            Maas += Maas * (yuzde / 100);
            Console.WriteLine($"{TamAd} için %{yuzde} zam yapıldı.");
            Console.WriteLine($"Eski maaş: {eskiMaas:C}, Yeni maaş: {Maas:C}");
        }
        
        public void BilgiGoster()
        {
            Console.WriteLine($"Ad Soyad: {TamAd}");
            Console.WriteLine($"Pozisyon: {Pozisyon}");
            Console.WriteLine($"Maaş: {Maas:C}");
            Console.WriteLine($"Yıllık Maaş: {YillikMaas:C}");
            Console.WriteLine($"İşe Başlama: {IseBaslamaTarihi:dd.MM.yyyy}");
            Console.WriteLine($"Çalışma Süresi: {CalismaSuresi} yıl");
        }
    }
    
    class Program
    {
        static void Main()
        {
            // Constructor 1 - Default
            Calisan calisan1 = new Calisan();
            calisan1.BilgiGoster();
            Console.WriteLine();
            
            // Constructor 2 - 4 parametre
            Calisan calisan2 = new Calisan("Ahmet", "Yılmaz", "Yazılım Geliştirici", 15000);
            calisan2.BilgiGoster();
            Console.WriteLine();
            
            // Zam yapma
            calisan2.ZamYap(10);
            Console.WriteLine();
            
            // Constructor 3 - 5 parametre (eski tarih)
            DateTime eskiTarih = new DateTime(2018, 5, 15);
            Calisan calisan3 = new Calisan("Ayşe", "Demir", "Proje Yöneticisi", 20000, eskiTarih);
            calisan3.BilgiGoster();
            Console.WriteLine();
            
            Console.WriteLine($"Çalışma Süresi: {calisan3.CalismaSuresi} yıl");
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Constructor overloading
- Auto-property ve normal property karışımı
- Tarih hesaplamaları
- Read-only hesaplanmış propertyler

## Alıştırmalar

1. `Araba` sınıfına property'ler ve constructor ekleyin
2. `Urun` sınıfı için indirim hesaplayan property yazın
3. `Ogrenci` sınıfına not ortalaması hesaplayan property ekleyin
4. `BankaKredi` sınıfı yapın (faiz hesaplama property'si ile)
5. `Kitap` sınıfına read-only `YayinYiliItibariyleYas` property'si ekleyin

## Önemli Notlar

- Constructor sınıf adı ile aynı olmalıdır
- Property'ler encapsulation sağlar
- Auto-property kısa kod için idealdir
- Read-only property için sadece get yazılır
- Private field + public property en güvenli yöntemdir
- `this` anahtar kelimesi parametre-field karışıklığını önler

## Ek Kaynaklar

- [C# Constructors](https://docs.microsoft.com/tr-tr/dotnet/csharp/programming-guide/classes-and-structs/constructors)
- [C# Properties](https://docs.microsoft.com/tr-tr/dotnet/csharp/programming-guide/classes-and-structs/properties)

## Sonraki Hafta

Hafta 8'de encapsulation ve erişim belirleyiciler konusunu işleyeceğiz.
