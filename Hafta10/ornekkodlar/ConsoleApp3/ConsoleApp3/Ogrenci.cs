namespace ConsoleApp3
{
    public class Ogrenci:Kisi
    {
        private string ogrNo;
        public string OgrNo
        {
            get { return "BEU" + ogrNo; }
            set
            {
                if (Convert.ToInt64(value) > 0)
                {
                    ogrNo = value;
                }
                else
                {
                    Console.WriteLine("Öğrenci numarası negatif olamaz");
                }
            }
        }
        public string Bolum { get; set; }
        public List<string> AldigiDersler{ get; set; }=new List<string>();

        public void DersleriListele()
        {
            foreach(var item in AldigiDersler)
            {
                Console.WriteLine(item);
            }
        }
    }
}
