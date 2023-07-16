using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Property(e => e.CreationDate).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(e => e.Name).HasMaxLength(100);

            builder.HasMany(e => e.Services).WithOne(x => x.Store).HasForeignKey(x => x.StoreId);
            builder.HasMany(e => e.Orders).WithOne(x => x.Store).HasForeignKey(x => x.StoreId);
            builder.HasMany(e => e.Feedbacks).WithOne(x => x.Store).HasForeignKey(x => x.StoreId);

        }
    }
}
