using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasMany(x=>x.Orders).WithOne(x=>x.Customer).HasForeignKey(x=>x.CustomerId);
        }
    }
}
