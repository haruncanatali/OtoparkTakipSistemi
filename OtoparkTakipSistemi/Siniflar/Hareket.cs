using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoparkTakipSistemi.Siniflar
{
    public class Hareket
    {
        public Guid Id { get; set; }
        public string Konum { get; set; }
        public DateTime GirisTarihi { get; set; }
        public bool IcTemizlik { get; set; }
        public bool DisTemizlik { get; set; }

        public virtual Arac Arac { get; set; }
    }
}
