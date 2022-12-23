using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Order.Domain.Model.Entities;
using Schgakko.src.Order.Domain.Model.Enums;
using Schgakko.src.Product.Domain.Model.ValueObjects;

namespace Schgakko.src.Order.Domain.Repositories
{
    public interface IInvoiceItemRepository
    {
        Task<IEnumerable<InvoiceItem>> FindAll();
        Task<IEnumerable<InvoiceItem>> FindAllByInvoiceId(InvoiceId invoiceId);
        Task<IEnumerable<InvoiceItem>> FindAllByItemId(ItemId itemId);
        Task Create(InvoiceItem invoiceItem);
        Task Create(IEnumerable<InvoiceItem> invoiceItems);
    }
}