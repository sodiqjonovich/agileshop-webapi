namespace AgileShop.WebApi.Configurations.Layers;

public static class WebConfiguration
{
    public static void ConfiguraWeb(this WebApplicationBuilder builder)
    {
        builder.ConfigureJwtAuth();
        builder.Services.AddAutoMapper(typeof(Program));
        builder.ConfigureSwaggerAuth();
        builder.ConfigureCORSPolicy();
        builder.ConfigureLogger();
    }
}
