using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Property(e => e.CreationDate).HasDefaultValueSql("GETUTCDATE()");

            // Configure the foreign keys
            builder.HasOne(li => li.Order)
                   .WithMany(lo => lo.OrderDetails)
                   .HasForeignKey(li => li.OrderId);

            builder.HasOne(li => li.Service)
                   .WithMany(s => s.OrderDetails)
                   .HasForeignKey(li => li.ServiceId);

            // Configure the properties
            builder.Property(li => li.Weight)
                   .IsRequired()
                   .HasPrecision(18, 2);

        }
    }
}
