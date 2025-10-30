# Örnek 1 — Temel Kapsülleme

Amaç: Bir sınıfın iç durumunu doğrudan dışarı açmadan, kontrollü erişim sağlamak. Örnek C# kodu gösterir.

Sınıf: `Person`

Özellikler:
- `name` ve `age` alanları private olarak tutulur.
- Public metotlar ile dışarıya veri verilip alınır.

Kod:

```csharp
using System;

public class Person
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Bir okuma metodu
    public string GetName()
    {
        return name;
    }

    // Bir yazma metodu
    public void SetName(string newName)
    {
        if (!string.IsNullOrWhiteSpace(newName))
            name = newName;
    }

    // Yaşa kontrollü erişim
    public int GetAge()
    {
        return age;
    }

    public void SetAge(int newAge)
    {
        if (newAge >= 0 && newAge <= 150)
            age = newAge;
    }
}

// Kullanım örneği
public class Program
{
    public static void Main()
    {
        var p = new Person("Ali", 30);
        Console.WriteLine($"İsim: {p.GetName()}, Yaş: {p.GetAge()}");
        p.SetAge(31);
        p.SetName("Mehmet");
        Console.WriteLine($"Güncel: {p.GetName()}, Yaş: {p.GetAge()}");
    }
}
```

Notlar:
- Bu yaklaşım doğrudan alanlara erişimi engeller ve sınıf içindeki kuralları zorlamanıza izin verir.
