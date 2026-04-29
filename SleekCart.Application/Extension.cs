using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Commands.Authentication.LoginUser;
using SleekCart.Application.Commands.Authentication.RefreshToken;
using SleekCart.Application.Commands.Authentication.RegisterUser;
using SleekCart.Application.Commands.User.AddAddress;
using SleekCart.Application.Commands.User.UpdateProfile;
using SleekCart.Application.Queries.User.GetMyAddresses;
using SleekCart.ApplicationCommands.Authentication.RegisterUser;
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
            services.AddScoped<IValidator<RefreshTokenCommand>, RefreshTokenValidator>();
            services.AddScoped<IValidator<GetMyAddressesQuery>, GetMyAddressesValidator>();
            services.AddScoped<IValidator<AddAddressCommand>, AddAddressValidator>();
            services.AddScoped<IValidator<UpdateProfileCommand>, UpdateProfileValidator>();


            var assembly = typeof(Extension).Assembly;
            services.Scan( s=> s.FromAssembliesOf(typeof(Extension))
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
