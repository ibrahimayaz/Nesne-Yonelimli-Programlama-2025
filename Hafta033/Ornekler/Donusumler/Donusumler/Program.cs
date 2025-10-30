//Otomatik Dönüşüm
//Herhangi bir aracıya(Convert,Parse) ihtiyaç duymaz.
int kucukSayi = 100;
long buyukSayi = kucukSayi;    // Otomatik dönüşüm

float kucukOndalik = 3.14f;
double buyukOndalik = kucukOndalik; // Otomatik dönüşüm


//Açık Dönüşüm
double sayi2 = 14.7;// Bu durumda noktadan sonraki değerler kaybolur.
int sayi1 = (int)sayi2; //sayi1 'in değeri bu durumda 14'dür.


/*
  Bu durumda büyük sayıdan küçük sayıya dönüşüm gerçekleştiğinden dolayı
  int tipinde olan değişkenin değeri küçük bir sayıya dönüştürülür.
 */
long uzun = 1000000500000000002; 
int normal = (int)uzun;
Console.WriteLine(normal);

//Convert ile Dönüştürme

string sayiMetin = "125555";
int sayi = Convert.ToInt32(sayiMetin);


string ondalikMetin = "45.67";
double ondalik = Convert.ToDouble(ondalikMetin);

string dogruMu = "True";
bool dogru = Convert.ToBoolean(dogruMu);

string a1 = Convert.ToString(sayi);
string a2 = Convert.ToString(ondalik);

//Parse ile dönüştürme
string sayiStr = "789";
int sayi3 = int.Parse(sayiStr);

string ondalikStr = "12.34";
double ondalik2 = double.Parse(ondalikStr);

string boolStr = "True";
bool boool = bool.Parse(boolStr);



