using AgileShop.DataAccess.Interfaces.Categories;
using AgileShop.DataAccess.Interfaces.Companies;
using AgileShop.DataAccess.Repositories.Categories;
using AgileShop.DataAccess.Repositories.Companies;
using AgileShop.Service.Interfaces.Categories;
using AgileShop.Service.Interfaces.Common;
using AgileShop.Service.Interfaces.Companies;
using AgileShop.Service.Services.Categories;
using AgileShop.Service.Services.Common;
using AgileShop.Service.Services.Companies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//-> DI containers, IoC containers
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();

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


