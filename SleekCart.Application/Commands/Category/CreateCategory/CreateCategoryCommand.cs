using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Category.CreateCategory;

public sealed record CreateCategoryCommand(string CategoryName): ICommand;
