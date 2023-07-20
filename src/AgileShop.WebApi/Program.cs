using AgileShop.DataAccess.Interfaces.Categories;
using AgileShop.DataAccess.Interfaces.Companies;
using AgileShop.DataAccess.Interfaces.Users;
using AgileShop.DataAccess.Repositories.Categories;
using AgileShop.DataAccess.Repositories.Companies;
using AgileShop.DataAccess.Repositories.Users;
using AgileShop.Service.Interfaces.Auth;
using AgileShop.Service.Interfaces.Categories;
using AgileShop.Service.Interfaces.Common;
using AgileShop.Service.Interfaces.Companies;
using AgileShop.Service.Interfaces.Notifcations;
using AgileShop.Service.Services.Auth;
using AgileShop.Service.Services.Categories;
using AgileShop.Service.Services.Common;
using AgileShop.Service.Services.Companies;
using AgileShop.Service.Services.Notifications;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

//-> DI containers, IoC containers
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddSingleton<ISmsSender, SmsSender>();

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


