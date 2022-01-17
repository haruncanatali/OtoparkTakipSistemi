
namespace OtoparkTakipSistemi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuDosyaOkuBtn = new DevExpress.XtraEditors.SimpleButton();
            this.menuDosyaKaydetBtn = new DevExpress.XtraEditors.SimpleButton();
            this.menuAracBilgileriBtn = new DevExpress.XtraEditors.SimpleButton();
            this.menuAracYerleriBtn = new DevExpress.XtraEditors.SimpleButton();
            this.menuCikisBtn = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // menuDosyaOkuBtn
            // 
            this.menuDosyaOkuBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menuDosyaOkuBtn.Appearance.Options.UseFont = true;
            this.menuDosyaOkuBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.menuDosyaOkuBtn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.menuDosyaOkuBtn.Location = new System.Drawing.Point(73, 112);
            this.menuDosyaOkuBtn.Name = "menuDosyaOkuBtn";
            this.menuDosyaOkuBtn.Size = new System.Drawing.Size(148, 109);
            this.menuDosyaOkuBtn.TabIndex = 0;
            this.menuDosyaOkuBtn.Text = "Dosya Oku";
            this.menuDosyaOkuBtn.Click += new System.EventHandler(this.Menu_Btns_Click);
            // 
            // menuDosyaKaydetBtn
            // 
            this.menuDosyaKaydetBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menuDosyaKaydetBtn.Appearance.Options.UseFont = true;
            this.menuDosyaKaydetBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.menuDosyaKaydetBtn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.menuDosyaKaydetBtn.Location = new System.Drawing.Point(227, 112);
            this.menuDosyaKaydetBtn.Name = "menuDosyaKaydetBtn";
            this.menuDosyaKaydetBtn.Size = new System.Drawing.Size(148, 109);
            this.menuDosyaKaydetBtn.TabIndex = 0;
            this.menuDosyaKaydetBtn.Text = "Dosya Kaydet";
            this.menuDosyaKaydetBtn.Click += new System.EventHandler(this.Menu_Btns_Click);
            // 
            // menuAracBilgileriBtn
            // 
            this.menuAracBilgileriBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menuAracBilgileriBtn.Appearance.Options.UseFont = true;
            this.menuAracBilgileriBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.menuAracBilgileriBtn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.menuAracBilgileriBtn.Location = new System.Drawing.Point(73, 227);
            this.menuAracBilgileriBtn.Name = "menuAracBilgileriBtn";
            this.menuAracBilgileriBtn.Size = new System.Drawing.Size(148, 109);
            this.menuAracBilgileriBtn.TabIndex = 0;
            this.menuAracBilgileriBtn.Text = "Araç Bilgileri";
            this.menuAracBilgileriBtn.Click += new System.EventHandler(this.Menu_Btns_Click);
            // 
            // menuAracYerleriBtn
            // 
            this.menuAracYerleriBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menuAracYerleriBtn.Appearance.Options.UseFont = true;
            this.menuAracYerleriBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.ImageOptions.Image")));
            this.menuAracYerleriBtn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.menuAracYerleriBtn.Location = new System.Drawing.Point(227, 227);
            this.menuAracYerleriBtn.Name = "menuAracYerleriBtn";
            this.menuAracYerleriBtn.Size = new System.Drawing.Size(148, 109);
            this.menuAracYerleriBtn.TabIndex = 0;
            this.menuAracYerleriBtn.Text = "Araç Yerleri";
            this.menuAracYerleriBtn.Click += new System.EventHandler(this.Menu_Btns_Click);
            // 
            // menuCikisBtn
            // 
            this.menuCikisBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menuCikisBtn.Appearance.Options.UseFont = true;
            this.menuCikisBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton5.ImageOptions.Image")));
            this.menuCikisBtn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.menuCikisBtn.Location = new System.Drawing.Point(152, 342);
            this.menuCikisBtn.Name = "menuCikisBtn";
            this.menuCikisBtn.Size = new System.Drawing.Size(148, 109);
            this.menuCikisBtn.TabIndex = 0;
            this.menuCikisBtn.Text = "Çıkış";
            this.menuCikisBtn.Click += new System.EventHandler(this.Menu_Btns_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelControl1.Location = new System.Drawing.Point(114, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(212, 23);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Otopark Takip Sistemi";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 476);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.menuCikisBtn);
            this.Controls.Add(this.menuAracYerleriBtn);
            this.Controls.Add(this.menuAracBilgileriBtn);
            this.Controls.Add(this.menuDosyaKaydetBtn);
            this.Controls.Add(this.menuDosyaOkuBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Otopark Takip Sistemi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton menuDosyaOkuBtn;
        private DevExpress.XtraEditors.SimpleButton menuDosyaKaydetBtn;
        private DevExpress.XtraEditors.SimpleButton menuAracBilgileriBtn;
        private DevExpress.XtraEditors.SimpleButton menuAracYerleriBtn;
        private DevExpress.XtraEditors.SimpleButton menuCikisBtn;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}

