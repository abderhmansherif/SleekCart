using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Product.ChangeCategory;

public sealed record ChangeCategoryCommand(Guid ProductId, Guid CategoryId): ICommand;
