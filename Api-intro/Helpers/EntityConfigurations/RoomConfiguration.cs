using Api_intro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_intro.Helpers.EntityConfigurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(x => x.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x=>x.Capacity)
                   .HasDefaultValue(10)
                   .IsRequired(false);
        }
    }
}
