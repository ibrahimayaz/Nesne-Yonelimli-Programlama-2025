using System.Security.Cryptography.X509Certificates;

namespace Oyun
{
    public partial class Form1 : Form
    {
        char[] soruHarfleri = new char[5];
        int AlinanHarf = 0;
        int DogruBilinenHarfSayisi = 0;
        int ToplamSkor = 0;
        Boolean[] Bulunmadimi = { true, true, true, true, true };
        bool harfAlmaAktif=false;
        int sorulacakindex = 0;
        List<string> SorulacakKelimeler = new List<string> { "BAHAR", "GÖZDE", "FATMA", "AHMET", "AYLÝN" };

        public Form1()
        {
            InitializeComponent();
        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void BtnOyunBasla_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            Random rnd = new Random();
            sorulacakindex = rnd.Next(0, SorulacakKelimeler.Count);
            soruHarfleri = SorulacakKelimeler[sorulacakindex].ToCharArray(); 

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {

                return;
            }
            else if (harfAlmaAktif)
            {
                harfAlmaAktif = false;
                if ((DogruBilinenHarfSayisi + AlinanHarf) == 5)
                {
                    lblDogruHarfNo.Text = DogruBilinenHarfSayisi.ToString();
                    ToplamSkor = ToplamSkor + DogruBilinenHarfSayisi;
                    LblToplam.Text= ToplamSkor.ToString();
                    MessageBox.Show("Tebrikler Oyun Kazandýnýz");
                    AlinanHarf = 0;
                    DogruBilinenHarfSayisi = 0;

                    OyunNext();
                   

                    //Tamamlanacak
                }
            
            }
            else if (textBox1.Text.Length == 1)
            {
                //girilen harf doðrumu kontrolü
                char[] Harfim = textBox1.Text.ToUpper().ToCharArray();
                if (soruHarfleri[0] == Harfim[0])
                {
                    DogruBilinenHarfSayisi++;
                    if ((DogruBilinenHarfSayisi+AlinanHarf) == 5)
                    {
                        lblDogruHarfNo.Text = DogruBilinenHarfSayisi.ToString();
                        ToplamSkor = ToplamSkor + DogruBilinenHarfSayisi;
                        LblToplam.Text = ToplamSkor.ToString();
                        MessageBox.Show("Tebrikler Oyun Kazandýnýz");
                        AlinanHarf = 0;
                        DogruBilinenHarfSayisi = 0;

                        OyunNext();
                          return;   
                        //Tamamlanacak
                    }
                    textBox1.Enabled = false;
                    lblDogruHarfNo.Text = DogruBilinenHarfSayisi.ToString();
                    Bulunmadimi[0] = false;
                }
                else
                {
                    MessageBox.Show("Girilen Harf Yanlýþ");
                    textBox1.Text = "";

                }
            }
            else
            {
                textBox1.Text = "";
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {

                return;
            }
            else if (harfAlmaAktif)
            {
                harfAlmaAktif = false;
                if ((DogruBilinenHarfSayisi + AlinanHarf) == 5)
                {
                    lblDogruHarfNo.Text = DogruBilinenHarfSayisi.ToString();
                    ToplamSkor = ToplamSkor + DogruBilinenHarfSayisi;
                    LblToplam.Text = ToplamSkor.ToString();
                    MessageBox.Show("Tebrikler Oyun Kazandýnýz");
                    AlinanHarf = 0;
                    DogruBilinenHarfSayisi = 0;

                    OyunNext();
                    return;
                    //Tamamlanacak
                }
                return;
            }
            else if (textBox2.Text.Length == 1)
            {
                //girilen harf doðrumu kontrolü
                char[] Harfim = textBox2.Text.ToUpper().ToCharArray();
                if (soruHarfleri[1] == Harfim[0])
                {
                    DogruBilinenHarfSayisi++;
                    if ((DogruBilinenHarfSayisi + AlinanHarf) == 5)
                    {
                        lblDogruHarfNo.Text = DogruBilinenHarfSayisi.ToString();
                        ToplamSkor = ToplamSkor + DogruBilinenHarfSayisi;
                        LblToplam.Text = ToplamSkor.ToString();
                        MessageBox.Show("Tebrikler Oyun Kazandýnýz");
                        AlinanHarf = 0;
                        DogruBilinenHarfSayisi = 0;

                        OyunNext();
                        return;
                        //Tamamlanacak
                    }
                    textBox2.Enabled = false;
                    lblDogruHarfNo.Text = DogruBilinenHarfSayisi.ToString();
                    Bulunmadimi[1] = false;

                }
                else
                {
                    MessageBox.Show("Girilen Harf Yanlýþ");
                    textBox2.Text = "";

                }
            }
            else
            {
                textBox2.Text = "";
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0)
            {

                return;
            }
            else if (harfAlmaAktif)
            {
                harfAlmaAktif = false;
                if ((DogruBilinenHarfSayisi + AlinanHarf) == 5)
                {
                    lblDogruHarfNo.Text = DogruBilinenHarfSayisi.ToString();
                    ToplamSkor = ToplamSkor + DogruBilinenHarfSayisi;
                    LblToplam.Text = ToplamSkor.ToString();
                    MessageBox.Show("Tebrikler Oyun Kazandýnýz");
                    AlinanHarf = 0;
                    DogruBilinenHarfSayisi = 0;

                    OyunNext();
                    return;
                    //Tamamlanacak
                }
                return;
            }
            else if (textBox3.Text.Length == 1)
            {
                //girilen harf doðrumu kontrolü
                char[] Harfim = textBox3.Text.ToUpper().ToCharArray();
                if (soruHarfleri[2] == Harfim[0])
                {
                    DogruBilinenHarfSayisi++;
                    if ((DogruBilinenHarfSayisi + AlinanHarf) == 5)
                    {
                        lblDogruHarfNo.Text = DogruBilinenHarfSayisi.ToString();
                        ToplamSkor = ToplamSkor + DogruBilinenHarfSayisi;
                        LblToplam.Text = ToplamSkor.ToString();
                        MessageBox.Show("Tebrikler Oyun Kazandýnýz");
                        AlinanHarf = 0;
                        DogruBilinenHarfSayisi = 0;

                        OyunNext();
                        return;
                        //Tamamlanacak
                    }
                    textBox3.Enabled = false;
                    lblDogruHarfNo.Text = DogruBilinenHarfSayisi.ToString();
                    Bulunmadimi[2] = false;

                }
                else
                {
                    MessageBox.Show("Girilen Harf Yanlýþ");
                    textBox3.Text = "";

                }
            }
            else
            {
                textBox3.Text = "";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0)
            {

                return;
            }
            else if (harfAlmaAktif)
            {
                harfAlmaAktif = false;
                if ((DogruBilinenHarfSayisi + AlinanHarf) == 5)
                {
                    lblDogruHarfNo.Text = DogruBilinenHarfSayisi.ToString();
                    ToplamSkor = ToplamSkor + DogruBilinenHarfSayisi;
                    LblToplam.Text = ToplamSkor.ToString();
                    MessageBox.Show("Tebrikler Oyun Kazandýnýz");
                    AlinanHarf = 0;
                    DogruBilinenHarfSayisi = 0;

                    OyunNext();
                    return;
                    //Tamamlanacak
                }
                return;
            }
            else if (textBox4.Text.Length == 1)
            {
                //girilen harf doðrumu kontrolü
                char[] Harfim = textBox4.Text.ToUpper().ToCharArray();
                if (soruHarfleri[3] == Harfim[0])
                {
                    DogruBilinenHarfSayisi++;
                    if ((DogruBilinenHarfSayisi + AlinanHarf) == 5)
                    {
                        lblDogruHarfNo.Text = DogruBilinenHarfSayisi.ToString();
                        ToplamSkor = ToplamSkor + DogruBilinenHarfSayisi;
                        LblToplam.Text = ToplamSkor.ToString();
                        MessageBox.Show("Tebrikler Oyun Kazandýnýz");
                        AlinanHarf = 0;
                        DogruBilinenHarfSayisi = 0;

                        OyunNext();
                        return;
                        //Tamamlanacak
                    }
                    textBox4.Enabled = false;
                    lblDogruHarfNo.Text = DogruBilinenHarfSayisi.ToString();
                    Bulunmadimi[3] = false;
                }
                else
                {
                    MessageBox.Show("Girilen Harf Yanlýþ");
                    textBox4.Text = "";

                }
            }
            else
            {
                textBox4.Text = "";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0)
            {

                return;
            }
            else if (harfAlmaAktif)
            {
                harfAlmaAktif = false;
                if ((DogruBilinenHarfSayisi + AlinanHarf) == 5)
                {
                    lblDogruHarfNo.Text = DogruBilinenHarfSayisi.ToString();
                    ToplamSkor = ToplamSkor + DogruBilinenHarfSayisi;
                    LblToplam.Text = ToplamSkor.ToString();
                    MessageBox.Show("Tebrikler Oyun Kazandýnýz");
                    AlinanHarf = 0;
                    DogruBilinenHarfSayisi = 0;

                    OyunNext();
                    return;
                    //Tamamlanacak
                }
                return;
            }
            else if (textBox5.Text.Length == 1)
            {
                //girilen harf doðrumu kontrolü
                char[] Harfim = textBox5.Text.ToUpper().ToCharArray();
                if (soruHarfleri[4] == Harfim[0])
                {
                    DogruBilinenHarfSayisi++;
                    if ((DogruBilinenHarfSayisi + AlinanHarf) == 5)
                    {
                        lblDogruHarfNo.Text = DogruBilinenHarfSayisi.ToString();
                        ToplamSkor = ToplamSkor + DogruBilinenHarfSayisi;
                        LblToplam.Text = ToplamSkor.ToString();
                        MessageBox.Show("Tebrikler Oyun Kazandýnýz");
                        AlinanHarf = 0;
                        DogruBilinenHarfSayisi = 0;

                        OyunNext();
                        return;
                        //Tamamlanacak
                    }
                    textBox5.Enabled = false;
                    lblDogruHarfNo.Text = DogruBilinenHarfSayisi.ToString();
                    Bulunmadimi[4] = false;

                }
                else
                {
                    MessageBox.Show("Girilen Harf Yanlýþ");
                    textBox5.Text = "";

                }
            }
            else
            {
                textBox5.Text = "";
            }
        }

        private void BtnHarfAl_Click(object sender, EventArgs e)
        {
            if (AlinanHarf < 3)
            {
                Random rnd = new Random();
                bool devam = true;
                while (devam)
                {

                    int VerilecekNo = rnd.Next(0, 5);
                    if (Bulunmadimi[VerilecekNo])
                    {
                        devam = false;
                        if (VerilecekNo == 0)
                        {
                            AlinanHarf++;
                            harfAlmaAktif = true;
                            textBox1.Text = soruHarfleri[0].ToString();
                            textBox1.Enabled = false;
                            Bulunmadimi[0] = false;
                          
                         


                        }
                        else if (VerilecekNo == 1)
                        {
                            AlinanHarf++;
                            harfAlmaAktif = true;
                            textBox2.Text = soruHarfleri[1].ToString();
                            textBox2.Enabled = false;
                            Bulunmadimi[1] = false;
                          

                        }
                        else if (VerilecekNo == 2)
                        {
                            AlinanHarf++;
                            harfAlmaAktif = true;
                            textBox3.Text = soruHarfleri[2].ToString();
                            textBox3.Enabled = false;
                            Bulunmadimi[2] = false;
                          

                        }
                        else if (VerilecekNo == 3)
                        {
                            AlinanHarf++;
                            harfAlmaAktif = true;
                            textBox4.Text = soruHarfleri[3].ToString();
                            textBox4.Enabled = false;
                            Bulunmadimi[3] = false;
                       
                           

                        }
                        else if (VerilecekNo == 4)
                        {
                            AlinanHarf++;
                            harfAlmaAktif = true;
                            textBox5.Text = soruHarfleri[4].ToString();
                            textBox5.Enabled = false;
                            Bulunmadimi[4] = false;
                           
                           

                        }

                        LblAlinanHarfNO.Text = (3 - AlinanHarf).ToString(); 
                    }


                }

            }
            else
            {
                MessageBox.Show("Harf Alama Hakkýnýz Yoktur");

            }
        }

         public void OyunNext()
        {
            if (ToplamSkor >= 10)
            {
                MessageBox.Show("Tebrikler Oyunu Oyunu Bitirdiniz");
                 this.Close();  
                
            }
            SorulacakKelimeler.RemoveAt(sorulacakindex);
            Random rnd = new Random();
            sorulacakindex = rnd.Next(0, SorulacakKelimeler.Count);
            soruHarfleri = SorulacakKelimeler[sorulacakindex].ToCharArray();
            Bulunmadimi[0]=true;
            Bulunmadimi[1] = true;
            Bulunmadimi[2] = true;
            Bulunmadimi[3] = true;
            Bulunmadimi[4] = true;
            textBox1.Text = "";
            textBox1.Enabled = true;
            textBox2.Text = "";
            textBox2.Enabled = true;
            textBox3.Text = "";
            textBox3.Enabled = true;
            textBox4.Text = "";
            textBox4.Enabled = true;
            textBox5.Text = "";
            textBox5.Enabled = true;
            LblAlinanHarfNO.Text = "3";
            lblDogruHarfNo.Text = "0";

        }
    }
}