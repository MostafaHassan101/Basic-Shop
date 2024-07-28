using BasicShop.Application.Common.Mappings;
using BasicShop.Domain.Entities;

namespace BasicShop.Application.Products.Queries.GetProductsQuery;

public class GetProductsDto : IMapFrom<Product>
{
    public Guid Id { get; init; }
    public string Name { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
