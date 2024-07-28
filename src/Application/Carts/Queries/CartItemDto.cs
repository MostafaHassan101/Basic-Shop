using AutoMapper;
using BasicShop.Application.Common.Mappings;
using BasicShop.Domain.Entities;

namespace BasicShop.Application.Carts.Queries;

public class CartItemDto : IMapFrom<CartItem>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    void IMapFrom<CartItem>.Mapping(Profile profile)
    {
        profile.CreateMap<Product, CartItemDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ReverseMap();

        profile.CreateMap<CartItem, CartItemDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
            .ReverseMap();

    }
}