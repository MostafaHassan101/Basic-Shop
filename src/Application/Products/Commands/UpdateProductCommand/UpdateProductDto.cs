using AutoMapper;
using BasicShop.Application.Common.Mappings;
using BasicShop.Domain.Entities;

namespace BasicShop.Application.Products.Commands.UpdateProductCommand;

public class UpdateProductDto : IMapFrom<Product>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public bool IsVisible { get; set; }


    void IMapFrom<Product>.Mapping(Profile profile)
    {
        profile.CreateMap<UpdateProductDto, Product>();
        profile.CreateMap<UpdateProductCommand, UpdateProductDto>();
    }

}
