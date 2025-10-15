# Hafta 9: Kalıtım (Inheritance)

## Teorik Bilgiler

### Kalıtım Nedir?
Kalıtım, var olan bir sınıfın özelliklerini ve davranışlarını yeni bir sınıfa aktarma mekanizmasıdır. Kod tekrarını önler ve hiyerarşik ilişkiler kurar.

**Terminoloji:**
- **Base Class (Üst Sınıf/Parent):** Miras veren sınıf
- **Derived Class (Alt Sınıf/Child):** Miras alan sınıf
- **IS-A İlişkisi:** "X bir Y'dir" ilişkisi (Köpek bir Hayvandır)

### Kalıtım Sözdizimi
```csharp
class BaseClass
{
    // Üst sınıf üyeleri
}

class DerivedClass : BaseClass
{
    // Alt sınıf üyeleri + Base sınıf üyeleri
}
```

### base Anahtar Kelimesi
Üst sınıfın üyelerine erişmek için kullanılır.

### Kalıtım Kuralları
- C#'da çoklu kalıtım yoktur (tek bir sınıftan kalıtım)
- Bir sınıf birden fazla interface'den kalıtım alabilir
- Sealed sınıflardan kalıtım alınamaz
- Private üyeler kalıtılmaz, protected kalıtılır

## Örnekler

### Örnek 1: Temel Kalıtım - Hayvan Hiyerarşisi
```csharp
using System;

namespace KalitimOrnegi
{
    // Base (Üst) sınıf
    class Hayvan
    {
        public string Ad { get; set; }
        public int Yas { get; set; }
        public string Renk { get; set; }
        
        public void Yemek()
        {
            Console.WriteLine($"{Ad} yemek yiyor.");
        }
        
        public void Uyumak()
        {
            Console.WriteLine($"{Ad} uyuyor.");
        }
        
        public virtual void SesCikar()
        {
            Console.WriteLine($"{Ad} ses çıkarıyor.");
        }
    }
    
    // Derived (Alt) sınıf - Köpek
    class Kopek : Hayvan
    {
        public string Cins { get; set; }
        
        public override void SesCikar()
        {
            Console.WriteLine($"{Ad} havlıyor: Hav hav!");
        }
        
        public void KuyrukSalla()
        {
            Console.WriteLine($"{Ad} kuyruk sallıyor.");
        }
    }
    
    // Derived (Alt) sınıf - Kedi
    class Kedi : Hayvan
    {
        public bool TirmanabilirMi { get; set; }
        
        public override void SesCikar()
        {
            Console.WriteLine($"{Ad} miyavlıyor: Miyav!");
        }
        
        public void Tirman()
        {
            if (TirmanabilirMi)
                Console.WriteLine($"{Ad} ağaca tırmanıyor.");
            else
                Console.WriteLine($"{Ad} tırmanamıyor.");
        }
    }
    
    // Derived (Alt) sınıf - Kuş
    class Kus : Hayvan
    {
        public bool UcabilirMi { get; set; }
        
        public override void SesCikar()
        {
            Console.WriteLine($"{Ad} ötüyor: Cik cik!");
        }
        
        public void Uc()
        {
            if (UcabilirMi)
                Console.WriteLine($"{Ad} uçuyor.");
            else
                Console.WriteLine($"{Ad} uçamıyor.");
        }
    }
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Köpek ===");
            Kopek kopek = new Kopek();
            kopek.Ad = "Karabaş";
            kopek.Yas = 3;
            kopek.Renk = "Kahverengi";
            kopek.Cins = "Golden Retriever";
            
            kopek.Yemek();        // Base sınıftan
            kopek.Uyumak();       // Base sınıftan
            kopek.SesCikar();     // Override edilmiş
            kopek.KuyrukSalla();  // Kendi metodu
            
            Console.WriteLine();
            Console.WriteLine("=== Kedi ===");
            Kedi kedi = new Kedi();
            kedi.Ad = "Pamuk";
            kedi.Yas = 2;
            kedi.TirmanabilirMi = true;
            
            kedi.Yemek();
            kedi.SesCikar();
            kedi.Tirman();
            
            Console.WriteLine();
            Console.WriteLine("=== Kuş ===");
            Kus kus = new Kus();
            kus.Ad = "Tweety";
            kus.Yas = 1;
            kus.UcabilirMi = true;
            
            kus.SesCikar();
            kus.Uc();
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Hayvan base sınıfı, ortak özellikleri tanımlar
- Köpek, Kedi, Kuş alt sınıfları Hayvan'dan kalıtım alır
- Her alt sınıf kendi özel üyelerini ekler
- `override` ile metotlar yeniden tanımlanır

### Örnek 2: base Anahtar Kelimesi ve Constructor
```csharp
using System;

namespace BaseKeyword
{
    class Calisan
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public double Maas { get; set; }
        
        public Calisan(string ad, string soyad, double maas)
        {
            Ad = ad;
            Soyad = soyad;
            Maas = maas;
            Console.WriteLine("Calisan constructor çağrıldı");
        }
        
        public virtual void BilgiGoster()
        {
            Console.WriteLine($"Ad: {Ad} {Soyad}");
            Console.WriteLine($"Maaş: {Maas:C}");
        }
        
        public virtual double MaasHesapla()
        {
            return Maas;
        }
    }
    
    class Mudur : Calisan
    {
        public double Prim { get; set; }
        public string Departman { get; set; }
        
        // base() ile üst sınıf constructor'ını çağırma
        public Mudur(string ad, string soyad, double maas, double prim, string departman) 
            : base(ad, soyad, maas)
        {
            Prim = prim;
            Departman = departman;
            Console.WriteLine("Mudur constructor çağrıldı");
        }
        
        public override void BilgiGoster()
        {
            base.BilgiGoster(); // Üst sınıf metodunu çağır
            Console.WriteLine($"Prim: {Prim:C}");
            Console.WriteLine($"Departman: {Departman}");
        }
        
        public override double MaasHesapla()
        {
            return base.MaasHesapla() + Prim; // Üst sınıf hesabı + prim
        }
    }
    
    class Muhendis : Calisan
    {
        public string UzmanlikAlani { get; set; }
        public int ProjeSayisi { get; set; }
        
        public Muhendis(string ad, string soyad, double maas, string uzmanlik) 
            : base(ad, soyad, maas)
        {
            UzmanlikAlani = uzmanlik;
            ProjeSayisi = 0;
            Console.WriteLine("Muhendis constructor çağrıldı");
        }
        
        public override void BilgiGoster()
        {
            base.BilgiGoster();
            Console.WriteLine($"Uzmanlık: {UzmanlikAlani}");
            Console.WriteLine($"Proje Sayısı: {ProjeSayisi}");
        }
        
        public override double MaasHesapla()
        {
            double projeBonus = ProjeSayisi * 500;
            return base.MaasHesapla() + projeBonus;
        }
    }
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Müdür Oluşturma ===");
            Mudur mudur = new Mudur("Ahmet", "Yılmaz", 15000, 5000, "IT");
            Console.WriteLine();
            
            mudur.BilgiGoster();
            Console.WriteLine($"Toplam Maaş: {mudur.MaasHesapla():C}");
            
            Console.WriteLine();
            Console.WriteLine("=== Mühendis Oluşturma ===");
            Muhendis muhendis = new Muhendis("Ayşe", "Demir", 12000, "Yazılım");
            muhendis.ProjeSayisi = 3;
            Console.WriteLine();
            
            muhendis.BilgiGoster();
            Console.WriteLine($"Toplam Maaş: {muhendis.MaasHesapla():C}");
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- `base()` ile üst sınıf constructor çağrısı
- `base.MetotAdi()` ile üst sınıf metotlarına erişim
- Constructor zinciri (chain)
- Override metotlarda üst sınıf işlevselliğini genişletme

### Örnek 3: Çok Seviyeli Kalıtım
```csharp
using System;

namespace CokSeviyeliKalitim
{
    // Level 1 - Canlı
    class Canli
    {
        public bool Yasiyormu { get; set; }
        
        public Canli()
        {
            Yasiyormu = true;
        }
        
        public virtual void NefesAl()
        {
            Console.WriteLine("Canlı nefes alıyor.");
        }
    }
    
    // Level 2 - Hayvan (Canlı'dan kalıtım)
    class Hayvan : Canli
    {
        public int BacakSayisi { get; set; }
        
        public override void NefesAl()
        {
            Console.WriteLine("Hayvan nefes alıyor.");
        }
        
        public virtual void Hareket()
        {
            Console.WriteLine("Hayvan hareket ediyor.");
        }
    }
    
    // Level 3 - Memeli (Hayvan'dan kalıtım)
    class Memeli : Hayvan
    {
        public bool SutveriMi { get; set; }
        
        public Memeli()
        {
            SutveriMi = true;
        }
        
        public void SutVer()
        {
            if (SutveriMi)
                Console.WriteLine("Memeli süt veriyor.");
        }
    }
    
    // Level 4 - Köpek (Memeli'den kalıtım)
    class Kopek : Memeli
    {
        public string Cins { get; set; }
        
        public Kopek(string cins)
        {
            Cins = cins;
            BacakSayisi = 4;
        }
        
        public override void Hareket()
        {
            Console.WriteLine("Köpek koşuyor.");
        }
        
        public void Havla()
        {
            Console.WriteLine($"{Cins} havlıyor: Hav hav!");
        }
    }
    
    class Program
    {
        static void Main()
        {
            Kopek kopek = new Kopek("Golden Retriever");
            
            Console.WriteLine($"Cins: {kopek.Cins}");
            Console.WriteLine($"Bacak Sayısı: {kopek.BacakSayisi}");
            Console.WriteLine($"Yaşıyor mu: {kopek.Yasiyormu}");
            Console.WriteLine($"Süt veriyor mu: {kopek.SutveriMi}");
            Console.WriteLine();
            
            // Tüm seviyelerdeki metotlar
            kopek.NefesAl();   // Level 1
            kopek.Hareket();   // Level 2 (override edilmiş)
            kopek.SutVer();    // Level 3
            kopek.Havla();     // Level 4
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Çok seviyeli kalıtım hiyerarşisi
- Her seviye bir öncekine özellik ekler
- Alt sınıf tüm üst sınıfların üyelerine erişebilir

### Örnek 4: protected Erişim Belirleyici
```csharp
using System;

namespace ProtectedOrnegi
{
    class BankaHesap
    {
        protected string hesapNo;      // Sadece bu sınıf ve alt sınıflar
        protected double bakiye;
        private string sifre;          // Sadece bu sınıf
        
        public BankaHesap(string hesapNo, double bakiye, string sifre)
        {
            this.hesapNo = hesapNo;
            this.bakiye = bakiye;
            this.sifre = sifre;
        }
        
        public virtual void BilgiGoster()
        {
            Console.WriteLine($"Hesap No: {hesapNo}");
            Console.WriteLine($"Bakiye: {bakiye:C}");
        }
        
        protected void BakiyeGuncelle(double yeniBackiye)
        {
            bakiye = yeniBackiye;
        }
    }
    
    class VadesizHesap : BankaHesap
    {
        private double gunlukCekimLimiti;
        
        public VadesizHesap(string hesapNo, double bakiye, string sifre, double limit) 
            : base(hesapNo, bakiye, sifre)
        {
            gunlukCekimLimiti = limit;
        }
        
        public void ParaCek(double miktar)
        {
            // protected üyelere erişebiliriz
            if (miktar > gunlukCekimLimiti)
            {
                Console.WriteLine("Günlük çekim limitini aştınız!");
                return;
            }
            
            if (miktar > bakiye)
            {
                Console.WriteLine("Yetersiz bakiye!");
                return;
            }
            
            BakiyeGuncelle(bakiye - miktar); // protected metot
            Console.WriteLine($"{miktar:C} çekildi.");
        }
        
        public override void BilgiGoster()
        {
            base.BilgiGoster();
            Console.WriteLine($"Günlük Çekim Limiti: {gunlukCekimLimiti:C}");
        }
    }
    
    class VadeliHesap : BankaHesap
    {
        private DateTime vadeBaslangic;
        private DateTime vadeBitis;
        private double faizOrani;
        
        public VadeliHesap(string hesapNo, double bakiye, string sifre, int vadeSuresi, double faizOrani) 
            : base(hesapNo, bakiye, sifre)
        {
            vadeBaslangic = DateTime.Now;
            vadeBitis = vadeBaslangic.AddMonths(vadeSuresi);
            this.faizOrani = faizOrani;
        }
        
        public void VadeSonuGetiri()
        {
            double faiz = bakiye * (faizOrani / 100);
            BakiyeGuncelle(bakiye + faiz);
            Console.WriteLine($"Vade sonu faiz: {faiz:C}");
            Console.WriteLine($"Yeni bakiye: {bakiye:C}");
        }
        
        public override void BilgiGoster()
        {
            base.BilgiGoster();
            Console.WriteLine($"Vade Başlangıç: {vadeBaslangic:dd.MM.yyyy}");
            Console.WriteLine($"Vade Bitiş: {vadeBitis:dd.MM.yyyy}");
            Console.WriteLine($"Faiz Oranı: %{faizOrani}");
        }
    }
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Vadesiz Hesap ===");
            VadesizHesap vadesiz = new VadesizHesap("TR123456", 5000, "1234", 2000);
            vadesiz.BilgiGoster();
            Console.WriteLine();
            vadesiz.ParaCek(1500);
            vadesiz.ParaCek(3000); // Limit aşımı
            Console.WriteLine();
            
            Console.WriteLine("=== Vadeli Hesap ===");
            VadeliHesap vadeli = new VadeliHesap("TR987654", 10000, "5678", 12, 15);
            vadeli.BilgiGoster();
            Console.WriteLine();
            vadeli.VadeSonuGetiri();
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- protected field'lar alt sınıflarda kullanılabilir
- Private field'lar sadece kendi sınıfında
- protected metotlar alt sınıflar için yardımcı
- IS-A ilişkisi (VadesizHesap bir BankaHesaptır)

### Örnek 5: Sealed ve virtual Kullanımı
```csharp
using System;

namespace SealedVirtual
{
    class Sekil
    {
        public string Ad { get; set; }
        
        public virtual double AlanHesapla()
        {
            return 0;
        }
        
        public virtual void BilgiGoster()
        {
            Console.WriteLine($"Şekil: {Ad}");
        }
    }
    
    class Dikdortgen : Sekil
    {
        public double Uzunluk { get; set; }
        public double Genislik { get; set; }
        
        public override double AlanHesapla()
        {
            return Uzunluk * Genislik;
        }
        
        public override void BilgiGoster()
        {
            base.BilgiGoster();
            Console.WriteLine($"Uzunluk: {Uzunluk}, Genişlik: {Genislik}");
            Console.WriteLine($"Alan: {AlanHesapla()}");
        }
    }
    
    // Sealed metot - bu metot artık override edilemez
    class Kare : Dikdortgen
    {
        public double Kenar 
        { 
            get { return Uzunluk; }
            set { Uzunluk = Genislik = value; }
        }
        
        public sealed override double AlanHesapla()
        {
            return Kenar * Kenar;
        }
    }
    
    // Sealed class - bu sınıftan kalıtım alınamaz
    sealed class Daire : Sekil
    {
        public double YariCap { get; set; }
        
        public override double AlanHesapla()
        {
            return Math.PI * YariCap * YariCap;
        }
        
        public override void BilgiGoster()
        {
            base.BilgiGoster();
            Console.WriteLine($"Yarıçap: {YariCap}");
            Console.WriteLine($"Alan: {AlanHesapla():F2}");
        }
    }
    
    // class DaireOzel : Daire { } // HATA: Sealed sınıftan kalıtım alınamaz
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Dikdörtgen ===");
            Dikdortgen dikdortgen = new Dikdortgen();
            dikdortgen.Ad = "Dikdörtgen";
            dikdortgen.Uzunluk = 10;
            dikdortgen.Genislik = 5;
            dikdortgen.BilgiGoster();
            
            Console.WriteLine();
            Console.WriteLine("=== Kare ===");
            Kare kare = new Kare();
            kare.Ad = "Kare";
            kare.Kenar = 7;
            kare.BilgiGoster();
            
            Console.WriteLine();
            Console.WriteLine("=== Daire ===");
            Daire daire = new Daire();
            daire.Ad = "Daire";
            daire.YariCap = 5;
            daire.BilgiGoster();
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- virtual: Metot override edilebilir
- sealed metot: Artık override edilemez
- sealed class: Bu sınıftan kalıtım alınamaz
- Kalıtım zincirinde esneklik kontrolü

## Alıştırmalar

1. `Arac` base sınıfından `Araba`, `Motorsiklet` alt sınıfları oluşturun
2. `Urun` sınıfından `Elektronik`, `Giyim` alt sınıfları yapın
3. `Calisan` hiyerarşisi: `Mudur`, `Muhendis`, `Teknisyen`
4. `OdemeSekli` base, `KrediKarti`, `Nakit` alt sınıflar
5. Çok seviyeli: `Cihaz` → `Telefon` → `Akıllıtelefon`

## Önemli Notlar

- C#'da sadece tek bir sınıftan kalıtım alınabilir
- `virtual` olmayan metotlar override edilemez
- `base` ile üst sınıf üyelerine erişilir
- Constructor'lar kalıtılmaz ama çağrılmalıdır
- `protected` üyeler alt sınıflarda görünür
- `sealed` class'tan kalıtım alınamaz

## Ek Kaynaklar

- [C# Inheritance](https://docs.microsoft.com/tr-tr/dotnet/csharp/fundamentals/object-oriented/inheritance)
- [base keyword](https://docs.microsoft.com/tr-tr/dotnet/csharp/language-reference/keywords/base)

## Sonraki Hafta

Hafta 10'da polymorphism (çok biçimlilik) konusunu işleyeceğiz.
