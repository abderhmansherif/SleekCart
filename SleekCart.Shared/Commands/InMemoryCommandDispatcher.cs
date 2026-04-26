using Microsoft.Extensions.DependencyInjection;
using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Shared.Commands
{
    internal sealed class InMemoryCommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
            => this._serviceProvider = serviceProvider;

        public async Task DispatchAsync<TCommand>(TCommand command, CancellationToken ct) where TCommand : ICommand
        {
            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            await handler.HandleAsync(command, ct);
        }
    }
}
