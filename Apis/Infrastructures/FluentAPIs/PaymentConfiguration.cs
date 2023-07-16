using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Property(e => e.CreationDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(e => e.Amount).HasPrecision(18, 2);

            builder.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
