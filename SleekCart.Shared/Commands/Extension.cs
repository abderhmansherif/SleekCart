using Microsoft.Extensions.DependencyInjection;
using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Shared.Commands
{
    public static class Extension
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddScoped<ICommandDispatcher, InMemoryCommandDispatcher>();
            return services;
        }
    }
}
