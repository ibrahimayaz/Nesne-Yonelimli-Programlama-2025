namespace ConsoleApp2
{
    //Araba sınıfı burada alt sınıf yani türetilmiş(Derived) sınıftır.
    /*Araba sınıfı üst (base) sınıfı olan Araç sınıfından miras aldığından dolayı
    Araç sınıfında public olan bütün sınıf üyeleri alt sınıfa aktarılır.*/
    public class Araba:Arac
    {
        public Araba(string ad, string vites, string yakit, string model, int yil) :base(ad, vites, yakit, model, yil)
        {
            
        }
    }
}
