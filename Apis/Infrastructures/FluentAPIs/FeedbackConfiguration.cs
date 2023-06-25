using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");

            builder.HasOne(x => x.Customer).WithMany(x => x.Feedbacks).HasForeignKey(x => x.CustomerId);
            builder.HasOne(x => x.Store).WithMany(x => x.Feedbacks).HasForeignKey(x => x.StoreId);

        }
    }
}
