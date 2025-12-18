using Polimorfizm;

Hayvan h1=new Hayvan();
h1.Rengi = "KIRMIZI";
h1.Adi = "SSSSS";
h1.Yas = 5;
Console.WriteLine(h1.Konus());

Hayvan h2 = new Kopek();
Console.WriteLine(h2.Konus());

Hayvan h3 = new Kus();
Console.WriteLine(h3.Konus());

Kus k1 = new YirticiKus();
Console.WriteLine(k1.Konus());