using SleekCart.Application.Abstractions.Commands;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Application.Commands.UpdateProfile;

public sealed record UpdateProfileCommand(UserId UserId, string NewFullName) : ICommand;
