namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtUrunKodu.Text != "" && txtUrunAd.Text != "" && TxtUrunFiyat.Text != "")
            {
                string Kod = txtUrunKodu.Text;
                string Ad = txtUrunAd.Text;
                string Fiyat = TxtUrunFiyat.Text;
                DataGridViewRow Satir = (DataGridViewRow)UrunListem.Rows[0].Clone();
                Satir.Cells[0].Value = Kod;
                Satir.Cells[1].Value = Ad;
                Satir.Cells[2].Value = Fiyat;

                UrunListem.Rows.Add(Satir);

            }
            else
            {

                MessageBox.Show("Eksik Alanlarý Tamlayýnýz");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (UrunListem.SelectedRows.Count > 0)
            {
                UrunListem.Rows.RemoveAt(UrunListem.SelectedRows[0].Index);
                MessageBox.Show("Silme Baþarýlý");
            }
            else
            {
                MessageBox.Show("Siliceðiniz satýrý seçiniz");
            }
        }

        private void UrunListem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (UrunListem.SelectedRows.Count > 0)
            {
                txtUrunKodu.Text = UrunListem.SelectedRows[0].Cells[0].Value.ToString();
                txtUrunAd.Text = UrunListem.SelectedRows[0].Cells[1].Value.ToString();
                TxtUrunFiyat.Text = UrunListem.SelectedRows[0].Cells[2].Value.ToString();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (UrunListem.SelectedRows.Count > 0)
            {
                UrunListem.Rows.RemoveAt(UrunListem.SelectedRows[0].Index);
                if (txtUrunKodu.Text != "" && txtUrunAd.Text != "" && TxtUrunFiyat.Text != "")
                {
                    string Kod = txtUrunKodu.Text;
                    string Ad = txtUrunAd.Text;
                    string Fiyat = TxtUrunFiyat.Text;
                    DataGridViewRow Satir = (DataGridViewRow)UrunListem.Rows[0].Clone();
                    Satir.Cells[0].Value = Kod;
                    Satir.Cells[1].Value = Ad;
                    Satir.Cells[2].Value = Fiyat;

                    UrunListem.Rows.Add(Satir);

                }
                else
                {

                    MessageBox.Show("Eksik Alanlarý Tamlayýnýz");
                }
            }
            else
            {
                MessageBox.Show("Siliceðiniz satýrý seçiniz");
            }
        }
    }
}
