using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Category.DeleteCategory;

public sealed record DeleteCategoryCommand(Guid CategoryId): ICommand;
