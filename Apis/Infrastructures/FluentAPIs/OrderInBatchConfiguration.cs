using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class OrderInBatchConfiguration : IEntityTypeConfiguration<OrderInBatch>
    {
        public void Configure(EntityTypeBuilder<OrderInBatch> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            // Configure the foreign keys
            builder.HasOne(oib => oib.Batch)
                   .WithMany(b => b.OrderInBatches)
                   .HasForeignKey(oib => oib.BatchId);

            builder.HasOne(oib => oib.Order)
                   .WithMany(lo => lo.OrderInBatches)
                   .HasForeignKey(oib => oib.OrderId);

            // Configure the properties
            builder.Property(oib => oib.Status)
                   .HasConversion<string>()
                   .HasMaxLength(20);
        }
    }
}
