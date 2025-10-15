# Hafta 11: Soyut Sınıflar ve Arayüzler

## Teorik Bilgiler

### Abstract Class (Soyut Sınıf)
Kendisinden nesne oluşturulamayan, alt sınıflar için şablon olan sınıftır.

**Özellikleri:**
- `abstract` anahtar kelimesi ile tanımlanır
- Abstract ve concrete (normal) metotlar içerebilir
- Abstract metotlar gövdesizdir, alt sınıfta tanımlanmalıdır
- Constructor içerebilir
- Field ve property içerebilir

### Interface (Arayüz)
Bir sözleşme (contract) tanımlar. Sınıfların uygulaması gereken metotları belirtir.

**Özellikleri:**
- Sadece metot imzaları (C# 8.0 sonrası default implementation)
- Çoklu implement edilebilir
- Field içeremez
- Constructor içeremez
- Tüm üyeler public'tir

### Abstract Class vs Interface

| Abstract Class | Interface |
|----------------|-----------|
| Tek kalıtım | Çoklu implement |
| Constructor var | Constructor yok |
| Field olabilir | Field olamaz |
| Access modifier | Hepsi public |
| IS-A ilişkisi | CAN-DO ilişkisi |

## Örnekler

### Örnek 1: Abstract Class Temelleri
```csharp
using System;

namespace AbstractClassOrnegi
{
    // Abstract class
    abstract class Sekil
    {
        // Normal property
        public string Ad { get; set; }
        public string Renk { get; set; }
        
        // Abstract metotlar - gövde yok
        public abstract double AlanHesapla();
        public abstract double CevreHesapla();
        
        // Normal metot - gövde var
        public void BilgiYazdir()
        {
            Console.WriteLine($"Şekil: {Ad}");
            Console.WriteLine($"Renk: {Renk}");
            Console.WriteLine($"Alan: {AlanHesapla():F2}");
            Console.WriteLine($"Çevre: {CevreHesapla():F2}");
        }
        
        // Virtual metot
        public virtual void Ciz()
        {
            Console.WriteLine($"{Ad} çiziliyor...");
        }
    }
    
    class Daire : Sekil
    {
        public double YariCap { get; set; }
        
        public Daire(double yariCap, string renk)
        {
            Ad = "Daire";
            YariCap = yariCap;
            Renk = renk;
        }
        
        public override double AlanHesapla()
        {
            return Math.PI * YariCap * YariCap;
        }
        
        public override double CevreHesapla()
        {
            return 2 * Math.PI * YariCap;
        }
        
        public override void Ciz()
        {
            Console.WriteLine($"Yarıçapı {YariCap} olan {Renk} daire çiziliyor.");
        }
    }
    
    class Kare : Sekil
    {
        public double Kenar { get; set; }
        
        public Kare(double kenar, string renk)
        {
            Ad = "Kare";
            Kenar = kenar;
            Renk = renk;
        }
        
        public override double AlanHesapla()
        {
            return Kenar * Kenar;
        }
        
        public override double CevreHesapla()
        {
            return 4 * Kenar;
        }
    }
    
    class Program
    {
        static void Main()
        {
            // Sekil sekil = new Sekil(); // HATA: Abstract sınıftan nesne oluşturulamaz
            
            Sekil daire = new Daire(5, "Kırmızı");
            daire.BilgiYazdir();
            daire.Ciz();
            
            Console.WriteLine();
            
            Sekil kare = new Kare(4, "Mavi");
            kare.BilgiYazdir();
            kare.Ciz();
            
            Console.ReadLine();
        }
    }
}
```

### Örnek 2: Interface Temelleri
```csharp
using System;

namespace InterfaceOrnegi
{
    // Interface tanımlaması
    interface ICalisan
    {
        // Property'ler
        string Ad { get; set; }
        string Soyad { get; set; }
        
        // Metotlar (sadece imza)
        double MaasHesapla();
        void BilgiGoster();
    }
    
    interface IYonetici
    {
        void EkipYonet();
        void RaporHazirla();
    }
    
    // Interface implementation
    class TamZamanliCalisan : ICalisan
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public double AylikMaas { get; set; }
        
        public double MaasHesapla()
        {
            return AylikMaas;
        }
        
        public void BilgiGoster()
        {
            Console.WriteLine($"{Ad} {Soyad} - Tam Zamanlı");
            Console.WriteLine($"Maaş: {MaasHesapla():C}");
        }
    }
    
    // Çoklu interface implementation
    class Mudur : ICalisan, IYonetici
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public double AylikMaas { get; set; }
        public double Prim { get; set; }
        
        public double MaasHesapla()
        {
            return AylikMaas + Prim;
        }
        
        public void BilgiGoster()
        {
            Console.WriteLine($"{Ad} {Soyad} - Müdür");
            Console.WriteLine($"Maaş: {AylikMaas:C} + Prim: {Prim:C}");
            Console.WriteLine($"Toplam: {MaasHesapla():C}");
        }
        
        public void EkipYonet()
        {
            Console.WriteLine($"{Ad} ekibi yönetiyor.");
        }
        
        public void RaporHazirla()
        {
            Console.WriteLine($"{Ad} rapor hazırlıyor.");
        }
    }
    
    class Program
    {
        static void Main()
        {
            ICalisan calisan = new TamZamanliCalisan
            {
                Ad = "Ahmet",
                Soyad = "Yılmaz",
                AylikMaas = 10000
            };
            calisan.BilgiGoster();
            
            Console.WriteLine();
            
            Mudur mudur = new Mudur
            {
                Ad = "Ayşe",
                Soyad = "Demir",
                AylikMaas = 20000,
                Prim = 5000
            };
            mudur.BilgiGoster();
            mudur.EkipYonet();
            mudur.RaporHazirla();
            
            Console.ReadLine();
        }
    }
}
```

### Örnek 3: Abstract Class ile Template Pattern
```csharp
using System;

namespace TemplatePattern
{
    abstract class VeriIsleyici
    {
        // Template method - akışı tanımlar
        public void VeriIsle()
        {
            VeriOku();
            VeriDogrula();
            VeriDonustur();
            VeriKaydet();
            Raporla();
        }
        
        // Abstract metotlar - alt sınıfta uygulanmalı
        protected abstract void VeriOku();
        protected abstract void VeriDonustur();
        protected abstract void VeriKaydet();
        
        // Concrete metotlar - ortak işlemler
        protected void VeriDogrula()
        {
            Console.WriteLine("Veri doğrulanıyor...");
        }
        
        protected virtual void Raporla()
        {
            Console.WriteLine("İşlem tamamlandı.\n");
        }
    }
    
    class CSVIsleyici : VeriIsleyici
    {
        protected override void VeriOku()
        {
            Console.WriteLine("CSV dosyası okunuyor...");
        }
        
        protected override void VeriDonustur()
        {
            Console.WriteLine("CSV verisi dönüştürülüyor...");
        }
        
        protected override void VeriKaydet()
        {
            Console.WriteLine("Veri veritabanına kaydediliyor...");
        }
        
        protected override void Raporla()
        {
            Console.WriteLine("CSV işleme raporu hazırlandı.\n");
        }
    }
    
    class XMLIsleyici : VeriIsleyici
    {
        protected override void VeriOku()
        {
            Console.WriteLine("XML dosyası okunuyor...");
        }
        
        protected override void VeriDonustur()
        {
            Console.WriteLine("XML verisi dönüştürülüyor...");
        }
        
        protected override void VeriKaydet()
        {
            Console.WriteLine("Veri XML formatında kaydediliyor...");
        }
    }
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== CSV İşleme ===");
            VeriIsleyici csv = new CSVIsleyici();
            csv.VeriIsle();
            
            Console.WriteLine("=== XML İşleme ===");
            VeriIsleyici xml = new XMLIsleyici();
            xml.VeriIsle();
            
            Console.ReadLine();
        }
    }
}
```

### Örnek 4: Interface Segregation
```csharp
using System;

namespace InterfaceSegregation
{
    // Küçük, özelleşmiş interface'ler
    interface IYazdir
    {
        void Yazdir();
    }
    
    interface ITarat
    {
        void Tarat();
    }
    
    interface IFotokopi
    {
        void FotokopiCek();
    }
    
    interface IFaks
    {
        void FaksGonder();
    }
    
    // Basit yazıcı - sadece yazdırma
    class BasitYazici : IYazdir
    {
        public void Yazdir()
        {
            Console.WriteLine("Basit yazıcı yazdırıyor...");
        }
    }
    
    // Çok fonksiyonlu yazıcı
    class CokFonksiyonluYazici : IYazdir, ITarat, IFotokopi, IFaks
    {
        public void Yazdir()
        {
            Console.WriteLine("Çok fonksiyonlu yazıcı yazdırıyor...");
        }
        
        public void Tarat()
        {
            Console.WriteLine("Taranıyor...");
        }
        
        public void FotokopiCek()
        {
            Console.WriteLine("Fotokopi çekiliyor...");
        }
        
        public void FaksGonder()
        {
            Console.WriteLine("Faks gönderiliyor...");
        }
    }
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Basit Yazıcı ===");
            BasitYazici basit = new BasitYazici();
            basit.Yazdir();
            
            Console.WriteLine();
            Console.WriteLine("=== Çok Fonksiyonlu Yazıcı ===");
            CokFonksiyonluYazici coklu = new CokFonksiyonluYazici();
            coklu.Yazdir();
            coklu.Tarat();
            coklu.FotokopiCek();
            coklu.FaksGonder();
            
            Console.ReadLine();
        }
    }
}
```

### Örnek 5: Abstract Class ve Interface Birlikte
```csharp
using System;

namespace AbstractInterfaceBirlikte
{
    // Interface - Yetenek
    interface IUcabilir
    {
        void Uc();
    }
    
    interface IYuzebilir
    {
        void Yuz();
    }
    
    // Abstract class - Temel yapı
    abstract class Hayvan
    {
        public string Ad { get; set; }
        public int Yas { get; set; }
        
        public abstract void SesCikar();
        
        public void Yemek()
        {
            Console.WriteLine($"{Ad} yemek yiyor.");
        }
    }
    
    // Kuş - Uçabilir
    class Kus : Hayvan, IUcabilir
    {
        public override void SesCikar()
        {
            Console.WriteLine($"{Ad} cik cik ötüyor.");
        }
        
        public void Uc()
        {
            Console.WriteLine($"{Ad} uçuyor.");
        }
    }
    
    // Balık - Yüzebilir
    class Balik : Hayvan, IYuzebilir
    {
        public override void SesCikar()
        {
            Console.WriteLine($"{Ad} sessiz...");
        }
        
        public void Yuz()
        {
            Console.WriteLine($"{Ad} yüzüyor.");
        }
    }
    
    // Ördek - Hem uçabilir hem yüzebilir
    class Ordek : Hayvan, IUcabilir, IYuzebilir
    {
        public override void SesCikar()
        {
            Console.WriteLine($"{Ad} vak vak ötüyor.");
        }
        
        public void Uc()
        {
            Console.WriteLine($"{Ad} uçuyor.");
        }
        
        public void Yuz()
        {
            Console.WriteLine($"{Ad} yüzüyor.");
        }
    }
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Kuş ===");
            Kus kus = new Kus { Ad = "Serçe", Yas = 2 };
            kus.SesCikar();
            kus.Yemek();
            kus.Uc();
            
            Console.WriteLine();
            Console.WriteLine("=== Balık ===");
            Balik balik = new Balik { Ad = "Levrek", Yas = 3 };
            balik.SesCikar();
            balik.Yemek();
            balik.Yuz();
            
            Console.WriteLine();
            Console.WriteLine("=== Ördek ===");
            Ordek ordek = new Ordek { Ad = "Vak Vak", Yas = 1 };
            ordek.SesCikar();
            ordek.Yemek();
            ordek.Uc();
            ordek.Yuz();
            
            Console.ReadLine();
        }
    }
}
```

## Alıştırmalar

1. `OdemeYontemi` abstract class'ı ve alt sınıfları oluşturun
2. `IVeriKaynagi` interface'i ile farklı veri kaynaklarını uygulayın
3. `Arac` abstract class'ından `Araba`, `Ucak` sınıfları türetin
4. `IBildirim` interface'i ile `Email`, `SMS`, `Push` bildirimleri yapın
5. `IRepository` pattern uygulayın (CRUD işlemleri)

## Önemli Notlar

- Abstract class: Ortak kod + sözleşme
- Interface: Sadece sözleşme
- Abstract class'tan nesne oluşturulamaz
- Interface çoklu implement edilebilir
- Abstract metotlar gövdesizdir
- Interface isimleri 'I' ile başlar (convention)

## Ek Kaynaklar

- [Abstract Classes](https://docs.microsoft.com/tr-tr/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members)
- [Interfaces](https://docs.microsoft.com/tr-tr/dotnet/csharp/fundamentals/types/interfaces)

## Sonraki Hafta

Hafta 12'de exception handling (hata yönetimi) konusunu işleyeceğiz.
