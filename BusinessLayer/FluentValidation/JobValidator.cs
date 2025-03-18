using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class JobValidator : AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Kategori Adı En Az 3 Karakter Olmalıdır");
     

        }
    }
}
