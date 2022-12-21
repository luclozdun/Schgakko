using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Schgakko.src.Product.Domain.Model.Entities;
using Schgakko.src.Product.Domain.Model.ValueObjects;
using Schgakko.src.Product.Domain.Repositories;
using Schgakko.src.Shared.Infraestructure;

namespace Schgakko.src.Product.Infraestructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataBaseContext context;

        public ItemRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task Create(Item item)
        {
            await context.Items.AddAsync(item);
        }

        public void Remove(Item item)
        {
            context.Items.Remove(item);
        }

        public async Task<IEnumerable<Item>> FindAll()
        {
            return await context.Items.ToListAsync();
        }

        public async Task<IEnumerable<Item>> FindByHighAndLowPrice(double hight, double low)
        {
            return await context.Items.Where(x => (x.Price > low && x.Price < hight)).ToListAsync();
        }

        public async Task<Item> FindById(ItemId id)
        {
            return await context.Items.Where(x => x.Id == (int)id).FirstOrDefaultAsync();
        }

        public void Update(Item item)
        {
            context.Items.Update(item);
        }
    }
}