using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schgakko.src.Security.Domain.Model.Entities;

namespace Schgakko.src.Security.Infraestructure.EntityConfigurations
{
    public class CompanyEntityTypeConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("companies");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Image).HasColumnName("Image");
            builder.Property(x => x.Password).HasColumnName("Password");
            builder.Property(x => x.Number).HasColumnName("Number");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.RUC).HasColumnName("RUC");
            builder.Property(x => x.CreateAt).HasColumnName("Created_At");
        }
    }
}