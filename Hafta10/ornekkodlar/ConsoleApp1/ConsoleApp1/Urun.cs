using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    public class Urun
    {

        private string barkod;
        private string ad;
        private decimal fiyat;
        private int adet;

        //Kapsülleme
        public decimal KdvliFiyat
        {
            get { return fiyat * 1.20m; }
        }
        public Urun()
        {
            
        }
        public Urun(string ad, decimal fiyat)
        {
            this.ad = ad;
            this.fiyat = fiyat;
        }
        public Urun(string barkod, string ad, decimal fiyat)
        {
            this.barkod = barkod;
            this.ad = ad;
            this.fiyat = fiyat;
        }

        public string SepeteEkle(string ad)
        {
            return "Ürün Sepete Eklenmiştir.";
        }
        public string SepeteEkle(string ad, decimal fiyat)
        {
            return $"{ad} adlı ürün sepete eklenmiştir.";
        }


    }
}
