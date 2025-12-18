namespace PoliformizmeGiris
{
    public class Hayvan
    {
        public string Ad { get; set; }
        public int Yas { get; set; }

        public virtual void SesCikar()
        {
            Console.WriteLine("Hayvan ses çıkarıyor.");
        }

        public void Kos()
        {
            Console.WriteLine("Hayvan yürüyor");
        }
    }
}
