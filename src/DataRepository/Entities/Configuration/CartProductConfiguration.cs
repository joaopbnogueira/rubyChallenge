using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cabify.DataRepository.Entities.Configuration
{
    public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.User)
                .WithMany(p => p.CartProducts)
                .HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.Product)
                .WithMany(p => p.CartProducts)
                .HasForeignKey(p => p.ProductId);

        }
    }
}
