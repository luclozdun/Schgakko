using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Order.Domain.Model.Entities;
using Schgakko.src.Shared.Domain.Result;

namespace Schgakko.src.Order.Domain.Result
{
    public class InvoiceResult : BaseResult<Invoice>
    {
        public InvoiceResult(Invoice resource) : base(resource)
        {
        }

        public InvoiceResult(string message) : base(message)
        {
        }
    }
}