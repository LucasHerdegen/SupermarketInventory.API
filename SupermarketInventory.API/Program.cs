using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SupermarketInventory.API.DTOs;
using SupermarketInventory.API.Mappers;
using SupermarketInventory.API.Models;
using SupermarketInventory.API.Repository;
using SupermarketInventory.API.Services;
using SupermarketInventory.API.Validators;

var builder = WebApplication.CreateBuilder(args);

/* Entity framework*/
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContextConnection"));
});

/* Services */
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

/* Repositories */
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();

/* Auto Mapper*/
builder.Services.AddAutoMapper(typeof(CategoryMapper));

/* Validators */
builder.Services.AddScoped<IValidator<ProductPostDto>, ProductPostValidator>();
builder.Services.AddScoped<IValidator<ProductPutDto>, ProductPutValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/", c =>
{
    c.Response.Redirect("/swagger");
    return Task.CompletedTask;
});
app.MapControllers();
app.Run();