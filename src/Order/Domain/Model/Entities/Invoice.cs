using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Schgakko.src.Security.Domain.Model.Entities;
using Schgakko.src.Security.Domain.Model.ValueObjects;
using Schgakko.src.Shared.Domain.Model.Entities;

namespace Schgakko.src.Order.Domain.Model.Entities
{
    public class Invoice : Entity
    {
        public DateTime CreatedAt { get; private set; }
        public double Total { get; private set; }
        public int CompanyId { get; private set; }
        public Company Company { get; private set; }
        public int CustomerId { get; private set; }
        public Customer Customer { get; private set; }

        [JsonIgnore]
        public IEnumerable<InvoiceItem> InvoiceItems { get; private set; }

        private Invoice(int companyId, int customerId)
        {
            CreatedAt = DateTime.UtcNow;
            Total = 0;
            CompanyId = companyId;
            CustomerId = customerId;
        }

        private Invoice()
        {
        }

        public static Invoice Create(CompanyId companyId, CustomerId customerId)
        {
            return new Invoice((int)companyId, (int)customerId);
        }

        public void UpdatePrice(double total)
        {
            Total = total;
        }
    }
}