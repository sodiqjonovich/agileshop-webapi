using AgileShop.DataAccess.Interfaces.Categories;
using AgileShop.DataAccess.Repositories.Categories;
using AgileShop.Service.Interfaces.Categories;
using AgileShop.Service.Interfaces.Common;
using AgileShop.Service.Services.Categories;
using AgileShop.Service.Services.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//->
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
//->

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
