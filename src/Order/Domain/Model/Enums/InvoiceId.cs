using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Shared.Domain.Model.ValueObjects;

namespace Schgakko.src.Order.Domain.Model.Enums
{
    public class InvoiceId : IdValueObject
    {
        public InvoiceId(int id) : base(id)
        {
        }
    }
}