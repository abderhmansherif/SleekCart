using Microsoft.Extensions.DependencyInjection;
using SleekCart.Application.Abstractions.Commands;
using System.Reflection;

namespace SleekCart.Shared.Commands
{
    public static class Extension
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();

            var assembly = typeof(ICommandHandler<>).Assembly;

            // Register all ICommandHandler<> implementations in the assembly
            services.Scan(s => s.FromAssemblies(assembly)
                    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            return services;
        }
    }
}
