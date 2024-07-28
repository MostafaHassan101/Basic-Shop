using AutoMapper.Internal;
using BasicShop.Application.Common.Interfaces;
using BasicShop.Application.Common.Models;
using BasicShop.Application.SearchCatalog;
using BasicShop.Infrastructure.Identity;
using BasicShop.Infrastructure.Persistence;
using BasicShop.Infrastructure.Persistence.Interceptors;
using BasicShop.Infrastructure.SearchCatalog;
using BasicShop.Infrastructure.Services;
using E_Commerce.Application.Common.Interfaces;
using E_Commerce.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("BasicShopDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        /// Identity Service Configuration
        services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


        services.AddTransient<IDateTime, DateTimeService>();
        /// Identity Service
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IProductSearch, ProductSearch>();
        services.AddScoped<ICartService, CartService>();



        #region Identity Server 4 Configuration
        /// Authorization by Identity Server 4
        /// enabled to see auth identity server related error
        //IdentityModelEventSource.ShowPII = true;
        //services.AddAuthentication("Bearer")
        //             .AddIdentityServerAuthentication(options =>
        //             {
        //                 options.Authority = "https://localhost:44304";
        //                 options.RequireHttpsMetadata = false;
        //                 options.ApiName = "webAPI";
        //                 options.SaveToken = true;
        //             });
        //// Add Cross Domain Policies
        //services.AddCors(opt => opt.AddPolicy("CorsPolicy", al =>
        //            al
        //            .AllowAnyHeader()
        //            .AllowAnyMethod()
        //            .AllowAnyOrigin()));
        #endregion


        services.AddAutoMapper(cfg =>
            {
                cfg.Internal().MethodMappingEnabled = false;
                cfg.AddProfile(new BasicShop.Infrastructure.Mapping.ProfileMapping());
            });

        return services;
    }
}
