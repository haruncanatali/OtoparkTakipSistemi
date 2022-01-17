using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OtoparkTakipSistemi.Siniflar;

namespace OtoparkTakipSistemi.Kontroller
{
    public class AracValidator:AbstractValidator<Arac>
    {
        public AracValidator()
        {
            this.RuleFor(c => c.Marka).Length(1, 50)
                .WithMessage("Marka alanı [1-50] karakter aralığından oluşmak zorundadır.").NotNull()
                .WithMessage("Marka alanı boş geçilemez.");
            this.RuleFor(c => c.Model).Length(1, 50)
                .WithMessage("Model alanı [1-50] karakter aralığından oluşmak zorundadır.").NotNull()
                .WithMessage("Model alanı boş geçilemez.");
            this.RuleFor(c => c.Renk).Length(1, 50)
                .WithMessage("Renk alanı [1-50] karakter aralığından oluşmak zorundadır.").NotNull()
                .WithMessage("Renk alanı boş geçilemez.");
            this.RuleFor(c => c.Plaka).Length(1, 20)
                .WithMessage("Plaka alanı [1-20] karakter aralığından oluşmak zorundadır.").NotNull()
                .WithMessage("Plaka alanı boş geçilemez.");
        }
    }
}
