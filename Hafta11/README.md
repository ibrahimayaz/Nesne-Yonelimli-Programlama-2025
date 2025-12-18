# Hafta11 — Çok Biçimlilik (Polimorfizm)

---

## Teorik Bilgi

- Polimorfizm, “aynı arayüz → farklı davranış” ilkesidir. Taban türden (sınıf ya da arayüz) bakıldığında çağrılan üye, çalışma zamanında gerçek tipe göre davranır.
- Çalışma zamanı polimorfizmi `virtual/override`, `abstract` üyeler ve `interface` uygulamalarıyla sağlanır. Çağrı dinamik olarak bağlanır (dynamic dispatch).
- Derleme zamanı “çok biçimlilik” olarak anılan metot aşırı yükleme (overload) ayrı bir konudur; imza farkıyla aynı isimde birden çok metot tanımlamaktır. Override ise imza aynı kalıp davranışı değiştirmektir.
- `new` anahtar sözcüğüyle üye gizleme yapılır; bu polimorfik değildir (statik bağlama). Sanal bağlama için `virtual/override` gerekir.
- Taban tür referansları (`Base b = new Derived();`) polimorfik kullanımın temelidir; koleksiyonlarda ve metot parametrelerinde sıkça kullanılır.

Basit söz dizimi hatırlatma:

```csharp
class Base
{
	public virtual void Calistir() => Console.WriteLine("Base");
}

class Derived : Base
{
	public override void Calistir() => Console.WriteLine("Derived");
}
```

---

## 5 Basit Polimorfizm Örneği

### 1) virtual/override ile Temel Polimorfizm
```csharp
class Sekil
{
	public virtual void Ciz() => Console.WriteLine("Sekil çiziliyor...");
}

class Daire : Sekil
{
	public override void Ciz() => Console.WriteLine("Daire çizildi");
}

class Kare : Sekil
{
	public override void Ciz() => Console.WriteLine("Kare çizildi");
}

Sekil[] sekiller = { new Sekil(), new Daire(), new Kare() };
foreach (var s in sekiller) s.Ciz();
```

### 2) Abstract Üye ile Zorunlu Override
```csharp
abstract class Odeme
{
	public abstract void Ode(decimal tutar);
}

class KrediKarti : Odeme
{
	public override void Ode(decimal tutar)
		=> Console.WriteLine($"Kredi kartı ile {tutar:C} ödendi");
}

class Havale : Odeme
{
	public override void Ode(decimal tutar)
		=> Console.WriteLine($"Havale ile {tutar:C} ödendi");
}

Odeme[] odemeler = { new KrediKarti(), new Havale() };
foreach (var o in odemeler) o.Ode(100);
```

### 3) Arayüz (interface) Tabanlı Polimorfizm
```csharp
interface ILogger
{
	void Log(string mesaj);
}

class ConsoleLogger : ILogger
{
	public void Log(string mesaj) => Console.WriteLine($"[Console] {mesaj}");
}

class FileLogger : ILogger
{
	public void Log(string mesaj) => Console.WriteLine($"[File] {mesaj}");
}

void Calistir(ILogger logger)
{
	logger.Log("Sistem başladı");
}

Calistir(new ConsoleLogger());
Calistir(new FileLogger());
```

### 4) new ile Gizleme vs Override Farkı
```csharp
class Yazici
{
	public virtual void Yaz() => Console.WriteLine("Yazici: Yaz()");
}

class RenkliYazici : Yazici
{
	public override void Yaz() => Console.WriteLine("RenkliYazici: Yaz()");
}

class EskiRenkliYazici : Yazici
{
	public new void Yaz() => Console.WriteLine("EskiRenkliYazici: Yaz()");
}

Yazici a = new RenkliYazici();
a.Yaz(); // RenkliYazici: Yaz()  (override → polimorfik)

Yazici b = new EskiRenkliYazici();
b.Yaz(); // Yazici: Yaz()         (new → gizleme, polimorfik değil)
```

### 5) Parametre Üzerinden Polimorfizm (İş Kuralları)
```csharp
abstract class Hayvan
{
	public abstract void SesCikar();
}

class Kopek : Hayvan
{
	public override void SesCikar() => Console.WriteLine("Hav Hav");
}

class Kedi : Hayvan
{
	public override void SesCikar() => Console.WriteLine("Miyav");
}

void Seslendir(Hayvan h)
{
	// Hangi tür geldiğini bilmeden doğru sesi çıkarır
	h.SesCikar();
}

Seslendir(new Kopek());
Seslendir(new Kedi());
```

---

## Özet İpuçları
- Sanal bağlama için `virtual/override` veya `abstract` kullanın; arayüzlerle sözleşmeyi netleştirin.
- Koleksiyonlarda taban tür/arayüz tutup türetilmişleri çalıştırmak polimorfizmin tipik kullanım alanıdır.
- `new` gizlemedir; polimorfik çağrı amacıyla uygun değildir.
- Davranış farklılaştırma gerekiyorsa kalıtım + override; birden çok rol gerekiyorsa arayüz + kompozisyon tercih edin.