
using ConsoleApp3;

Kisi k = new Kisi();

Ogrenci o1=new Ogrenci();

o1.Ad = "Muhammed";
o1.Soyad = "YEŞİLYAPRAK";
o1.OgrNo = "154555555555555555";
o1.Bolum = "Bilgisayar Teknolojisi";
o1.AldigiDersler.Add("OOP");
o1.AldigiDersler.Add("Görsel Programlama");
o1.AldigiDersler.Add("Matematik");
o1.AldigiDersler.Add("Fizik");


Console.WriteLine(o1.OgrNo);

o1.Konus();

o1.DersleriListele();