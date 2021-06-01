using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Core.Entities;
 

namespace OrderManager.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(e => e.Id);
       
            builder.Property(e => e.FirstName)
               .HasColumnName("FirstName");


            builder.Property(e => e.LastName)
           .HasColumnName("LastName");

            
            builder.Property(e => e.UserLogin)
           .HasColumnName("UserLogin");


            builder.Property(e => e.Password)
         .HasColumnName("Password");

          
        }
    }
}
