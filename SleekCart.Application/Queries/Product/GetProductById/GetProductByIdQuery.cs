using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.DTOs.Product;

namespace SleekCart.Application.Queries.Product.GetProductById;

public sealed record GetProductByIdQuery(Guid ProductId): IQuery<ProductDetailsDto>;
