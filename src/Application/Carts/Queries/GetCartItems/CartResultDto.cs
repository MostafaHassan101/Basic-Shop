namespace BasicShop.Application.Carts.Queries.GetCartItems;

public class CartResultDto
{
    public IEnumerable<CartItemDto>? Items { get;set; }
    public decimal? Total { get;set; }
}
