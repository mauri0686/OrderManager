using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Core.Entities;
 

namespace OrderManager.Infrastructure.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.HasKey(e => e.Id);
 
            builder.Property(e => e.Description)
                  .HasColumnName("Descripcion")
                  .IsRequired()
                  .HasMaxLength(1000)
                  .IsUnicode(false);

            builder.Property(e => e.Price)
                    .HasColumnName("Price");


            builder.HasOne(d => d.Order)
                       .WithMany(p => p.Items)
                       .HasForeignKey(d => d.OrderId)
                       .OnDelete(DeleteBehavior.ClientSetNull)
                       .HasConstraintName("FK_Items_Order");
        }
    }
}
