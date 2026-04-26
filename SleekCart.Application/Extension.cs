using Microsoft.Extensions.DependencyInjection;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Shared.Commands;

namespace SleekCart.Application
{
    public static class Extension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();

            var assembly = typeof(Extension).Assembly;
            services.Scan( s=> s.FromAssembliesOf(typeof(Extension))
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());


            return services;
        }
    }
}
