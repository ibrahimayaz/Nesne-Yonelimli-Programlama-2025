namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtUrunKodu = new TextBox();
            txtUrunAd = new TextBox();
            label2 = new Label();
            TxtUrunFiyat = new TextBox();
            label3 = new Label();
            btnEkle = new Button();
            UrunListem = new DataGridView();
            UrunKodu = new DataGridViewTextBoxColumn();
            UrunAD = new DataGridViewTextBoxColumn();
            UrunFiyat = new DataGridViewTextBoxColumn();
            btnSil = new Button();
            btnGuncelle = new Button();
            ((System.ComponentModel.ISupportInitialize)UrunListem).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(28, 18);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 0;
            label1.Text = "Ürün Kodu:";
            // 
            // txtUrunKodu
            // 
            txtUrunKodu.Location = new Point(127, 16);
            txtUrunKodu.Name = "txtUrunKodu";
            txtUrunKodu.Size = new Size(125, 27);
            txtUrunKodu.TabIndex = 1;
            // 
            // txtUrunAd
            // 
            txtUrunAd.Location = new Point(376, 18);
            txtUrunAd.Name = "txtUrunAd";
            txtUrunAd.Size = new Size(125, 27);
            txtUrunAd.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(277, 20);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 2;
            label2.Text = "Ürün Adı:";
            // 
            // TxtUrunFiyat
            // 
            TxtUrunFiyat.Location = new Point(636, 20);
            TxtUrunFiyat.Name = "TxtUrunFiyat";
            TxtUrunFiyat.Size = new Size(125, 27);
            TxtUrunFiyat.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(537, 22);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 4;
            label3.Text = "Ürün Fiyatı:";
            // 
            // btnEkle
            // 
            btnEkle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEkle.Location = new Point(596, 78);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(151, 29);
            btnEkle.TabIndex = 6;
            btnEkle.Text = "Stoğa Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // UrunListem
            // 
            UrunListem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UrunListem.Columns.AddRange(new DataGridViewColumn[] { UrunKodu, UrunAD, UrunFiyat });
            UrunListem.Location = new Point(84, 139);
            UrunListem.Name = "UrunListem";
            UrunListem.RowHeadersWidth = 51;
            UrunListem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            UrunListem.Size = new Size(654, 253);
            UrunListem.TabIndex = 7;
            UrunListem.CellClick += UrunListem_CellDoubleClick;
            UrunListem.CellContentClick += UrunListem_CellDoubleClick;
            UrunListem.CellDoubleClick += UrunListem_CellDoubleClick;
            // 
            // UrunKodu
            // 
            UrunKodu.HeaderText = "Ürün Kodu";
            UrunKodu.MinimumWidth = 6;
            UrunKodu.Name = "UrunKodu";
            UrunKodu.Width = 200;
            // 
            // UrunAD
            // 
            UrunAD.HeaderText = "Ürün Adı";
            UrunAD.MinimumWidth = 6;
            UrunAD.Name = "UrunAD";
            UrunAD.Width = 200;
            // 
            // UrunFiyat
            // 
            UrunFiyat.HeaderText = "Ürün Fiyatı";
            UrunFiyat.MinimumWidth = 6;
            UrunFiyat.Name = "UrunFiyat";
            UrunFiyat.Width = 200;
            // 
            // btnSil
            // 
            btnSil.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSil.Location = new Point(462, 78);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(94, 29);
            btnSil.TabIndex = 8;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuncelle.Location = new Point(332, 78);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(94, 29);
            btnGuncelle.TabIndex = 9;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 487);
            Controls.Add(btnGuncelle);
            Controls.Add(btnSil);
            Controls.Add(UrunListem);
            Controls.Add(btnEkle);
            Controls.Add(TxtUrunFiyat);
            Controls.Add(label3);
            Controls.Add(txtUrunAd);
            Controls.Add(label2);
            Controls.Add(txtUrunKodu);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)UrunListem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUrunKodu;
        private TextBox txtUrunAd;
        private Label label2;
        private TextBox TxtUrunFiyat;
        private Label label3;
        private Button btnEkle;
        private DataGridView UrunListem;
        private DataGridViewTextBoxColumn UrunKodu;
        private DataGridViewTextBoxColumn UrunAD;
        private DataGridViewTextBoxColumn UrunFiyat;
        private Button btnSil;
        private Button btnGuncelle;
    }
}
