using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Ürün Adı Boş Geçilemez");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Ürün Adı En Az 3 Karakter Olmalıdır");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Fiyat Boş Geçilemez");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır");
            RuleFor(p => p.Stock).NotEmpty().WithMessage("Stok Adedi Boş Geçilemez");
            RuleFor(p => p.Stock).GreaterThan(0).WithMessage("Stok Adedi 0'dan büyük olmalıdır");

        }
    }
}

