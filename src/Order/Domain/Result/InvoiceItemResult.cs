using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Order.Application.Dto;
using Schgakko.src.Order.Domain.Model.Entities;
using Schgakko.src.Shared.Domain.Result;

namespace Schgakko.src.Order.Domain.Result
{
    public class InvoiceItemResult : BaseResult<InvoiceItemResponse>
    {
        public InvoiceItemResult(InvoiceItemResponse resource) : base(resource)
        {
        }

        public InvoiceItemResult(string message) : base(message)
        {
        }
    }
}