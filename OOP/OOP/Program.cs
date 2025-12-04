using System;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dogum = new DateTime(1992,02,01);
            Kullanici k1 = new Kullanici("İbrahim", "AYAZ", dogum, "iayaz@beu.edu.tr", "123456");

            Console.WriteLine($"Ad Soyad: {k1.TamAd}\nYaşınız {k1.Yas}");
        }
    }
}
