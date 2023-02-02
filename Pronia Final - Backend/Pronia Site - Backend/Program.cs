using Pronia_Site___Backend.Infrastructure.Extensions;

namespace Pronia_Site___Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Register services (IoC container)
            builder.Services.ConfigureServices(builder.Configuration);

            //setup
            var app = builder.Build();

            //Configuration of middleware pipeline
            app.ConfigureMiddlewarePipeline();

            //setup
            app.Run();
        }
    }
}