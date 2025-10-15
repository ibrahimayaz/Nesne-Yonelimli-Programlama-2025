# Hafta 5: Metotlar ve Fonksiyonlar

## Teorik Bilgiler

### Metot Nedir?
Metot (Method/Function), belirli bir işlevi yerine getiren, yeniden kullanılabilir kod bloklarıdır. Kodun tekrarını önler ve programı daha düzenli hale getirir.

### Metot Tanımlama
```csharp
erişim_belirleyici geri_dönüş_tipi MetotAdı(parametreler)
{
    // Metot gövdesi
    return değer; // geri dönüş tipi void değilse
}
```

### Metot Bileşenleri
- **Erişim Belirleyici:** public, private, protected vb.
- **Geri Dönüş Tipi:** Metodun döndüreceği veri tipi (void dönüş yoksa)
- **Metot Adı:** PascalCase ile yazılır
- **Parametreler:** Metoda gönderilen değerler (opsiyonel)

### Parametre Türleri
- **Value Parameters:** Değer kopyası gönderilir
- **ref Parameters:** Referans ile gönderilir, değişiklik orijinali etkiler
- **out Parameters:** Çıkış parametresi, metot içinde değer atanmalı
- **params Parameters:** Değişken sayıda parametre

### Method Overloading
Aynı isimde farklı parametreli metotlar tanımlama.

## Örnekler

### Örnek 1: Temel Metot Kullanımı
```csharp
using System;

namespace MetotOrnegi
{
    class Program
    {
        // Parametresiz, geri dönüş değeri olmayan metot
        static void SelamVer()
        {
            Console.WriteLine("Merhaba!");
            Console.WriteLine("Metotlara hoş geldiniz!");
        }
        
        // Parametreli, geri dönüş değeri olmayan metot
        static void KisiyleSelamlas(string isim)
        {
            Console.WriteLine($"Merhaba, {isim}!");
        }
        
        // Parametresiz, geri dönüş değeri olan metot
        static string GunuGetir()
        {
            return DateTime.Now.DayOfWeek.ToString();
        }
        
        // Parametreli, geri dönüş değeri olan metot
        static int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }
        
        // Çoklu parametreli metot
        static double OrtalamaHesapla(int sayi1, int sayi2, int sayi3)
        {
            double toplam = sayi1 + sayi2 + sayi3;
            return toplam / 3;
        }
        
        static void Main()
        {
            Console.WriteLine("=== Parametresiz Metot ===");
            SelamVer();
            
            Console.WriteLine();
            Console.WriteLine("=== Parametreli Metot ===");
            KisiyleSelamlas("Ahmet");
            KisiyleSelamlas("Mehmet");
            
            Console.WriteLine();
            Console.WriteLine("=== Geri Dönüş Değeri Olan Metot ===");
            string gun = GunuGetir();
            Console.WriteLine($"Bugün: {gun}");
            
            Console.WriteLine();
            Console.WriteLine("=== Hesaplama Metotları ===");
            int sonuc = Topla(10, 20);
            Console.WriteLine($"10 + 20 = {sonuc}");
            
            double ortalama = OrtalamaHesapla(70, 85, 90);
            Console.WriteLine($"Ortalama: {ortalama:F2}");
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Parametresiz ve parametreli metotlar
- void ve değer döndüren metotlar
- Metot çağrımı ve sonuç kullanımı

### Örnek 2: Method Overloading (Aşırı Yükleme)
```csharp
using System;

namespace MethodOverloadingOrnegi
{
    class Program
    {
        // İki tam sayının toplamı
        static int Topla(int a, int b)
        {
            Console.WriteLine("int Topla(int, int) çağrıldı");
            return a + b;
        }
        
        // Üç tam sayının toplamı
        static int Topla(int a, int b, int c)
        {
            Console.WriteLine("int Topla(int, int, int) çağrıldı");
            return a + b + c;
        }
        
        // İki ondalıklı sayının toplamı
        static double Topla(double a, double b)
        {
            Console.WriteLine("double Topla(double, double) çağrıldı");
            return a + b;
        }
        
        // String birleştirme
        static string Topla(string a, string b)
        {
            Console.WriteLine("string Topla(string, string) çağrıldı");
            return a + " " + b;
        }
        
        // Alan hesaplama - Kare
        static double AlanHesapla(double kenar)
        {
            return kenar * kenar;
        }
        
        // Alan hesaplama - Dikdörtgen
        static double AlanHesapla(double uzunluk, double genislik)
        {
            return uzunluk * genislik;
        }
        
        // Alan hesaplama - Üçgen
        static double AlanHesapla(double taban, double yukseklik, bool ucgen)
        {
            return (taban * yukseklik) / 2;
        }
        
        static void Main()
        {
            Console.WriteLine("=== Method Overloading ===");
            
            // Farklı Topla metotlarını çağırma
            Console.WriteLine($"Sonuç: {Topla(5, 10)}");
            Console.WriteLine($"Sonuç: {Topla(5, 10, 15)}");
            Console.WriteLine($"Sonuç: {Topla(5.5, 10.3)}");
            Console.WriteLine($"Sonuç: {Topla("Merhaba", "Dünya")}");
            
            Console.WriteLine();
            Console.WriteLine("=== Alan Hesaplama ===");
            Console.WriteLine($"Karenin alanı (kenar=5): {AlanHesapla(5)}");
            Console.WriteLine($"Dikdörtgenin alanı (4x6): {AlanHesapla(4, 6)}");
            Console.WriteLine($"Üçgenin alanı (taban=8, yükseklik=5): {AlanHesapla(8, 5, true)}");
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Aynı isimde farklı parametre sayısı/tipi ile metotlar
- Derleyici parametrelere göre doğru metodu seçer
- Farklı geometrik şekiller için alan hesaplama

### Örnek 3: ref, out ve params Parametreleri
```csharp
using System;

namespace ParametreTurleriOrnegi
{
    class Program
    {
        // Normal parametre (value)
        static void DegeriArtir(int sayi)
        {
            sayi += 10;
            Console.WriteLine($"Metot içinde: {sayi}");
        }
        
        // ref parametresi
        static void DegeriArtirRef(ref int sayi)
        {
            sayi += 10;
            Console.WriteLine($"Metot içinde (ref): {sayi}");
        }
        
        // out parametresi
        static void BolmeIslemi(int bolunen, int bolen, out int bolum, out int kalan)
        {
            bolum = bolunen / bolen;
            kalan = bolunen % bolen;
        }
        
        // out parametresi - TryParse benzeri
        static bool SayiyaCevir(string metin, out int sayi)
        {
            try
            {
                sayi = int.Parse(metin);
                return true;
            }
            catch
            {
                sayi = 0;
                return false;
            }
        }
        
        // params parametresi - değişken sayıda parametre
        static int ToplamHesapla(params int[] sayilar)
        {
            int toplam = 0;
            foreach (int sayi in sayilar)
            {
                toplam += sayi;
            }
            return toplam;
        }
        
        static double OrtalamaHesapla(params double[] sayilar)
        {
            if (sayilar.Length == 0)
                return 0;
            
            double toplam = 0;
            foreach (double sayi in sayilar)
            {
                toplam += sayi;
            }
            return toplam / sayilar.Length;
        }
        
        static void Main()
        {
            Console.WriteLine("=== Value Parametre ===");
            int x = 5;
            Console.WriteLine($"Öncesi: {x}");
            DegeriArtir(x);
            Console.WriteLine($"Sonrası: {x}"); // Değişmez
            
            Console.WriteLine();
            Console.WriteLine("=== ref Parametre ===");
            int y = 5;
            Console.WriteLine($"Öncesi: {y}");
            DegeriArtirRef(ref y);
            Console.WriteLine($"Sonrası: {y}"); // Değişir
            
            Console.WriteLine();
            Console.WriteLine("=== out Parametre ===");
            int bolum, kalan;
            BolmeIslemi(17, 5, out bolum, out kalan);
            Console.WriteLine($"17 / 5 = {bolum}, Kalan: {kalan}");
            
            Console.WriteLine();
            int sonuc;
            if (SayiyaCevir("123", out sonuc))
                Console.WriteLine($"Başarılı: {sonuc}");
            else
                Console.WriteLine("Dönüşüm başarısız");
            
            if (SayiyaCevir("abc", out sonuc))
                Console.WriteLine($"Başarılı: {sonuc}");
            else
                Console.WriteLine("Dönüşüm başarısız");
            
            Console.WriteLine();
            Console.WriteLine("=== params Parametre ===");
            Console.WriteLine($"Toplam (2 sayı): {ToplamHesapla(10, 20)}");
            Console.WriteLine($"Toplam (4 sayı): {ToplamHesapla(10, 20, 30, 40)}");
            Console.WriteLine($"Toplam (6 sayı): {ToplamHesapla(5, 10, 15, 20, 25, 30)}");
            
            Console.WriteLine($"Ortalama: {OrtalamaHesapla(70, 85, 90, 65, 80):F2}");
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Value parametre: Kopya gönderilir, değişiklik orijinali etkilemez
- ref: Referans gönderilir, değişiklik orijinali etkiler
- out: Çıkış parametresi, metot içinde mutlaka değer atanmalı
- params: Değişken sayıda parametre alır

### Örnek 4: Recursive (Özyinelemeli) Metotlar
```csharp
using System;

namespace RecursiveOrnegi
{
    class Program
    {
        // Faktöriyel hesaplama (5! = 5 × 4 × 3 × 2 × 1)
        static int Faktoriyel(int n)
        {
            if (n <= 1)
                return 1;
            else
                return n * Faktoriyel(n - 1);
        }
        
        // Fibonacci sayısı bulma
        static int Fibonacci(int n)
        {
            if (n <= 1)
                return n;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        
        // Sayıların toplamı (1'den n'e kadar)
        static int ToplamHesapla(int n)
        {
            if (n == 1)
                return 1;
            else
                return n + ToplamHesapla(n - 1);
        }
        
        // Üs alma işlemi (taban^us)
        static int UsAl(int taban, int us)
        {
            if (us == 0)
                return 1;
            else
                return taban * UsAl(taban, us - 1);
        }
        
        // Sayının basamaklarının toplamı
        static int BasamakTopla(int sayi)
        {
            if (sayi < 10)
                return sayi;
            else
                return (sayi % 10) + BasamakTopla(sayi / 10);
        }
        
        static void Main()
        {
            Console.WriteLine("=== Faktöriyel ===");
            for (int i = 1; i <= 6; i++)
            {
                Console.WriteLine($"{i}! = {Faktoriyel(i)}");
            }
            
            Console.WriteLine();
            Console.WriteLine("=== Fibonacci Dizisi ===");
            Console.Write("İlk 10 Fibonacci sayısı: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(Fibonacci(i) + " ");
            }
            Console.WriteLine();
            
            Console.WriteLine();
            Console.WriteLine("=== Toplam Hesaplama ===");
            int n = 100;
            Console.WriteLine($"1'den {n}'e kadar sayıların toplamı: {ToplamHesapla(n)}");
            
            Console.WriteLine();
            Console.WriteLine("=== Üs Alma ===");
            Console.WriteLine($"2^8 = {UsAl(2, 8)}");
            Console.WriteLine($"3^4 = {UsAl(3, 4)}");
            
            Console.WriteLine();
            Console.WriteLine("=== Basamak Toplamı ===");
            int sayi = 12345;
            Console.WriteLine($"{sayi} sayısının basamakları toplamı: {BasamakTopla(sayi)}");
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Recursive (özyinelemeli) metotlar kendini çağırır
- Base case (çıkış koşulu) şarttır, yoksa sonsuz döngü oluşur
- Faktöriyel, Fibonacci gibi matematiksel işlemler için idealdir
- Her çağrıda problem daha küçük hale gelir

### Örnek 5: Pratik Metot Örnekleri
```csharp
using System;

namespace PratikMetotlar
{
    class Program
    {
        // Asal sayı kontrolü
        static bool AsalMi(int sayi)
        {
            if (sayi < 2)
                return false;
            
            for (int i = 2; i <= Math.Sqrt(sayi); i++)
            {
                if (sayi % i == 0)
                    return false;
            }
            return true;
        }
        
        // String'i ters çevirme
        static string TersCevir(string metin)
        {
            char[] karakterler = metin.ToCharArray();
            Array.Reverse(karakterler);
            return new string(karakterler);
        }
        
        // Palindrom kontrolü
        static bool PalindromMu(string metin)
        {
            string temiz = metin.ToLower().Replace(" ", "");
            string ters = TersCevir(temiz);
            return temiz == ters;
        }
        
        // İki sayının EBOB'unu bulma (Öklid Algoritması)
        static int EBOB(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        
        // İki sayının EKOK'unu bulma
        static int EKOK(int a, int b)
        {
            return (a * b) / EBOB(a, b);
        }
        
        // Nottan harf notu hesaplama
        static string HarfNotuHesapla(int puan)
        {
            if (puan >= 90) return "AA";
            else if (puan >= 80) return "BA";
            else if (puan >= 70) return "BB";
            else if (puan >= 60) return "CB";
            else if (puan >= 50) return "CC";
            else return "FF";
        }
        
        // Şifre güvenlik kontrolü
        static bool GuvenliSifreMi(string sifre)
        {
            if (sifre.Length < 8)
                return false;
            
            bool buyukHarf = false;
            bool kucukHarf = false;
            bool rakam = false;
            
            foreach (char c in sifre)
            {
                if (char.IsUpper(c)) buyukHarf = true;
                if (char.IsLower(c)) kucukHarf = false;
                if (char.IsDigit(c)) rakam = true;
            }
            
            return buyukHarf && kucukHarf && rakam;
        }
        
        // Dizi içinde maksimum değer bulma
        static int MaksimumBul(int[] dizi)
        {
            int max = dizi[0];
            foreach (int sayi in dizi)
            {
                if (sayi > max)
                    max = sayi;
            }
            return max;
        }
        
        // Dizi ortalaması
        static double DiziOrtalamasi(int[] dizi)
        {
            int toplam = 0;
            foreach (int sayi in dizi)
            {
                toplam += sayi;
            }
            return (double)toplam / dizi.Length;
        }
        
        static void Main()
        {
            Console.WriteLine("=== Asal Sayı Kontrolü ===");
            int[] sayilar = { 2, 7, 12, 17, 20, 23 };
            foreach (int sayi in sayilar)
            {
                Console.WriteLine($"{sayi} asal mı? {AsalMi(sayi)}");
            }
            
            Console.WriteLine();
            Console.WriteLine("=== String İşlemleri ===");
            string metin = "Merhaba";
            Console.WriteLine($"Orijinal: {metin}");
            Console.WriteLine($"Ters: {TersCevir(metin)}");
            
            Console.WriteLine();
            Console.WriteLine("=== Palindrom Kontrolü ===");
            string[] kelimeler = { "kayak", "rar", "merhaba", "ana" };
            foreach (string kelime in kelimeler)
            {
                Console.WriteLine($"{kelime}: {PalindromMu(kelime)}");
            }
            
            Console.WriteLine();
            Console.WriteLine("=== EBOB ve EKOK ===");
            Console.WriteLine($"EBOB(48, 18) = {EBOB(48, 18)}");
            Console.WriteLine($"EKOK(48, 18) = {EKOK(48, 18)}");
            
            Console.WriteLine();
            Console.WriteLine("=== Harf Notu Hesaplama ===");
            int[] notlar = { 95, 82, 75, 65, 55, 45 };
            foreach (int not in notlar)
            {
                Console.WriteLine($"{not} → {HarfNotuHesapla(not)}");
            }
            
            Console.WriteLine();
            Console.WriteLine("=== Dizi İşlemleri ===");
            int[] numaralar = { 45, 78, 23, 89, 12, 67 };
            Console.WriteLine($"Dizideki maksimum: {MaksimumBul(numaralar)}");
            Console.WriteLine($"Dizinin ortalaması: {DiziOrtalamasi(numaralar):F2}");
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Asal sayı kontrolü algoritması
- String manipülasyon metotları
- Palindrom (tersten okunuşu aynı kelime) kontrolü
- EBOB/EKOK hesaplama
- Pratik kullanım senaryoları

## Alıştırmalar

1. İki sayının çarpımını döndüren metot yazın
2. Bir sayının mükemmel kare olup olmadığını kontrol eden metot yazın
3. Dizi elemanlarını sıralayan metot yazın
4. Celsius'u Fahrenheit'e çeviren ve tersini yapan metotlar yazın
5. Kullanıcıdan aldığı yaş bilgisine göre yaş kategorisi döndüren metot yazın

## Önemli Notlar

- Metot isimleri PascalCase ile yazılır (ÖrnekMetot)
- Parametreler camelCase ile yazılır (parametreAdi)
- Her metot tek bir iş yapmalıdır (Single Responsibility)
- Uzun metotları daha küçük metotlara bölün
- Recursive metotlarda çıkış koşulu şarttır
- Method overloading'de return tipi ayırt edici değildir

## Ek Kaynaklar

- [C# Metotlar](https://docs.microsoft.com/tr-tr/dotnet/csharp/programming-guide/classes-and-structs/methods)
- [Method Overloading](https://docs.microsoft.com/tr-tr/dotnet/csharp/programming-guide/classes-and-structs/methods#method-overloading)

## Sonraki Hafta

Hafta 6'da sınıflar ve nesneler konusuna giriş yapacağız.
