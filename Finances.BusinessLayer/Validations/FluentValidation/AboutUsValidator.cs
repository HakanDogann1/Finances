using Finances.DtoLayer.DTOs.AboutUs;
using Finances.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.BusinessLayer.Validations.FluentValidation
{
    public class AboutUsValidator:AbstractValidator<AboutUs>
    {
        public AboutUsValidator()
        {
            RuleFor(x => x.AboutUsTitle).NotEmpty().WithMessage("Başlık Alanı Boş Bırakılamaz...");
            RuleFor(x => x.AboutUsDescription).NotEmpty().WithMessage("İçerik Alanı Boş Bırakılamaz...");
        }
    }
}
