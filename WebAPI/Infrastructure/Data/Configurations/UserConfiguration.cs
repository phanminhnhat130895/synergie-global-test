using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(255);

            builder.Property(x => x.Password)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(500);

            builder.Property(x => x.DateCreated)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(x => x.DateUpdated)
                .HasColumnType("datetime2")
                .IsRequired(false);

            builder.Property(x => x.DateDeleted)
                .HasColumnType("datetime2")
                .IsRequired(false);
        }
    }
}
