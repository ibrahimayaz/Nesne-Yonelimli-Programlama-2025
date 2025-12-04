# Örnek 3 — Private yardımcı metot (çok basit)

```csharp
public class Hesap
{
    private int _bakiye;

    public int Bakiye => _bakiye;   // sadece okunur

    public void Yatir(int tutar)
    {
        if (Pozitif(tutar)) _bakiye += tutar;
    }

    public void Cek(int tutar)
    {
        if (Pozitif(tutar) && tutar <= _bakiye) _bakiye -= tutar;
    }

    private bool Pozitif(int x) => x > 0; // dışarı açmıyoruz
}
```