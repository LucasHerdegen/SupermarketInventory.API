using Microsoft.EntityFrameworkCore;
using SupermarketInventory.API.Mappers;
using SupermarketInventory.API.Models;
using SupermarketInventory.API.Repository;
using SupermarketInventory.API.Services;

var builder = WebApplication.CreateBuilder(args);

/* Entity framework*/
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContextConnection"));
});

/* Dependency inyections */
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();

/* Auto Mapper*/
builder.Services.AddAutoMapper(typeof(CategoryMapper));

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