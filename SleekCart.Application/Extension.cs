using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Commands.LoginUser;
using SleekCart.Application.Commands.RegisterUser;
using SleekCart.Application.RegisterUser;
using SleekCart.Shared.Commands;

namespace SleekCart.Application
{
    public static class Extension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            
            services.AddScoped<IValidator<RegisterUserCommand>, RegisterUserValidator>();
            services.AddScoped<IValidator<LoginUserCommand>, LoginUserValidator>();



            var assembly = typeof(Extension).Assembly;
            services.Scan( s=> s.FromAssembliesOf(typeof(Extension))
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
