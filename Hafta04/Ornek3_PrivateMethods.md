# Örnek 3 — Private yardımcı metotlar ve iç durum yönetimi

Amaç: Sınıf dışına açmak istemediğimiz mantığı private metotlara taşıyarak kodun okunabilirliğini ve yeniden kullanılabilirliğini artırmak.

Örnek: `Inventory` sınıfı — stok yönetimi, özel doğrulamalar ve yardımcı metotlar.

Kod:

```csharp
using System;
using System.Collections.Generic;

public class Inventory
{
    private Dictionary<string, int> items = new Dictionary<string, int>();

    public void AddItem(string sku, int amount)
    {
        EnsurePositive(amount);
        if (items.ContainsKey(sku))
            items[sku] += amount;
        else
            items[sku] = amount;
    }

    public bool RemoveItem(string sku, int amount)
    {
        EnsurePositive(amount);
        if (!items.ContainsKey(sku) || items[sku] < amount) return false;
        items[sku] -= amount;
        if (items[sku] == 0) items.Remove(sku);
        return true;
    }

    public int GetQuantity(string sku)
    {
        return items.TryGetValue(sku, out var q) ? q : 0;
    }

    // Private helper that kapsülleme sağlar: public API daha temiz olur
    private void EnsurePositive(int amount)
    {
        if (amount <= 0) throw new ArgumentException("Miktar pozitif olmalı.");
    }
}

// Kullanım örneği
public class Program
{
    public static void Main()
    {
        var inv = new Inventory();
        inv.AddItem("TB-001", 10);
        Console.WriteLine(inv.GetQuantity("TB-001")); // 10
        inv.RemoveItem("TB-001", 3);
        Console.WriteLine(inv.GetQuantity("TB-001")); // 7
    }
}
```

Notlar:
- Private metotlar sınıfın iç mantığını soyutlar. Böylece tekrar eden doğrulamalar tek yerde toplanır.
