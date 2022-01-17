using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtoparkTakipSistemi.Siniflar;

namespace OtoparkTakipSistemi.Formlar
{
    public partial class AracYerleri : Form
    {
        public AracYerleri()
        {
            InitializeComponent();
        }

        private void AracYerleri_Load(object sender, EventArgs e)
        {
            if (Db.hareketler == null)
            {
                XtraMessageBox.Show(
                    "Veritabanı dosyası okunmamış.Lütfen menüden \'Dosya Oku\' kısmından veritabanını sisteme tanımlayın.",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Form1 f = new Form1();
                this.Close();
                f.Show();
            }
            else
            {
                A();
                B();
                C();
                D();
            }
            
        }

        private void D()
        {
            var dList = new List<string>();
            foreach (var item in Db.hareketler)
            {
                if (item.Konum.Contains("D"))
                {
                    dList.Add(item.Konum);
                }
            }

            foreach (var item in dBlokGrup.Controls)
            {
                if (item is Button)
                {
                    Button b = item as Button;
                    if (dList.Contains(b.Text))
                    {
                        b.BackColor = Color.Red;
                        b.Tag = Db.hareketler.FirstOrDefault(c => c.Konum == b.Text).Id;
                    }
                }
            }
        }

        private void C()
        {
            var cList = new List<string>();
            foreach (var item in Db.hareketler)
            {
                if (item.Konum.Contains("C"))
                {
                    cList.Add(item.Konum);
                }
            }

            foreach (var item in cBlokGrup.Controls)
            {
                if (item is Button)
                {
                    Button b = item as Button;
                    if (cList.Contains(b.Text))
                    {
                        b.BackColor = Color.Red;
                        b.Tag = Db.hareketler.FirstOrDefault(c => c.Konum == b.Text).Id;
                    }
                }
            }
        }

        private void B()
        {
            var bList = new List<string>();
            foreach (var item in Db.hareketler)
            {
                if (item.Konum.Contains("B"))
                {
                    bList.Add(item.Konum);
                }
            }

            foreach (var item in bBlokGrup.Controls)
            {
                if (item is Button)
                {
                    Button b = item as Button;
                    if (bList.Contains(b.Text))
                    {
                        b.BackColor = Color.Red;
                        b.Tag = Db.hareketler.FirstOrDefault(c => c.Konum == b.Text).Id;
                    }
                }
            }
        }

        private void A()
        {
            var aList = new List<string>();
            foreach (var item in Db.hareketler)
            {
                if (item.Konum.Contains("A"))
                {
                    aList.Add(item.Konum);
                }
            }

            foreach (var item in aBlokGrup.Controls)
            {
                if (item is Button)
                {
                    Button b = item as Button;
                    if (aList.Contains(b.Text))
                    {
                        b.BackColor = Color.Red;
                        //b.Text = Db.hareketler.FirstOrDefault(c => c.Konum == item).Arac.Plaka;
                        b.Tag = Db.hareketler.FirstOrDefault(c => c.Konum == b.Text).Id;
                    }
                }
            }
        }

        private void Konum_Btns_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackColor == Color.Red)
            {
                var arac = Db.hareketler.FirstOrDefault(c => c.Konum == btn.Text);
                AracBilgileri f = new AracBilgileri(arac.Id.ToString());
                this.Close();
                f.Show();
            }
        }
    }
}
