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
        get {return _fiyat;}
        set
        {
            if (value < 0){
                Console.WriteLine("Fiyat negatif olamaz.");
            }else{
                _fiyat = value;
            }
        }
    }

    public int Stok { get; set; }

    public decimal ToplamDeger{
        get{
            return Fiyat*Stok;
        }
    }

    public Urun(string ad, decimal fiyat, int stok)
    {
        Ad = ad;
        Fiyat = fiyat; 
        Stok = stok;
    }

    public void StokEkle(int miktar)
    {
        if (miktar <= 0){
            Console.WriteLine("Miktar pozitif olmalı.");
        }else{
            Stok += miktar;
        }
    }

    public bool StokCikar(int miktar)
    {
        if (miktar <= 0){
            Console.WriteLine("Miktar pozitif olmalı.");
            return false;
        }else if(miktar > Stok){
            return false;
        }else{
            Stok -= miktar;
            return true;
        }   
    }
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
    }
}
```

## Özet

- `private set`: Dışarıdan doğrudan değişimi engeller, değişim yalnızca sınıf içi metotlarla.
- Doğrulamalı setter: Geçersiz değerleri daha içeri girmeden engeller.
- Hesaplanan property: Alanı dışarı açmadan, türetilmiş bilgiyi sunar.
- `init`-only: Nesne oluşturulurken atanır ve sonra değiştirilemez — daha güvenli model.
