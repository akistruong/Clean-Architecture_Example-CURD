using Infrastructure.MySQL;
using Infrastructure.SQLServer;
using System.Net;
using System.Reflection;
using UseCase;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var Database = "MYSQL";
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// ADD USECASE SERVICE
builder.Services.AddUseCaseServices();
if (Database == "MYSQL")
{
    builder.Services.AddMySQLInfrastructureServices();
}
else
{
    builder.Services.AddSQLServerInfrastructureServices();
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
