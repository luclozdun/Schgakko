using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Schgakko.src.Order.Domain.Model.Entities;
using Schgakko.src.Order.Domain.Repositories;
using Schgakko.src.Security.Domain.Model.ValueObjects;
using Schgakko.src.Shared.Infraestructure;

namespace Schgakko.src.Order.Infraestructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataBaseContext context;

        public InvoiceRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task Create(Invoice invoice)
        {
            await context.Invoices.AddAsync(invoice);
        }

        public async Task<IEnumerable<Invoice>> FindAll()
        {
            return await context.Invoices.ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> FindAllByCompanyId(CompanyId companyId)
        {
            return await context.Invoices.Where(x => x.CompanyId == (int)companyId).ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> FindAllByCustomerId(CustomerId customerId)
        {
            return await context.Invoices.Where(x => x.CustomerId == (int)customerId).ToListAsync();
        }

        public void Update(Invoice invoice)
        {
            context.Invoices.Update(invoice);
        }
    }
}