using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schgakko.src.Order.Domain.Model.Entities;

namespace Schgakko.src.Order.Infraestructure.EntityConfigurations
{
    public class InvoiceEntityTypeConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoices");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Total).HasColumnName("Total");
            builder.Property(x => x.CreatedAt).HasColumnName("Created_At");
            builder.HasOne(x => x.Company).WithMany(x => x.Invoices).HasForeignKey(x => x.CompanyId);
            builder.HasOne(x => x.Customer).WithMany(x => x.Invoices).HasForeignKey(x => x.CustomerId);
        }
    }
}