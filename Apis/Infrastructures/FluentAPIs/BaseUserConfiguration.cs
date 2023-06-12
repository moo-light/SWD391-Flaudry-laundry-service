using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class BaseUserConfiguration : IEntityTypeConfiguration<BaseUser>
    {
        public void Configure(EntityTypeBuilder<BaseUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.HasIndex(e => e.Email).IsUnique();

            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.FullName).HasMaxLength(100);
            builder.Property(e => e.PhoneNumber).HasMaxLength(20);

        }
    }
}
