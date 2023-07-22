using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class StoreManagerConfiguration : IEntityTypeConfiguration<StoreManager>
    {
        public void Configure(EntityTypeBuilder<StoreManager> builder)
        {
            builder.HasOne(x => x.Store)
                   .WithOne(x => x.StoreManager)
                   .HasForeignKey<Store>(x => x.StoreManagerId);
        }
    }
}
