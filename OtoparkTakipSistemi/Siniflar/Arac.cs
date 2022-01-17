using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoparkTakipSistemi.Siniflar
{
    public class Arac
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Renk { get; set; }
        public string Plaka { get; set; }

        public virtual Musteri Musteri { get; set; }
    }
}
