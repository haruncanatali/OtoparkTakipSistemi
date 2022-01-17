using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtoparkTakipSistemi.Formlar;
using OtoparkTakipSistemi.Siniflar;

namespace OtoparkTakipSistemi
{
    public partial class Form1 : Form
    {
        private bool cikisKontrol = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Menu_Btns_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            switch (btn.Name)
            {
                case "menuDosyaOkuBtn":
                    DosyaOku();
                    break;
                case "menuDosyaKaydetBtn":
                    DosyaKaydet();
                    break;
                case "menuAracBilgileriBtn":
                    GitAracBilgileriForm();
                    break;
                case "menuAracYerleriBtn":
                    GitAracYerleriForm();
                    break;
                case "menuCikisBtn":
                    Cikis();
                    break;
            }
        }

        private void GitAracYerleriForm()
        {
            AracYerleri f = new AracYerleri();
            this.Hide();
            f.Show();
        }

        private void GitAracBilgileriForm()
        {
            AracBilgileri f1 = new AracBilgileri();
            this.Hide();
            f1.Show();
        }

        private void Cikis()
        {
            if (XtraMessageBox.Show("Çıkış yapmak istediğinize emin misiniz?","Bilgilendirme",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void DosyaKaydet()
        {
            if (DbKey.GirisPath == null)
            {
                XtraMessageBox.Show("Giriş dosyası seçmediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (File.Exists(DbKey.GirisPath))
                {
                    if (Db.hareketler != null && Db.hareketler.Count > 0)
                    {
                        try
                        {
                            if (!Directory.Exists(DbKey.DbDirectoryPath))
                            {
                                Directory.CreateDirectory(DbKey.DbDirectoryPath);
                            }

                            if (!File.Exists(DbKey.DbFilePath))
                            {
                                using (var mFile = File.Create(DbKey.DbFilePath))
                                {
                                    mFile.Close();
                                }
                            }

                            var temp = "";

                            foreach (var item in Db.hareketler)
                            {
                                temp += item.Id + "#" + item.Arac.Musteri.Ad + "#" + item.Arac.Musteri.Soyad + "#" +
                                        item.Arac.Musteri.Tel + "#" + item.Arac.Musteri.Tckn + "#" + item.Arac.Plaka +
                                        "#" + item.Arac.Marka + "#" + item.Arac.Model + "#" + item.Arac.Renk + "#" +
                                        item.Konum + "#" + item.GirisTarihi + "#" + item.IcTemizlik + "#" +
                                        item.DisTemizlik + "\n";
                            }


                            File.WriteAllText(DbKey.DbFilePath,temp);

                            if (XtraMessageBox.Show("Kayıt başarılı oldu. Kayıt dosyasına gitmek istiyor musunuz?", "Bilgilerdirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                Process.Start(DbKey.DbFilePath);
                            }
                        }
                        catch (Exception e)
                        {
                            XtraMessageBox.Show("Hata meydana geldi.Mesaj:" + e.Message, "Hata", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Park hareketleri boş!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DosyaOku()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Text|*.txt|All|*.*";
            fd.ShowDialog();

            if (!String.IsNullOrEmpty(fd.FileName))
            {
                DbKey.GirisPath = fd.FileName;
                try
                {
                    Db.Singleton();
                    Db.DosyaOkuVeKaydet(File.ReadAllText(DbKey.GirisPath));
                }
                catch (Exception e)
                {
                    XtraMessageBox.Show("Dosyadaki veriler okunurken hata meydana geldi.Mesaj:" + e.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                XtraMessageBox.Show("Veritabanı dosyası başarıyla içeriye alındı.", "Bilgilendirme",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
