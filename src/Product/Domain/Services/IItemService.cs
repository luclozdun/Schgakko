using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Product.Domain.Model.Entities;
using Schgakko.src.Product.Domain.Model.ValueObjects;
using Schgakko.src.Product.Domain.Result;

namespace Schgakko.src.Product.Domain.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> FindAll();
        Task<ItemResult> FindById(int id);
        Task<IEnumerable<Item>> FindByHighAndLowPrice(double hight, double low);
        Task<ItemResult> Create(Item request);
        Task<ItemResult> Update(Item request, int _itemId);
        Task<ItemResult> Remove(int itemId, int companyId);
    }
}