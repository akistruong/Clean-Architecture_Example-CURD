﻿using UseCase.Interfaces.Respositories;
using UseCase.UnitOfWork.Base;

namespace UseCase.Product.UnitOfWork
{
    public interface ICreateProductUnitOfWork : IUnitOfWorkBase
    {
        IProductRepository _productRepository { get; }
        IIventoryRepository _iventoryRepository { get; }
    }
}
