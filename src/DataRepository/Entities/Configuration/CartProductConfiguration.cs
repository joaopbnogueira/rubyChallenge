using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cabify.DataRepository.Entities.Configuration
{
    public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder.HasKey(p => new { p.CartId, p.ProductId });

            builder.HasOne(p => p.Cart)
                .WithMany(p => p.CartProducts)
                .HasForeignKey(p => p.CartId);

            builder.HasOne(p => p.Product)
                .WithMany(p => p.CartProducts)
                .HasForeignKey(p => p.ProductId);

        }
    }
}
