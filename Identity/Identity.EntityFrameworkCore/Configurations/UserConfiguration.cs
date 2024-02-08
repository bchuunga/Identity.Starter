using Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.EntityFrameworkCore.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(x => x.LastName).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(x => x.Nationality).HasColumnType("nvarchar(150)");
        }
    }
}
