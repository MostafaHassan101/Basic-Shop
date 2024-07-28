﻿using BasicShop.Application.Common.Interfaces;
using BasicShop.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
//using NSwag;
//using NSwag.Generation.Processors.Security;
using WebApi.Services;
using ZymLabs.NSwag.FluentValidation;

namespace WebApi;

public static class ConfigureServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddControllers();

        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                //builder.AllowAnyOrigin()
                //    .AllowAnyMethod()
                //    .AllowAnyHeader();
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders("WWW-Authenticate");
            });
        });

        services.AddScoped<FluentValidationSchemaProcessor>(provider =>
        {
            var validationRules = provider.GetService<IEnumerable<FluentValidationRule>>();
            var loggerFactory = provider.GetService<ILoggerFactory>();

            return new FluentValidationSchemaProcessor(provider, validationRules, loggerFactory);
        });

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        //services.AddOpenApiDocument((configure, serviceProvider) =>
        //{
        //    var fluentValidationSchemaProcessor = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<FluentValidationSchemaProcessor>();

        //    // Add the fluent validations schema processor
        //    configure.SchemaProcessors.Add(fluentValidationSchemaProcessor);

        //    configure.Title = "E-Commerce API";
        //    configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
        //    {
        //        Type = OpenApiSecuritySchemeType.ApiKey,
        //        Name = "Authorization",
        //        In = OpenApiSecurityApiKeyLocation.Header,
        //        Description = "Type into the textbox: Bearer {your JWT token}."
        //    });

        //    configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        //});

        return services;
    }
}