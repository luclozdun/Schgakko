using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Order.Domain.Model.Enums;
using Schgakko.src.Product.Domain.Model.ValueObjects;
using Schgakko.src.Security.Domain.Model.ValueObjects;

namespace Schgakko.src.Order.Application.Dto
{
    public class InvoiceItemResponse
    {
        public InvoiceId InvoiceId { get; private set; }
        public CompanyId CompanyId { get; private set; }
        public CustomerId CustomerId { get; private set; }
        public double Total { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Stack<InvoiceItemDetailResponse> invoiceItems { get; private set; }

        public InvoiceItemResponse(InvoiceId invoiceId, CompanyId companyId, CustomerId customerId, double total, DateTime createdAt, Stack<InvoiceItemDetailResponse> invoiceItems)
        {
            InvoiceId = invoiceId;
            CompanyId = companyId;
            CustomerId = customerId;
            Total = total;
            CreatedAt = createdAt;
            this.invoiceItems = invoiceItems;
        }
    }

    public class InvoiceItemDetailResponse
    {
        public int ItemId { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
        public InvoiceItemDetailResponse(ItemId itemId, string name, double price, int quantity)
        {
            ItemId = itemId;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}