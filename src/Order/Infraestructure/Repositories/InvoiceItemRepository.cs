using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Schgakko.src.Order.Domain.Model.Entities;
using Schgakko.src.Order.Domain.Model.Enums;
using Schgakko.src.Order.Domain.Repositories;
using Schgakko.src.Product.Domain.Model.ValueObjects;
using Schgakko.src.Shared.Infraestructure;

namespace Schgakko.src.Order.Infraestructure.Repositories
{
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        private readonly DataBaseContext context;

        public InvoiceItemRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task Create(InvoiceItem invoiceItem)
        {
            await context.InvoiceItems.AddAsync(invoiceItem);
        }

        public async Task Create(IEnumerable<InvoiceItem> invoiceItems)
        {
            await context.InvoiceItems.AddRangeAsync(invoiceItems);
        }

        public async Task<IEnumerable<InvoiceItem>> FindAll()
        {
            return await context.InvoiceItems.ToListAsync();
        }

        public async Task<IEnumerable<InvoiceItem>> FindAllByInvoiceId(InvoiceId invoiceId)
        {
            return await context.InvoiceItems.Where(x => x.InvoiceId == (int)invoiceId).ToListAsync();
        }

        public async Task<IEnumerable<InvoiceItem>> FindAllByItemId(ItemId itemId)
        {
            return await context.InvoiceItems.Where(x => x.ItemId == (int)itemId).ToListAsync();
        }
    }
}