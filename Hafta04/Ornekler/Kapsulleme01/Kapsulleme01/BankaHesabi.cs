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
            this.iban= iban;
            this.bakiye = bakiye;
        }
    }
}
