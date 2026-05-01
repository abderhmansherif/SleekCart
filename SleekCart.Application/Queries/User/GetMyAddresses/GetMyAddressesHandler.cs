using e_commerse.Domain.Abstractions.Repositories;
using FluentValidation;
using SleekCart.Application.DTOs;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Mappers;
using SleekCart.Shared.Abstractions.Queries;

namespace SleekCart.Application.Queries.User.GetMyAddresses;

public sealed class GetMyAddressesHandler: IQueryHandler<GetMyAddressesQuery, List<AddressDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<GetMyAddressesQuery> _validator;

    public GetMyAddressesHandler(IUserRepository userRepository, IValidator<GetMyAddressesQuery> validator)
    {
        this._userRepository = userRepository;
        this._validator = validator;
    }

    public async Task<List<AddressDto>> HandleAsync(GetMyAddressesQuery query, CancellationToken ct)
    {
        var result = _validator.Validate(query);

        if(!result.IsValid)
        {
            throw new ValidationFailedException(result.Errors);
        }

        var user = await _userRepository.GetByIdAsync(query.UserId, ct);

        if(user is null)
        {
            throw new NotFoundUserException();
        }

        return user.ToAddressDtos();
    }
}
