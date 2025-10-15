# Hafta 1: C# Diline Giriş ve Temel Sözdizimi

## Teorik Bilgiler

### C# Nedir?
C# (C-Sharp), Microsoft tarafından geliştirilen, nesne yönelimli, tip-güvenli, modern bir programlama dilidir. .NET platformu üzerinde çalışır ve Windows, web, mobil ve oyun geliştirme gibi birçok alanda kullanılır.

### C#'ın Özellikleri
- **Nesne Yönelimli:** Her şey sınıflar ve nesneler etrafında döner
- **Tip Güvenli:** Derleme zamanında tip kontrolü yapılır
- **Otomatik Bellek Yönetimi:** Garbage Collection ile otomatik bellek temizleme
- **Zengin Kütüphane:** .NET Framework/Core geniş sınıf kütüphanesi sunar
- **Platform Bağımsızlık:** .NET Core ile cross-platform geliştirme

### İlk Program Yapısı
Bir C# programı temel olarak şu bileşenlerden oluşur:
- **Namespace:** Sınıfları organize etmek için kullanılır
- **Class:** Kodun yazıldığı temel yapı
- **Main Method:** Programın başlangıç noktası
- **Statements:** Program komutları

## Örnekler

### Örnek 1: En Basit "Merhaba Dünya" Programı
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Merhaba Dünya!");
    }
}
```
**Açıklama:** 
- `using System;` - System namespace'ini kullanmamızı sağlar
- `class Program` - Program adında bir sınıf tanımlar
- `static void Main()` - Programın başlangıç noktası
- `Console.WriteLine()` - Ekrana yazı yazdırır

### Örnek 2: Birden Fazla Satır Yazdırma
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("C# Programlamaya Hoş Geldiniz!");
        Console.WriteLine("Bu ikinci satırdır.");
        Console.WriteLine("Bu üçüncü satırdır.");
        
        Console.Write("Bu yazı ");
        Console.Write("aynı satırda devam eder.");
    }
}
```
**Açıklama:**
- `WriteLine()` - Yazıyı yazdırıp alt satıra geçer
- `Write()` - Yazıyı yazdırır ama alt satıra geçmez

### Örnek 3: Namespace Kullanımı
```csharp
using System;

namespace BenimProgramim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bu program BenimProgramim namespace'i içinde!");
            Console.WriteLine("Namespace'ler kodları organize etmeye yarar.");
            
            // Programın kapanmasını bekle
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- `namespace BenimProgramim` - Özel bir namespace tanımlar
- `string[] args` - Komut satırından parametre almayı sağlar
- `Console.ReadLine()` - Kullanıcıdan girdi bekler (program kapanmayı önler)

### Örnek 4: Yorumlar ve Kod Belgelendirme
```csharp
using System;

namespace OrnekProgram
{
    /// <summary>
    /// Bu sınıf programın ana sınıfıdır
    /// </summary>
    class Program
    {
        /// <summary>
        /// Programın başlangıç noktası
        /// </summary>
        static void Main()
        {
            // Bu tek satırlık bir yorumdur
            Console.WriteLine("Yorumlar kodu açıklamak için kullanılır");
            
            /*
             * Bu çok satırlı
             * bir yorumdur
             * Uzun açıklamalar için kullanılır
             */
            Console.WriteLine("Yorumlar derleyici tarafından görmezden gelinir");
            
            // TODO: Burada gelecekte bir özellik eklenecek
            Console.WriteLine("Program çalışıyor...");
        }
    }
}
```
**Açıklama:**
- `//` - Tek satırlık yorum
- `/* */` - Çok satırlı yorum
- `/// <summary>` - XML belgelendirme yorumu (IntelliSense için)

### Örnek 5: Temel Çıktı Formatlama
```csharp
using System;

namespace FormatlıCıktı
{
    class Program
    {
        static void Main()
        {
            string ad = "Ahmet";
            int yas = 20;
            string sehir = "İstanbul";
            
            // Eski yöntem - String birleştirme
            Console.WriteLine("Merhaba, benim adım " + ad + " ve " + yas + " yaşındayım.");
            
            // Daha modern yöntem - String interpolation
            Console.WriteLine($"Merhaba, benim adım {ad} ve {yas} yaşındayım.");
            Console.WriteLine($"{ad}, {sehir} şehrinde yaşıyor.");
            
            // Placeholder yöntemi
            Console.WriteLine("İsim: {0}, Yaş: {1}, Şehir: {2}", ad, yas, sehir);
            
            // Kaçış karakterleri
            Console.WriteLine("Tab karakteri:\tBu sekme ile ayrılmış");
            Console.WriteLine("Yeni satır:\nBu alt satırda");
            Console.WriteLine("Tırnak işareti: \"Merhaba\"");
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- `+` operatörü ile string birleştirme
- `$""` ile string interpolation (C# 6.0+)
- `{0}, {1}` ile placeholder kullanımı
- `\t, \n, \"` gibi kaçış karakterleri

## Alıştırmalar

1. Kendi adınızı ve soyadınızı ekrana yazdıran bir program yazın
2. Favori film veya kitabınız hakkında 3 satırlık bilgi yazdıran program yazın
3. String interpolation kullanarak yaşınızı ve doğum yılınızı gösteren bir program yazın
4. Hem `Write()` hem de `WriteLine()` metodlarını kullanarak bir şiir yazdırın
5. Farklı kaçış karakterlerini kullanarak formatlı bir adres bilgisi yazdırın

## Önemli Notlar

- C# büyük/küçük harf duyarlıdır (`Main` ≠ `main`)
- Her statement noktalı virgül (;) ile biter
- Süslü parantezler { } kod bloklarını tanımlar
- İyi kod yazımı için girintileme (indentation) önemlidir

## Ek Kaynaklar

- [Microsoft C# Dokümantasyonu](https://docs.microsoft.com/tr-tr/dotnet/csharp/)
- [C# Başlangıç Rehberi](https://docs.microsoft.com/tr-tr/dotnet/csharp/tour-of-csharp/)

## Sonraki Hafta

Hafta 2'de değişkenler, veri tipleri ve operatörler konusunu işleyeceğiz.
