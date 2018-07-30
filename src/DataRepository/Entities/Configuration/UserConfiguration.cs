using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cabify.DataRepository.Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Email)
                .IsRequired();

            builder.HasOne(p => p.Cart)
                .WithOne(p => p.User)
                .HasForeignKey<Cart>(p => p.UserId);
        }
    }
}
