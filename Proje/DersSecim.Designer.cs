namespace Proje
{
    partial class DersSecim
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
            ogrencibilgiLbl = new Label();
            DerslerLbl = new Label();
            dersdatagrid = new DataGridView();
            ogrderskaydetBtn = new Button();
            secilendersLbl = new Label();
            aldigiderslerGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dersdatagrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)aldigiderslerGrid).BeginInit();
            SuspendLayout();
            // 
            // ogrencibilgiLbl
            // 
            ogrencibilgiLbl.AutoSize = true;
            ogrencibilgiLbl.Location = new Point(37, 29);
            ogrencibilgiLbl.Name = "ogrencibilgiLbl";
            ogrencibilgiLbl.Size = new Size(91, 15);
            ogrencibilgiLbl.TabIndex = 0;
            ogrencibilgiLbl.Text = "Öğrenci Bilgileri";
            // 
            // DerslerLbl
            // 
            DerslerLbl.AutoSize = true;
            DerslerLbl.Location = new Point(37, 93);
            DerslerLbl.Name = "DerslerLbl";
            DerslerLbl.Size = new Size(43, 15);
            DerslerLbl.TabIndex = 1;
            DerslerLbl.Text = "Dersler";
            // 
            // dersdatagrid
            // 
            dersdatagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dersdatagrid.Location = new Point(37, 111);
            dersdatagrid.Name = "dersdatagrid";
            dersdatagrid.RowTemplate.Height = 25;
            dersdatagrid.Size = new Size(723, 117);
            dersdatagrid.TabIndex = 2;
            // 
            // ogrderskaydetBtn
            // 
            ogrderskaydetBtn.Location = new Point(296, 393);
            ogrderskaydetBtn.Name = "ogrderskaydetBtn";
            ogrderskaydetBtn.Size = new Size(196, 23);
            ogrderskaydetBtn.TabIndex = 3;
            ogrderskaydetBtn.Text = "Öğrencinin Derslerini Kaydet";
            ogrderskaydetBtn.UseVisualStyleBackColor = true;
            ogrderskaydetBtn.Click += ogrderskaydetBtn_Click;
            // 
            // secilendersLbl
            // 
            secilendersLbl.AutoSize = true;
            secilendersLbl.Location = new Point(37, 245);
            secilendersLbl.Name = "secilendersLbl";
            secilendersLbl.Size = new Size(139, 15);
            secilendersLbl.TabIndex = 4;
            secilendersLbl.Text = "Öğrencinin Aldığı Dersler";
            // 
            // aldigiderslerGrid
            // 
            aldigiderslerGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            aldigiderslerGrid.Location = new Point(37, 263);
            aldigiderslerGrid.Name = "aldigiderslerGrid";
            aldigiderslerGrid.RowTemplate.Height = 25;
            aldigiderslerGrid.Size = new Size(723, 117);
            aldigiderslerGrid.TabIndex = 5;
            // 
            // DersSecim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(aldigiderslerGrid);
            Controls.Add(secilendersLbl);
            Controls.Add(ogrderskaydetBtn);
            Controls.Add(dersdatagrid);
            Controls.Add(DerslerLbl);
            Controls.Add(ogrencibilgiLbl);
            Name = "DersSecim";
            Text = "DersSecim";
            ((System.ComponentModel.ISupportInitialize)dersdatagrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)aldigiderslerGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ogrencibilgiLbl;
        private Label DerslerLbl;
        private DataGridView dersdatagrid;
        private Button ogrderskaydetBtn;
        private Label secilendersLbl;
        private DataGridView aldigiderslerGrid;
    }
}