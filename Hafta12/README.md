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
	public abstract int Kapasite { get; }

	public void Yazdir() => Console.WriteLine($"Kapasite: {Kapasite}");
}

class HafizaDeposu : Depo
{
	public override int Kapasite { get; } = 256; // GB
}

class BulutDeposu : Depo
{
	public override int Kapasite { get; } = 1024;
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