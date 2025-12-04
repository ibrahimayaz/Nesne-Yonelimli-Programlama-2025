namespace ConsoleApp1
{
    public class Araba
    {
        //Alan=Sınıf Değişkeni --> (Fields)
        private string marka;
        private string model;
        private int yil;
        private string renk;
        //Parametresiz yapıcı metoddur.
        //Aşırı Yükleme (Overloading)
        public Araba()
        {
            
        }
        public Araba(string marka)
        {
            this.marka = marka;
        }

        public Araba(int yil)
        {
            this.yil = yil;
        }
        public Araba(string marka, int yil, string model, string renk)
        {
            this.yil = yil;
        }

    }
}
