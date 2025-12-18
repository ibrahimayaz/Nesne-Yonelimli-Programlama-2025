# Hafta10 — Kalıtım

---

## Teorik Bilgi

- Kalıtım (inheritance), bir sınıfın başka bir sınıftan üyeleri (alan, özellik, metot) devralmasını sağlar. Böylece kod tekrarını azaltır, hiyerarşi kurar ve polimorfizmi mümkün kılar.
- C# tekli sınıf kalıtımını destekler: Bir sınıf yalnızca bir sınıftan türeyebilir; ancak birden fazla arayüzü (`interface`) uygulayabilir.
- İlişki “is-a” şeklindedir: `Kopek` bir `Hayvan`dır.
- Erişim belirleyicileri kalıtımda önemlidir:
  - `public`: Her yerden erişilebilir.
  - `protected`: Yalnızca sınıfın kendisi ve türeyen sınıflardan erişilebilir.
  - `private`: Yalnızca sınıfın içinden erişilebilir.
- Sanal üyeler: `virtual` olarak işaretlenmiş metot/özellikler türeyen sınıflarda `override` edilerek davranış özelleştirilebilir. `base` anahtar sözcüğü taban sınıfın üyelerine erişir.
- `abstract` sınıflar örneklenemez; en az bir `abstract` üye içerir ve türeyen sınıflar bunları `override` etmek zorundadır.
- `sealed` sınıflar/override’lar daha fazla kalıtımı veya yeniden geçersiz kılmayı engeller.

Basit sözdizimi:

```csharp
class Taban
{
	public virtual void Calistir() => Console.WriteLine("Taban çalıştı");
}

class Turemis : Taban
{
	public override void Calistir() => Console.WriteLine("Türemiş çalıştı");
}
```

---

## 5 Basit Kalıtım Örneği

### 1) Basit Kalıtım ve Kullanım
```csharp
// Arac -> Otomobil
class Arac
{
	public string Marka { get; set; } = "Bilinmiyor";
	public void Calistir() => Console.WriteLine($"{Marka} araç çalıştı.");
}

class Otomobil : Arac
{
	public int KapiSayisi { get; set; } = 4;
}

// Kullanım
var oto = new Otomobil { Marka = "Toyota", KapiSayisi = 5 };
oto.Calistir(); // "Toyota araç çalıştı."
Console.WriteLine($"Kapı: {oto.KapiSayisi}");
```

### 2) virtual/override ve Polimorfizm
```csharp
// Sekil -> Daire, Dikdortgen
abstract class Sekil
{
	public abstract double Alan();
}

class Daire : Sekil
{
	public double YariCap { get; }
	public Daire(double r) => YariCap = r;
	public override double Alan() => Math.PI * YariCap * YariCap;
}

class Dikdortgen : Sekil
{
	public double Genislik { get; }
	public double Yukseklik { get; }
	public Dikdortgen(double g, double y) { Genislik = g; Yukseklik = y; }
	public override double Alan() => Genislik * Yukseklik;
}

// Polimorfik kullanım
Sekil[] sekiller = { new Daire(2), new Dikdortgen(3, 4) };
foreach (var s in sekiller)
	Console.WriteLine(s.Alan());
```

### 3) protected Üye ve base Ctor Zinciri
```csharp
// Kisi -> Ogrenci
class Kisi
{
	protected string AdSoyad { get; }
	public Kisi(string adSoyad) => AdSoyad = adSoyad;
}

class Ogrenci : Kisi
{
	public string Numara { get; }
	public Ogrenci(string adSoyad, string numara) : base(adSoyad)
		=> Numara = numara;

	public void Yazdir() => Console.WriteLine($"{AdSoyad} - No: {Numara}");
}

// Kullanım
var ogr = new Ogrenci("Ayşe Yılmaz", "1001");
ogr.Yazdir();
```

### 4) sealed ile Kalıtımı Engelleme
```csharp
class Cihaz
{
	public virtual void Ac() => Console.WriteLine("Cihaz açıldı");
}

sealed class Telefon : Cihaz
{
	public sealed override void Ac() => Console.WriteLine("Telefon açıldı");
}

// Aşağıdaki satır derlenmez (Telefon sealed):
// class AkilliTelefon : Telefon { }
```

### 5) new ile Üye Gizleme (Override Değil)
```csharp
class Yazici
{
	public void Yaz() => Console.WriteLine("Yazici: Yaz()");
}

class RenkliYazici : Yazici
{
	public new void Yaz() => Console.WriteLine("RenkliYazici: Yaz()");
}

// Kullanım farkı
Yazici y1 = new RenkliYazici();
y1.Yaz();            // Yazici: Yaz()  -> (statik bağlama)

var y2 = new RenkliYazici();
y2.Yaz();            // RenkliYazici: Yaz()

// Not: new gizleme yapar; sanal bağlama (polimorfizm) için virtual/override kullanın.
```

---

## Özet İpuçları
- Kod tekrarını azaltmak ve ortak davranışları merkezileştirmek için kalıtım kullanın.
- Çalışma zamanında farklı davranış için `virtual/override` ve gerekirse `abstract` üyeler tercih edin.
- Dışa kapalı ama türetilen sınıflara açık veri/metotlar için `protected` kullanın.
- Kalıtım hiyerarşisini sade tutun; gereksiz derinlikten kaçının.
- Çoklu davranış söz konusuysa sınıf kalıtımı yerine arayüzlerle kompozisyonu da düşünün.