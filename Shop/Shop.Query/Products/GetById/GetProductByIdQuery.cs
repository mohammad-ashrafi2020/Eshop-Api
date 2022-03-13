using Common.Query;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetById;

public record GetProductByIdQuery(long ProductId) : IQuery<ProductDto?>;