using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoparkTakipSistemi.Siniflar
{
    public class Db
    {
        public static List<Hareket> hareketler;

        public static void Singleton()
        {
            if (hareketler==null)
            {
                hareketler = new List<Hareket>();
            }
        }

        public static void DosyaOkuVeKaydet(string data)
        {
            string[] satirlar = data.Split('\n');
            for (int i = 0; i < satirlar.Length; i++)
            {
                string[] satirVerisi = satirlar[i].Split('#');

                var musteri = new Musteri
                {
                    Ad = satirVerisi[1].ToString(),
                    Soyad = satirVerisi[2].ToString(),
                    Tckn = satirVerisi[4].ToString(),
                    Tel = satirVerisi[3].ToString()
                };

                var arac = new Arac
                {
                    Marka = satirVerisi[6].ToString(),
                    Model = satirVerisi[7].ToString(),
                    Renk = satirVerisi[8].ToString(),
                    Plaka = satirVerisi[5].ToString(),
                    Musteri = musteri
                };

                var hareket = new Hareket
                {
                    Id = Guid.Parse(satirVerisi[0].ToString()),
                    GirisTarihi = DateTime.Parse(satirVerisi[10].ToString()),
                    IcTemizlik = bool.Parse(satirVerisi[11].ToString()),
                    DisTemizlik = bool.Parse(satirVerisi[12].ToString()),
                    Konum = satirVerisi[9].ToString(),
                    Arac = arac
                };
                Db.hareketler.Add(hareket);
            }
        }
    }
}
