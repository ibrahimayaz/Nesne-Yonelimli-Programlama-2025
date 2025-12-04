using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Kisi
    {
        public string TcNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public void Konus()
        {
            Console.WriteLine($"{Ad} {Soyad } isimli kişi konuşuyor.");
        }
    }
}
