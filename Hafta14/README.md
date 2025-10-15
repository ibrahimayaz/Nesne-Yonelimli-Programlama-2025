# Hafta 14: Genel Tekrar ve İleri Seviye Konular

## 14 Haftalık Özet

### Hafta 1-5: Temel C# ve Programlama
- C# sözdizimi ve temel yapılar
- Değişkenler, veri tipleri, operatörler
- Kontrol yapıları (if-else, switch)
- Döngüler (for, while, foreach)
- Metotlar ve fonksiyonlar

### Hafta 6-8: Nesne Yönelimli Programlama Temelleri
- Sınıflar ve nesneler
- Constructor ve Properties
- Encapsulation ve Access Modifiers
- Field, Property, Method kavramları

### Hafta 9-11: İleri OOP Kavramları
- Inheritance (Kalıtım)
- Polymorphism (Çok biçimlilik)
- Abstract Classes
- Interfaces

### Hafta 12-13: Pratik Konular
- Exception Handling
- Collections (List, Dictionary, Queue, Stack)
- LINQ temelleri

## İleri Seviye Konular

### 1. Delegates ve Events
```csharp
using System;

namespace DelegatesEvents
{
    // Delegate tanımı
    public delegate void BildirimDelegate(string mesaj);
    
    class Bildirim
    {
        // Event tanımı
        public event BildirimDelegate BildirimGonder;
        
        public void YeniBildirim(string mesaj)
        {
            Console.WriteLine($"Yeni bildirim: {mesaj}");
            
            // Event tetikleme
            BildirimGonder?.Invoke(mesaj);
        }
    }
    
    class Program
    {
        static void EmailGonder(string mesaj)
        {
            Console.WriteLine($"Email gönderildi: {mesaj}");
        }
        
        static void SMSGonder(string mesaj)
        {
            Console.WriteLine($"SMS gönderildi: {mesaj}");
        }
        
        static void Main()
        {
            Bildirim bildirim = new Bildirim();
            
            // Event'e subscriber ekleme
            bildirim.BildirimGonder += EmailGonder;
            bildirim.BildirimGonder += SMSGonder;
            
            bildirim.YeniBildirim("Sistem güncellemesi mevcut");
            
            Console.ReadLine();
        }
    }
}
```

### 2. Generic Types
```csharp
using System;

namespace Generics
{
    // Generic sınıf
    class Kutu<T>
    {
        private T icerik;
        
        public void KoyKutu(T item)
        {
            icerik = item;
            Console.WriteLine($"Kutuya kondu: {item}");
        }
        
        public T KutuyuAc()
        {
            return icerik;
        }
    }
    
    // Generic metot
    class Utility
    {
        public static void Tasi<T>(T[] kaynak, T[] hedef, int index)
        {
            hedef[index] = kaynak[index];
        }
        
        public static T EnBuyuk<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
    
    class Program
    {
        static void Main()
        {
            // String kutusu
            Kutu<string> stringKutu = new Kutu<string>();
            stringKutu.KoyKutu("Merhaba");
            Console.WriteLine($"Kutuda: {stringKutu.KutuyuAc()}");
            
            Console.WriteLine();
            
            // Int kutusu
            Kutu<int> intKutu = new Kutu<int>();
            intKutu.KoyKutu(42);
            Console.WriteLine($"Kutuda: {intKutu.KutuyuAc()}");
            
            Console.WriteLine();
            
            // Generic metot kullanımı
            Console.WriteLine($"En büyük: {Utility.EnBuyuk(10, 20)}");
            Console.WriteLine($"En büyük: {Utility.EnBuyuk("Ahmet", "Mehmet")}");
            
            Console.ReadLine();
        }
    }
}
```

### 3. Extension Methods
```csharp
using System;

namespace ExtensionMethods
{
    // Extension method sınıfı (static olmalı)
    static class StringExtensions
    {
        // Extension metotlar (static, ilk parametre this)
        public static string TersCevir(this string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
        
        public static int KelimeSayisi(this string str)
        {
            return str.Split(' ').Length;
        }
        
        public static string Buyult(this string str)
        {
            return str.ToUpper();
        }
    }
    
    static class IntExtensions
    {
        public static bool CiftMi(this int sayi)
        {
            return sayi % 2 == 0;
        }
        
        public static int Kare(this int sayi)
        {
            return sayi * sayi;
        }
    }
    
    class Program
    {
        static void Main()
        {
            string metin = "Merhaba Dünya";
            
            Console.WriteLine($"Orjinal: {metin}");
            Console.WriteLine($"Ters: {metin.TersCevir()}");
            Console.WriteLine($"Kelime sayısı: {metin.KelimeSayisi()}");
            Console.WriteLine($"Büyük harf: {metin.Buyult()}");
            
            Console.WriteLine();
            
            int sayi = 15;
            Console.WriteLine($"Sayı: {sayi}");
            Console.WriteLine($"Çift mi? {sayi.CiftMi()}");
            Console.WriteLine($"Karesi: {sayi.Kare()}");
            
            Console.ReadLine();
        }
    }
}
```

### 4. Lambda Expressions
```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaExpressions
{
    class Urun
    {
        public string Ad { get; set; }
        public double Fiyat { get; set; }
        public int Stok { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            List<Urun> urunler = new List<Urun>
            {
                new Urun { Ad = "Laptop", Fiyat = 15000, Stok = 10 },
                new Urun { Ad = "Mouse", Fiyat = 150, Stok = 50 },
                new Urun { Ad = "Klavye", Fiyat = 300, Stok = 30 }
            };
            
            // Lambda ile filtreleme
            var pahalılar = urunler.Where(u => u.Fiyat > 200);
            
            // Lambda ile sıralama
            var sirali = urunler.OrderBy(u => u.Fiyat);
            
            // Lambda ile seçim
            var adlar = urunler.Select(u => u.Ad);
            
            // Lambda ile koşul
            bool hepsiStokta = urunler.All(u => u.Stok > 0);
            
            // Delegate ile lambda
            Func<int, int, int> topla = (a, b) => a + b;
            Console.WriteLine($"Toplam: {topla(5, 3)}");
            
            Action<string> yazdir = mesaj => Console.WriteLine(mesaj);
            yazdir("Lambda ile yazdırma");
            
            // Çoklu satır lambda
            Func<int, string> kategori = sayi =>
            {
                if (sayi < 10) return "Küçük";
                else if (sayi < 100) return "Orta";
                else return "Büyük";
            };
            
            Console.WriteLine($"50: {kategori(50)}");
            
            Console.ReadLine();
        }
    }
}
```

### 5. Async/Await (Asenkron Programlama)
```csharp
using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class VeriServisi
    {
        public async Task<string> VeriIndir(string url)
        {
            Console.WriteLine($"İndiriliyor: {url}");
            
            // Asenkron bekleme (simülasyon)
            await Task.Delay(2000);
            
            return $"Veri indirildi: {url}";
        }
        
        public async Task<int> HesaplaAsync(int sayi)
        {
            Console.WriteLine("Hesaplama başladı...");
            
            await Task.Delay(1000);
            
            Console.WriteLine("Hesaplama tamamlandı");
            return sayi * sayi;
        }
    }
    
    class Program
    {
        static async Task Main()
        {
            VeriServisi servis = new VeriServisi();
            
            // Asenkron çağrı
            string sonuc = await servis.VeriIndir("https://example.com");
            Console.WriteLine(sonuc);
            
            Console.WriteLine();
            
            // Paralel işlemler
            Task<int> task1 = servis.HesaplaAsync(5);
            Task<int> task2 = servis.HesaplaAsync(10);
            
            int[] sonuclar = await Task.WhenAll(task1, task2);
            Console.WriteLine($"Sonuçlar: {sonuclar[0]}, {sonuclar[1]}");
            
            Console.ReadLine();
        }
    }
}
```

## SOLID Prensipleri

### S - Single Responsibility (Tek Sorumluluk)
Her sınıf tek bir sorumluluğa sahip olmalıdır.

### O - Open/Closed (Açık/Kapalı)
Sınıflar genişlemeye açık, değişikliğe kapalı olmalıdır.

### L - Liskov Substitution (Liskov Yerine Geçme)
Alt sınıflar, üst sınıfların yerine geçebilmelidir.

### I - Interface Segregation (Arayüz Ayrımı)
Geniş arayüzler yerine özelleşmiş küçük arayüzler kullanılmalıdır.

### D - Dependency Inversion (Bağımlılık Tersine Çevirme)
Yüksek seviye modüller düşük seviye modüllere bağımlı olmamalıdır.

## Özet Proje Örneği

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace KutuphaneYonetim
{
    interface IKiralama
    {
        void Kirala();
        void IadeEt();
    }
    
    abstract class Materyal
    {
        public string Id { get; set; }
        public string Baslik { get; set; }
        public bool KiralikMi { get; protected set; }
        
        public abstract void BilgiGoster();
    }
    
    class Kitap : Materyal, IKiralama
    {
        public string Yazar { get; set; }
        public int SayfaSayisi { get; set; }
        
        public void Kirala()
        {
            if (!KiralikMi)
            {
                KiralikMi = true;
                Console.WriteLine($"{Baslik} kiralandı");
            }
            else
            {
                Console.WriteLine($"{Baslik} zaten kiralık");
            }
        }
        
        public void IadeEt()
        {
            KiralikMi = false;
            Console.WriteLine($"{Baslik} iade edildi");
        }
        
        public override void BilgiGoster()
        {
            Console.WriteLine($"Kitap: {Baslik} - {Yazar}");
            Console.WriteLine($"Sayfa: {SayfaSayisi}");
            Console.WriteLine($"Durum: {(KiralikMi ? "Kiralık" : "Mevcut")}");
        }
    }
    
    class Kutuphane
    {
        private List<Materyal> materyaller = new List<Materyal>();
        
        public void MateryalEkle(Materyal materyal)
        {
            materyaller.Add(materyal);
            Console.WriteLine($"{materyal.Baslik} kütüphaneye eklendi");
        }
        
        public void TumMateralleriListele()
        {
            Console.WriteLine("\n=== Kütüphane Materyalleri ===");
            foreach (var materyal in materyaller)
            {
                materyal.BilgiGoster();
                Console.WriteLine();
            }
        }
        
        public List<Materyal> MusaitMateryaller()
        {
            return materyaller.Where(m => !m.KiralikMi).ToList();
        }
    }
    
    class Program
    {
        static void Main()
        {
            Kutuphane kutuphane = new Kutuphane();
            
            Kitap kitap1 = new Kitap 
            { 
                Id = "K001", 
                Baslik = "Suç ve Ceza", 
                Yazar = "Dostoyevski", 
                SayfaSayisi = 671 
            };
            
            Kitap kitap2 = new Kitap 
            { 
                Id = "K002", 
                Baslik = "1984", 
                Yazar = "George Orwell", 
                SayfaSayisi = 328 
            };
            
            kutuphane.MateryalEkle(kitap1);
            kutuphane.MateryalEkle(kitap2);
            
            Console.WriteLine();
            kitap1.Kirala();
            
            kutuphane.TumMateralleriListele();
            
            Console.WriteLine($"Müsait materyal sayısı: {kutuphane.MusaitMateryaller().Count}");
            
            Console.ReadLine();
        }
    }
}
```

## Sonuç ve Değerlendirme

Bu 14 haftalık kurs boyunca:
- ✓ C# temellerini öğrendik
- ✓ Nesne Yönelimli Programlama prensiplerini kavradık
- ✓ Encapsulation, Inheritance, Polymorphism, Abstraction
- ✓ Exception Handling öğrendik
- ✓ Collections ve LINQ kullanımını gördük
- ✓ İleri seviye konulara giriş yaptık

### Sonraki Adımlar
1. **Projeler:** Öğrendiklerinizle gerçek projeler yapın
2. **Design Patterns:** Gang of Four tasarım kalıplarını öğrenin
3. **ASP.NET Core:** Web geliştirmeye geçin
4. **Entity Framework:** ORM kullanımı
5. **Unit Testing:** Test yazma pratikleri
6. **Clean Code:** Kod kalitesi ve best practices

### Önerilen Projeler
- Kütüphane yönetim sistemi
- E-ticaret uygulaması
- Öğrenci bilgi sistemi
- Banka hesap yönetimi
- Envanter takip sistemi

## Kaynaklar

- [Microsoft C# Documentation](https://docs.microsoft.com/tr-tr/dotnet/csharp/)
- [C# Programming Guide](https://docs.microsoft.com/tr-tr/dotnet/csharp/programming-guide/)
- [.NET API Browser](https://docs.microsoft.com/tr-tr/dotnet/api/)

## Tebrikler!

14 haftalık Nesne Yönelimli Programlama kursunu tamamladınız! 🎉

Başarılar dileriz! 🚀
