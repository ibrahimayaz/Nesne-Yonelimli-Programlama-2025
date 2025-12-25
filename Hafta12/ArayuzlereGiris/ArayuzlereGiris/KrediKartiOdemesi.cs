namespace ArayuzlereGiris
{
    public class KrediKartiOdemesi : IOdeme
    {
        public void Ode(decimal miktar)
        {
            Console.WriteLine($"KK ile {miktar:C}");
        }
    }
}
