using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schgakko.src.Product.Domain.Model.Entities;

namespace Schgakko.src.Product.Infraestructure.EntityConfigurations
{
    public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("items");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Title).HasColumnName("Title");
            builder.Property(x => x.Image).HasColumnName("Image");
            builder.Property(x => x.Subtitle).HasColumnName("Subtitle");
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.Property(x => x.Descount).HasColumnName("Descount");
            builder.Property(x => x.Quantity).HasColumnName("Quantity");
            builder.Property(x => x.Price).HasColumnName("Price");
            builder.Property(x => x.CreatedAt).HasColumnName("Create_At");
            builder.Property(x => x.UpdateAt).HasColumnName("Update_At");
            builder.HasOne(x => x.Company).WithMany(x => x.Items).HasForeignKey(x => x.CompanyId);
        }
    }
}