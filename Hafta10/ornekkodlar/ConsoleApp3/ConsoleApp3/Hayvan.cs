namespace ConsoleApp3
{
    public class Hayvan
    {
        public string Ad { get; set; }

        public string Konus()
        {
            return $"{Ad} isimli hayvan konuşuyor.";
        }
    }
}
