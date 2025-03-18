using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Kategori Adı En Az 3 Karakter Olmalıdır");
            RuleFor(p => p.City).NotEmpty().WithMessage("Şehir Adı Boş Geçilemez");
            RuleFor(p => p.City).MinimumLength(3).WithMessage("Şehir Adı En Az 3 Karakter Olmalıdır");


        }
    }

}