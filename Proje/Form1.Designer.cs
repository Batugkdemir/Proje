using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Proje
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            grpogrenci = new GroupBox();
            DerssecimBtn = new Button();
            SinifcomboBox = new ComboBox();
            SinifLbl = new Label();
            btnbul = new Button();
            btnguncel = new Button();
            numara = new Label();
            soyad = new Label();
            ad = new Label();
            btnkaydet = new Button();
            TxtNumara = new TextBox();
            TxtSoyad = new TextBox();
            TxtAd = new TextBox();
            dersBox = new GroupBox();
            dersguncelleBtn = new Button();
            dersbulBtn = new Button();
            derskaydetBtn = new Button();
            derskoduTxt = new TextBox();
            label1 = new Label();
            dersadTxt = new TextBox();
            dersLbl = new Label();
            groupBox1 = new GroupBox();
            sinifguncelleBtn = new Button();
            sinifbulBtn = new Button();
            sinifkaydetBtn = new Button();
            sinifkontenjanTxt = new TextBox();
            label2 = new Label();
            sinifadTxt = new TextBox();
            label3 = new Label();
            grpogrenci.SuspendLayout();
            dersBox.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // grpogrenci
            // 
            grpogrenci.Controls.Add(DerssecimBtn);
            grpogrenci.Controls.Add(SinifcomboBox);
            grpogrenci.Controls.Add(SinifLbl);
            grpogrenci.Controls.Add(btnbul);
            grpogrenci.Controls.Add(btnguncel);
            grpogrenci.Controls.Add(numara);
            grpogrenci.Controls.Add(soyad);
            grpogrenci.Controls.Add(ad);
            grpogrenci.Controls.Add(btnkaydet);
            grpogrenci.Controls.Add(TxtNumara);
            grpogrenci.Controls.Add(TxtSoyad);
            grpogrenci.Controls.Add(TxtAd);
            grpogrenci.Location = new Point(12, 12);
            grpogrenci.Name = "grpogrenci";
            grpogrenci.Size = new Size(382, 309);
            grpogrenci.TabIndex = 0;
            grpogrenci.TabStop = false;
            grpogrenci.Text = "Öğrenci Ekleme";
            // 
            // DerssecimBtn
            // 
            DerssecimBtn.Location = new Point(146, 260);
            DerssecimBtn.Name = "DerssecimBtn";
            DerssecimBtn.Size = new Size(93, 25);
            DerssecimBtn.TabIndex = 13;
            DerssecimBtn.Text = "Ders Seçimi";
            DerssecimBtn.UseVisualStyleBackColor = true;
            DerssecimBtn.Click += DerssecimBtn_Click;
            // 
            // SinifcomboBox
            // 
            SinifcomboBox.FormattingEnabled = true;
            SinifcomboBox.Location = new Point(113, 161);
            SinifcomboBox.Name = "SinifcomboBox";
            SinifcomboBox.Size = new Size(192, 23);
            SinifcomboBox.TabIndex = 12;
            // 
            // SinifLbl
            // 
            SinifLbl.AutoSize = true;
            SinifLbl.Location = new Point(35, 161);
            SinifLbl.Name = "SinifLbl";
            SinifLbl.Size = new Size(69, 15);
            SinifLbl.TabIndex = 11;
            SinifLbl.Text = "Sınıf Seçiniz";
            // 
            // btnbul
            // 
            btnbul.Location = new Point(244, 229);
            btnbul.Name = "btnbul";
            btnbul.Size = new Size(93, 25);
            btnbul.TabIndex = 10;
            btnbul.Text = "Bul";
            btnbul.UseVisualStyleBackColor = true;
            btnbul.Click += btnbul_Click;
            // 
            // btnguncel
            // 
            btnguncel.Location = new Point(48, 229);
            btnguncel.Name = "btnguncel";
            btnguncel.Size = new Size(93, 25);
            btnguncel.TabIndex = 9;
            btnguncel.Text = "Güncelle";
            btnguncel.UseVisualStyleBackColor = true;
            btnguncel.Click += btnguncel_Click;
            // 
            // numara
            // 
            numara.AutoSize = true;
            numara.Location = new Point(35, 122);
            numara.Name = "numara";
            numara.Size = new Size(50, 15);
            numara.TabIndex = 6;
            numara.Text = "Numara";
            // 
            // soyad
            // 
            soyad.AutoSize = true;
            soyad.Location = new Point(35, 82);
            soyad.Name = "soyad";
            soyad.Size = new Size(39, 15);
            soyad.TabIndex = 5;
            soyad.Text = "Soyad";
            // 
            // ad
            // 
            ad.AutoSize = true;
            ad.Location = new Point(35, 43);
            ad.Name = "ad";
            ad.Size = new Size(22, 15);
            ad.TabIndex = 4;
            ad.Text = "Ad";
            // 
            // btnkaydet
            // 
            btnkaydet.Location = new Point(146, 229);
            btnkaydet.Name = "btnkaydet";
            btnkaydet.Size = new Size(93, 25);
            btnkaydet.TabIndex = 3;
            btnkaydet.Text = "Kaydet";
            btnkaydet.UseVisualStyleBackColor = true;
            btnkaydet.Click += button1_Click;
            // 
            // TxtNumara
            // 
            TxtNumara.Location = new Point(113, 122);
            TxtNumara.MaxLength = 20;
            TxtNumara.Name = "TxtNumara";
            TxtNumara.Size = new Size(192, 23);
            TxtNumara.TabIndex = 2;
            // 
            // TxtSoyad
            // 
            TxtSoyad.Location = new Point(113, 82);
            TxtSoyad.MaxLength = 20;
            TxtSoyad.Name = "TxtSoyad";
            TxtSoyad.Size = new Size(192, 23);
            TxtSoyad.TabIndex = 1;
            // 
            // TxtAd
            // 
            TxtAd.Location = new Point(113, 43);
            TxtAd.MaxLength = 20;
            TxtAd.Name = "TxtAd";
            TxtAd.Size = new Size(192, 23);
            TxtAd.TabIndex = 0;
            // 
            // dersBox
            // 
            dersBox.Controls.Add(dersguncelleBtn);
            dersBox.Controls.Add(dersbulBtn);
            dersBox.Controls.Add(derskaydetBtn);
            dersBox.Controls.Add(derskoduTxt);
            dersBox.Controls.Add(label1);
            dersBox.Controls.Add(dersadTxt);
            dersBox.Controls.Add(dersLbl);
            dersBox.Location = new Point(400, 12);
            dersBox.Name = "dersBox";
            dersBox.Size = new Size(386, 309);
            dersBox.TabIndex = 1;
            dersBox.TabStop = false;
            dersBox.Text = "Ders Ekleme";
            // 
            // dersguncelleBtn
            // 
            dersguncelleBtn.Location = new Point(37, 229);
            dersguncelleBtn.Name = "dersguncelleBtn";
            dersguncelleBtn.Size = new Size(93, 25);
            dersguncelleBtn.TabIndex = 14;
            dersguncelleBtn.Text = "Güncelle";
            dersguncelleBtn.UseVisualStyleBackColor = true;
            dersguncelleBtn.Click += dersguncelleBtn_Click;
            // 
            // dersbulBtn
            // 
            dersbulBtn.Location = new Point(257, 229);
            dersbulBtn.Name = "dersbulBtn";
            dersbulBtn.Size = new Size(93, 25);
            dersbulBtn.TabIndex = 14;
            dersbulBtn.Text = "Bul";
            dersbulBtn.UseVisualStyleBackColor = true;
            dersbulBtn.Click += dersbulBtn_Click;
            // 
            // derskaydetBtn
            // 
            derskaydetBtn.Location = new Point(146, 229);
            derskaydetBtn.Name = "derskaydetBtn";
            derskaydetBtn.Size = new Size(93, 25);
            derskaydetBtn.TabIndex = 14;
            derskaydetBtn.Text = "Kaydet";
            derskaydetBtn.UseVisualStyleBackColor = true;
            derskaydetBtn.Click += derskaydetBtn_Click;
            // 
            // derskoduTxt
            // 
            derskoduTxt.Location = new Point(130, 79);
            derskoduTxt.MaxLength = 20;
            derskoduTxt.Name = "derskoduTxt";
            derskoduTxt.Size = new Size(192, 23);
            derskoduTxt.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 82);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 15;
            label1.Text = "Ders Kodu Giriniz";
            // 
            // dersadTxt
            // 
            dersadTxt.Location = new Point(130, 40);
            dersadTxt.MaxLength = 20;
            dersadTxt.Name = "dersadTxt";
            dersadTxt.Size = new Size(192, 23);
            dersadTxt.TabIndex = 14;
            // 
            // dersLbl
            // 
            dersLbl.AutoSize = true;
            dersLbl.Location = new Point(37, 43);
            dersLbl.Name = "dersLbl";
            dersLbl.Size = new Size(87, 15);
            dersLbl.TabIndex = 14;
            dersLbl.Text = "Ders Adı Giriniz";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(sinifguncelleBtn);
            groupBox1.Controls.Add(sinifbulBtn);
            groupBox1.Controls.Add(sinifkaydetBtn);
            groupBox1.Controls.Add(sinifkontenjanTxt);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(sinifadTxt);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(792, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(386, 309);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sınıf Ekleme";
            // 
            // sinifguncelleBtn
            // 
            sinifguncelleBtn.Location = new Point(37, 229);
            sinifguncelleBtn.Name = "sinifguncelleBtn";
            sinifguncelleBtn.Size = new Size(93, 25);
            sinifguncelleBtn.TabIndex = 14;
            sinifguncelleBtn.Text = "Güncelle";
            sinifguncelleBtn.UseVisualStyleBackColor = true;
            sinifguncelleBtn.Click += sinifguncelleBtn_Click;
            // 
            // sinifbulBtn
            // 
            sinifbulBtn.Location = new Point(257, 229);
            sinifbulBtn.Name = "sinifbulBtn";
            sinifbulBtn.Size = new Size(93, 25);
            sinifbulBtn.TabIndex = 14;
            sinifbulBtn.Text = "Bul";
            sinifbulBtn.UseVisualStyleBackColor = true;
            sinifbulBtn.Click += sinifbulBtn_Click;
            // 
            // sinifkaydetBtn
            // 
            sinifkaydetBtn.Location = new Point(146, 229);
            sinifkaydetBtn.Name = "sinifkaydetBtn";
            sinifkaydetBtn.Size = new Size(93, 25);
            sinifkaydetBtn.TabIndex = 14;
            sinifkaydetBtn.Text = "Kaydet";
            sinifkaydetBtn.UseVisualStyleBackColor = true;
            sinifkaydetBtn.Click += sinifkaydetBtn_Click;
            // 
            // sinifkontenjanTxt
            // 
            sinifkontenjanTxt.Location = new Point(130, 79);
            sinifkontenjanTxt.MaxLength = 20;
            sinifkontenjanTxt.Name = "sinifkontenjanTxt";
            sinifkontenjanTxt.Size = new Size(192, 23);
            sinifkontenjanTxt.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 82);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 15;
            label2.Text = "Kontenjan Giriniz";
            // 
            // sinifadTxt
            // 
            sinifadTxt.Location = new Point(130, 40);
            sinifadTxt.MaxLength = 20;
            sinifadTxt.Name = "sinifadTxt";
            sinifadTxt.Size = new Size(192, 23);
            sinifadTxt.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 43);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 14;
            label3.Text = "Sınıf Adı Giriniz";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1197, 422);
            Controls.Add(groupBox1);
            Controls.Add(dersBox);
            Controls.Add(grpogrenci);
            Name = "Form1";
            Text = "Form1";
            grpogrenci.ResumeLayout(false);
            grpogrenci.PerformLayout();
            dersBox.ResumeLayout(false);
            dersBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox grpogrenci;
        private Button btnkaydet;
        private TextBox TxtNumara;
        private TextBox TxtSoyad;
        private TextBox TxtAd;
        private Label numara;
        private Label soyad;
        private Label ad;
        private Button btnbul;
        private Button btnguncel;
        private Label SinifLbl;
        private ComboBox SinifcomboBox;
        private Button DerssecimBtn;
        private GroupBox dersBox;
        private Label dersLbl;
        private TextBox dersadTxt;
        private Label label1;
        private TextBox derskoduTxt;
        private Button derskaydetBtn;
        private Button dersbulBtn;
        private Button dersguncelleBtn;
        private GroupBox groupBox1;
        private Button sinifguncelleBtn;
        private Button sinifbulBtn;
        private Button sinifkaydetBtn;
        private TextBox sinifkontenjanTxt;
        private Label label2;
        private TextBox sinifadTxt;
        private Label label3;
    }
}