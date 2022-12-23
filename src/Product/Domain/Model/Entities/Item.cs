using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Schgakko.src.Order.Domain.Model.Entities;
using Schgakko.src.Security.Domain.Model.Entities;
using Schgakko.src.Shared.Domain.Model.Entities;

namespace Schgakko.src.Product.Domain.Model.Entities
{
    public class Item : Entity
    {
        public string Title { get; private set; }
        public string Image { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public double Descount { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdateAt { get; private set; }
        public int CompanyId { get; private set; }
        public Company Company { get; private set; }

        [JsonIgnore]
        public IEnumerable<InvoiceItem> InvoiceItems { get; private set; }

        private Item()
        {
            CreatedAt = DateTime.UtcNow;
            UpdateAt = DateTime.UtcNow;
        }

        public void Update(Item request)
        {
            Quantity = request.Quantity;
            Title = request.Title;
            Image = request.Image;
            Subtitle = request.Subtitle;
            Description = request.Description;
            Descount = request.Descount;
            Price = request.Price;
            UpdateAt = DateTime.UtcNow;
        }

        public void UpdateQuantify(int quantity)
        {
            Quantity = Quantity - quantity;
        }

        public class ItemBuilder
        {

            public Item item = new Item();

            public ItemBuilder WithTitle(string title)
            {
                item.Title = title;
                return this;
            }

            public ItemBuilder WithImage(string image)
            {
                item.Image = image;
                return this;
            }

            public ItemBuilder WithSubtitle(string subtitle)
            {
                item.Subtitle = subtitle;
                return this;
            }

            public ItemBuilder WithQuantify(int quantity)
            {
                item.Quantity = quantity;
                return this;
            }

            public ItemBuilder WithDescription(string description)
            {
                item.Description = description;
                return this;
            }

            public ItemBuilder WithDescount(double descount)
            {
                item.Descount = Math.Round(descount, 4);
                return this;
            }

            public ItemBuilder WithPrice(double price)
            {
                item.Price = Math.Round(price, 2);
                return this;
            }

            public ItemBuilder WithCompanyId(int companyId)
            {
                item.CompanyId = companyId;
                return this;
            }

            public Item Build()
            {
                return item;
            }

        }
    }
}