using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.DTOs;

namespace SleekCart.Application.Queries.User.GetMyAddresses;

public sealed record GetMyAddressesQuery(Guid UserId) : IQuery<List<AddressDto>>;
