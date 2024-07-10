using FluentValidation;

namespace UseCase.OrderItem.Validators
{
    public  class OrderItemValidator : AbstractValidator<Entities.OrderItem>
    {
        public OrderItemValidator()
        {
            RuleFor(x => x.Qty).GreaterThan(0);
        }
    }
}
