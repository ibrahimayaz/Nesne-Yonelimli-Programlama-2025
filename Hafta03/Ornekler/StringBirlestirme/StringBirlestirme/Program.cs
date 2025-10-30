string ad = "Ahmet";
string soyad = "YILMAZ";
int yas = 20;
bool cinsiyet = false;
string tamAd = $"{ad} {soyad}";
//Metinsel ifadelerde + operatörü birleştirme yapar.
Console.WriteLine(tamAd + " " + yas + " " + cinsiyet);

//String Interpolation
Console.WriteLine($"{ad} {soyad} {yas} {cinsiyet}");


double boy = 170.5;
//Sayısal ifadelerde + operatörü toplama işlemi yapar.
Console.WriteLine(yas+boy);

//Örtük Dönüşüm(otomatik olarak) -daha küçük bir türü daha büyük boyutlu bir türe dönüştürme
//char -> int -> long -> float -> double

//Açık Dönüşüm (manuel olarak) - daha büyük bir türü daha küçük boyutlu bir türe dönüştürme
//double -> float -> long -> int -> char

