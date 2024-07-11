﻿using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Shared;
using UseCase.UnitOfWork.Order;

namespace UseCase.Order.Commands.Handlers
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, Result>
    {
        private readonly ICreateOrderUnitOfWork _createOrderUnitOfWork;
        private IMapper _mapper;
        private IValidator<PlaceOrderCommand> _validator;



        public PlaceOrderCommandHandler(ICreateOrderUnitOfWork createOrderUnitOfWork, IMapper mapper, IValidator<PlaceOrderCommand> validator)
        {
            _createOrderUnitOfWork = createOrderUnitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<Result> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _createOrderUnitOfWork.Begin();
                var _orderValidation = _validator.Validate(request);
                if (!_orderValidation.IsValid)
                {
                    return Result.Failure(new Error("Validation invalid"));
                }
                var _orderAddData = _mapper.Map<Entities.Order>(request);
                var _items = _orderAddData.Items;
                //Update qty item;
                for (int i = 0; i < _items.Count; i++)
                {
                    var _item = _items[i];   
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
                        return Result.Failure(new Error("Quantity invalid"));
                    }
                    _item.Price = _product.ProductPrice;
                    _createOrderUnitOfWork._productRepository.Update(_product);
                    _createOrderUnitOfWork._iventoryRepository.Update(_iventory);
                }
                //Create Order 
                await HandleInsertOrder(_orderAddData);
                // Save and Commit
                await _createOrderUnitOfWork.Commit();
                return Result.Success();

            }
            catch (Exception ex)
            {
                await _createOrderUnitOfWork.Cancel();
                throw ex;
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
