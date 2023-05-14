using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schgakko.src.Order.Domain.Model.Entities;

namespace Schgakko.src.Order.Infraestructure.EntityConfigurations
{
    public class InvoiceItemEntityTypeConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.ToTable("invoice_items");
            builder.HasKey(x => new { x.ItemId, x.InvoiceId });
            builder.HasOne(x => x.Item).WithMany(x => x.InvoiceItems).HasForeignKey(x => x.ItemId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.Invoice).WithMany(x => x.InvoiceItems).OnDelete(DeleteBehavior.ClientSetNull);
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Price).HasColumnName("Price");
            builder.Property(x => x.Quantity).HasColumnName("Quantity");
        }
    }
}