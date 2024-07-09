using Entities.Respositories;
using FluentValidation;
using Infrastructure.MongoDB.Data;
using Infrastructure.MongoDB.Repositories.Iventory;
using Infrastructure.MongoDB.Repositories.Order;
using Infrastructure.MongoDB.Repositories.Product;
using Infrastructure.MongoDB.Repositories.UnitOfWork.Order;
using Infrastructure.MongoDB.Repositories.UnitOfWork.Product;
using Infrastructure.MySQL;
using Infrastructure.SQLServer;
using System.Net;
using System.Reflection;
using UseCase.Order.Commands.Handlers;
using UseCase.Product.Command.Handler;
using UseCase.Product.Query.Handler;
using UseCase.Product.UnitOfWork;
using UseCase.UnitOfWork.Base;
using UseCase.UnitOfWork.Order;
using UseCase.Validators;

var builder = WebApplication.CreateBuilder(args);
var Database = "MYSQL";
// Add services to the container.
builder.Services.AddAutoMapper(Assembly.Load("InterfaceAdapter"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// add service MediatR
builder.Services.AddMediatR(cfg =>
{
    //PRODUCT
    cfg.RegisterServicesFromAssembly(typeof(PropductQueryCommandHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CreateProductCommandHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(UpdateProductCommandHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(DeleteProductCommandHandler).Assembly);
    //ORDER
    cfg.RegisterServicesFromAssembly(typeof(PlaceOrderCommandHandler).Assembly);


});
//VALIDATORS
builder.Services.AddScoped<IValidator<Entities.Product>, ProductValidator>();
if (Database == "MYSQL")
{
    //MYSQL
    builder.Services.AddDbContext<OrderDbContext>();
    /*PRODUCT*/
    /*PRODUCT*/
    builder.Services.AddTransient<IProductRepository, Infrastructure.MySQL.Repositories.ProductRepository>();
    builder.Services.AddTransient<ICreateProductUnitOfWork, Infrastructure.MySQL.UnitOfWork.Product.CreateProductUnitOfWork>();
    /* ORDER*/
    builder.Services.AddTransient<IOrderRepository, Infrastructure.MySQL.Repositories.OrderRepository>();
    builder.Services.AddTransient<ICreateOrderUnitOfWork, Infrastructure.MySQL.UnitOfWork.Order.CreateOrderUnitOfWork>();
    /*IVENTORY*/
    builder.Services.AddTransient<IIventoryRepository, Infrastructure.MySQL.Repositories.IventoryRepository>();
    /*PAGINATION*/
    //UnitOfWork
    builder.Services.AddTransient<IUnitOfWorkBase, Infrastructure.MySQL.UnitOfWork.Base.UnitOfWorkBase>();
}
else if (Database == "MONGODB")
{
    //MONGODB
    builder.Services.AddTransient<MongoDBService>();
    builder.Services.AddTransient<IProductRepository, MongoDbProductRepository>();
    builder.Services.AddTransient<IIventoryRepository, MongoDbIventoryRepository>();
    builder.Services.AddTransient<IOrderRepository, MongoDbOrderRepository>();
    builder.Services.AddTransient<ICreateProductUnitOfWork, MongoDbCreateProductUnitOfWork>();
    builder.Services.AddTransient<ICreateOrderUnitOfWork, MongoDBCreateOrderUnitOfWork>();
}
else
{
    builder.Services.AddDbContext<SQLServerDbContext>();
    /*PRODUCT*/
    builder.Services.AddTransient<IProductRepository, Infrastructure.SQLServer.Repositories.ProductRepository>();
    builder.Services.AddTransient<ICreateProductUnitOfWork, Infrastructure.SQLServer.UnitOfWork.Product.CreateProductUnitOfWork>();
    /* ORDER*/
    builder.Services.AddTransient<IOrderRepository, Infrastructure.SQLServer.Repositories.OrderRepository>();
    builder.Services.AddTransient<ICreateOrderUnitOfWork, Infrastructure.SQLServer.UnitOfWork.Order.CreateOrderUnitOfWork>();
    /*IVENTORY*/
    builder.Services.AddTransient<IIventoryRepository, Infrastructure.SQLServer.Repositories.IventoryRepository>();
    /*PAGINATION*/
    //builder.Services.AddTransient<IProductPagination, ProductPagination>();
    //UnitOfWork
    builder.Services.AddTransient<IUnitOfWorkBase, Infrastructure.SQLServer.UnitOfWork.Base.UnitOfWorkBase>();
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
