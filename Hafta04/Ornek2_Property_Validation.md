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
    private decimal balance;

    public BankaHesabi(decimal initial)
    {
        if (initial < 0) throw new ArgumentException("Başlangıç bakiyesi negatif olamaz.");
        balance = initial;
    }

    // Salt okunur property — dışarıya sadece okunabilir
    public decimal Balance => balance;

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Yatırılan tutar pozitif olmalı.");
        balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Çekilen tutar pozitif olmalı.");
        if (amount > balance) throw new InvalidOperationException("Yetersiz bakiye.");
        balance -= amount;
    }
}

// Kullanım örneği
public class Program
{
    public static void Main()
    {
        var h = new BankaHesabi(1000m);
        Console.WriteLine($"Başlangıç: {h.Balance}");
        h.Deposit(250m);
        Console.WriteLine($"Yatırma sonrası: {h.Balance}");
        try
        {
            h.Withdraw(2000m);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
        }
    }
}
```

Notlar:
- `Balance` property aracılığıyla dış katmanlar bakiyeyi okuyabilir ama doğrudan değiştiremez.
- Bütün doğrulama sınıf içindeki metotlarda yapılır; bu, tutarlı durum sağlar.
