using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Order.Application.Dto
{
    public class InvoiceRequest
    {
        public double Total { get; private set; }
        public int CompanyId { get; private set; }
        public int CustomerId { get; private set; }

        public InvoiceRequest(double total, int companyId, int customerId)
        {
            Total = total;
            CompanyId = companyId;
            CustomerId = customerId;
        }
    }
}