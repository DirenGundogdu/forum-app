using Forum.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Api.Infrastructure.Persistence.Extension;

public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ForumContext>(conf =>
        {
            var connStr = configuration["ForumDbConnectionString"].ToString();
            conf.UseSqlServer(connStr, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        });

        var seedData = new SeedData();
        seedData.SeedAsync(configuration).GetAwaiter().GetResult();

        return services;
    }
}