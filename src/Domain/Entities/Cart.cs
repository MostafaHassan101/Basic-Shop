namespace BasicShop.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }
    }
}
