# Örnek 4 — Properties ile Kapsülleme

Bu örnekte kapsüllemeyi C# properties (özellikler) üzerinden göstereceğiz: otomatik özellikler, `private set`, doğrulamalı setter, hesaplanan (read-only) özellik ve `init`-only özellikler.

## 1) Doğrulamalı setter + private set

Aşağıdaki `Urun` sınıfında:
- `Fiyat` için doğrulama setter içinde yapılır (negatif olamaz).
- `Stok` dışarıdan değiştirilemesin diye `private set` kullanılır, değişiklik sadece sınıf içindeki metotlarla yapılır.
- `ToplamDeger` hesaplanan read-only bir property’dir.

```csharp
using System;

public class Urun
{
    private decimal _fiyat; // doğrulamayı burada kontrol edeceğiz

    public string Ad { get; set; } = string.Empty; // otomatik property

    public decimal Fiyat
    {
        get => _fiyat;
        set
        {
            if (value < 0)
                throw new ArgumentException("Fiyat negatif olamaz.");
            _fiyat = value;
        }
    }

    public int Stok { get; private set; } // dışarıdan set edilemez

    public decimal ToplamDeger => Fiyat * Stok; // hesaplanan (salt okunur)

    public Urun(string ad, decimal fiyat, int stok)
    {
        Ad = ad;
        Fiyat = fiyat; // doğrulama devreye girer
        Stok = Math.Max(0, stok);
    }

    public void StokEkle(int miktar)
    {
        if (miktar <= 0) throw new ArgumentException("Miktar pozitif olmalı.");
        Stok += miktar;
    }

    public bool StokCikar(int miktar)
    {
        if (miktar <= 0) throw new ArgumentException("Miktar pozitif olmalı.");
        if (miktar > Stok) return false;
        Stok -= miktar;
        return true;
    }
}
```

## 2) init-only özellikler (oluşturulurken bir kez atanır)

C# 9+ ile gelen `init` erişimcisi, nesne oluşturulurken değer atayıp sonrasında değiştirilmesini engeller. Bu da kapsülleme ve değişmezlik (immutability) için kullanışlıdır.

```csharp
public class Ogrenci
{
    public int Id { get; init; }            // yalnızca nesne oluşturulurken set edilebilir
    public string Ad { get; init; } = "";  // init-only

    private int _yas;
    public int Yas
    {
        get => _yas;
        set
        {
            if (value < 0 || value > 120)
                throw new ArgumentOutOfRangeException(nameof(Yas), "Geçersiz yaş aralığı.");
            _yas = value;
        }
    }

    public bool ResitMi => Yas >= 18; // hesaplanan property
}
```

Kullanım:

```csharp
public class Program
{
    public static void Main()
    {
        var urun = new Urun("Kulaklık", 499.90m, 10);
        Console.WriteLine($"{urun.Ad} — Fiyat: {urun.Fiyat}, Stok: {urun.Stok}, Toplam: {urun.ToplamDeger}");
        urun.StokEkle(5);
        Console.WriteLine($"Yeni stok: {urun.Stok}, Toplam: {urun.ToplamDeger}");

        var ogr = new Ogrenci { Id = 101, Ad = "Ayşe", Yas = 20 }; // Id ve Ad sadece burada set edilebilir
        Console.WriteLine($"Öğrenci: {ogr.Id} - {ogr.Ad}, Reşit mi? {ogr.ResitMi}");

        // Aşağıdaki satır derlenir ama çalışma anında hataya sebep olur çünkü doğrulama yakalar
        // urun.Fiyat = -10; // ArgumentException

        // Aşağıdaki satır derlenmez (init-only):
        // ogr.Ad = "Zeynep"; // CS8852: init-only property'ye init dışında atama yapılamaz
    }
}
```

## Özet

- `private set`: Dışarıdan doğrudan değişimi engeller, değişim yalnızca sınıf içi metotlarla.
- Doğrulamalı setter: Geçersiz değerleri daha içeri girmeden engeller.
- Hesaplanan property: Alanı dışarı açmadan, türetilmiş bilgiyi sunar.
- `init`-only: Nesne oluşturulurken atanır ve sonra değiştirilemez — daha güvenli model.
