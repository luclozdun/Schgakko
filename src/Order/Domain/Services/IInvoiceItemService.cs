using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Order.Application.Dto;
using Schgakko.src.Order.Domain.Model.Entities;
using Schgakko.src.Order.Domain.Result;

namespace Schgakko.src.Order.Domain.Services
{
    public interface IInvoiceItemService
    {
        Task<IEnumerable<InvoiceItem>> FindAll();
        Task<IEnumerable<InvoiceItem>> FindAllByInvoiceId(int invoiceId);
        Task<IEnumerable<InvoiceItem>> FindAllByItemId(int itemId);
        Task<InvoiceItemResult> Create(InvoiceItemRequest request);
    }
}