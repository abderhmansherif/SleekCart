namespace SleekCart.Application.Abstractions.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, CancellationToken ct);
    }

    public interface ICommandHandler<TCommand, TResponse> where TCommand : ICommand
    {
        Task<TResponse> HandleAsync(TCommand command, CancellationToken ct);
    }
}
