# Örnek 5 — Basit, kısa kapsülleme örnekleri (5 küçük senaryo)

Bu dosya 5 küçük ve basit senaryo içerir; her biri kapsülleme ilkelerini C#'ta kısa bir şekilde gösterir. Her kod parçası ders sırasında hızlıca gösterilmeye uygundur.

1) Salt okunur alan ve public getter

```csharp
public class SayiKutusu
{
    private readonly int _sabit;
    public int Deger => _sabit; // yalnızca okunur

    public SayiKutusu(int deger)
    {
        _sabit = deger;
    }
}
```

2) Backing field + property ile doğrulama

```csharp
public class Kisi
{
    private string _isim = "";
    public string Isim
    {
        get => _isim;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("İsim gerekli");
            _isim = value.Trim();
        }
    }
}
```

3) private set ile dışarı sabit, içerden değişen state

```csharp
public class Sayaç
{
    public int AdimSayisi { get; private set; }

    public void Adim()
    {
        AdimSayisi++;
    }
}
```

4) Hesaplanan property ile türetilmiş bilgi sunma

```csharp
public class Nokta
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Norm => Math.Sqrt(X * X + Y * Y); // hesaplanan property
}
```

5) Encapsulation ile hata önleme (metot aracılığıyla değişim)

```csharp
public class Sayaç2
{
    private int _deger;
    public int Deger => _deger;

    public bool Azalt(int miktar)
    {
        if (miktar <= 0) return false;
        if (_deger - miktar < 0) return false; // negatif olmaya izin verme
        _deger -= miktar;
        return true;
    }

    public void Arttir(int miktar) => _deger += Math.Max(0, miktar);
}
```

Her örneği konsol uygulamasında `Program.Main` içinde tek tek gösterip nasıl davranış farkları olduğunu (direkt alan erişimi yerine property/metot ile nasıl koruma sağlandığını) anlatabilirsiniz.
