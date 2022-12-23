using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Order.Application.Dto
{
    public class InvoiceItemRequest
    {
        public Stack<InvoiceItemDetail> Details { get; private set; }
        public int CompanyId { get; private set; }
        public int CustomerId { get; private set; }

        public InvoiceItemRequest(Stack<InvoiceItemDetail> details, int companyId, int customerId)
        {
            Details = details;
            CompanyId = companyId;
            CustomerId = customerId;
        }
    }
}