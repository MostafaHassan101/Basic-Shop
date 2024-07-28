namespace BasicShop.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Quantity {  get; set; }
        public decimal Price { get; set; }
        public bool IsVisible { get; set; }

        public IEnumerable<CartItem>? CartItems { get; set; }

    }
}
