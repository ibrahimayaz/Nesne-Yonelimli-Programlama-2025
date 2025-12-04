# Kapsülleme (Encapsulation) C# Ders İçeriği

Kapsülleme, nesne yönelimli programlamada (OOP) bir nesnenin verilerini (alanlarını) ve bu verilere erişimi sağlayan metotları bir arada tutma ve dışarıdan doğrudan erişimi sınırlandırma tekniğidir. Böylece veri bütünlüğü korunur ve kodun bakımı kolaylaşır.

## Kapsülleme Nedir?
- Bir sınıfın içindeki verilerin (field) doğrudan erişimini engelleyip, bu verilere erişimi metotlar veya özellikler (property) ile kontrol etmektir.
- Genellikle alanlar `private`, erişim metotları veya özellikler ise `public` olarak tanımlanır.

## Neden Kapsülleme Kullanılır?
- Veri gizliliği ve güvenliği sağlar.
- Kodun dışarıdan yanlışlıkla değiştirilmesini engeller.
- Kodun bakımı ve güncellenmesi kolaylaşır.

---

## 1. Basit Kapsülleme Örneği

```csharp
public class Person
{
    private string name; // Alan gizli

    public void SetName(string newName)
    {
        name = newName;
    }

    public string GetName()
    {
        return name;
    }
}
```
Kullanım:
```csharp
Person p = new Person();
p.SetName("Ali");
Console.WriteLine(p.GetName());
```

---

## 2. Property ile Kapsülleme

```csharp
public class Student
{
    private int age;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }
}
```
Kullanım:
```csharp
Student s = new Student();
s.Age = 20;
Console.WriteLine(s.Age);
```

---

## 3. Property ile Doğrulama (Validation)

```csharp
public class BankAccount
{
    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
        set
        {
            if (value >= 0)
                balance = value;
        }
    }
}
```
Kullanım:
```csharp
BankAccount b = new BankAccount();
b.Balance = 100;
b.Balance = -50; // Değişmez, çünkü negatif olamaz
Console.WriteLine(b.Balance); // 100
```

---

## 4. Sadece Okunabilir Property

```csharp
public class Car
{
    private string model = "Toyota";

    public string Model
    {
        get { return model; }
    }
}
```
Kullanım:
```csharp
Car c = new Car();
Console.WriteLine(c.Model); // "Toyota"
```

---

## 5. Otomatik Property ile Kapsülleme

```csharp
public class Book
{
    public string Title { get; set; }
}
```
Kullanım:
```csharp
Book b = new Book();
b.Title = "C# Programlama";
Console.WriteLine(b.Title);
```

---

## Özet
- Kapsülleme, verileri gizleyip kontrollü erişim sağlar.
- Alanlar genellikle `private`, erişim metotları veya özellikler ise `public` olur.
- Property ile veri doğrulama ve sadece okunabilir/ayarlanabilir alanlar oluşturulabilir.

### Kaynaklar
- [Codecademy C# Encapsulation Cheatsheet](https://www.codecademy.com/learn/learn-c-sharp/modules/learn-csharp-encapsulation/cheatsheet)
- [GeeksforGeeks - Encapsulation in C#](https://www.geeksforgeeks.org/c-sharp/encapsulation-in-c-sharp/)

# Hafta09 — LINQ ile Nesne Koleksiyonları

Bu haftada LINQ sorguları ve raporlama pratikleri işlenecektir. (C# örnekleri bir sonraki adımda eklenecektir.)

---