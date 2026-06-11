using ProductManagementAPI.Repositories;
using ProductManagementAPI.Services;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Data;
using FluentValidation;
using ProductManagementAPI.Validators;
using ProductManagementAPI.Models;
using ProductManagementAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IValidator<Product>, ProductValidator>(); // ProductValidator class'i Product'i validate etmek uzere eklendi

builder.Services.AddDbContext<AppDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // DB'ye connectionstring ile baglandi 

IServiceCollection serviceCollection = builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//middleware usage
app.UseMiddleware<GlobalExceptionMiddleware>();

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
