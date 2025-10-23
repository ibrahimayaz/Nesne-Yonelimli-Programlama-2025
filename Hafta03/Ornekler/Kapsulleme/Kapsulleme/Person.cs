
namespace Kapsulleme
{
    public class Person
    {
        private string name; // field

        private string password;

        public string Name   // property
        {
            get { return name; }   // get method
            set
            {

                name = value;// set method
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (value=="123")
                {
                    Console.WriteLine("Tebrikler! Giriş Yaptınız");
                    password = value;
                }
                else
                {
                    Console.WriteLine("Şifreniz hatalı");
                }
            }
        }
    }
}
