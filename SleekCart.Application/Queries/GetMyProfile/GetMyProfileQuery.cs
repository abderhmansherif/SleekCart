using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.DTOs;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Application.Queries.GetMyProfile;

public sealed record GetMyProfileQuery(UserId UserId) :IQuery<ProfileDto>;
