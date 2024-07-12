using Infrastructure.MySQL;
using Infrastructure.SQLServer;
using Serilog;
using System.Net;
using UseCase;
var builder = WebApplication.CreateBuilder(args);
var Database = "SQLServer";
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// ADD USECASE SERVICE
builder.Services.AddUseCaseServices();
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));
if (Database == "MySQL")
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
