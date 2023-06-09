using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("NEWID()");
            builder.Property(e => e.EndTime);
            // Configure relationships
            builder.HasOne(s => s.Batch).WithMany(x => x.Sessions).HasForeignKey(s => s.BatchId);
            builder.HasOne(s => s.Building).WithMany(x => x.Sessions).HasForeignKey(s => s.BuildingId);

        }
    }
}
