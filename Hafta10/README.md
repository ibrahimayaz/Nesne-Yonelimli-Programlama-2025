# Hafta 10: Çok Biçimlilik (Polymorphism)

## Teorik Bilgiler

### Polymorphism Nedir?
Çok biçimlilik, aynı arayüzün farklı şekillerde uygulanabilmesidir. "Aynı isim, farklı davranış" prensibidir.

**Türleri:**
- **Compile-time (Static) Polymorphism:** Method overloading
- **Runtime (Dynamic) Polymorphism:** Method overriding

### virtual, override, abstract
- **virtual:** Override edilebilir metot tanımlar
- **override:** Virtual metodu yeniden tanımlar
- **abstract:** Alt sınıfta mutlaka tanımlanmalı

### Polymorphic Behavior
Base class referansı ile alt sınıf nesnelerine erişim.

## Örnekler

### Örnek 1: Runtime Polymorphism
```csharp
using System;

namespace PolymorphismOrnegi
{
    class Sekil
    {
        public string Ad { get; set; }
        
        public virtual double AlanHesapla()
        {
            return 0;
        }
        
        public virtual double CevreHesapla()
        {
            return 0;
        }
        
        public virtual void Ciz()
        {
            Console.WriteLine($"{Ad} çiziliyor...");
        }
    }
    
    class Daire : Sekil
    {
        public double YariCap { get; set; }
        
        public Daire(double yariCap)
        {
            Ad = "Daire";
            YariCap = yariCap;
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
            Console.WriteLine($"Yarıçapı {YariCap} olan daire çiziliyor.");
        }
    }
    
    class Dikdortgen : Sekil
    {
        public double Uzunluk { get; set; }
        public double Genislik { get; set; }
        
        public Dikdortgen(double uzunluk, double genislik)
        {
            Ad = "Dikdörtgen";
            Uzunluk = uzunluk;
            Genislik = genislik;
        }
        
        public override double AlanHesapla()
        {
            return Uzunluk * Genislik;
        }
        
        public override double CevreHesapla()
        {
            return 2 * (Uzunluk + Genislik);
        }
        
        public override void Ciz()
        {
            Console.WriteLine($"{Uzunluk}x{Genislik} dikdörtgen çiziliyor.");
        }
    }
    
    class Ucgen : Sekil
    {
        public double Taban { get; set; }
        public double Yukseklik { get; set; }
        
        public Ucgen(double taban, double yukseklik)
        {
            Ad = "Üçgen";
            Taban = taban;
            Yukseklik = yukseklik;
        }
        
        public override double AlanHesapla()
        {
            return (Taban * Yukseklik) / 2;
        }
        
        public override void Ciz()
        {
            Console.WriteLine($"Tabanı {Taban}, yüksekliği {Yukseklik} olan üçgen çiziliyor.");
        }
    }
    
    class Program
    {
        static void Main()
        {
            // Polymorphic array - Base class referansı
            Sekil[] sekiller = new Sekil[3];
            sekiller[0] = new Daire(5);
            sekiller[1] = new Dikdortgen(10, 5);
            sekiller[2] = new Ucgen(8, 6);
            
            // Polymorphic davranış
            foreach (Sekil sekil in sekiller)
            {
                Console.WriteLine($"\n=== {sekil.Ad} ===");
                sekil.Ciz();
                Console.WriteLine($"Alan: {sekil.AlanHesapla():F2}");
                Console.WriteLine($"Çevre: {sekil.CevreHesapla():F2}");
            }
            
            Console.ReadLine();
        }
    }
}
```

### Örnek 2: is ve as Operatörleri
```csharp
using System;

namespace TypeChecking
{
    class Hayvan
    {
        public string Ad { get; set; }
        public virtual void SesCikar()
        {
            Console.WriteLine("Hayvan ses çıkarıyor");
        }
    }
    
    class Kopek : Hayvan
    {
        public override void SesCikar()
        {
            Console.WriteLine("Hav hav!");
        }
        
        public void KuyrukSalla()
        {
            Console.WriteLine("Kuyruk sallıyor");
        }
    }
    
    class Kedi : Hayvan
    {
        public override void SesCikar()
        {
            Console.WriteLine("Miyav!");
        }
        
        public void Tirman()
        {
            Console.WriteLine("Tırmanıyor");
        }
    }
    
    class Program
    {
        static void HayvanIsle(Hayvan hayvan)
        {
            hayvan.SesCikar();
            
            // is operatörü - tip kontrolü
            if (hayvan is Kopek)
            {
                Console.WriteLine("Bu bir köpek!");
                Kopek kopek = (Kopek)hayvan;
                kopek.KuyrukSalla();
            }
            else if (hayvan is Kedi)
            {
                Console.WriteLine("Bu bir kedi!");
                Kedi kedi = hayvan as Kedi; // as operatörü
                kedi?.Tirman();
            }
        }
        
        static void Main()
        {
            Hayvan[] hayvanlar = new Hayvan[]
            {
                new Kopek { Ad = "Karabaş" },
                new Kedi { Ad = "Pamuk" },
                new Kopek { Ad = "Boncuk" }
            };
            
            foreach (Hayvan hayvan in hayvanlar)
            {
                Console.WriteLine($"\n{hayvan.Ad}:");
                HayvanIsle(hayvan);
            }
            
            Console.ReadLine();
        }
    }
}
```

### Örnek 3: Abstract Class ile Polymorphism
```csharp
using System;

namespace AbstractPolymorphism
{
    abstract class Veritabani
    {
        public string BaglantiString { get; set; }
        
        // Abstract metotlar - alt sınıfta mutlaka tanımlanmalı
        public abstract void Baglan();
        public abstract void Kapat();
        public abstract void SorguCalistir(string sorgu);
        
        // Virtual metot - opsiyonel override
        public virtual void BaglantiTest()
        {
            Console.WriteLine("Bağlantı test ediliyor...");
        }
    }
    
    class MySQLVeritabani : Veritabani
    {
        public override void Baglan()
        {
            Console.WriteLine($"MySQL'e bağlanılıyor: {BaglantiString}");
        }
        
        public override void Kapat()
        {
            Console.WriteLine("MySQL bağlantısı kapatıldı.");
        }
        
        public override void SorguCalistir(string sorgu)
        {
            Console.WriteLine($"MySQL sorgusu: {sorgu}");
        }
    }
    
    class SQLServerVeritabani : Veritabani
    {
        public override void Baglan()
        {
            Console.WriteLine($"SQL Server'a bağlanılıyor: {BaglantiString}");
        }
        
        public override void Kapat()
        {
            Console.WriteLine("SQL Server bağlantısı kapatıldı.");
        }
        
        public override void SorguCalistir(string sorgu)
        {
            Console.WriteLine($"SQL Server sorgusu: {sorgu}");
        }
        
        public override void BaglantiTest()
        {
            Console.WriteLine("SQL Server özel test yapılıyor...");
            base.BaglantiTest();
        }
    }
    
    class Program
    {
        static void VeritabaniIslemleri(Veritabani db)
        {
            db.Baglan();
            db.BaglantiTest();
            db.SorguCalistir("SELECT * FROM users");
            db.Kapat();
        }
        
        static void Main()
        {
            Console.WriteLine("=== MySQL ===");
            Veritabani mysql = new MySQLVeritabani();
            mysql.BaglantiString = "server=localhost;database=testdb";
            VeritabaniIslemleri(mysql);
            
            Console.WriteLine("\n=== SQL Server ===");
            Veritabani sqlserver = new SQLServerVeritabani();
            sqlserver.BaglantiString = "server=.;database=testdb";
            VeritabaniIslemleri(sqlserver);
            
            Console.ReadLine();
        }
    }
}
```

### Örnek 4: Ödeme Sistemi - Pratik Örnek
```csharp
using System;

namespace OdemeSistemi
{
    abstract class OdemeYontemi
    {
        public string Ad { get; set; }
        public abstract bool OdemeYap(double tutar);
        public abstract void IslemDetayiGoster();
    }
    
    class KrediKarti : OdemeYontemi
    {
        public string KartNo { get; set; }
        public string SonKullanma { get; set; }
        
        public KrediKarti(string kartNo, string sonKullanma)
        {
            Ad = "Kredi Kartı";
            KartNo = kartNo;
            SonKullanma = sonKullanma;
        }
        
        public override bool OdemeYap(double tutar)
        {
            Console.WriteLine($"{tutar:C} kredi kartından çekildi.");
            Console.WriteLine($"Kart: {MaskedKartNo()}");
            return true;
        }
        
        public override void IslemDetayiGoster()
        {
            Console.WriteLine("Kredi Kartı ile ödeme");
            Console.WriteLine($"Kart: {MaskedKartNo()}");
        }
        
        private string MaskedKartNo()
        {
            return "**** **** **** " + KartNo.Substring(KartNo.Length - 4);
        }
    }
    
    class BankaHavalesi : OdemeYontemi
    {
        public string IbanNo { get; set; }
        
        public BankaHavalesi(string iban)
        {
            Ad = "Banka Havalesi";
            IbanNo = iban;
        }
        
        public override bool OdemeYap(double tutar)
        {
            Console.WriteLine($"{tutar:C} banka havalesi ile gönderildi.");
            Console.WriteLine($"IBAN: {IbanNo}");
            return true;
        }
        
        public override void IslemDetayiGoster()
        {
            Console.WriteLine("Banka Havalesi");
            Console.WriteLine($"IBAN: {IbanNo}");
        }
    }
    
    class Nakit : OdemeYontemi
    {
        public Nakit()
        {
            Ad = "Nakit";
        }
        
        public override bool OdemeYap(double tutar)
        {
            Console.WriteLine($"{tutar:C} nakit ödeme alındı.");
            return true;
        }
        
        public override void IslemDetayiGoster()
        {
            Console.WriteLine("Nakit ödeme");
        }
    }
    
    class SiparisYoneticisi
    {
        public void SiparisOnayla(double tutar, OdemeYontemi odemeYontemi)
        {
            Console.WriteLine($"\n=== Sipariş Özeti ===");
            Console.WriteLine($"Tutar: {tutar:C}");
            odemeYontemi.IslemDetayiGoster();
            
            Console.WriteLine("\nÖdeme işlemi başlatılıyor...");
            bool basarili = odemeYontemi.OdemeYap(tutar);
            
            if (basarili)
                Console.WriteLine("✓ Sipariş onaylandı!");
            else
                Console.WriteLine("✗ Ödeme başarısız!");
        }
    }
    
    class Program
    {
        static void Main()
        {
            SiparisYoneticisi yonetici = new SiparisYoneticisi();
            
            // Kredi kartı ile ödeme
            KrediKarti kk = new KrediKarti("1234567890123456", "12/25");
            yonetici.SiparisOnayla(150.50, kk);
            
            // Banka havalesi
            BankaHavalesi havale = new BankaHavalesi("TR123456789012345678901234");
            yonetici.SiparisOnayla(250.00, havale);
            
            // Nakit
            Nakit nakit = new Nakit();
            yonetici.SiparisOnayla(75.25, nakit);
            
            Console.ReadLine();
        }
    }
}
```

### Örnek 5: Interface ile Polymorphism
```csharp
using System;

namespace InterfacePolymorphism
{
    interface ICalisan
    {
        string Ad { get; set; }
        double MaasHesapla();
        void BilgiGoster();
    }
    
    class TamZamanliCalisan : ICalisan
    {
        public string Ad { get; set; }
        public double AylikMaas { get; set; }
        
        public double MaasHesapla()
        {
            return AylikMaas;
        }
        
        public void BilgiGoster()
        {
            Console.WriteLine($"{Ad} - Tam Zamanlı");
            Console.WriteLine($"Aylık Maaş: {MaasHesapla():C}");
        }
    }
    
    class YariZamanliCalisan : ICalisan
    {
        public string Ad { get; set; }
        public double SaatlikUcret { get; set; }
        public int CalisilanSaat { get; set; }
        
        public double MaasHesapla()
        {
            return SaatlikUcret * CalisilanSaat;
        }
        
        public void BilgiGoster()
        {
            Console.WriteLine($"{Ad} - Yarı Zamanlı");
            Console.WriteLine($"Saatlik: {SaatlikUcret:C}, Saat: {CalisilanSaat}");
            Console.WriteLine($"Toplam: {MaasHesapla():C}");
        }
    }
    
    class SerbetCalisan : ICalisan
    {
        public string Ad { get; set; }
        public double ProjeFiyati { get; set; }
        public int TamamlananProjeSayisi { get; set; }
        
        public double MaasHesapla()
        {
            return ProjeFiyati * TamamlananProjeSayisi;
        }
        
        public void BilgiGoster()
        {
            Console.WriteLine($"{Ad} - Serbest Çalışan");
            Console.WriteLine($"Proje: {ProjeFiyati:C}, Sayı: {TamamlananProjeSayisi}");
            Console.WriteLine($"Toplam: {MaasHesapla():C}");
        }
    }
    
    class Program
    {
        static void MaasOde(ICalisan calisan)
        {
            calisan.BilgiGoster();
            Console.WriteLine($"Ödenecek: {calisan.MaasHesapla():C}\n");
        }
        
        static void Main()
        {
            ICalisan[] calisanlar = new ICalisan[]
            {
                new TamZamanliCalisan { Ad = "Ahmet", AylikMaas = 15000 },
                new YariZamanliCalisan { Ad = "Mehmet", SaatlikUcret = 75, CalisilanSaat = 120 },
                new SerbetCalisan { Ad = "Ayşe", ProjeFiyati = 5000, TamamlananProjeSayisi = 3 }
            };
            
            double toplamMaas = 0;
            
            foreach (ICalisan calisan in calisanlar)
            {
                MaasOde(calisan);
                toplamMaas += calisan.MaasHesapla();
            }
            
            Console.WriteLine($"Toplam maaş ödemesi: {toplamMaas:C}");
            
            Console.ReadLine();
        }
    }
}
```

## Alıştırmalar

1. `Arac` sınıfı ile polymorphic bir yakıt hesaplama sistemi yapın
2. Farklı ödeme yöntemleri için interface kullanın
3. `Dosya` base class'ı ile `PDF`, `Word`, `Excel` alt sınıfları oluşturun
4. `Bildirim` sistemi: `Email`, `SMS`, `Push` notification
5. `YaziciSurucu` abstract class ile farklı yazıcı tipleri

## Önemli Notlar

- Polymorphism = "Çok biçimlilik"
- Base class referansı ile alt sınıf nesneleri
- virtual/override ile runtime polymorphism
- is/as operatörleri ile tip kontrolü
- Interface'ler tam polymorphic davranış sağlar

## Ek Kaynaklar

- [C# Polymorphism](https://docs.microsoft.com/tr-tr/dotnet/csharp/fundamentals/object-oriented/polymorphism)

## Sonraki Hafta

Hafta 11'de abstract class ve interface konusunu derinlemesine işleyeceğiz.
