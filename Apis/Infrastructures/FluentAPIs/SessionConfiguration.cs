using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class SessionConfiguration : IEntityTypeConfiguration<BatchOfBuilding>
    {
        public void Configure(EntityTypeBuilder<BatchOfBuilding> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Property(e => e.CreationDate).HasDefaultValueSql("GETUTCDATE()");
            // Configure relationships
            builder.HasOne(s => s.Batch).WithMany(x => x.BatchOfBuildings).HasForeignKey(s => s.BatchId);
            builder.HasOne(s => s.Building).WithMany(x => x.BatchOfBuildings).HasForeignKey(s => s.BuildingId);

        }
    }
}
