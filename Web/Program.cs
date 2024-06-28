using Entities.Respositories;
using Infrastructure.MongoDB.Data;
using Infrastructure.MongoDB.Repositories;
using Infrastructure.MongoDB.Repositories.Iventory;
using Infrastructure.MongoDB.Repositories.Order;
using Infrastructure.MongoDB.Repositories.UnitOfWork.Product;
using Infrastructure.MySQL;
using Infrastructure.MySQL.Repositories;
using Infrastructure.MySQL.Repositories.Pagination;
using Infrastructure.MySQL.Repositories.Pagination.Product;
using Infrastructure.MySQL.UnitOfWork.Order;
using Infrastructure.MySQL.UnitOfWork.Product;
using System.Net;
using UseCase.Order;
using UseCase.Pagination.Base;
using UseCase.Pagination.Product;
using UseCase.Product.Command;
using UseCase.Product.Command.Handler;
using UseCase.Product.Query;
using UseCase.Product.Query.Handler;
using UseCase.Product.UnitOfWork;
using UseCase.UnitOfWork.Order;

var builder = WebApplication.CreateBuilder(args);
var Database = "MYSQL";
// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
if (Database=="MYSQL")
{
    //MYSQL
    builder.Services.AddDbContext<OrderDbContext>();
        /*PRODUCT*/
    builder.Services.AddTransient<IProductRepository, ProductRepository>();
    builder.Services.AddTransient<ICreateProductUnitOfWork, CreateProductUnitOfWork>();
    builder.Services.AddTransient<ICreateProduct, CreateProduct>();
    builder.Services.AddTransient<IUpdateProduct, UpdateProduct>();
    builder.Services.AddTransient<IDeleteProduct, DeleteProduct>();
    builder.Services.AddTransient<IProductQuery, ProductQuery>();
    /* ORDER*/
    builder.Services.AddTransient<IOrderRepository, OrderRepository>();
    builder.Services.AddTransient<ICreateOrderUnitOfWork, CreateOrderUnitOfWork>();
    builder.Services.AddTransient<IPlaceOrder, PlaceOrder>();
    /*IVENTORY*/
    builder.Services.AddTransient<IIventoryRepository, IventoryRepository>();
    /*PAGINATION*/
    builder.Services.AddTransient<IProductPagination,ProductPagination>();

}
else
{
    //MONGODB
    builder.Services.AddTransient<MongoDBService>();
    builder.Services.AddTransient<IProductRepository, MongoProductRepository>();
    builder.Services.AddTransient<IIventoryRepository, MongoDbIventoryRepository>();
    builder.Services.AddTransient<IOrderRepository, MongoDbOrderRepository>();
    builder.Services.AddTransient<ICreateProductUnitOfWork, MongoDbCreateProductUnitOfWork>();
    builder.Services.AddTransient<ICreateProduct, CreateProduct>();
}



builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
}); ;

var app = builder.Build();
app.UseExceptionHandler(option =>
{
    option.Run(async (context) =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    });
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
