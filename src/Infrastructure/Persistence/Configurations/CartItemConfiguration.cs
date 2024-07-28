using BasicShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BasicShop.Infrastructure.Persistence.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.CartId);

        builder.HasIndex(x => x.ProductId).IsUnique();

        builder.HasOne(i => i.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(c => c.CartId);

        builder.HasOne(c => c.Product)
            .WithMany(p => p.CartItems)
            .HasForeignKey(c => c.ProductId);
    }
}
