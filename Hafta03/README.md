# Hafta 3: Kontrol Yapıları (if-else, switch)

## Teorik Bilgiler

### Kontrol Yapıları Nedir?
Kontrol yapıları, programın akışını belirli koşullara göre yönlendirmemizi sağlayan yapılardır. Bu sayede programlarımız farklı durumlar için farklı işlemler yapabilir.

### if-else Yapısı
`if` statement'ı bir koşulun doğru olup olmadığını kontrol eder. Koşul doğruysa (true) ilgili kod bloğu çalışır.

**Sözdizimi:**
```csharp
if (koşul)
{
    // Koşul doğruysa çalışacak kod
}
else if (başka_koşul)
{
    // İlk koşul yanlış, bu koşul doğruysa çalışacak kod
}
else
{
    // Hiçbir koşul doğru değilse çalışacak kod
}
```

### switch-case Yapısı
`switch` statement'ı bir değişkenin değerini birden fazla olasılıkla karşılaştırmak için kullanılır.

**Sözdizimi:**
```csharp
switch (değişken)
{
    case değer1:
        // değişken == değer1 ise çalışacak kod
        break;
    case değer2:
        // değişken == değer2 ise çalışacak kod
        break;
    default:
        // Hiçbir case eşleşmezse çalışacak kod
        break;
}
```

### Ternary Operator
Basit if-else durumları için kısa yazım:
```csharp
sonuç = (koşul) ? değer_doğruysa : değer_yanlışsa;
```

## Örnekler

### Örnek 1: Temel if-else Kullanımı
```csharp
using System;

namespace IfElseOrnegi
{
    class Program
    {
        static void Main()
        {
            // Basit if kullanımı
            int sayi = 10;
            
            if (sayi > 0)
            {
                Console.WriteLine("Sayı pozitif");
            }
            
            Console.WriteLine(); // Boş satır
            
            // if-else kullanımı
            int yas = 17;
            
            if (yas >= 18)
            {
                Console.WriteLine("Reşitsiniz");
            }
            else
            {
                Console.WriteLine("Reşit değilsiniz");
            }
            
            Console.WriteLine();
            
            // if-else if-else kullanımı
            int puan = 75;
            
            if (puan >= 90)
            {
                Console.WriteLine("Notunuz: AA");
            }
            else if (puan >= 80)
            {
                Console.WriteLine("Notunuz: BA");
            }
            else if (puan >= 70)
            {
                Console.WriteLine("Notunuz: BB");
            }
            else if (puan >= 60)
            {
                Console.WriteLine("Notunuz: CB");
            }
            else if (puan >= 50)
            {
                Console.WriteLine("Notunuz: CC");
            }
            else
            {
                Console.WriteLine("Kaldınız");
            }
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Basit if ile tek koşul kontrolü
- if-else ile iki durumlu kontrol
- if-else if-else ile çoklu koşul kontrolü (not sistemi)

### Örnek 2: İç İçe if Yapıları ve Mantıksal Operatörler
```csharp
using System;

namespace IcIceIfOrnegi
{
    class Program
    {
        static void Main()
        {
            // İç içe if kullanımı
            string kullaniciAdi = "admin";
            string sifre = "12345";
            
            Console.WriteLine("=== Giriş Sistemi ===");
            
            if (kullaniciAdi == "admin")
            {
                if (sifre == "12345")
                {
                    Console.WriteLine("Giriş başarılı!");
                }
                else
                {
                    Console.WriteLine("Şifre yanlış!");
                }
            }
            else
            {
                Console.WriteLine("Kullanıcı adı yanlış!");
            }
            
            Console.WriteLine();
            
            // Mantıksal operatörlerle aynı işlem
            if (kullaniciAdi == "admin" && sifre == "12345")
            {
                Console.WriteLine("Giriş başarılı! (Mantıksal operatör ile)");
            }
            else
            {
                Console.WriteLine("Kullanıcı adı veya şifre yanlış!");
            }
            
            Console.WriteLine();
            
            // Çoklu koşul örneği - Kredi başvurusu
            int maas = 5000;
            int yasKredi = 25;
            bool krediBorucu = false;
            
            Console.WriteLine("=== Kredi Başvuru Değerlendirmesi ===");
            Console.WriteLine($"Maaş: {maas} TL");
            Console.WriteLine($"Yaş: {yasKredi}");
            Console.WriteLine($"Kredi borcu: {(krediBorucu ? "Var" : "Yok")}");
            
            if (yasKredi >= 18 && yasKredi <= 65)
            {
                if (maas >= 4000)
                {
                    if (!krediBorucu)
                    {
                        Console.WriteLine("✓ Kredi başvurunuz onaylandı!");
                    }
                    else
                    {
                        Console.WriteLine("✗ Mevcut kredi borcunuz var!");
                    }
                }
                else
                {
                    Console.WriteLine("✗ Maaşınız yeterli değil!");
                }
            }
            else
            {
                Console.WriteLine("✗ Yaş aralığı uygun değil!");
            }
            
            Console.WriteLine();
            
            // Veya (||) operatörü örneği
            string gun = "Cumartesi";
            
            if (gun == "Cumartesi" || gun == "Pazar")
            {
                Console.WriteLine("Hafta sonu - Tatil!");
            }
            else
            {
                Console.WriteLine("Hafta içi - Çalışma günü");
            }
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- İç içe if yapıları ile çoklu kontrol
- && (ve) operatörü ile birden fazla koşul kontrolü
- || (veya) operatörü kullanımı
- ! (değil) operatörü ile olumsuzlama

### Örnek 3: switch-case Yapısı
```csharp
using System;

namespace SwitchCaseOrnegi
{
    class Program
    {
        static void Main()
        {
            // Basit switch-case kullanımı
            int gun = 3;
            
            Console.WriteLine("=== Günün Adı ===");
            switch (gun)
            {
                case 1:
                    Console.WriteLine("Pazartesi");
                    break;
                case 2:
                    Console.WriteLine("Salı");
                    break;
                case 3:
                    Console.WriteLine("Çarşamba");
                    break;
                case 4:
                    Console.WriteLine("Perşembe");
                    break;
                case 5:
                    Console.WriteLine("Cuma");
                    break;
                case 6:
                    Console.WriteLine("Cumartesi");
                    break;
                case 7:
                    Console.WriteLine("Pazar");
                    break;
                default:
                    Console.WriteLine("Geçersiz gün!");
                    break;
            }
            
            Console.WriteLine();
            
            // String ile switch-case
            string ay = "Mart";
            int gunSayisi;
            
            Console.WriteLine("=== Aydaki Gün Sayısı ===");
            switch (ay)
            {
                case "Ocak":
                case "Mart":
                case "Mayıs":
                case "Temmuz":
                case "Ağustos":
                case "Ekim":
                case "Aralık":
                    gunSayisi = 31;
                    Console.WriteLine($"{ay} ayı {gunSayisi} gündür");
                    break;
                case "Nisan":
                case "Haziran":
                case "Eylül":
                case "Kasım":
                    gunSayisi = 30;
                    Console.WriteLine($"{ay} ayı {gunSayisi} gündür");
                    break;
                case "Şubat":
                    gunSayisi = 28;
                    Console.WriteLine($"{ay} ayı {gunSayisi} veya 29 gündür");
                    break;
                default:
                    Console.WriteLine("Geçersiz ay adı!");
                    break;
            }
            
            Console.WriteLine();
            
            // Hesap makinesi örneği
            double sayi1 = 10;
            double sayi2 = 5;
            char islem = '+';
            
            Console.WriteLine("=== Hesap Makinesi ===");
            Console.WriteLine($"{sayi1} {islem} {sayi2} = ");
            
            switch (islem)
            {
                case '+':
                    Console.WriteLine(sayi1 + sayi2);
                    break;
                case '-':
                    Console.WriteLine(sayi1 - sayi2);
                    break;
                case '*':
                    Console.WriteLine(sayi1 * sayi2);
                    break;
                case '/':
                    if (sayi2 != 0)
                        Console.WriteLine(sayi1 / sayi2);
                    else
                        Console.WriteLine("Sıfıra bölme hatası!");
                    break;
                default:
                    Console.WriteLine("Geçersiz işlem!");
                    break;
            }
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Sayılarla switch-case kullanımı
- String değerlerle switch-case
- Birden fazla case için aynı kod bloğu (fall-through)
- default bloğu ile hata kontrolü

### Örnek 4: Ternary Operator ve Kısa Kontrol Yapıları
```csharp
using System;

namespace TernaryOperatorOrnegi
{
    class Program
    {
        static void Main()
        {
            // Temel ternary operator
            int sayi = 15;
            string sonuc = (sayi % 2 == 0) ? "Çift" : "Tek";
            Console.WriteLine($"{sayi} sayısı {sonuc}tir");
            
            Console.WriteLine();
            
            // if-else ile aynı işlem
            string sonuc2;
            if (sayi % 2 == 0)
                sonuc2 = "Çift";
            else
                sonuc2 = "Tek";
            Console.WriteLine($"if-else ile: {sayi} sayısı {sonuc2}tir");
            
            Console.WriteLine();
            
            // Yaş kontrolü
            int yas = 20;
            string kategori = (yas < 18) ? "Çocuk" : (yas < 65) ? "Yetişkin" : "Yaşlı";
            Console.WriteLine($"Yaş {yas} - Kategori: {kategori}");
            
            Console.WriteLine();
            
            // İndirim hesaplama
            decimal tutar = 1000;
            decimal indirimOrani = (tutar > 500) ? 0.20m : (tutar > 200) ? 0.10m : 0.05m;
            decimal indirim = tutar * indirimOrani;
            decimal odenecek = tutar - indirim;
            
            Console.WriteLine("=== Alışveriş Fişi ===");
            Console.WriteLine($"Toplam: {tutar:C}");
            Console.WriteLine($"İndirim Oranı: %{indirimOrani * 100}");
            Console.WriteLine($"İndirim Tutarı: {indirim:C}");
            Console.WriteLine($"Ödenecek: {odenecek:C}");
            
            Console.WriteLine();
            
            // Null coalescing operator (??)
            string isim = null;
            string kullanilacakIsim = isim ?? "Misafir";
            Console.WriteLine($"Hoş geldin, {kullanilacakIsim}!");
            
            isim = "Ahmet";
            kullanilacakIsim = isim ?? "Misafir";
            Console.WriteLine($"Hoş geldin, {kullanilacakIsim}!");
            
            Console.WriteLine();
            
            // Kısa devre değerlendirme (short-circuit)
            int a = 10;
            int b = 0;
            
            // b sıfır olduğu için ikinci koşul kontrol edilmez
            if (b != 0 && a / b > 5)
            {
                Console.WriteLine("Koşul sağlandı");
            }
            else
            {
                Console.WriteLine("Koşul sağlanmadı (sıfıra bölme engellendi)");
            }
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Basit ve iç içe ternary operator kullanımı
- Null coalescing operator (??) gösterildi
- Short-circuit evaluation ile hata önleme
- Pratik kullanım senaryoları

### Örnek 5: Gerçek Dünya Senaryoları
```csharp
using System;

namespace GercekDunyaOrnekleri
{
    class Program
    {
        static void Main()
        {
            // Örnek 1: Sınav Değerlendirme Sistemi
            Console.WriteLine("=== Sınav Değerlendirme Sistemi ===");
            
            int yazili1 = 70;
            int yazili2 = 85;
            int sozlu = 80;
            
            double ortalama = (yazili1 + yazili2 + sozlu) / 3.0;
            Console.WriteLine($"Yazılı 1: {yazili1}");
            Console.WriteLine($"Yazılı 2: {yazili2}");
            Console.WriteLine($"Sözlü: {sozlu}");
            Console.WriteLine($"Ortalama: {ortalama:F2}");
            
            if (ortalama >= 85)
            {
                Console.WriteLine("Harf Notu: A - Pekiyi");
            }
            else if (ortalama >= 70)
            {
                Console.WriteLine("Harf Notu: B - İyi");
            }
            else if (ortalama >= 60)
            {
                Console.WriteLine("Harf Notu: C - Orta");
            }
            else if (ortalama >= 50)
            {
                Console.WriteLine("Harf Notu: D - Geçer");
            }
            else
            {
                Console.WriteLine("Harf Notu: F - Kaldı");
            }
            
            Console.WriteLine();
            
            // Örnek 2: Araç Kiralama Sistemi
            Console.WriteLine("=== Araç Kiralama Sistemi ===");
            
            int surucu_yasi = 25;
            int ehliyet_yili = 4;
            bool trafik_cezasi = false;
            
            Console.WriteLine($"Yaş: {surucu_yasi}");
            Console.WriteLine($"Ehliyet yılı: {ehliyet_yili}");
            Console.WriteLine($"Trafik cezası: {(trafik_cezasi ? "Var" : "Yok")}");
            
            if (surucu_yasi < 21)
            {
                Console.WriteLine("✗ En az 21 yaşında olmalısınız");
            }
            else if (ehliyet_yili < 2)
            {
                Console.WriteLine("✗ En az 2 yıl ehliyet tecrübesi gerekli");
            }
            else if (trafik_cezasi)
            {
                Console.WriteLine("✗ Aktif trafik cezanız var");
            }
            else
            {
                Console.WriteLine("✓ Araç kiralayabilirsiniz");
                
                // Kiralama fiyatı hesaplama
                int gunlukFiyat;
                if (surucu_yasi < 25)
                    gunlukFiyat = 300;
                else if (surucu_yasi < 30)
                    gunlukFiyat = 250;
                else
                    gunlukFiyat = 200;
                
                Console.WriteLine($"Günlük kiralama ücreti: {gunlukFiyat} TL");
            }
            
            Console.WriteLine();
            
            // Örnek 3: Sezon Belirleme
            Console.WriteLine("=== Mevsim Belirleme ===");
            
            int ayNo = 10;
            string mevsim;
            
            switch (ayNo)
            {
                case 12:
                case 1:
                case 2:
                    mevsim = "Kış";
                    break;
                case 3:
                case 4:
                case 5:
                    mevsim = "İlkbahar";
                    break;
                case 6:
                case 7:
                case 8:
                    mevsim = "Yaz";
                    break;
                case 9:
                case 10:
                case 11:
                    mevsim = "Sonbahar";
                    break;
                default:
                    mevsim = "Geçersiz ay";
                    break;
            }
            
            Console.WriteLine($"Ay: {ayNo}");
            Console.WriteLine($"Mevsim: {mevsim}");
            
            Console.WriteLine();
            
            // Örnek 4: VKİ (Vücut Kitle İndeksi) Hesaplama
            Console.WriteLine("=== VKİ Hesaplama ===");
            
            double kilo = 75;
            double boy = 1.75; // metre
            double vki = kilo / (boy * boy);
            
            Console.WriteLine($"Kilo: {kilo} kg");
            Console.WriteLine($"Boy: {boy} m");
            Console.WriteLine($"VKİ: {vki:F2}");
            
            string durum;
            if (vki < 18.5)
                durum = "Zayıf";
            else if (vki < 25)
                durum = "Normal";
            else if (vki < 30)
                durum = "Fazla kilolu";
            else
                durum = "Obez";
            
            Console.WriteLine($"Durum: {durum}");
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Sınav değerlendirme sistemi
- Araç kiralama yeterliliği kontrolü
- Mevsim belirleme (switch-case)
- VKİ hesaplama ve değerlendirme
- Gerçek hayat senaryolarında kontrol yapılarının kullanımı

## Alıştırmalar

1. Kullanıcıdan bir sayı alıp pozitif, negatif veya sıfır olduğunu söyleyen program yazın
2. Bir sayının 3'e ve 5'e tam bölünüp bölünmediğini kontrol eden program yazın
3. 0-100 arası bir nota göre harf notu veren program yazın
4. Basit bir ATM menüsü oluşturun (switch-case ile)
5. Üç sayının en büyüğünü bulan program yazın

## Önemli Notlar

- if parantezleri zorunludur: `if (koşul)`
- Tek satırlık kod için süslü parantez opsiyoneldir ama önerilir
- switch-case'de break unutulmamalıdır
- default bloğu her zaman son sırada olmalıdır
- Ternary operator sadece basit durumlar için kullanılmalıdır

## Ek Kaynaklar

- [C# if-else](https://docs.microsoft.com/tr-tr/dotnet/csharp/language-reference/statements/selection-statements)
- [C# switch-case](https://docs.microsoft.com/tr-tr/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement)

## Sonraki Hafta

Hafta 4'te döngüler (for, while, foreach) konusunu işleyeceğiz.
