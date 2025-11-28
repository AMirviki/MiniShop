using Application.Products.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DI;

public static class PersistenceModule
{
    public static IServiceCollection AddMiniShopPersistance(this IServiceCollection services
        , IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MiniShopConnection");

        services.AddDbContext<MiniShopDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
