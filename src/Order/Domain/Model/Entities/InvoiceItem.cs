using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Product.Domain.Model.Entities;

namespace Schgakko.src.Order.Domain.Model.Entities
{
    public class InvoiceItem
    {
        public int InvoiceId { get; private set; }
        public Invoice Invoice { get; private set; }
        public int ItemId { get; private set; }
        public Item Item { get; private set; }
        public double Price { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }

        private InvoiceItem(int invoiceId, int itemId, double price, string name, int quantity)
        {
            InvoiceId = invoiceId;
            ItemId = itemId;
            Price = price;
            Name = name;
            Quantity = quantity;
        }

        private InvoiceItem()
        {
        }

        public static InvoiceItem Create(int invoiceId, int itemId, double price, string name, int quantity)
        {
            return new InvoiceItem(invoiceId, itemId, price, name, quantity);
        }
    }
}