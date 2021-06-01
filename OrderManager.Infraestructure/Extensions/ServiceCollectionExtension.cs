 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManager.Infrastructure.Data;

namespace OrderManager.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("OrderManager"))
           );

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            //services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));

            return services;
        }

        //public static IServiceCollection AddServices(this IServiceCollection services)
        //{
        //    services.AddTransient<IPostService, PostService>();
        //    services.AddTransient<ISecurityService, SecurityService>();
        //    services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        //    services.AddTransient<IUnitOfWork, UnitOfWork>();
        //    services.AddSingleton<IPasswordService, PasswordService>();
        //    services.AddSingleton<IUriService>(provider =>
        //    {
        //        var accesor = provider.GetRequiredService<IHttpContextAccessor>();
        //        var request = accesor.HttpContext.Request;
        //        var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
        //        return new UriService(absoluteUri);
        //    });

        //    return services;
        //}

        //public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        //{
        //    services.AddSwaggerGen(doc =>
        //    {
        //        doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Social Media API", Version = "v1" });

        //        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
        //        doc.IncludeXmlComments(xmlPath);
        //    });

        //    return services;
        //}
    }
}
