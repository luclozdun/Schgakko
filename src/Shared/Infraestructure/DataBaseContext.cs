using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Schgakko.src.Order.Domain.Model.Entities;
using Schgakko.src.Order.Infraestructure.EntityConfigurations;
using Schgakko.src.Product.Domain.Model.Entities;
using Schgakko.src.Product.Infraestructure.EntityConfigurations;
using Schgakko.src.Security.Domain.Model.Entities;
using Schgakko.src.Security.Infraestructure.EntityConfigurations;

namespace Schgakko.src.Shared.Infraestructure
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceItemEntityTypeConfiguration());
        }
    }
}