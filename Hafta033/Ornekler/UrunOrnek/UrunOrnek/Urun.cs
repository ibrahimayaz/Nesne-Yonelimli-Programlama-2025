using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunOrnek
{
    public class Urun
    {
        private string ad;
        private decimal fiyat;

        //Yapıcı/Kurucu/Constructor
        public Urun(string ad, decimal fiyat)
        {
            this.ad = ad;
            this.fiyat = fiyat;
        }

        public string Ad() => ad;
        public decimal Fiyat() => fiyat;

        public void ZamYap(decimal yuzde)
        {
            if (yuzde <= 0)
            {
                Console.WriteLine("Zam yapma oranı negatif olamaz");
            }
            else
            {
                fiyat +=fiyat*yuzde/100;
            }
                
        }
    }
}
