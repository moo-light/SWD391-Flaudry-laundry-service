using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.HasIndex(e => e.Email).IsUnique();

            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.FullName).HasMaxLength(100);
            builder.Property(e => e.PhoneNumber).HasMaxLength(20);

            builder.HasMany(x=>x.Orders).WithOne(x=>x.Customer).HasForeignKey(x=>x.CustomerId);
        }
    }
}
