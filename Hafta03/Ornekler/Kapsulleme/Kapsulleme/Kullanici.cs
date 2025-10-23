namespace Kapsulleme
{
    public class Kullanici
    {
        private string ad;
        private string soyad;
        private DateTime dogumTarihi;

        public int Yas
        {
            get
            {
                return DateTime.Now.Year-dogumTarihi.Year;
            }
        }
        public string TamBilgi
        {
            get
            {
                return $"Ad:{ad}\nSoyad:{soyad}\nYaş:{Yas}";
            }
        }
        
        public Kullanici(string ad, string soyad, DateTime dogumTarihi)
        {
            this.ad = ad;
            this.soyad = soyad;
            this.dogumTarihi = dogumTarihi;
        }
    }
}
