using System.Reflection;
using Application.Features.Auths.Rules;
using Application.Features.Brands.Rules;
using Application.Features.Categories.Rules;
using Application.Features.Products.Rules;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        
        //Validation
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        
        //BusinessRules
        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<BrandBusinessRules>();
        services.AddScoped<ProductBusinessRules>();
        services.AddScoped<AuthBusinessRules>();

        return services;
    }
}