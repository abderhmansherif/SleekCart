using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Category.UpdateCategory;

public sealed record UpdateCategoryCommand(Guid CategoryId, string NewCategoryName): ICommand;
