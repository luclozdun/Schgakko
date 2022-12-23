using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Order.Application.Dto
{
    public class InvoiceItemDetail
    {
        public int Quantity { get; private set; }
        public int ItemId { get; private set; }

        public InvoiceItemDetail(int quantity, int itemId)
        {
            Quantity = quantity;
            ItemId = itemId;
        }
    }
}