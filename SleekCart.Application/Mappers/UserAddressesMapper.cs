using SleekCart.Application.DTOs;
using SleekCart.Domain.Entities;

namespace SleekCart.Application.Mappers;

public static class UserAddressesMapper
{
    public static List<AddressDto> ToAddressDtos(this User user)
        => user.Addresses.Select(a => new AddressDto
            {
                AddressId = a.Id,
                City = a.City.Value,
                Street = a.Street.Value,
                Building = a.Building.Value,
                Note = a.Note.Value

            }).ToList();
        
}
