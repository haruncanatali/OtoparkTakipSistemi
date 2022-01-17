using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OtoparkTakipSistemi.Siniflar;

namespace OtoparkTakipSistemi.Kontroller
{
    public class HareketValidator:AbstractValidator<Hareket>
    {
        public HareketValidator()
        {
            this.RuleFor(c => c.Id).NotNull()
                .WithMessage("ID alanı boş geçilemez.");
            this.RuleFor(c => c.Konum).NotNull()
                .WithMessage("Konum alanı boş geçilemez.").Must(KonumArastir).WithMessage("Belirtilen konum doludur.");
            this.RuleFor(c => c.GirisTarihi).NotNull()
                .WithMessage("Giriş Tarihi boş geçilemez.");
            this.RuleFor(c => c.Arac).NotNull()
                .WithMessage("Harekete ait bir araç ve ona bağlı bir müşteri olmalıdır.");
        }

        public bool KonumArastir(string arg)
        {
            if (Db.hareketler!=null && Db.hareketler.Count>0)
            {
                foreach (var item in Db.hareketler)
                {
                    if (item.Konum == arg)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
