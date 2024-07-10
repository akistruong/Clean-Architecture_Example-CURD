using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Validators
{
    public sealed class OrderValidator : AbstractValidator<Entities.Order>
    {
        public OrderValidator()
        {
            this.RuleFor(x => x.TotalOrder).GreaterThan(0);
            this.RuleFor(x => x.TotalQty).GreaterThan(0);
            this.RuleFor(x => x.EmailOrder).EmailAddress();
            this.RuleForEach(x => x.Items).SetValidator(new OrderItemValidator());
        }
    }
}
