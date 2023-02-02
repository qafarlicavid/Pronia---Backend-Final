using Microsoft.EntityFrameworkCore;
using Pronia_Site___Backend.Database;

namespace Pronia_Site___Backend.Infrastructure.Configurations
{
    public static class DatabaseConfigurations
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("JavidPC"));
            });
        }
    }
}
