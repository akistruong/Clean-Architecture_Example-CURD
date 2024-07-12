using AutoMapper;
using FluentValidation;
using MediatR;
using UseCase.Interfaces.Respositories;
using UseCase.Shared;
using UseCase.Shared.ErrorsShared;

namespace UseCase.Order.Commands.Handlers
{
    public class PlaceOrderCommandHandler(
        IProductRepository _productRepository, IOrderRepository _orderRepository, IIventoryRepository _iventoryRepository,
        IMapper mapper, IValidator<PlaceOrderCommand> validator) : IRequestHandler<PlaceOrderCommand, Result>
    {
        public async Task<Result> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            var _orderValidation = validator.Validate(request);
            if (!_orderValidation.IsValid)
            {
                return Result.Failure(ErrorsShared.InvalidModel);
            }
            var _orderAddData = mapper.Map<Entities.Order>(request);
            var _items = _orderAddData.Items;
            //Update qty item;
            for (int i = 0; i < _items.Count; i++)
            {
                var _item = _items[i];
                //Product Cart Quantity 
                var _productCartQty = _item.Qty;
                //Finded Iventory
                var _iventory = await _iventoryRepository.GetIventoryByProductID(_item.ProductID);
                ArgumentNullException.ThrowIfNull(_iventory);
                //Finded Product
                var _product = await _productRepository.SelectAsync(_item.ProductID);
                ArgumentNullException.ThrowIfNull(_product);
                ArgumentOutOfRangeException.ThrowIfNotEqual(_product.Qty, _iventory.Qty);
                var _remainingStock = _iventory.Qty - _productCartQty;
                if (_remainingStock > 0)
                {
                    // Product updated
                    _product.Qty -= _productCartQty;
                    //Iventory updated
                    _iventory.Qty -= _productCartQty;
                }
                else if (_remainingStock == 0)
                {
                    _product.IsStock = false;
                    // Product updated
                    _product.Qty -= _productCartQty;
                    //Iventory updated
                    _iventory.Qty -= _productCartQty;
                }
                else
                {
                    return Result.Failure(OrderErrors.QtyInvalid);
                }
                _item.Price = _product.ProductPrice;
                _productRepository.Update(_product);
                _iventoryRepository.Update(_iventory);
            }
            //Create Order 
            await HandleInsertOrder(_orderAddData);
            // Save and Commit
            return Result.Success;
        }

        private async Task HandleInsertOrder(Entities.Order _orderAddData)
        {
            _orderAddData.OrderID = Guid.NewGuid().ToString();
            _orderAddData.TotalQty = _orderAddData.GetTotalQty();
            _orderAddData.TotalOrder = _orderAddData.GetFinalPrice();
            await _orderRepository.InsertAsync(_orderAddData);
        }
    }
}
