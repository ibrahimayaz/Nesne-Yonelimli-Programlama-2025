namespace ConsoleApp2
{
    //Base Class = Üst Sınıf
    public class Arac
    {
        //Özellikler - Properties
        public string Ad { get; set; }
        public string VitesTipi { get; set; }
        public string YakitTipi { get; set; }
        public string Model { get; set; }
        public int ModelYili { get; set; }

        //Yapıcı/Kurucu Metod
        public Arac(string ad, string vites, string yakit, string model, int modelYili)
        {
            Ad = ad;
            VitesTipi = vites;
            YakitTipi = yakit;
            Model = model;
            ModelYili = modelYili;
        }

        public string AracBilgisiniGetir()
        {
            return $"{Model}-{Ad}-{YakitTipi}-{VitesTipi}-{ModelYili}";
        }

    }
}
