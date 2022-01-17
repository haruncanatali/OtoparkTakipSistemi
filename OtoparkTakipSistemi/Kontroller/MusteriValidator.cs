using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OtoparkTakipSistemi.Siniflar;

namespace OtoparkTakipSistemi.Kontroller
{
    public class MusteriValidator:AbstractValidator<Musteri>
    {
        public MusteriValidator()
        {
            this.RuleFor(c => c.Ad).Length(1, 50)
                .WithMessage("Ad alanı [1-50] karakter aralığından oluşmak zorundadır.").NotNull()
                .WithMessage("Ad alanı boş geçilemez.");
            this.RuleFor(c => c.Soyad).Length(1, 50)
                .WithMessage("Soyad alanı [1-50] karakter aralığından oluşmak zorundadır.").NotNull()
                .WithMessage("Soyad alanı boş geçilemez.");
            this.RuleFor(c => c.Tel).Length(1, 20)
                .WithMessage("Telefon alanı [1-20] karakter aralığından oluşmak zorundadır.").NotNull()
                .WithMessage("Telefon alanı boş geçilemez.");
            this.RuleFor(c => c.Tckn).Length(1, 11)
                .WithMessage("TC Kimlik No alanı [1-11] karakter aralığından oluşmak zorundadır.").NotNull()
                .WithMessage("TC Kimlik No alanı boş geçilemez.");
        }
    }
}
