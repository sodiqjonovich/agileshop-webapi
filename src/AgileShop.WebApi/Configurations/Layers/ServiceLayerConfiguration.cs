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

namespace AgileShop.WebApi.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<ICompanyService, CompanyService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IPaginator, Paginator>();
        builder.Services.AddSingleton<ISmsSender, SmsSender>();
        builder.Services.AddScoped<IIdentityService, IdentityService>();
    }
}
