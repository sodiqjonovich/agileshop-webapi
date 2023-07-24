using AgileShop.DataAccess.Interfaces.Categories;
using AgileShop.DataAccess.Interfaces.Companies;
using AgileShop.DataAccess.Interfaces.Users;
using AgileShop.DataAccess.Repositories.Categories;
using AgileShop.DataAccess.Repositories.Companies;
using AgileShop.DataAccess.Repositories.Users;

namespace AgileShop.WebApi.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }
}
