using System;

namespace OOP
{
    public class Kullanici
    {
        private string ad;
        private string soyad;
        private DateTime dogumTarihi;
        private string eposta;
        private string sifre;

        public Kullanici(string ad, string soyad, DateTime dogumTarihi, string eposta, string password)
        {
            string gercekEposta = "iayaz@beu.edu.tr";
            string gercekSifre = "123456";
            if (eposta== gercekEposta && password== gercekSifre) {
                Console.WriteLine("Şifreniz doğru");
                this.ad = ad;
                this.soyad = soyad;
                this.dogumTarihi = dogumTarihi;
                this.eposta = eposta;
                sifre = password;
            }
            else
            {
                Console.WriteLine("Şifre veya eposta yanlış, lütfen tekrar deneyiniz.");
            }
        }
        public int Yas { get {
                return DateTime.Now.Year - dogumTarihi.Year;
            }
        }

        public string TamAd
        {
            get
            {
                return $"{ad} {soyad}";
            }
        }



    }
}
