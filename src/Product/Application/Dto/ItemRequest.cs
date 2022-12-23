using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Product.Application.Dto
{
    public class ItemRequest
    {
        public string Title { get; private set; }
        public string Image { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public double Descount { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
        public int CompanyId { get; private set; }

        public ItemRequest(string title, string image, string subtitle, string description, double descount, double price, int companyId, int quantity)
        {
            Title = title;
            Image = image;
            Subtitle = subtitle;
            Description = description;
            Descount = descount;
            Price = price;
            CompanyId = companyId;
            Quantity = quantity;
        }
    }
}