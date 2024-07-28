using BasicShop.Application.Common.Mappings;
using BasicShop.Domain.Entities;

namespace BasicShop.Application.Search.Queries.DTOs;

public class ProductResultDto : IMapFrom<Product>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public bool IsVisible { get; set; }

}
