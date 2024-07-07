using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.UnitOfWork.Order;

namespace UseCase.Order.Commands.Handlers
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, OrderResult>
    {
        private readonly ICreateOrderUnitOfWork _createOrderUnitOfWork;
        private IMapper _mapper;
        public PlaceOrderCommandHandler(ICreateOrderUnitOfWork createOrderUnitOfWork, IMapper mapper)
        {
            _createOrderUnitOfWork = createOrderUnitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderResult> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _createOrderUnitOfWork.Begin();
                var _orderAddData = _mapper.Map<Entities.Order>(request._request);
                var _items = _orderAddData.Items;
                //Update qty item;
                for (int i = 0; i < _items.Count; i++)
                {
                    var _item = _items[i];   
                    if (_item.Qty <= 0) return OrderResult.QtyInvalid;
                    //Product Cart Quantity 
                    var _productCartQty = _item.Qty;
                    //Finded Iventory
                    var _iventory = await _createOrderUnitOfWork._iventoryRepository.GetIventoryByProductID(_item.ProductID);
                    ArgumentNullException.ThrowIfNull(_iventory);
                    //Finded Product
                    var _product = await _createOrderUnitOfWork._productRepository.SelectAsync(_item.ProductID);
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
                        return OrderResult.QtyInvalid;
                    }
                    _item.Price = _product.ProductPrice;
                    _createOrderUnitOfWork._productRepository.Update(_product);
                    _createOrderUnitOfWork._iventoryRepository.Update(_iventory);
                }
                //Create Order 
                await HandleInsertOrder(_orderAddData);
                // Save and Commit
                await _createOrderUnitOfWork.Commit();
                return OrderResult.Success;

            }
            catch (Exception ex)
            {
                await _createOrderUnitOfWork.Cancel();
                return OrderResult.Faild;
            }
        }

        private async Task HandleInsertOrder(Entities.Order _orderAddData)
        {
            _orderAddData.OrderID = Guid.NewGuid().ToString();
            _orderAddData.TotalQty = _orderAddData.GetTotalQty();
            _orderAddData.TotalOrder = _orderAddData.GetFinalPrice();
            await _createOrderUnitOfWork._orderRepository.InsertAsync(_orderAddData);
        }
    }
}
