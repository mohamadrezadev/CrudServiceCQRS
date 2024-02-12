using Application.Behaviors;
using Application.Tools;
using Domain.Entities.Users;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Application.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication( this IServiceCollection services )
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(assembly);
                configuration.AddBehavior(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(assembly);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

          

            return services;
        }
    };
}
