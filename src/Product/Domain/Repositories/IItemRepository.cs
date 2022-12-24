using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Product.Domain.Model.Entities;
using Schgakko.src.Product.Domain.Model.ValueObjects;
using Schgakko.src.Shared.Domain.Model.Entities;

namespace Schgakko.src.Product.Domain.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> FindAll();
        Task<Item> FindById(ItemId id);
        Task<IEnumerable<Item>> FindByHighAndLowPrice(double hight, double low);
        Task Create(Item item);
        void Update(Item item);
        void Remove(Item item);
    }
}