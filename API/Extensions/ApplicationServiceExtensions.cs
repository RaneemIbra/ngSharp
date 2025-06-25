using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices
        (this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });

        services.AddCors();

        services.AddControllers();
        services.AddOpenApi();
        services.AddScoped<ITokenService, TokenService>();
        return services;
    }
}