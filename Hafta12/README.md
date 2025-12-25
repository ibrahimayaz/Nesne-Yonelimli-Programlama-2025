# Hafta12 — Soyutlama (Abstraction)

---

## Teorik Bilgi

- Soyutlama; gereksiz detayları saklayıp, gerekli arayüzü ve davranışı öne çıkarmaktır. Kullanıcı “ne yapacağını” bilir, “nasıl”ını bilmek zorunda değildir.
- C#’ta soyutlama için iki temel araç: `abstract` sınıflar (kısmi uygulama + zorunlu üyeler) ve `interface` (sadece sözleşme). Bir sınıf birden çok arayüzü uygulayabilir, tek bir sınıftan türeyebilir.
- `abstract` sınıflar örneklenemez; en az bir `abstract` üye içerir. Türeyenler bu üyeleri `override` etmek zorundadır.
- Arayüzler varsayılan olarak public sözleşme tanımlar; uygulayan sınıf tüm üyeleri public olarak sağlamak zorundadır.
- Soyutlama, bağımlılıkları azaltır ve değişimin etkisini sınırlar: Kod, somut sınıf yerine soyut tipe (interface/abstract base) bağlı olur.

---

## 5 Basit Soyutlama Örneği

### 1) Basit Abstract Sınıf
```csharp
abstract class Sekil
{
	public abstract double Alan();
}

class Kare : Sekil
{
	public double Kenar { get; }
	public Kare(double kenar) => Kenar = kenar;
	public override double Alan() => Kenar * Kenar;
}

Sekil s = new Kare(3);
Console.WriteLine(s.Alan());
```

### 2) Arayüz ile Sözleşme
```csharp
interface IOdeme
{
	void Ode(decimal tutar);
}

class KrediKartiOdemesi : IOdeme
{
	public void Ode(decimal tutar) => Console.WriteLine($"KK ile {tutar:C}");
}

class HavaleOdemesi : IOdeme
{
	public void Ode(decimal tutar) => Console.WriteLine($"Havale ile {tutar:C}");
}

void OdemeYap(IOdeme odeme, decimal tutar) => odeme.Ode(tutar);

OdemeYap(new KrediKartiOdemesi(), 150);
OdemeYap(new HavaleOdemesi(), 200);
```

### 3) Abstract Özellik ve Ortak Davranış
```csharp
abstract class Depo
{
	public abstract int Kapasite { get; set; }

	public void Yazdir() => Console.WriteLine($"Kapasite: {Kapasite}");
}

class HafizaDeposu : Depo
{
	public override int Kapasite { get; set; } = 256; // GB
}

class BulutDeposu : Depo
{
	public override int Kapasite { get; set; } = 1024;
}

Depo[] depolar = { new HafizaDeposu(), new BulutDeposu() };
foreach (var d in depolar) d.Yazdir();
```

### 4) Kısmi Uygulama + Zorunlu Üye
```csharp
abstract class Raporlayici
{
	public void Calistir()
	{
		Baslat();
		RaporUret();
		Bitir();
	}

	protected virtual void Baslat() => Console.WriteLine("Hazırlanıyor...");
	protected abstract void RaporUret();
	protected virtual void Bitir() => Console.WriteLine("Bitti.");
}

class PdfRaporlayici : Raporlayici
{
	protected override void RaporUret() => Console.WriteLine("PDF üretildi");
}

new PdfRaporlayici().Calistir();
```

### 5) Arayüzle Bağımlılığı Azaltma (Injection)
```csharp
interface IMesajGonderici
{
	void Gonder(string alici, string icerik);
}

class EpostaGonderici : IMesajGonderici
{
	public void Gonder(string alici, string icerik)
		=> Console.WriteLine($"E-posta -> {alici}: {icerik}");
}

class SmsGonderici : IMesajGonderici
{
	public void Gonder(string alici, string icerik)
		=> Console.WriteLine($"SMS -> {alici}: {icerik}");
}

class BildirimServisi
{
	private readonly IMesajGonderici _gonderici;
	public BildirimServisi(IMesajGonderici gonderici) => _gonderici = gonderici;
	public void Bilgilendir(string alici, string mesaj) => _gonderici.Gonder(alici, mesaj);
}

var servis = new BildirimServisi(new SmsGonderici());
servis.Bilgilendir("555-000", "Kodunuz 1234");
```

---

## Özet İpuçları
- Somut sınıf yerine soyut tipe (interface/abstract base) bağımlı olun; değişimi sınırlayın.
- `abstract` sınıflar ortak davranış + zorunlu üyeler sağlar; arayüzler yalnızca sözleşme verir.
- Kısmi şablonlar için `abstract` + `virtual` kombinasyonu, bağımlılık enjeksiyonu için arayüzler tercih edin.

---

## Ek: 5 Basit Örnek (Farklı Senaryolar)

### 1) Abstract Taban Sınıf: Arac
```csharp
abstract class Arac
{
	public abstract void Calistir();
	public void Dur() => Console.WriteLine("Araç durdu.");
}

class Otomobil : Arac
{
	public override void Calistir() => Console.WriteLine("Otomobil çalıştı.");
}

class Otobus : Arac
{
	public override void Calistir() => Console.WriteLine("Otobüs çalıştı.");
}

Arac a1 = new Otomobil();
Arac a2 = new Otobus();
a1.Calistir();
a2.Calistir();
a1.Dur();
```

### 2) Arayüz ile Basit Selamlama
```csharp
interface ISelamlayici
{
	void SelamVer(string ad);
}

class BasitSelamlayici : ISelamlayici
{
	public void SelamVer(string ad) => Console.WriteLine($"Merhaba, {ad}!");
}

ISelamlayici s = new BasitSelamlayici();
s.SelamVer("Ayşe");
```

### 3) Abstract Özellik + Virtual Davranış
```csharp
abstract class Calisan
{
	public string Ad { get; }
	protected Calisan(string ad) => Ad = ad;
	public abstract decimal Maas { get; }
	public virtual string Unvan => "Calisan";
	public void Yazdir() => Console.WriteLine($"{Unvan} {Ad} - Maas: {Maas:C}");
}

class Muhendis : Calisan
{
	public Muhendis(string ad) : base(ad) { }
	public override decimal Maas => 40000m;
	public override string Unvan => "Muhendis";
}

class Stajyer : Calisan
{
	public Stajyer(string ad) : base(ad) { }
	public override decimal Maas => 10000m;
}

Calisan[] ekip = { new Muhendis("Ayşe"), new Stajyer("Ali") };
foreach (var c in ekip) c.Yazdir();
```

### 4) Çoklu Arayüz Uygulaması
```csharp
interface IHareketli { void HareketEt(double km); }
interface IUcabilen { void UcusBaslat(); void UcusBitir(); }

class Drone : IHareketli, IUcabilen
{
	public void HareketEt(double km) => Console.WriteLine($"Drone {km} km ilerledi.");
	public void UcusBaslat() => Console.WriteLine("Uçuş başladı.");
	public void UcusBitir() => Console.WriteLine("Uçuş bitti.");
}

IUcabilen ucan = new Drone();
ucan.UcusBaslat();
((IHareketli)ucan).HareketEt(2.5);
ucan.UcusBitir();
```

### 5) Şablon Metodu (Template Method) ile İş Akışı
```csharp
abstract class VeriIsleyici
{
	public void Calistir()
	{
		Baglan();
		var veri = Getir();
		Isle(veri);
		Kapat();
	}

	protected virtual void Baglan() => Console.WriteLine("Bağlanıldı.");
	protected abstract string Getir();
	protected abstract void Isle(string veri);
	protected virtual void Kapat() => Console.WriteLine("Bağlantı kapatıldı.");
}

class ApiIsleyici : VeriIsleyici
{
	protected override string Getir() => "api-verisi";
	protected override void Isle(string veri) => Console.WriteLine($"Veri işlendi: {veri}");
}

new ApiIsleyici().Calistir();
```