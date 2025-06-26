using Microsoft.Extensions.Configuration;
using UtilsApiNet8.Models.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Basic use of options:
var options = new MySettings();
builder.Configuration.GetSection(nameof(MySettings)).Bind(options);
Console.WriteLine($"MySettings.MyKey1={options.MyKey1}");

//Get appsettings.subsection.key's value
var method1 = builder.Configuration.GetSection("Logging:LogLevel").GetValue<string>("Default");
var method2 = builder.Configuration.GetValue<string>("Logging:LogLevel:Default");
Console.WriteLine($"method1: {method1} | method2: {method2}");

var conStr = builder.Configuration.GetConnectionString("MainConStr");

var app = builder.Build();

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
