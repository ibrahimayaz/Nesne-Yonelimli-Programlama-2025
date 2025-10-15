# Hafta 13: Koleksiyonlar ve LINQ Temelleri

## Teorik Bilgiler

### Koleksiyonlar Nedir?
Birden fazla öğeyi depolamak ve yönetmek için kullanılan veri yapılarıdır.

### Yaygın Koleksiyon Türleri
- **List<T>:** Dinamik dizi, sıralı koleksiyon
- **Dictionary<TKey, TValue>:** Anahtar-değer çiftleri
- **Queue<T>:** FIFO (İlk giren ilk çıkar)
- **Stack<T>:** LIFO (Son giren ilk çıkar)
- **HashSet<T>:** Benzersiz öğeler

### LINQ (Language Integrated Query)
Koleksiyonlar üzerinde sorgu yapmak için kullanılan C# özelliğidir.

**Temel LINQ Metotları:**
- Where: Filtreleme
- Select: Projeksiyon
- OrderBy: Sıralama
- First/FirstOrDefault: İlk eleman
- Count: Sayma
- Sum, Average, Min, Max: Agregasyon

## Örnekler

### Örnek 1: List<T> Kullanımı
```csharp
using System;
using System.Collections.Generic;

namespace ListOrnegi
{
    class Ogrenci
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }
        public double Not { get; set; }
        
        public override string ToString()
        {
            return $"{Ad} {Soyad} - Yaş: {Yas}, Not: {Not}";
        }
    }
    
    class Program
    {
        static void Main()
        {
            // List oluşturma
            List<int> sayilar = new List<int>();
            
            // Eleman ekleme
            sayilar.Add(10);
            sayilar.Add(20);
            sayilar.Add(30);
            sayilar.Add(40);
            sayilar.Add(50);
            
            Console.WriteLine("=== Sayılar Listesi ===");
            foreach (int sayi in sayilar)
            {
                Console.WriteLine(sayi);
            }
            
            // List işlemleri
            Console.WriteLine($"\nEleman sayısı: {sayilar.Count}");
            Console.WriteLine($"İlk eleman: {sayilar[0]}");
            Console.WriteLine($"Son eleman: {sayilar[sayilar.Count - 1]}");
            Console.WriteLine($"30 var mı? {sayilar.Contains(30)}");
            
            // Eleman silme
            sayilar.Remove(30);
            Console.WriteLine("\n30 silindikten sonra:");
            Console.WriteLine(string.Join(", ", sayilar));
            
            // Öğrenci listesi
            List<Ogrenci> ogrenciler = new List<Ogrenci>
            {
                new Ogrenci { Ad = "Ahmet", Soyad = "Yılmaz", Yas = 20, Not = 85 },
                new Ogrenci { Ad = "Mehmet", Soyad = "Demir", Yas = 22, Not = 90 },
                new Ogrenci { Ad = "Ayşe", Soyad = "Kaya", Yas = 21, Not = 75 },
                new Ogrenci { Ad = "Fatma", Soyad = "Şahin", Yas = 23, Not = 88 }
            };
            
            Console.WriteLine("\n=== Öğrenci Listesi ===");
            foreach (Ogrenci ogr in ogrenciler)
            {
                Console.WriteLine(ogr);
            }
            
            // AddRange ile çoklu ekleme
            ogrenciler.AddRange(new List<Ogrenci>
            {
                new Ogrenci { Ad = "Ali", Soyad = "Yıldız", Yas = 20, Not = 82 }
            });
            
            Console.WriteLine($"\nToplam öğrenci: {ogrenciler.Count}");
            
            Console.ReadLine();
        }
    }
}
```

### Örnek 2: Dictionary<TKey, TValue>
```csharp
using System;
using System.Collections.Generic;

namespace DictionaryOrnegi
{
    class Program
    {
        static void Main()
        {
            // Dictionary oluşturma
            Dictionary<string, string> telefonRehberi = new Dictionary<string, string>();
            
            // Eleman ekleme
            telefonRehberi.Add("Ahmet", "555-1234");
            telefonRehberi.Add("Mehmet", "555-5678");
            telefonRehberi.Add("Ayşe", "555-9012");
            
            // Değere erişim
            Console.WriteLine("=== Telefon Rehberi ===");
            Console.WriteLine($"Ahmet'in telefonu: {telefonRehberi["Ahmet"]}");
            
            // Tüm elemanları yazdırma
            Console.WriteLine("\nTüm kayıtlar:");
            foreach (KeyValuePair<string, string> kvp in telefonRehberi)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            
            // Anahtar kontrolü
            if (telefonRehberi.ContainsKey("Mehmet"))
            {
                Console.WriteLine($"\nMehmet bulundu: {telefonRehberi["Mehmet"]}");
            }
            
            // Güvenli erişim (TryGetValue)
            if (telefonRehberi.TryGetValue("Ali", out string telefon))
            {
                Console.WriteLine($"Ali: {telefon}");
            }
            else
            {
                Console.WriteLine("Ali bulunamadı");
            }
            
            // Ürün fiyatları
            Dictionary<string, double> urunFiyatlari = new Dictionary<string, double>
            {
                { "Ekmek", 5.00 },
                { "Süt", 15.50 },
                { "Yumurta", 25.00 },
                { "Peynir", 85.00 }
            };
            
            Console.WriteLine("\n=== Ürün Fiyatları ===");
            foreach (var urun in urunFiyatlari)
            {
                Console.WriteLine($"{urun.Key}: {urun.Value:C}");
            }
            
            // Güncelleme
            urunFiyatlari["Ekmek"] = 6.00;
            Console.WriteLine($"\nGüncel ekmek fiyatı: {urunFiyatlari["Ekmek"]:C}");
            
            Console.ReadLine();
        }
    }
}
```

### Örnek 3: LINQ Temel Sorguları
```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQOrnekleri
{
    class Urun
    {
        public string Ad { get; set; }
        public string Kategori { get; set; }
        public double Fiyat { get; set; }
        public int Stok { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            List<Urun> urunler = new List<Urun>
            {
                new Urun { Ad = "Laptop", Kategori = "Elektronik", Fiyat = 15000, Stok = 10 },
                new Urun { Ad = "Mouse", Kategori = "Elektronik", Fiyat = 150, Stok = 50 },
                new Urun { Ad = "Klavye", Kategori = "Elektronik", Fiyat = 300, Stok = 30 },
                new Urun { Ad = "Masa", Kategori = "Mobilya", Fiyat = 2000, Stok = 5 },
                new Urun { Ad = "Sandalye", Kategori = "Mobilya", Fiyat = 800, Stok = 15 },
                new Urun { Ad = "Monitor", Kategori = "Elektronik", Fiyat = 3000, Stok = 20 }
            };
            
            // Where - Filtreleme
            Console.WriteLine("=== 1000 TL üzeri ürünler ===");
            var pahalıUrunler = urunler.Where(u => u.Fiyat > 1000);
            foreach (var urun in pahalıUrunler)
            {
                Console.WriteLine($"{urun.Ad}: {urun.Fiyat:C}");
            }
            
            // OrderBy - Sıralama
            Console.WriteLine("\n=== Fiyata göre sıralı (artan) ===");
            var siraliUrunler = urunler.OrderBy(u => u.Fiyat);
            foreach (var urun in siraliUrunler)
            {
                Console.WriteLine($"{urun.Ad}: {urun.Fiyat:C}");
            }
            
            // OrderByDescending - Azalan sıralama
            Console.WriteLine("\n=== Fiyata göre sıralı (azalan) ===");
            var azalanUrunler = urunler.OrderByDescending(u => u.Fiyat).Take(3);
            foreach (var urun in azalanUrunler)
            {
                Console.WriteLine($"{urun.Ad}: {urun.Fiyat:C}");
            }
            
            // Select - Projeksiyon
            Console.WriteLine("\n=== Sadece ürün adları ===");
            var urunAdlari = urunler.Select(u => u.Ad);
            Console.WriteLine(string.Join(", ", urunAdlari));
            
            // Count
            Console.WriteLine($"\n=== Toplam ürün sayısı: {urunler.Count()} ===");
            Console.WriteLine($"Elektronik ürün sayısı: {urunler.Count(u => u.Kategori == "Elektronik")}");
            
            // Sum, Average, Min, Max
            Console.WriteLine("\n=== İstatistikler ===");
            Console.WriteLine($"Toplam değer: {urunler.Sum(u => u.Fiyat):C}");
            Console.WriteLine($"Ortalama fiyat: {urunler.Average(u => u.Fiyat):C}");
            Console.WriteLine($"En ucuz: {urunler.Min(u => u.Fiyat):C}");
            Console.WriteLine($"En pahalı: {urunler.Max(u => u.Fiyat):C}");
            
            // First, FirstOrDefault
            var ilkElektronik = urunler.First(u => u.Kategori == "Elektronik");
            Console.WriteLine($"\nİlk elektronik ürün: {ilkElektronik.Ad}");
            
            // Any - Herhangi biri
            bool stoktaYokMu = urunler.Any(u => u.Stok == 0);
            Console.WriteLine($"\nStokta olmayan ürün var mı? {stoktaYokMu}");
            
            // All - Hepsi
            bool hepsiPozitif = urunler.All(u => u.Fiyat > 0);
            Console.WriteLine($"Tüm fiyatlar pozitif mi? {hepsiPozitif}");
            
            Console.ReadLine();
        }
    }
}
```

### Örnek 4: Queue ve Stack
```csharp
using System;
using System.Collections.Generic;

namespace QueueStackOrnegi
{
    class Program
    {
        static void Main()
        {
            // Queue - FIFO (First In First Out)
            Console.WriteLine("=== QUEUE (Kuyruk) ===");
            Queue<string> kuyruk = new Queue<string>();
            
            // Enqueue - Ekleme
            kuyruk.Enqueue("Ali");
            kuyruk.Enqueue("Veli");
            kuyruk.Enqueue("Ayşe");
            kuyruk.Enqueue("Fatma");
            
            Console.WriteLine($"Kuyruktaki kişi sayısı: {kuyruk.Count}");
            Console.WriteLine($"Sıradaki: {kuyruk.Peek()}"); // İlke bakar, çıkarmaz
            
            Console.WriteLine("\nKuyruktan çıkartma:");
            while (kuyruk.Count > 0)
            {
                string kisi = kuyruk.Dequeue();
                Console.WriteLine($"{kisi} işlem gördü");
            }
            
            Console.WriteLine();
            
            // Stack - LIFO (Last In First Out)
            Console.WriteLine("=== STACK (Yığın) ===");
            Stack<string> yigin = new Stack<string>();
            
            // Push - Ekleme
            yigin.Push("Sayfa 1");
            yigin.Push("Sayfa 2");
            yigin.Push("Sayfa 3");
            yigin.Push("Sayfa 4");
            
            Console.WriteLine($"Yığındaki sayfa sayısı: {yigin.Count}");
            Console.WriteLine($"En üstteki: {yigin.Peek()}");
            
            Console.WriteLine("\nGeri gitme (Pop):");
            while (yigin.Count > 0)
            {
                string sayfa = yigin.Pop();
                Console.WriteLine($"{sayfa} kapatıldı");
            }
            
            // Pratik örnek - Geri alma (Undo)
            Console.WriteLine("\n=== Geri Alma Sistemi ===");
            Stack<string> islemler = new Stack<string>();
            
            islemler.Push("Metin yazdı");
            islemler.Push("Formatladı");
            islemler.Push("Renk değiştirdi");
            
            Console.WriteLine("İşlemler:");
            foreach (string islem in islemler)
            {
                Console.WriteLine($"- {islem}");
            }
            
            Console.WriteLine("\nGeri al:");
            if (islemler.Count > 0)
            {
                string sonIslem = islemler.Pop();
                Console.WriteLine($"'{sonIslem}' geri alındı");
            }
            
            Console.ReadLine();
        }
    }
}
```

### Örnek 5: LINQ ile Gelişmiş Sorgular
```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQGelismis
{
    class Ogrenci
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }
        public string Sehir { get; set; }
        public List<int> Notlar { get; set; }
        
        public double Ortalama => Notlar.Average();
    }
    
    class Program
    {
        static void Main()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>
            {
                new Ogrenci { Id = 1, Ad = "Ahmet", Soyad = "Yılmaz", Yas = 20, Sehir = "İstanbul", Notlar = new List<int> { 70, 80, 90 } },
                new Ogrenci { Id = 2, Ad = "Mehmet", Soyad = "Demir", Yas = 22, Sehir = "Ankara", Notlar = new List<int> { 85, 90, 95 } },
                new Ogrenci { Id = 3, Ad = "Ayşe", Soyad = "Kaya", Yas = 21, Sehir = "İzmir", Notlar = new List<int> { 60, 70, 75 } },
                new Ogrenci { Id = 4, Ad = "Fatma", Soyad = "Şahin", Yas = 23, Sehir = "İstanbul", Notlar = new List<int> { 88, 92, 85 } },
                new Ogrenci { Id = 5, Ad = "Ali", Soyad = "Öz", Yas = 20, Sehir = "Ankara", Notlar = new List<int> { 75, 80, 85 } }
            };
            
            // Şehre göre gruplama
            Console.WriteLine("=== Şehre Göre Gruplandırma ===");
            var sehirGruplari = ogrenciler.GroupBy(o => o.Sehir);
            foreach (var grup in sehirGruplari)
            {
                Console.WriteLine($"\n{grup.Key} ({grup.Count()} öğrenci):");
                foreach (var ogr in grup)
                {
                    Console.WriteLine($"  - {ogr.Ad} {ogr.Soyad}");
                }
            }
            
            // Ortalaması 80'in üzerinde olanlar
            Console.WriteLine("\n=== Ortalama 80+ Öğrenciler ===");
            var basarililar = ogrenciler.Where(o => o.Ortalama >= 80)
                                       .OrderByDescending(o => o.Ortalama);
            foreach (var ogr in basarililar)
            {
                Console.WriteLine($"{ogr.Ad} {ogr.Soyad}: {ogr.Ortalama:F2}");
            }
            
            // Query syntax
            Console.WriteLine("\n=== Query Syntax (SQL benzeri) ===");
            var gencogrenciler = from ogr in ogrenciler
                                 where ogr.Yas <= 21
                                 orderby ogr.Ad
                                 select new { ogr.Ad, ogr.Soyad, ogr.Yas };
            
            foreach (var ogr in gencogrenciler)
            {
                Console.WriteLine($"{ogr.Ad} {ogr.Soyad} ({ogr.Yas})");
            }
            
            // Join benzeri işlem
            Console.WriteLine("\n=== Şehir İstatistikleri ===");
            var sehirIstatistik = ogrenciler.GroupBy(o => o.Sehir)
                                            .Select(g => new
                                            {
                                                Sehir = g.Key,
                                                OgrenciSayisi = g.Count(),
                                                OrtalamaYas = g.Average(o => o.Yas),
                                                OrtalamaNotOrtalamasi = g.Average(o => o.Ortalama)
                                            });
            
            foreach (var stat in sehirIstatistik)
            {
                Console.WriteLine($"{stat.Sehir}:");
                Console.WriteLine($"  Öğrenci: {stat.OgrenciSayisi}");
                Console.WriteLine($"  Ort. Yaş: {stat.OrtalamaYas:F1}");
                Console.WriteLine($"  Ort. Not: {stat.OrtalamaNotOrtalamasi:F2}");
            }
            
            Console.ReadLine();
        }
    }
}
```

## Alıştırmalar

1. `List<T>` ile öğrenci yönetim sistemi yapın
2. `Dictionary` ile sözlük uygulaması oluşturun
3. LINQ ile ürün filtreleme ve sıralama yapın
4. `Queue` ile bilet kuyruğu simülasyonu yapın
5. `Stack` ile geri al/yinele (undo/redo) sistemi oluşturun

## Önemli Notlar

- `List<T>` en çok kullanılan koleksiyondur
- `Dictionary` anahtar-değer çiftleri için idealdir
- LINQ sorguları koleksiyon işlemlerini kolaylaştırır
- `Queue` FIFO, `Stack` LIFO çalışır
- LINQ lazy evaluation kullanır (gerektiğinde çalışır)

## Ek Kaynaklar

- [Collections](https://docs.microsoft.com/tr-tr/dotnet/csharp/programming-guide/concepts/collections)
- [LINQ](https://docs.microsoft.com/tr-tr/dotnet/csharp/programming-guide/concepts/linq/)

## Sonraki Hafta

Hafta 14'te genel tekrar ve ileri seviye konular işlenecek.
