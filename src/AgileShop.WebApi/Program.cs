using AgileShop.DataAccess.Interfaces.Categories;
using AgileShop.DataAccess.Repositories.Categories;
using AgileShop.Service.Interfaces.Categories;
using AgileShop.Service.Interfaces.Common;
using AgileShop.Service.Services.Categories;
using AgileShop.Service.Services.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//-> DI containers, IoC containers
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();


