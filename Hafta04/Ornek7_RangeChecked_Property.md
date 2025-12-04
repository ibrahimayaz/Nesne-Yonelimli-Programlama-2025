# Örnek 7 — Aralık kontrollü property (çok basit)

```csharp
public class Temperature
{
    private double _celsius;

    public double Celsius
    {
        get => _celsius;
        set
        {
            if (value < -273.15) return; // çok basit: mutlak sıfırın altını kabul etme
            _celsius = value;
        }
    }

    public double Fahrenheit => _celsius * 9 / 5 + 32; // hesaplanan
}
```