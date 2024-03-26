using Contracts.Repository;
using Contracts.Services;
using DAL;
using Domain.Mappings;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;
using System.Text.Json.Serialization;

namespace AutoServiceAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:8081")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
        public static void ConfigureJsonSerialization(this IServiceCollection services)
        {
            services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
        }
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:default_connection"];
            services.AddDbContext<RepositoryContext>(o => o.UseLazyLoadingProxies().UseSqlServer(connectionString));

        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(StoreProfile));

            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
