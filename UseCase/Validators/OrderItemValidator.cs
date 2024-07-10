using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Validators
{
    public class OrderItemValidator : AbstractValidator<Entities.OrderItem>
    {
        public OrderItemValidator()
        {
            RuleFor(x => x.Qty).GreaterThan(0);
        }
    }
}
