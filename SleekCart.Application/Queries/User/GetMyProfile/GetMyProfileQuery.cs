using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.User.DTOs;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Application.Queries.User.GetMyProfile;

public sealed record GetMyProfileQuery(UserId UserId) :IQuery<ProfileDto>;
