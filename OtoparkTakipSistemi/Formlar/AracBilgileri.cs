using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtoparkTakipSistemi.Kontroller;
using OtoparkTakipSistemi.Siniflar;

namespace OtoparkTakipSistemi.Formlar
{
    public partial class AracBilgileri : Form
    {
        private int index = 0;
        private Hareket mevcutHareket = null;

        public AracBilgileri(string val = null)
        {
            InitializeComponent();
            if (val!=null)
            {
                for (int i = 0; i < Db.hareketler.Count; i++)
                {
                    if (Db.hareketler[i].Id.ToString() == val)
                    {
                        index = i ;
                        break;
                    }
                }           
            }
        }

        private void AracBilgileri_Load(object sender, EventArgs e)
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
                HareketBaslangicYonlendirme();
            }

        }

        private void HareketBaslangicYonlendirme()
        {
            if (Db.hareketler.Count == 0)
            {
                siraGosterimTxt.Text = "0";
            }
            else
            {
                if (index!=0)
                {
                    siraGosterimTxt.Text = index+1 + "/" + Db.hareketler.Count;
                    BilgiDoldur(Db.hareketler[index]);
                }
                else
                {
                    siraGosterimTxt.Text = "1/" + Db.hareketler.Count;
                    BilgiDoldur(Db.hareketler.First());
                }
            }
        }

        private void BilgiDoldur(Hareket entity)
        {

            mevcutHareket = entity;

            musteriAdTxt.Text = entity.Arac.Musteri.Ad;
            musteriSoyadTxt.Text = entity.Arac.Musteri.Soyad;
            musteriCepTelTxt.Text = entity.Arac.Musteri.Tel;
            musteriTcknTxt.Text = entity.Arac.Musteri.Tckn;

            aracMarkaTxt.Text = entity.Arac.Marka;
            aracModelTxt.Text = entity.Arac.Model;
            aracRenkTxt.Text = entity.Arac.Renk;
            aracPlakaTxt.Text = entity.Arac.Plaka;

            hesapKonumCbx.Text = entity.Konum;
            hesapGirisTarihiTxt.Text = entity.GirisTarihi.ToString();
            hesapIcTemizlikChck.Checked = entity.IcTemizlik == true ? true : false;
            hesapDisTemizliChck.Checked = entity.DisTemizlik == true ? true : false;
        }

        private void AracBilgileri_VTBtns_Clik(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            switch (btn.Name)
            {
                case "aracGirisiBtn":
                    AracGirisi();
                    break;
                case "aracCikisiBtn":
                    AracCikisi();
                    break;
                case "aracGuncelleBtn":
                    AracGuncelle();
                    break;
                case "aracYenileBtn":
                    Yenile();
                    break;
                case "aracTemizleBtn":
                    Temizlik();
                    break;
                case "anaMenuBtn":
                    GitAnaMenuBtn();
                    break;
            }
        }

        private void AracGuncelle()
        {
            if (mevcutHareket != null)
            {
                try
                {
                    Musteri musteri = new Musteri
                    {
                        Ad = musteriAdTxt.Text,
                        Soyad = musteriSoyadTxt.Text,
                        Tckn = musteriTcknTxt.Text,
                        Tel = musteriCepTelTxt.Text
                    };
                    var musResult = (new MusteriValidator()).Validate(musteri);

                    Arac arac = new Arac
                    {
                        Marka = aracMarkaTxt.Text,
                        Model = aracModelTxt.Text,
                        Plaka = aracPlakaTxt.Text,
                        Renk = aracRenkTxt.Text,
                        Musteri = musteri
                    };
                    var aracResult = (new AracValidator()).Validate(arac);

                    if (!aracResult.IsValid || !musResult.IsValid)
                    {
                        var temp = "";
                        if (!musResult.IsValid)
                        {
                            foreach (var item in musResult.Errors)
                            {
                                temp += "\n-" + item.ErrorMessage;
                            }
                        }

                        if (!aracResult.IsValid)
                        {
                            foreach (var item in aracResult.Errors)
                            {
                                temp += "\n-" + item.ErrorMessage;
                            }
                        }

                        throw new ValidationException(temp);
                    }

                    if (hesapKonumCbx.Text != null)
                    {
                        bool durum = false;
                        foreach (var item in Db.hareketler)
                        {
                            if (item.Konum!=mevcutHareket.Konum && item.Konum == hesapKonumCbx.Text)
                            {
                                durum = true;
                                break;
                            }
                        }

                        if (durum)
                        {
                            XtraMessageBox.Show("Seçilen konum doludur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            DateTime dt;
                            try
                            {
                                dt = DateTime.Parse(hesapGirisTarihiTxt.Text);
                                Db.hareketler.FirstOrDefault(c => c.Id == mevcutHareket.Id).Konum = null;

                                var hareketx = new Hareket
                                {
                                    Id = mevcutHareket.Id,
                                    GirisTarihi = DateTime.Parse(hesapGirisTarihiTxt.Text.ToString()),
                                    IcTemizlik = hesapIcTemizlikChck.Checked == true ? true : false,
                                    DisTemizlik = hesapDisTemizliChck.Checked == true ? true : false,
                                    Konum = hesapKonumCbx.Text,
                                    Arac = arac
                                };

                                var e_h = Db.hareketler.FirstOrDefault(c => c.Id == mevcutHareket.Id);
                                var indexx = Db.hareketler.IndexOf(e_h);
                                Db.hareketler[indexx] = hareketx;

                                mevcutHareket = null;
                                XtraMessageBox.Show(hareketx.Arac.Plaka + " plakalı aracın güncellemesi başarılı oldu.",
                                    "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception e)
                            {
                                XtraMessageBox.Show("Giriş tarihi tarih formatı hatalıdır.", "Hata", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Lütfen konum seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    index = 0;
                    HareketBaslangicYonlendirme();
                }
                catch (Exception e)
                {
                    XtraMessageBox.Show("Hata meydana geldi.Mesaj:" + e.Message, "Hata", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("Odaklanmış bir hareket bulunmalıdır.", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AracCikisi()
        {
            if (mevcutHareket!=null)
            {
                TimeSpan span = DateTime.Now - mevcutHareket.GirisTarihi;
                var ucret = decimal.Parse(span.Hours.ToString()) * (5.60m);
                if (ucret == 0.0m)
                {
                    ucret = 5.60m;
                }
                XtraMessageBox.Show(
                    mevcutHareket.Arac.Plaka + " plakalı aracın çıkışı başarılı olmuştur. Toplam ücret " +
                    ucret.ToString("0.00") + " TL dir. İyi günler dileriz.", "Bilgilendirme", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Db.hareketler.Remove(mevcutHareket);
                Temizlik(true);
                index = 0;
                HareketBaslangicYonlendirme();
            }
            else
            {
                XtraMessageBox.Show("Odaklanmış bir hareket bulunmalıdır.", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Yenile()
        {
            HareketBaslangicYonlendirme();
        }

        private void Temizlik(bool aracCikis = false)
        {
            if (aracCikis == true)
            {
                mevcutHareket = null;
            }

            musteriAdTxt.Text = "";
            musteriSoyadTxt.Text = "";
            musteriCepTelTxt.Text = "";
            musteriTcknTxt.Text = "";
            aracMarkaTxt.Text = "";
            aracModelTxt.Text = "";
            aracRenkTxt.Text = "";
            aracPlakaTxt.Text = "";
            hesapKonumCbx.Text = "";
            hesapGirisTarihiTxt.Text = "";
            hesapIcTemizlikChck.Checked = false;
            hesapDisTemizliChck.Checked = false;
        }

        private void AracGirisi()
        {
            if (Db.hareketler.Count == 20)
            {
                XtraMessageBox.Show("Otopark kapasitesi doludur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                index = 0;
                HareketBaslangicYonlendirme();
            }
            else
            {
                try
                {
                    Musteri musteri = new Musteri
                    {
                        Ad = musteriAdTxt.Text,
                        Soyad = musteriSoyadTxt.Text,
                        Tckn = musteriTcknTxt.Text,
                        Tel = musteriCepTelTxt.Text
                    };
                    var musResult = (new MusteriValidator()).Validate(musteri);

                    Arac arac = new Arac
                    {
                        Marka = aracMarkaTxt.Text,
                        Model = aracModelTxt.Text,
                        Plaka = aracPlakaTxt.Text,
                        Renk = aracRenkTxt.Text,
                        Musteri = musteri
                    };
                    var aracResult = (new AracValidator()).Validate(arac);

                    Hareket hareket = new Hareket
                    {
                        Id = Guid.NewGuid(),
                        GirisTarihi = DateTime.Parse(hesapGirisTarihiTxt.Text.ToString()),
                        IcTemizlik = hesapIcTemizlikChck.Checked == true ? true : false,
                        DisTemizlik = hesapDisTemizliChck.Checked == true ? true : false,
                        Konum = hesapKonumCbx.Text,
                        Arac = arac
                    };
                    var hareketResult = (new HareketValidator()).Validate(hareket);

                    if (musResult.IsValid && aracResult.IsValid && hareketResult.IsValid)
                    {
                        Db.hareketler.Add(hareket);
                        XtraMessageBox.Show("Araç giriş başarılı oldu.", "Bilgilendirme", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        index = 0;
                        HareketBaslangicYonlendirme();
                    }
                    else
                    {
                        var temp = "";
                        if (!musResult.IsValid)
                        {
                            foreach (var item in musResult.Errors)
                            {
                                temp += "\n-" + item.ErrorMessage;
                            }
                        }

                        if (!aracResult.IsValid)
                        {
                            foreach (var item in aracResult.Errors)
                            {
                                temp += "\n-" + item.ErrorMessage;
                            }
                        }

                        if (!hareketResult.IsValid)
                        {
                            foreach (var item in hareketResult.Errors)
                            {
                                temp += "\n-" + item.ErrorMessage;
                            }
                        }

                        throw new ValidationException(temp);
                    }

                }
                catch (Exception e)
                {
                    XtraMessageBox.Show("Hata meydana geldi. Mesaj:" + e.Message, "Hata", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void GitAnaMenuBtn()
        {
            Form1 f1 = new Form1();
            this.Close();
            f1.Show();
        }

        private void tarihAlBtn_Click(object sender, EventArgs e)
        {
            hesapGirisTarihiTxt.Text = DateTime.Now.ToString();
        }

        private void Yonlendirme_Btns_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            if (Db.hareketler.Count>0)
            {
                switch (btn.Name)
                {
                    case "ilkAracBtn":
                        index = 0;
                        HareketBaslangicYonlendirme();
                        break;
                    case "oncekiAracBtn":
                        OncekiAracGosterici();
                        break;
                    case "sonrakiAracBtn":
                        SonrakiAracGosterici();
                        break;
                    case "sonAracBtn":
                        SonAracGosterici();
                        break;
                }
            }
        }

        private void SonAracGosterici()
        {
            if (Db.hareketler.Count == 0)
            {
                index = 0;
                HareketBaslangicYonlendirme();
            }
            else
            {
                index = Db.hareketler.IndexOf(Db.hareketler.Last());
                HareketBaslangicYonlendirme();
            }
        }

        private void OncekiAracGosterici()
        {
            if (Db.hareketler.Count!=1)
            {
                if (mevcutHareket!= Db.hareketler.First())
                {
                    var h_index = Db.hareketler.IndexOf(mevcutHareket);
                    index = h_index - 1;
                    HareketBaslangicYonlendirme();
                }
            }
        }

        private void SonrakiAracGosterici()
        {
            if (Db.hareketler.Count!=1)
            {
                if (mevcutHareket != Db.hareketler.Last())
                {
                    var h_index = Db.hareketler.IndexOf(mevcutHareket);
                    index = h_index + 1;
                    HareketBaslangicYonlendirme();
                }
            }
        }
    }
}
