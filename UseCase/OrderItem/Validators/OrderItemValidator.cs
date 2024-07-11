using FluentValidation;

namespace UseCase.OrderItem.Validators
{
    public  class OrderItemValidator : AbstractValidator<OrderItemCommand>
    {
        public OrderItemValidator()
        {
            RuleFor(x => x.Qty).GreaterThan(0);
        }
    }
}
