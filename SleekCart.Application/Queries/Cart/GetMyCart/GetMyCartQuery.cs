using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.DTOs.Cart;

namespace SleekCart.Application.Queries.Cart.GetMyCart;

public sealed record GetMyCartQuery(Guid UserId): IQuery<CartDto>;
