using FluentValidation;
using UseCase.Order.Commands;
using UseCase.OrderItem.Validators;
namespace UseCase.Order.Validators
{
    public sealed class PlaceOrderCommandValidator : AbstractValidator<PlaceOrderCommand>
    {
        public PlaceOrderCommandValidator()
        {
            //this.RuleFor(x => x.TotalOrder).GreaterThan(0);
            //this.RuleFor(x => x.TotalQty).GreaterThan(0);
            this.RuleFor(x => x.EmailOrder).EmailAddress();
            this.RuleForEach(x => x.Items).SetValidator(new OrderItemValidator());
        }
    }
}
