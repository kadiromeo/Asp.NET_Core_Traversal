using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(m => m.Description).NotEmpty().WithMessage("Açıklama boş geçilemez...!");
            RuleFor(m => m.Description).MinimumLength(50).WithMessage("Lütfen en az 50 karakterlik açıklama giriniz...!");
            RuleFor(m => m.Description).MaximumLength(1500).WithMessage("Lütfen en fazla 1500 karakterlik açıklama giriniz...!");
            RuleFor(m => m.Image1).NotEmpty().WithMessage("Lütfen görsel seçin...!");
        }
    }
}
