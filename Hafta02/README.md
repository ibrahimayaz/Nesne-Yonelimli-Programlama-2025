# Hafta 2: Değişkenler, Veri Tipleri ve Operatörler

## Teorik Bilgiler

### Değişken Nedir?
Değişken, bellekte değer saklamak için kullanılan isimlendirilmiş bir alandır. Her değişkenin bir veri tipi, bir adı ve bir değeri vardır.

### Değişken Tanımlama Kuralları
- Harf, rakam ve alt çizgi (_) içerebilir
- Rakamla başlayamaz
- C# anahtar kelimeleri kullanılamaz (int, class, vb.)
- Büyük/küçük harf duyarlıdır (age ≠ Age)
- Anlamlı isimler kullanılmalıdır (camelCase önerilir)

### Temel Veri Tipleri

#### Sayısal Tipler
- **int** - Tam sayılar (-2,147,483,648 ile 2,147,483,647)
- **long** - Büyük tam sayılar
- **float** - Ondalıklı sayılar (7 basamak hassasiyet)
- **double** - Ondalıklı sayılar (15-16 basamak hassasiyet)
- **decimal** - Finansal hesaplamalar için (28-29 basamak hassasiyet)

#### Diğer Tipler
- **string** - Metin verileri
- **char** - Tek karakter
- **bool** - True/False değerleri
- **DateTime** - Tarih ve zaman

### Operatörler
- **Aritmetik:** +, -, *, /, % (mod)
- **Karşılaştırma:** ==, !=, >, <, >=, <=
- **Mantıksal:** && (ve), || (veya), ! (değil)
- **Atama:** =, +=, -=, *=, /=
- **Artırma/Azaltma:** ++, --

## Örnekler

### Örnek 1: Temel Değişken Tanımlama ve Kullanımı
```csharp
using System;

namespace DegiskenOrnegi
{
    class Program
    {
        static void Main()
        {
            // Değişken tanımlama ve değer atama
            int yas = 25;
            string isim = "Mehmet";
            double boy = 1.75;
            bool ogrenciMi = true;
            
            // Değişkenleri ekrana yazdırma
            Console.WriteLine($"İsim: {isim}");
            Console.WriteLine($"Yaş: {yas}");
            Console.WriteLine($"Boy: {boy} metre");
            Console.WriteLine($"Öğrenci mi: {ogrenciMi}");
            
            // Değişken değerini değiştirme
            yas = 26;
            Console.WriteLine($"Yeni yaş: {yas}");
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Farklı veri tiplerinde değişkenler tanımlandı
- String interpolation ile değerler yazdırıldı
- Değişken değeri sonradan değiştirilebildi

### Örnek 2: Veri Tipi Dönüşümleri
```csharp
using System;

namespace TipDonusumleri
{
    class Program
    {
        static void Main()
        {
            // Otomatik dönüşüm (implicit)
            int tamSayi = 100;
            double ondalikSayi = tamSayi; // int'den double'a otomatik
            Console.WriteLine($"Otomatik dönüşüm: {ondalikSayi}");
            
            // Açık dönüşüm (explicit - casting)
            double pi = 3.14159;
            int piTamSayi = (int)pi; // Ondalık kısım atılır
            Console.WriteLine($"Pi'nin tam sayı hali: {piTamSayi}");
            
            // String'den sayıya dönüşüm
            string sayiMetin = "42";
            int sayi = int.Parse(sayiMetin);
            Console.WriteLine($"String'den int'e: {sayi}");
            
            // Güvenli dönüşüm
            string gecersizSayi = "abc";
            int sonuc;
            bool basariliMi = int.TryParse(gecersizSayi, out sonuc);
            
            if (basariliMi)
                Console.WriteLine($"Dönüşüm başarılı: {sonuc}");
            else
                Console.WriteLine("Dönüşüm başarısız!");
            
            // Sayıdan string'e dönüşüm
            int numara = 123;
            string numaraMetin = numara.ToString();
            Console.WriteLine($"Sayı string olarak: {numaraMetin}");
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Implicit (otomatik) ve explicit (açık) dönüşümler gösterildi
- `Parse()` ve `TryParse()` metodları kullanıldı
- `ToString()` ile sayıdan string'e dönüşüm yapıldı

### Örnek 3: Aritmetik Operatörler
```csharp
using System;

namespace AritmetikIslemler
{
    class Program
    {
        static void Main()
        {
            int sayi1 = 20;
            int sayi2 = 7;
            
            // Temel aritmetik işlemler
            Console.WriteLine($"Toplama: {sayi1} + {sayi2} = {sayi1 + sayi2}");
            Console.WriteLine($"Çıkarma: {sayi1} - {sayi2} = {sayi1 - sayi2}");
            Console.WriteLine($"Çarpma: {sayi1} * {sayi2} = {sayi1 * sayi2}");
            Console.WriteLine($"Bölme: {sayi1} / {sayi2} = {sayi1 / sayi2}"); // Tam sayı bölme
            Console.WriteLine($"Mod (Kalan): {sayi1} % {sayi2} = {sayi1 % sayi2}");
            
            // Ondalıklı bölme
            double ondalikBolme = (double)sayi1 / sayi2;
            Console.WriteLine($"Ondalıklı bölme: {ondalikBolme:F2}");
            
            // Artırma ve azaltma
            int sayac = 10;
            Console.WriteLine($"\nBaşlangıç değeri: {sayac}");
            
            sayac++; // Post-increment
            Console.WriteLine($"sayac++ sonrası: {sayac}");
            
            ++sayac; // Pre-increment
            Console.WriteLine($"++sayac sonrası: {sayac}");
            
            sayac--; // Decrement
            Console.WriteLine($"sayac-- sonrası: {sayac}");
            
            // Kısa atama operatörleri
            int toplam = 100;
            toplam += 50;  // toplam = toplam + 50
            Console.WriteLine($"\ntoplam += 50: {toplam}");
            
            toplam -= 20;  // toplam = toplam - 20
            Console.WriteLine($"toplam -= 20: {toplam}");
            
            toplam *= 2;   // toplam = toplam * 2
            Console.WriteLine($"toplam *= 2: {toplam}");
            
            toplam /= 4;   // toplam = toplam / 4
            Console.WriteLine($"toplam /= 4: {toplam}");
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Temel aritmetik operatörler (+, -, *, /, %) gösterildi
- Artırma (++) ve azaltma (--) operatörleri kullanıldı
- Kısa atama operatörleri (+=, -=, *=, /=) örneklendi

### Örnek 4: Karşılaştırma ve Mantıksal Operatörler
```csharp
using System;

namespace KarsilastirmaOperatorleri
{
    class Program
    {
        static void Main()
        {
            int a = 10;
            int b = 20;
            int c = 10;
            
            // Karşılaştırma operatörleri
            Console.WriteLine("=== Karşılaştırma Operatörleri ===");
            Console.WriteLine($"a = {a}, b = {b}, c = {c}");
            Console.WriteLine($"a == b: {a == b}"); // Eşit mi?
            Console.WriteLine($"a != b: {a != b}"); // Eşit değil mi?
            Console.WriteLine($"a < b: {a < b}");   // Küçük mü?
            Console.WriteLine($"a > b: {a > b}");   // Büyük mü?
            Console.WriteLine($"a <= c: {a <= c}"); // Küçük veya eşit mi?
            Console.WriteLine($"a >= c: {a >= c}"); // Büyük veya eşit mi?
            
            // Mantıksal operatörler
            Console.WriteLine("\n=== Mantıksal Operatörler ===");
            bool dogru = true;
            bool yanlis = false;
            
            Console.WriteLine($"dogru && yanlis: {dogru && yanlis}"); // VE (AND)
            Console.WriteLine($"dogru || yanlis: {dogru || yanlis}"); // VEYA (OR)
            Console.WriteLine($"!dogru: {!dogru}");                   // DEĞİL (NOT)
            
            // Gerçek dünya örneği
            int yas = 18;
            bool ehliyetiVar = true;
            
            bool arabaSurebilir = (yas >= 18) && ehliyetiVar;
            Console.WriteLine($"\nYaş: {yas}, Ehliyeti var mı: {ehliyetiVar}");
            Console.WriteLine($"Araba sürebilir mi: {arabaSurebilir}");
            
            // Çoklu koşul
            int not1 = 70;
            int not2 = 65;
            int ortalama = (not1 + not2) / 2;
            
            bool gectiMi = (ortalama >= 60) && (not1 >= 50) && (not2 >= 50);
            Console.WriteLine($"\nNot1: {not1}, Not2: {not2}, Ortalama: {ortalama}");
            Console.WriteLine($"Dersten geçti mi: {gectiMi}");
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Karşılaştırma operatörleri (==, !=, <, >, <=, >=) kullanıldı
- Mantıksal operatörler (&&, ||, !) örneklendi
- Gerçek dünya senaryolarında operatörlerin kullanımı gösterildi

### Örnek 5: Farklı Veri Tipleri ve Özellikleri
```csharp
using System;

namespace VeriTipleri
{
    class Program
    {
        static void Main()
        {
            // Integer (Tam sayı) tipleri
            byte kucukSayi = 255;        // 0-255 arası
            short ortaSayi = 32000;      // -32,768 ile 32,767 arası
            int normalSayi = 1000000;    // Standart tam sayı
            long buyukSayi = 9999999999L; // Büyük tam sayılar için
            
            Console.WriteLine("=== Tam Sayı Tipleri ===");
            Console.WriteLine($"byte: {kucukSayi}");
            Console.WriteLine($"short: {ortaSayi}");
            Console.WriteLine($"int: {normalSayi}");
            Console.WriteLine($"long: {buyukSayi}");
            
            // Ondalıklı sayı tipleri
            float ondalik1 = 3.14f;           // 7 basamak hassasiyet
            double ondalik2 = 3.141592653589;  // 15-16 basamak hassasiyet
            decimal finansal = 19.99m;         // Finansal hesaplamalar için
            
            Console.WriteLine("\n=== Ondalıklı Sayı Tipleri ===");
            Console.WriteLine($"float: {ondalik1}");
            Console.WriteLine($"double: {ondalik2}");
            Console.WriteLine($"decimal: {finansal}");
            
            // Karakter ve String
            char karakter = 'A';
            char unicode = '\u0041'; // A karakterinin unicode değeri
            string metin = "Merhaba C#";
            
            Console.WriteLine("\n=== Karakter ve String ===");
            Console.WriteLine($"char: {karakter}");
            Console.WriteLine($"unicode char: {unicode}");
            Console.WriteLine($"string: {metin}");
            Console.WriteLine($"String uzunluğu: {metin.Length}");
            
            // Boolean
            bool aktif = true;
            bool pasif = false;
            
            Console.WriteLine("\n=== Boolean ===");
            Console.WriteLine($"Aktif: {aktif}");
            Console.WriteLine($"Pasif: {pasif}");
            
            // DateTime
            DateTime simdi = DateTime.Now;
            DateTime bugun = DateTime.Today;
            
            Console.WriteLine("\n=== Tarih ve Zaman ===");
            Console.WriteLine($"Şu an: {simdi}");
            Console.WriteLine($"Bugün: {bugun:dd.MM.yyyy}");
            Console.WriteLine($"Saat: {simdi:HH:mm:ss}");
            
            // var kullanımı (tip çıkarımı)
            var otomatikTip = 42;          // int olarak algılanır
            var otomatikString = "Metin";   // string olarak algılanır
            var otomatikDouble = 3.14;      // double olarak algılanır
            
            Console.WriteLine("\n=== var ile Tip Çıkarımı ===");
            Console.WriteLine($"otomatikTip: {otomatikTip} - Tipi: {otomatikTip.GetType()}");
            Console.WriteLine($"otomatikString: {otomatikString} - Tipi: {otomatikString.GetType()}");
            Console.WriteLine($"otomatikDouble: {otomatikDouble} - Tipi: {otomatikDouble.GetType()}");
            
            // Sabit (const) tanımlama
            const double PI = 3.14159;
            const string UYGULAMA_ADI = "C# Eğitimi";
            
            Console.WriteLine("\n=== Sabitler ===");
            Console.WriteLine($"PI: {PI}");
            Console.WriteLine($"Uygulama: {UYGULAMA_ADI}");
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Tüm temel veri tipleri (byte, short, int, long, float, double, decimal) gösterildi
- Karakter, string ve boolean kullanımı örneklendi
- DateTime ile tarih-zaman işlemleri yapıldı
- `var` anahtar kelimesi ile tip çıkarımı gösterildi
- `const` ile sabit tanımlama yapıldı

## Alıştırmalar

1. Adınız, soyadınız, yaşınız ve boyunuz için uygun veri tiplerinde değişkenler oluşturun
2. İki sayının toplama, çıkarma, çarpma ve bölme işlemlerini yapan bir program yazın
3. Fahrenheit'i Celsius'a çeviren bir program yazın (C = (F - 32) * 5/9)
4. Bir dikdörtgenin alanını ve çevresini hesaplayan program yazın
5. Kullanıcının yaşını alıp yetişkin olup olmadığını kontrol eden program yazın

## Önemli Notlar

- `int` tam sayı bölmesi yapar (10/3 = 3)
- Ondalıklı sonuç için en az bir değerin `double` olması gerekir
- `float` için 'f', `decimal` için 'm' soneki kullanılmalıdır
- `const` değişkenler değiştirilemez
- `var` ile tanımlanan değişkenin tipi ilk atama ile belirlenir

## Ek Kaynaklar

- [C# Veri Tipleri](https://docs.microsoft.com/tr-tr/dotnet/csharp/language-reference/builtin-types/built-in-types)
- [C# Operatörler](https://docs.microsoft.com/tr-tr/dotnet/csharp/language-reference/operators/)

## Sonraki Hafta

Hafta 3'te kontrol yapıları (if-else, switch) konusunu işleyeceğiz.
