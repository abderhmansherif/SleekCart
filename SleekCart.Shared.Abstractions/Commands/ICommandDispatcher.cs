namespace SleekCart.Application.Abstractions.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<TCommand>(TCommand command, CancellationToken ct) where TCommand : ICommand;
    }
}
