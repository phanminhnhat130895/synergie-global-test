using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class FlashCardConfiguration : IEntityTypeConfiguration<FlashCard>
    {
        public void Configure(EntityTypeBuilder<FlashCard> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Content)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(500);

            builder.Property(x => x.Meaning)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(1000);

            builder.Property(x => x.DateCreated)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(x => x.DateUpdated)
                .HasColumnType("datetime2")
                .IsRequired(false);

            builder.Property(x => x.DateDeleted)
                .HasColumnType("datetime2")
                .IsRequired(false);

            builder.HasOne(x => x.User)
                .WithMany(x => x.FlashCards)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
