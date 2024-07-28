using AutoMapper;
using BasicShop.Application.Common.Mappings;
using BasicShop.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace BasicShop.Application.Products.Commands.CreateProductCommand;

public class CreateProductDto : IMapFrom<Product>
{
    public string Name { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public bool IsVisible { get; set; }


    void IMapFrom<Product>.Mapping(Profile profile)
    {
        profile.CreateMap<CreateProductDto, Product>().ReverseMap();
        profile.CreateMap<CreateProductCommand, CreateProductDto>().ReverseMap();
    }
}
