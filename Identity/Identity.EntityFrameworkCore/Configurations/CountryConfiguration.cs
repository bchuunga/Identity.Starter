using Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.EntityFrameworkCore.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name)
                .HasColumnType("nvarchar(125)")
                .IsRequired();
        }
    }
}
