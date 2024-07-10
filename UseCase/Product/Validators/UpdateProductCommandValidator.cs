using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Product.Command;

namespace UseCase.Product.Validators
{
    public sealed class UpdateProductCommandValidator:AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            this.RuleFor(x => x.Qty).GreaterThan(0);
            this.RuleFor(x => x.ProductPrice).GreaterThan(0);
            this.RuleFor(x => x.ProductID).NotNull();
        }
    }
}
