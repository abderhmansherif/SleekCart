using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.User.AddAddress;

public sealed record AddAddressCommand : ICommand
{
    public Guid UserId { get; }
    public string City { get;}
    public string Street { get; }
    public string Building { get; }
    public string Note { get; }

    public AddAddressCommand(Guid userId, string city, string street, string building, string note)
    {
        this.UserId = userId;
        this.City = city;
        this.Street = street;
        this.Building = building;
        this.Note = note;
    }
}
