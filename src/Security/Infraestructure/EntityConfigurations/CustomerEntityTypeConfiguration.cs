using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schgakko.src.Security.Domain.Model.Entities;

namespace Schgakko.src.Security.Infraestructure.EntityConfigurations
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.LastName).HasColumnName("Last_Name");
            builder.Property(x => x.DNI).HasColumnName("DNI");
            builder.Property(x => x.Number).HasColumnName("Number");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.Password).HasColumnName("Password");
            builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt");
        }
    }
}