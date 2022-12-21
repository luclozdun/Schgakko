using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Product.Domain.Model.Entities;

namespace Schgakko.src.Product.Application.Dto
{
    public class ItemResponse
    {
        public string Title { get; private set; }
        public string Image { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public double Descount { get; private set; }
        public double Price { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdateAt { get; private set; }
        public int CompanyId { get; private set; }

        public ItemResponse(Item item)
        {
            Title = item.Title;
            Image = item.Image;
            Subtitle = item.Subtitle;
            Description = item.Description;
            Descount = item.Descount;
            Price = item.Price;
            CreatedAt = item.CreatedAt;
            UpdateAt = item.UpdateAt;
            CompanyId = item.CompanyId;
        }
    }
}