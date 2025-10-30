# Örnek 2 — Properties ve Doğrulama (Validation)

Amaç: C# properties kullanarak daha temiz bir API oluşturmak ve değer doğrulaması yapmak.

Sınıf: `BankaHesabi`

Özellikler:
- Bakiyeyi (`Balance`) sadece okunabilir hale getiririz.
- Para yatırma/çekme metotları dolaşımı ve doğrulamayı içerir.

Kod:

```csharp
using System;

public class BankaHesabi
{
    private decimal bakiye;

    public BankaHesabi(decimal baslangicBakiyesi)
    {
        if (baslangicBakiyesi < 0){
            Console.WriteLine("Başlangıç bakiyesi negatif olamaz.");
        }else{
            bakiye = baslangicBakiyesi;
        }
    }

    // Salt okunur property — dışarıya sadece okunabilir
    public decimal Bakiye{
        get{
            return bakiye;
        }
    };

    public void ParaYatir(decimal miktar)
    {
        if (miktar <= 0){
            Console.WriteLine("Yatırılan tutar pozitif olmalı.");
        }else{
            bakiye += miktar;
        }
    }

    public void ParaCek(decimal miktar)
    {
        if (miktar <= 0){
            Console.WriteLine("Çekilen tutar pozitif olmalı.");
        }
        else if (miktar > bakiye){
            Console.WriteLine("Yetersiz bakiye.");
        }else{
            balance -= amount;
        }
    }
}

// Kullanım örneği
public class Program
{
    public static void Main()
    {
        var h = new BankaHesabi(1000m);
        Console.WriteLine($"Başlangıç: {h.Balance}");
        h.ParaYatir(250);
        Console.WriteLine($"Yatırma sonrası: {h.Balance}");
        h.ParaCek(2000);
        
    }
}
```

Notlar:
- `Balance` property aracılığıyla dış katmanlar bakiyeyi okuyabilir ama doğrudan değiştiremez.
- Bütün doğrulama sınıf içindeki metotlarda yapılır; bu, tutarlı durum sağlar.
