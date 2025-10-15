# Hafta 12: Hata Yönetimi (Exception Handling)

## Teorik Bilgiler

### Exception (İstisna) Nedir?
Program çalışırken oluşan beklenmedik durumlardır. Sıfıra bölme, dosya bulunamama, bellek yetersizliği gibi.

### Exception Handling
Hataları yakalayıp uygun şekilde işleme mekanizması.

**Yapısı:**
```csharp
try
{
    // Hata oluşabilecek kod
}
catch (ExceptionType ex)
{
    // Hata yakalandığında çalışacak kod
}
finally
{
    // Her durumda çalışacak kod
}
```

### Yaygın Exception Türleri
- **NullReferenceException:** Null nesneye erişim
- **DivideByZeroException:** Sıfıra bölme
- **IndexOutOfRangeException:** Dizi sınır aşımı
- **FileNotFoundException:** Dosya bulunamadı
- **InvalidOperationException:** Geçersiz işlem

### throw Anahtar Kelimesi
Manuel olarak exception fırlatmak için kullanılır.

## Örnekler

### Örnek 1: Temel Exception Handling
```csharp
using System;

namespace ExceptionOrnegi
{
    class Program
    {
        static void Main()
        {
            // Örnek 1: Sıfıra bölme
            Console.WriteLine("=== Sıfıra Bölme ===");
            try
            {
                int sayi1 = 10;
                int sayi2 = 0;
                int sonuc = sayi1 / sayi2; // Exception oluşur
                Console.WriteLine($"Sonuç: {sonuc}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("HATA: Sıfıra bölme yapılamaz!");
                Console.WriteLine($"Detay: {ex.Message}");
            }
            
            Console.WriteLine();
            
            // Örnek 2: Dizi sınır aşımı
            Console.WriteLine("=== Dizi Sınır Aşımı ===");
            try
            {
                int[] sayilar = { 1, 2, 3, 4, 5 };
                Console.WriteLine(sayilar[10]); // Exception
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("HATA: Dizi sınırları dışında erişim!");
                Console.WriteLine($"Detay: {ex.Message}");
            }
            
            Console.WriteLine();
            
            // Örnek 3: Format hatası
            Console.WriteLine("=== Format Hatası ===");
            try
            {
                string metin = "abc";
                int sayi = int.Parse(metin); // Exception
            }
            catch (FormatException ex)
            {
                Console.WriteLine("HATA: Geçersiz format!");
                Console.WriteLine($"Detay: {ex.Message}");
            }
            
            Console.WriteLine();
            
            // Örnek 4: Null referans
            Console.WriteLine("=== Null Referans ===");
            try
            {
                string metin = null;
                int uzunluk = metin.Length; // Exception
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("HATA: Null nesneye erişim!");
                Console.WriteLine($"Detay: {ex.Message}");
            }
            
            Console.ReadLine();
        }
    }
}
```

### Örnek 2: Çoklu catch Blokları
```csharp
using System;

namespace CokluCatch
{
    class Program
    {
        static void GuvenliIslem(string sayi1Str, string sayi2Str)
        {
            try
            {
                int sayi1 = int.Parse(sayi1Str);
                int sayi2 = int.Parse(sayi2Str);
                
                int toplam = sayi1 + sayi2;
                int bolum = sayi1 / sayi2;
                
                Console.WriteLine($"Toplam: {toplam}");
                Console.WriteLine($"Bölüm: {bolum}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("HATA: Geçersiz sayı formatı!");
                Console.WriteLine($"Detay: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("HATA: Sıfıra bölme!");
                Console.WriteLine($"Detay: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("HATA: Sayı çok büyük!");
                Console.WriteLine($"Detay: {ex.Message}");
            }
            catch (Exception ex) // Genel exception (en sonda olmalı)
            {
                Console.WriteLine("HATA: Beklenmeyen bir hata oluştu!");
                Console.WriteLine($"Detay: {ex.Message}");
            }
        }
        
        static void Main()
        {
            Console.WriteLine("Test 1:");
            GuvenliIslem("10", "2");
            
            Console.WriteLine("\nTest 2:");
            GuvenliIslem("abc", "5");
            
            Console.WriteLine("\nTest 3:");
            GuvenliIslem("10", "0");
            
            Console.ReadLine();
        }
    }
}
```

### Örnek 3: finally Bloğu
```csharp
using System;
using System.IO;

namespace FinallyOrnegi
{
    class Program
    {
        static void DosyaOku(string dosyaYolu)
        {
            StreamReader reader = null;
            
            try
            {
                reader = new StreamReader(dosyaYolu);
                string icerik = reader.ReadToEnd();
                Console.WriteLine("Dosya içeriği:");
                Console.WriteLine(icerik);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"HATA: Dosya bulunamadı - {dosyaYolu}");
                Console.WriteLine($"Detay: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine("HATA: Dosya okuma hatası!");
                Console.WriteLine($"Detay: {ex.Message}");
            }
            finally
            {
                // Hata olsa da olmasa da çalışır
                Console.WriteLine("finally bloğu çalıştı");
                
                if (reader != null)
                {
                    reader.Close();
                    Console.WriteLine("Dosya kapatıldı");
                }
            }
        }
        
        static void Main()
        {
            Console.WriteLine("=== Mevcut dosya ===");
            DosyaOku("test.txt");
            
            Console.WriteLine("\n=== Olmayan dosya ===");
            DosyaOku("olmayan.txt");
            
            Console.ReadLine();
        }
    }
}
```

### Örnek 4: Custom Exception (Özel İstisna)
```csharp
using System;

namespace CustomException
{
    // Özel exception sınıfı
    class YetersizBakiyeException : Exception
    {
        public double MevcutBakiye { get; set; }
        public double IstenMiktar { get; set; }
        
        public YetersizBakiyeException(double mevcutBakiye, double istenMiktar)
            : base($"Yetersiz bakiye! Mevcut: {mevcutBakiye:C}, İstenen: {istenMiktar:C}")
        {
            MevcutBakiye = mevcutBakiye;
            IstenMiktar = istenMiktar;
        }
    }
    
    class GecersizMiktarException : Exception
    {
        public GecersizMiktarException(string mesaj) : base(mesaj) { }
    }
    
    class BankaHesap
    {
        public string HesapNo { get; private set; }
        public double Bakiye { get; private set; }
        
        public BankaHesap(string hesapNo, double ilkBakiye)
        {
            HesapNo = hesapNo;
            Bakiye = ilkBakiye;
        }
        
        public void ParaYatir(double miktar)
        {
            if (miktar <= 0)
            {
                throw new GecersizMiktarException("Para yatırma miktarı pozitif olmalıdır!");
            }
            
            Bakiye += miktar;
            Console.WriteLine($"{miktar:C} yatırıldı. Yeni bakiye: {Bakiye:C}");
        }
        
        public void ParaCek(double miktar)
        {
            if (miktar <= 0)
            {
                throw new GecersizMiktarException("Para çekme miktarı pozitif olmalıdır!");
            }
            
            if (miktar > Bakiye)
            {
                throw new YetersizBakiyeException(Bakiye, miktar);
            }
            
            Bakiye -= miktar;
            Console.WriteLine($"{miktar:C} çekildi. Kalan bakiye: {Bakiye:C}");
        }
    }
    
    class Program
    {
        static void Main()
        {
            BankaHesap hesap = new BankaHesap("TR123456", 1000);
            
            try
            {
                Console.WriteLine($"Başlangıç bakiyesi: {hesap.Bakiye:C}\n");
                
                hesap.ParaYatir(500);
                hesap.ParaCek(300);
                
                Console.WriteLine();
                hesap.ParaCek(-100); // Geçersiz miktar
            }
            catch (GecersizMiktarException ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
            }
            catch (YetersizBakiyeException ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                Console.WriteLine($"Eksik miktar: {ex.IstenMiktar - ex.MevcutBakiye:C}");
            }
            
            Console.WriteLine();
            
            try
            {
                hesap.ParaCek(2000); // Yetersiz bakiye
            }
            catch (YetersizBakiyeException ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
            }
            
            Console.ReadLine();
        }
    }
}
```

### Örnek 5: Exception'ı Yeniden Fırlatma ve Logging
```csharp
using System;

namespace ExceptionLogging
{
    class Logger
    {
        public static void Log(string mesaj)
        {
            string zaman = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[{zaman}] LOG: {mesaj}");
        }
        
        public static void LogError(Exception ex)
        {
            string zaman = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"[{zaman}] ERROR: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }
    }
    
    class VeriIsleyici
    {
        public void VeriOku(string dosyaAdi)
        {
            try
            {
                Logger.Log($"Dosya okunuyor: {dosyaAdi}");
                
                if (string.IsNullOrEmpty(dosyaAdi))
                {
                    throw new ArgumentNullException(nameof(dosyaAdi), "Dosya adı boş olamaz!");
                }
                
                // Dosya okuma simülasyonu
                if (dosyaAdi == "hata.txt")
                {
                    throw new Exception("Dosya bozuk!");
                }
                
                Logger.Log("Dosya başarıyla okundu");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw; // Exception'ı yeniden fırlat
            }
        }
        
        public void GuvenliVeriOku(string dosyaAdi)
        {
            try
            {
                VeriOku(dosyaAdi);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Parametre hatası: {ex.ParamName}");
                Console.WriteLine($"Mesaj: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Genel hata: {ex.Message}");
            }
        }
    }
    
    class Program
    {
        static void Main()
        {
            VeriIsleyici isleyici = new VeriIsleyici();
            
            Console.WriteLine("=== Test 1: Normal okuma ===");
            isleyici.GuvenliVeriOku("dosya.txt");
            
            Console.WriteLine("\n=== Test 2: Null dosya adı ===");
            isleyici.GuvenliVeriOku(null);
            
            Console.WriteLine("\n=== Test 3: Hatalı dosya ===");
            isleyici.GuvenliVeriOku("hata.txt");
            
            Console.ReadLine();
        }
    }
}
```

## Alıştırmalar

1. Kullanıcıdan sayı alan ve güvenli bölen hesaplama programı yazın
2. Dosya okuma/yazma işlemlerinde exception handling kullanın
3. Yaş doğrulama için custom exception oluşturun
4. Try-catch-finally ile kaynak yönetimi yapın
5. Exception logging sistemi oluşturun

## Önemli Notlar

- Her zaman spesifik exception'ları yakalayın
- Genel Exception en sonda olmalı
- finally bloğu her durumda çalışır
- throw ile exception fırlatılır
- Custom exception'lar Exception'dan türer
- Exception'ları log'layın
- Gereksiz yere exception kullanmayın

## Ek Kaynaklar

- [Exception Handling](https://docs.microsoft.com/tr-tr/dotnet/csharp/fundamentals/exceptions/)
- [Custom Exceptions](https://docs.microsoft.com/tr-tr/dotnet/standard/exceptions/how-to-create-user-defined-exceptions)

## Sonraki Hafta

Hafta 13'te koleksiyonlar ve LINQ temelleri konusunu işleyeceğiz.
