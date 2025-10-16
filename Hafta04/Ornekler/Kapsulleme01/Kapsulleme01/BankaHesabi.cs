namespace Kapsulleme01
{
    public class BankaHesabi
    {
        //-bakiye:decimal
        private decimal bakiye;

        //+iban:string
        private string iban;

        //+BankaHesabi(iban:string, bakiye:decimal)
        public BankaHesabi(string iban, decimal bakiye)
        {
     
            this.iban = string.IsNullOrWhiteSpace(iban) ? iban : "Geçersiz IBAN";
            this.bakiye = (bakiye>=0)? bakiye:0;

        }

        public void ParaYatir(decimal tutar)
        {
            if (tutar<0)
            {
                Console.WriteLine("Lütfen geçerli bir tutar giriniz.");
            }
            else
            {
                bakiye += tutar;
            }
        }

        public void ParaCek(decimal tutar) {
            if (tutar<0)
            {
                Console.WriteLine("Girilen tutar negatif olamaz");
            }else if (tutar > bakiye)
            {
                Console.WriteLine("Yetersiz bakiye !");
            }
            else
            {
                bakiye -= tutar;
            }
        }

        public decimal Bakiye()
        {
            return bakiye;
        }

    }
}
