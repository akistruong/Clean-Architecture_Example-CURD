using FluentValidation;
using InterfaceAdapter.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Validators
{
    public class ProductValidator : AbstractValidator<Entities.Product>
    {
        public ProductValidator()
        {
            this.RuleFor(x => x.Qty).GreaterThan(0);
            this.RuleFor(x => x.ProductPrice).GreaterThan(0);
            this.RuleFor(x => x.ProductID).NotNull();
        }
    }
}
