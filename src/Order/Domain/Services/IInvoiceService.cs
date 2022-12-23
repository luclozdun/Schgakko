using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Order.Application.Dto;
using Schgakko.src.Order.Domain.Model.Entities;
using Schgakko.src.Order.Domain.Result;

namespace Schgakko.src.Order.Domain.Services
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> FindAll();
        Task<IEnumerable<Invoice>> FindAllByCompanyId(int companyId);
        Task<IEnumerable<Invoice>> FindAllByCustomerId(int customerId);
        Task<InvoiceResult> Create(InvoiceRequest request);
    }
}