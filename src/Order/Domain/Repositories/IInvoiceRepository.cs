using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Order.Domain.Model.Entities;
using Schgakko.src.Security.Domain.Model.ValueObjects;

namespace Schgakko.src.Order.Domain.Repositories
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> FindAll();
        Task<IEnumerable<Invoice>> FindAllByCompanyId(CompanyId companyId);
        Task<IEnumerable<Invoice>> FindAllByCustomerId(CustomerId customerId);
        Task Create(Invoice invoice);
        void Update(Invoice invoice);
    }
}