# Hafta 4: Döngüler (for, while, foreach)

## Teorik Bilgiler

### Döngü Nedir?
Döngüler, belirli bir kod bloğunu tekrar tekrar çalıştırmamızı sağlayan yapılardır. Bu sayede aynı işlemi birçok kez yapmak için kodu tekrar yazmamıza gerek kalmaz.

### Döngü Türleri

#### for Döngüsü
Belirli sayıda tekrar için kullanılır. Başlangıç değeri, koşul ve artış/azalış ifadesi içerir.

```csharp
for (başlangıç; koşul; artış/azalış)
{
    // Tekrar edilecek kod
}
```

#### while Döngüsü
Koşul doğru olduğu sürece çalışır. Tekrar sayısı önceden bilinmiyorsa kullanılır.

```csharp
while (koşul)
{
    // Koşul doğru olduğu sürece çalışacak kod
}
```

#### do-while Döngüsü
Koşul kontrolü sonunda yapılır, en az bir kez çalışır.

```csharp
do
{
    // En az bir kez çalışacak kod
} while (koşul);
```

#### foreach Döngüsü
Koleksiyonlar ve diziler üzerinde dolaşmak için kullanılır.

```csharp
foreach (var eleman in koleksiyon)
{
    // Her eleman için çalışacak kod
}
```

### Döngü Kontrol İfadeleri
- **break:** Döngüyü tamamen sonlandırır
- **continue:** Döngünün o iterasyonunu atlar, bir sonrakine geçer

## Örnekler

### Örnek 1: Temel for Döngüsü
```csharp
using System;

namespace ForDongusuOrnegi
{
    class Program
    {
        static void Main()
        {
            // Basit for döngüsü - 1'den 10'a kadar sayıları yazdırma
            Console.WriteLine("=== 1'den 10'a Sayılar ===");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
            
            Console.WriteLine();
            
            // Çift sayıları yazdırma
            Console.WriteLine("=== 1'den 20'ye Çift Sayılar ===");
            for (int i = 2; i <= 20; i += 2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            
            Console.WriteLine();
            
            // Geriye doğru sayma
            Console.WriteLine("=== 10'dan 1'e Geri Sayım ===");
            for (int i = 10; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Sıfır!");
            
            Console.WriteLine();
            
            // Çarpım tablosu
            int sayi = 7;
            Console.WriteLine($"=== {sayi} Çarpım Tablosu ===");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{sayi} x {i} = {sayi * i}");
            }
            
            Console.WriteLine();
            
            // İç içe for döngüsü - Çarpım tablosu tam
            Console.WriteLine("=== Çarpım Tablosu (1-5) ===");
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Console.Write($"{i * j,4}"); // 4 karakter genişliğinde
                }
                Console.WriteLine();
            }
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Basit for döngüsü ile sayı dizisi
- Artış miktarı değiştirilerek çift sayılar
- Azalan döngü ile geri sayım
- İç içe döngülerle çarpım tablosu

### Örnek 2: while Döngüsü
```csharp
using System;

namespace WhileDongusuOrnegi
{
    class Program
    {
        static void Main()
        {
            // Basit while döngüsü
            Console.WriteLine("=== Basit While Döngüsü ===");
            int sayac = 1;
            while (sayac <= 5)
            {
                Console.WriteLine($"Sayaç: {sayac}");
                sayac++;
            }
            
            Console.WriteLine();
            
            // Kullanıcı "çıkış" yazana kadar devam eden döngü
            Console.WriteLine("=== Döngüden Çıkmak için 'q' yazın ===");
            string giris = "";
            while (giris.ToLower() != "q")
            {
                Console.Write("Bir şeyler yazın (çıkmak için 'q'): ");
                giris = Console.ReadLine();
                
                if (giris.ToLower() != "q")
                {
                    Console.WriteLine($"Yazdığınız: {giris}");
                }
            }
            Console.WriteLine("Döngüden çıkıldı!");
            
            Console.WriteLine();
            
            // Toplam bulma
            Console.WriteLine("=== 1'den 100'e Kadar Sayıların Toplamı ===");
            int toplam = 0;
            int i = 1;
            while (i <= 100)
            {
                toplam += i;
                i++;
            }
            Console.WriteLine($"Toplam: {toplam}");
            
            Console.WriteLine();
            
            // Şifre kontrolü (maksimum 3 deneme)
            Console.WriteLine("=== Şifre Kontrolü ===");
            string dogruSifre = "12345";
            string girilenSifre = "";
            int denemeSayisi = 0;
            int maxDeneme = 3;
            
            while (girilenSifre != dogruSifre && denemeSayisi < maxDeneme)
            {
                Console.Write("Şifre: ");
                girilenSifre = Console.ReadLine();
                denemeSayisi++;
                
                if (girilenSifre == dogruSifre)
                {
                    Console.WriteLine("Giriş başarılı!");
                }
                else if (denemeSayisi < maxDeneme)
                {
                    Console.WriteLine($"Yanlış şifre! Kalan deneme: {maxDeneme - denemeSayisi}");
                }
                else
                {
                    Console.WriteLine("Hesap kilitlendi!");
                }
            }
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Koşul bazlı while döngüsü
- Kullanıcı girdisi ile döngü kontrolü
- Sayaç ile toplam hesaplama
- Deneme hakkı kontrolü

### Örnek 3: do-while Döngüsü
```csharp
using System;

namespace DoWhileDongusuOrnegi
{
    class Program
    {
        static void Main()
        {
            // Basit do-while döngüsü
            Console.WriteLine("=== Do-While Döngüsü ===");
            int sayi = 1;
            do
            {
                Console.WriteLine($"Sayı: {sayi}");
                sayi++;
            } while (sayi <= 5);
            
            Console.WriteLine();
            
            // While vs Do-While farkı
            Console.WriteLine("=== While vs Do-While Farkı ===");
            
            int x = 10;
            Console.WriteLine("While döngüsü (koşul başta false):");
            while (x < 5)
            {
                Console.WriteLine("Bu mesaj görünmez");
                x++;
            }
            Console.WriteLine("While döngüsü hiç çalışmadı");
            
            Console.WriteLine();
            
            int y = 10;
            Console.WriteLine("Do-While döngüsü (koşul başta false):");
            do
            {
                Console.WriteLine("Bu mesaj en az bir kez görünür");
                y++;
            } while (y < 5);
            Console.WriteLine("Do-While en az bir kez çalıştı");
            
            Console.WriteLine();
            
            // Menü sistemi
            Console.WriteLine("=== Basit Menü Sistemi ===");
            int secim;
            do
            {
                Console.WriteLine("\n--- MENÜ ---");
                Console.WriteLine("1. Toplama");
                Console.WriteLine("2. Çıkarma");
                Console.WriteLine("3. Çarpma");
                Console.WriteLine("4. Bölme");
                Console.WriteLine("0. Çıkış");
                Console.Write("Seçiminiz: ");
                
                secim = int.Parse(Console.ReadLine());
                
                if (secim >= 1 && secim <= 4)
                {
                    Console.Write("Birinci sayı: ");
                    double s1 = double.Parse(Console.ReadLine());
                    Console.Write("İkinci sayı: ");
                    double s2 = double.Parse(Console.ReadLine());
                    
                    switch (secim)
                    {
                        case 1:
                            Console.WriteLine($"Sonuç: {s1 + s2}");
                            break;
                        case 2:
                            Console.WriteLine($"Sonuç: {s1 - s2}");
                            break;
                        case 3:
                            Console.WriteLine($"Sonuç: {s1 * s2}");
                            break;
                        case 4:
                            if (s2 != 0)
                                Console.WriteLine($"Sonuç: {s1 / s2}");
                            else
                                Console.WriteLine("Sıfıra bölme hatası!");
                            break;
                    }
                }
                else if (secim != 0)
                {
                    Console.WriteLine("Geçersiz seçim!");
                }
                
            } while (secim != 0);
            
            Console.WriteLine("Program sonlandı.");
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- do-while ile en az bir kez çalışma garantisi
- while ve do-while fark gösterimi
- Menü sisteminde do-while kullanımı
- Kullanıcı '0' girene kadar devam eden döngü

### Örnek 4: foreach Döngüsü
```csharp
using System;

namespace ForeachDongusuOrnegi
{
    class Program
    {
        static void Main()
        {
            // Dizi üzerinde foreach
            Console.WriteLine("=== Dizi Elemanlarını Yazdırma ===");
            int[] sayilar = { 10, 20, 30, 40, 50 };
            
            foreach (int sayi in sayilar)
            {
                Console.WriteLine(sayi);
            }
            
            Console.WriteLine();
            
            // String dizisi
            Console.WriteLine("=== Şehirler ===");
            string[] sehirler = { "İstanbul", "Ankara", "İzmir", "Bursa", "Antalya" };
            
            foreach (string sehir in sehirler)
            {
                Console.WriteLine($"- {sehir}");
            }
            
            Console.WriteLine();
            
            // String karakterleri üzerinde foreach
            Console.WriteLine("=== String Karakterleri ===");
            string kelime = "MERHABA";
            
            foreach (char karakter in kelime)
            {
                Console.WriteLine(karakter);
            }
            
            Console.WriteLine();
            
            // Dizi elemanlarının toplamı
            Console.WriteLine("=== Dizi Toplamı ===");
            int[] notlar = { 70, 85, 90, 65, 80 };
            int toplam = 0;
            
            Console.Write("Notlar: ");
            foreach (int not in notlar)
            {
                Console.Write(not + " ");
                toplam += not;
            }
            Console.WriteLine();
            Console.WriteLine($"Toplam: {toplam}");
            Console.WriteLine($"Ortalama: {toplam / (double)notlar.Length:F2}");
            
            Console.WriteLine();
            
            // Çok boyutlu dizi
            Console.WriteLine("=== Çok Boyutlu Dizi ===");
            int[,] matris = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            
            foreach (int eleman in matris)
            {
                Console.Write(eleman + " ");
            }
            Console.WriteLine();
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Diziler üzerinde foreach kullanımı
- String dizilerinde gezinme
- String'in karakterleri üzerinde dolaşma
- Toplam ve ortalama hesaplama
- Çok boyutlu dizilerde foreach

### Örnek 5: break ve continue Kullanımı
```csharp
using System;

namespace BreakContinueOrnegi
{
    class Program
    {
        static void Main()
        {
            // break kullanımı
            Console.WriteLine("=== break Kullanımı ===");
            Console.WriteLine("1'den 10'a kadar, ama 5'te dur:");
            
            for (int i = 1; i <= 10; i++)
            {
                if (i == 5)
                {
                    Console.WriteLine("5'e ulaşıldı, döngü durduruluyor!");
                    break;
                }
                Console.WriteLine(i);
            }
            
            Console.WriteLine();
            
            // continue kullanımı
            Console.WriteLine("=== continue Kullanımı ===");
            Console.WriteLine("1'den 10'a kadar, ama 5'i atla:");
            
            for (int i = 1; i <= 10; i++)
            {
                if (i == 5)
                {
                    Console.WriteLine("5 atlandı!");
                    continue;
                }
                Console.WriteLine(i);
            }
            
            Console.WriteLine();
            
            // Tek sayıları atlama
            Console.WriteLine("=== Sadece Çift Sayılar ===");
            for (int i = 1; i <= 20; i++)
            {
                if (i % 2 != 0) // Tek sayı ise
                {
                    continue; // Atla
                }
                Console.Write(i + " ");
            }
            Console.WriteLine();
            
            Console.WriteLine();
            
            // Asal sayı bulma
            Console.WriteLine("=== 2-50 Arası Asal Sayılar ===");
            for (int sayi = 2; sayi <= 50; sayi++)
            {
                bool asal = true;
                
                for (int i = 2; i <= Math.Sqrt(sayi); i++)
                {
                    if (sayi % i == 0)
                    {
                        asal = false;
                        break; // Böleni bulundu, kontrol etmeye gerek yok
                    }
                }
                
                if (asal)
                {
                    Console.Write(sayi + " ");
                }
            }
            Console.WriteLine();
            
            Console.WriteLine();
            
            // Sayı tahmin oyunu
            Console.WriteLine("=== Sayı Tahmin Oyunu ===");
            int gizliSayi = 42;
            int tahmin;
            int denemeSayisi = 0;
            int maxDeneme = 5;
            bool buldu = false;
            
            while (denemeSayisi < maxDeneme)
            {
                Console.Write($"Tahmininiz (1-100) [{denemeSayisi + 1}/{maxDeneme}]: ");
                tahmin = int.Parse(Console.ReadLine());
                denemeSayisi++;
                
                if (tahmin == gizliSayi)
                {
                    Console.WriteLine($"Tebrikler! {denemeSayisi} denemede buldunuz!");
                    buldu = true;
                    break;
                }
                else if (tahmin < gizliSayi)
                {
                    Console.WriteLine("Daha büyük bir sayı deneyin!");
                }
                else
                {
                    Console.WriteLine("Daha küçük bir sayı deneyin!");
                }
            }
            
            if (!buldu)
            {
                Console.WriteLine($"Kaybettiniz! Gizli sayı {gizliSayi} idi.");
            }
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- break ile döngüyü sonlandırma
- continue ile iterasyonu atlama
- Tek/çift sayı filtreleme
- Asal sayı bulma algoritması
- Sayı tahmin oyunu örneği

## Alıştırmalar

1. 1'den 100'e kadar olan sayıların toplamını bulan program yazın
2. Faktöriyel hesaplayan program yazın (5! = 5 × 4 × 3 × 2 × 1)
3. Fibonacci dizisinin ilk 10 terimini yazdıran program yazın
4. Kullanıcıdan alınan sayının çarpım tablosunu gösteren program yazın
5. Yıldızlarla üçgen çizen program yazın

## Önemli Notlar

- for döngüsü tekrar sayısı belirli işler için idealdir
- while döngüsü koşul bazlı tekrarlar için kullanılır
- do-while en az bir kez çalışması gereken durumlarda tercih edilir
- foreach döngüsü koleksiyonları okumak için kullanılır (değiştirmek için değil)
- Sonsuz döngülerden kaçınmak için koşulları dikkatli yazın
- break ve continue kullanımında dikkatli olun, kod okunabilirliğini etkileyebilir

## Ek Kaynaklar

- [C# for Döngüsü](https://docs.microsoft.com/tr-tr/dotnet/csharp/language-reference/statements/iteration-statements#the-for-statement)
- [C# while Döngüsü](https://docs.microsoft.com/tr-tr/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement)
- [C# foreach Döngüsü](https://docs.microsoft.com/tr-tr/dotnet/csharp/language-reference/statements/iteration-statements#the-foreach-statement)

## Sonraki Hafta

Hafta 5'te metotlar ve fonksiyonlar konusunu işleyeceğiz.
