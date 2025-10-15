# Hafta 8: Kapsülleme ve Erişim Belirleyiciler

## Teorik Bilgiler

### Encapsulation (Kapsülleme) Nedir?
Kapsülleme, verileri ve bu verileri işleyen metotları bir arada tutup, dışarıdan doğrudan erişimi engelleyen OOP prensibidir.

**Faydaları:**
- Veri güvenliği
- Kod bakımı kolaylığı
- Esneklik
- Veri bütünlüğü

### Erişim Belirleyiciler (Access Modifiers)
- **public:** Her yerden erişilebilir
- **private:** Sadece kendi sınıfından erişilebilir
- **protected:** Kendi sınıfı ve türetilen sınıflardan erişilebilir
- **internal:** Aynı assembly içinden erişilebilir
- **protected internal:** protected veya internal
- **private protected:** protected ve internal (aynı assembly)

### Best Practices
- Fieldlar private olmalı
- Propertyler public yapılmalı
- Metotlar gerektiğinde public
- Helper metotlar private

## Örnekler

### Örnek 1: Temel Encapsulation
```csharp
using System;

namespace EncapsulationOrnegi
{
    class BankaHesap
    {
        // Private fields - dışarıdan erişilemez
        private string hesapNo;
        private double bakiye;
        private string sifre;
        
        // Public properties - kontrollü erişim
        public string HesapNo 
        { 
            get { return hesapNo; }
            private set { hesapNo = value; } // Sadece sınıf içinden set edilebilir
        }
        
        public double Bakiye 
        { 
            get { return bakiye; }
            private set { bakiye = value; }
        }
        
        // Constructor
        public BankaHesap(string hesapNo, string sifre, double ilkBakiye = 0)
        {
            this.HesapNo = hesapNo;
            this.sifre = sifre;
            this.Bakiye = ilkBakiye;
        }
        
        // Public metodlar - işlemler için
        public bool ParaYatir(double miktar, string sifre)
        {
            if (!SifreDogrula(sifre))
            {
                Console.WriteLine("Hatalı şifre!");
                return false;
            }
            
            if (miktar <= 0)
            {
                Console.WriteLine("Geçersiz miktar!");
                return false;
            }
            
            Bakiye += miktar;
            Console.WriteLine($"{miktar:C} yatırıldı. Yeni bakiye: {Bakiye:C}");
            return true;
        }
        
        public bool ParaCek(double miktar, string sifre)
        {
            if (!SifreDogrula(sifre))
            {
                Console.WriteLine("Hatalı şifre!");
                return false;
            }
            
            if (miktar > Bakiye)
            {
                Console.WriteLine("Yetersiz bakiye!");
                return false;
            }
            
            Bakiye -= miktar;
            Console.WriteLine($"{miktar:C} çekildi. Kalan bakiye: {Bakiye:C}");
            return true;
        }
        
        // Private metot - sadece sınıf içinden kullanılır
        private bool SifreDogrula(string girilenSifre)
        {
            return this.sifre == girilenSifre;
        }
        
        public void SifreDegistir(string eskiSifre, string yeniSifre)
        {
            if (SifreDogrula(eskiSifre))
            {
                sifre = yeniSifre;
                Console.WriteLine("Şifre değiştirildi.");
            }
            else
            {
                Console.WriteLine("Eski şifre hatalı!");
            }
        }
    }
    
    class Program
    {
        static void Main()
        {
            BankaHesap hesap = new BankaHesap("TR123456", "1234", 1000);
            
            Console.WriteLine($"Hesap No: {hesap.HesapNo}");
            Console.WriteLine($"Bakiye: {hesap.Bakiye:C}");
            
            // hesap.bakiye = 999999; // HATA: private field'a erişilemez
            // hesap.Bakiye = 999999; // HATA: private set
            
            Console.WriteLine();
            hesap.ParaYatir(500, "1234");
            hesap.ParaCek(200, "1234");
            hesap.ParaCek(200, "9999"); // Hatalı şifre
            
            Console.WriteLine();
            hesap.SifreDegistir("1234", "5678");
            hesap.ParaYatir(100, "5678");
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Private fieldlar ile veri gizleme
- Public propertyler ile kontrollü okuma
- Private setter ile sadece sınıf içinden değiştirme
- Private metotlarla iç işlemler

### Örnek 2: Erişim Belirleyiciler
```csharp
using System;

namespace AccessModifiers
{
    class Calisan
    {
        // public - her yerden erişilebilir
        public string Ad;
        public string Soyad;
        
        // private - sadece bu sınıftan erişilebilir
        private double maas;
        private string tcNo;
        
        // protected - bu sınıf ve türetilen sınıflardan erişilebilir
        protected int izinGunu;
        
        // internal - aynı projeden erişilebilir
        internal string departman;
        
        // Public property ile private field'a erişim
        public double Maas
        {
            get { return maas; }
            set
            {
                if (value >= 0)
                    maas = value;
            }
        }
        
        // Constructor
        public Calisan(string ad, string soyad, double maas, string tcNo)
        {
            this.Ad = ad;
            this.Soyad = soyad;
            this.Maas = maas;
            this.tcNo = tcNo;
            this.izinGunu = 14; // Başlangıç değeri
        }
        
        // Public metot
        public void BilgiGoster()
        {
            Console.WriteLine($"{Ad} {Soyad}");
            Console.WriteLine($"Maaş: {Maas:C}");
            Console.WriteLine($"İzin Günü: {izinGunu}");
            MaskedTCGoster(); // Private metot çağrısı
        }
        
        // Private metot
        private void MaskedTCGoster()
        {
            string masked = "***" + tcNo.Substring(tcNo.Length - 3);
            Console.WriteLine($"TC: {masked}");
        }
        
        // Protected metot
        protected void IzinEkle(int gun)
        {
            izinGunu += gun;
            Console.WriteLine($"{gun} gün izin eklendi. Toplam: {izinGunu}");
        }
        
        // Internal metot
        internal void DepartmanDegistir(string yeniDepartman)
        {
            departman = yeniDepartman;
            Console.WriteLine($"Departman değiştirildi: {departman}");
        }
    }
    
    class Mudur : Calisan
    {
        public Mudur(string ad, string soyad, double maas, string tcNo) 
            : base(ad, soyad, maas, tcNo)
        {
            // Protected field'a erişebiliriz
            izinGunu = 30; // Müdürlerin daha fazla izni var
        }
        
        public void EkIzinVer(int gun)
        {
            // Protected metoda erişebiliriz
            IzinEkle(gun);
        }
    }
    
    class Program
    {
        static void Main()
        {
            Calisan calisan = new Calisan("Ahmet", "Yılmaz", 10000, "12345678901");
            
            // Public erişim
            Console.WriteLine($"Ad: {calisan.Ad}");
            calisan.BilgiGoster();
            
            // calisan.maas = 20000; // HATA: private
            // calisan.tcNo = "999"; // HATA: private
            // calisan.izinGunu = 30; // HATA: protected
            
            // Property ile erişim
            calisan.Maas = 12000; // OK
            
            Console.WriteLine();
            
            Mudur mudur = new Mudur("Ayşe", "Demir", 20000, "98765432109");
            mudur.BilgiGoster();
            mudur.EkIzinVer(5);
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Tüm erişim belirleyici türleri
- Kalıtımda protected kullanımı
- Internal ile assembly erişimi
- Her seviyenin kullanım amacı

### Örnek 3: Property ile Validasyon
```csharp
using System;
using System.Text.RegularExpressions;

namespace PropertyValidation
{
    class Kullanici
    {
        private string email;
        private string kullaniciAdi;
        private string sifre;
        private int yas;
        
        public string Email
        {
            get { return email; }
            set
            {
                if (EmailGecerliMi(value))
                    email = value;
                else
                    throw new ArgumentException("Geçersiz email adresi!");
            }
        }
        
        public string KullaniciAdi
        {
            get { return kullaniciAdi; }
            set
            {
                if (value.Length >= 3 && value.Length <= 20)
                    kullaniciAdi = value;
                else
                    throw new ArgumentException("Kullanıcı adı 3-20 karakter olmalı!");
            }
        }
        
        public string Sifre
        {
            set // Sadece set - güvenlik için get yok
            {
                if (SifreGucluMu(value))
                    sifre = value;
                else
                    throw new ArgumentException("Şifre en az 8 karakter, 1 büyük harf, 1 rakam içermeli!");
            }
        }
        
        public int Yas
        {
            get { return yas; }
            set
            {
                if (value >= 18 && value <= 120)
                    yas = value;
                else
                    throw new ArgumentException("Yaş 18-120 arasında olmalı!");
            }
        }
        
        // Constructor
        public Kullanici(string email, string kullaniciAdi, string sifre, int yas)
        {
            Email = email; // Property üzerinden validasyon yapılır
            KullaniciAdi = kullaniciAdi;
            Sifre = sifre;
            Yas = yas;
        }
        
        private bool EmailGecerliMi(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
        
        private bool SifreGucluMu(string sifre)
        {
            if (sifre.Length < 8) return false;
            
            bool buyukHarf = false;
            bool rakam = false;
            
            foreach (char c in sifre)
            {
                if (char.IsUpper(c)) buyukHarf = true;
                if (char.IsDigit(c)) rakam = true;
            }
            
            return buyukHarf && rakam;
        }
        
        public bool GirisYap(string girilenSifre)
        {
            return sifre == girilenSifre;
        }
        
        public void BilgiGoster()
        {
            Console.WriteLine($"Kullanıcı: {KullaniciAdi}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Yaş: {Yas}");
        }
    }
    
    class Program
    {
        static void Main()
        {
            try
            {
                Kullanici kullanici = new Kullanici(
                    "ahmet@example.com",
                    "ahmet123",
                    "Sifre123",
                    25
                );
                
                kullanici.BilgiGoster();
                
                Console.WriteLine();
                
                // Geçersiz email denemesi
                //Kullanici hatali = new Kullanici("hataliemail", "user", "Pass123", 25);
                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Property setter'da veri doğrulama
- Email ve şifre validasyonu
- Write-only property (Sifre)
- Exception fırlatma

### Örnek 4: Read-Only ve Immutable Sınıf
```csharp
using System;

namespace ImmutableClass
{
    // Immutable (Değiştirilemez) sınıf
    class Nokta
    {
        // Read-only fields - sadece constructor'da atanabilir
        private readonly int x;
        private readonly int y;
        
        // Read-only properties
        public int X { get { return x; } }
        public int Y { get { return y; } }
        
        // Hesaplanmış read-only property
        public double OrijineUzaklik
        {
            get { return Math.Sqrt(x * x + y * y); }
        }
        
        // Constructor - tek değer atama yeri
        public Nokta(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        // Değer değiştirme yerine yeni nesne döndür
        public Nokta Tasi(int deltaX, int deltaY)
        {
            return new Nokta(x + deltaX, y + deltaY);
        }
        
        public void BilgiGoster()
        {
            Console.WriteLine($"Nokta({X}, {Y})");
            Console.WriteLine($"Orijine uzaklık: {OrijineUzaklik:F2}");
        }
    }
    
    class Program
    {
        static void Main()
        {
            Nokta nokta1 = new Nokta(3, 4);
            nokta1.BilgiGoster();
            
            // nokta1.X = 10; // HATA: read-only
            
            // Taşıma yeni nesne oluşturur
            Nokta nokta2 = nokta1.Tasi(2, 3);
            
            Console.WriteLine("\nTaşıma sonrası:");
            Console.WriteLine("Orjinal nokta:");
            nokta1.BilgiGoster();
            Console.WriteLine("\nYeni nokta:");
            nokta2.BilgiGoster();
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Readonly field kullanımı
- Immutable (değiştirilemez) sınıf
- Değişiklik yerine yeni nesne oluşturma
- Thread-safe yapı

### Örnek 5: Lazy Loading ve Backing Field
```csharp
using System;

namespace LazyLoading
{
    class RaporOlusturucu
    {
        private string raporIcerigi; // Backing field
        private bool raporOlusturuldu;
        
        public string Ad { get; set; }
        public DateTime OlusturmaTarihi { get; private set; }
        
        // Lazy loading property
        public string RaporIcerigi
        {
            get
            {
                if (!raporOlusturuldu)
                {
                    RaporOlustur();
                }
                return raporIcerigi;
            }
        }
        
        public RaporOlusturucu(string ad)
        {
            Ad = ad;
            OlusturmaTarihi = DateTime.Now;
            raporOlusturuldu = false;
            Console.WriteLine($"Rapor oluşturucu hazırlandı: {Ad}");
        }
        
        private void RaporOlustur()
        {
            Console.WriteLine("Rapor oluşturuluyor...");
            System.Threading.Thread.Sleep(1000); // Simülasyon
            
            raporIcerigi = $"=== {Ad} Raporu ===\n";
            raporIcerigi += $"Tarih: {OlusturmaTarihi:dd.MM.yyyy HH:mm}\n";
            raporIcerigi += "İçerik: Bu bir örnek rapordur.\n";
            raporIcerigi += "Veriler işlendi ve analiz edildi.\n";
            
            raporOlusturuldu = true;
            Console.WriteLine("Rapor oluşturuldu!");
        }
    }
    
    class Program
    {
        static void Main()
        {
            RaporOlusturucu rapor = new RaporOlusturucu("Aylık Satış Raporu");
            Console.WriteLine("Rapor nesnesi oluşturuldu ama henüz içerik yok.\n");
            
            Console.WriteLine("Bekliyor...\n");
            System.Threading.Thread.Sleep(2000);
            
            // İlk erişimde rapor oluşturulur
            Console.WriteLine("Rapora erişiliyor...");
            Console.WriteLine(rapor.RaporIcerigi);
            
            Console.WriteLine("\n2. erişim (cache'den):");
            Console.WriteLine(rapor.RaporIcerigi);
            
            Console.ReadLine();
        }
    }
}
```
**Açıklama:**
- Lazy loading pattern
- Backing field kullanımı
- İlk erişimde hesaplama
- Performans optimizasyonu

## Alıştırmalar

1. `KrediKarti` sınıfı yapın (kart numarası maskeli gösterilsin)
2. `Ogrenci` sınıfına yaş validasyonu ekleyin (18-65 arası)
3. `SifreYoneticisi` sınıfı yapın (şifre hash'lensin)
4. Immutable `Tarih` sınıfı oluşturun
5. `UrunStok` sınıfında lazy loading kullanın

## Önemli Notlar

- **Encapsulation = Data Hiding + Abstraction**
- Private fieldlar, public propertyler kullanın
- Validasyonu property setter'da yapın
- Readonly fieldlar sadece constructor'da atanır
- Private metotlar iç işlemler için kullanılır
- Gereksiz yere public yapmayın

## Ek Kaynaklar

- [C# Encapsulation](https://docs.microsoft.com/tr-tr/dotnet/csharp/programming-guide/classes-and-structs/encapsulation)
- [Access Modifiers](https://docs.microsoft.com/tr-tr/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers)

## Sonraki Hafta

Hafta 9'da kalıtım (inheritance) konusunu işleyeceğiz.
