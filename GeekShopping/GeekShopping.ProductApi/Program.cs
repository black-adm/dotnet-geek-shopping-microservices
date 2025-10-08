using GeekShopping.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("MySqlConnectionString") ??
     throw new InvalidOperationException("Connection string 'MySqlConnectionString'" +
    " not found.");

builder.Services.AddDbContext<MySqlContext>(opt => 
    opt.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 5))));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
