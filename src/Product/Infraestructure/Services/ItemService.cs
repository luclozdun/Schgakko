using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Product.Domain.Model.Entities;
using Schgakko.src.Product.Domain.Model.ValueObjects;
using Schgakko.src.Product.Domain.Repositories;
using Schgakko.src.Product.Domain.Result;
using Schgakko.src.Product.Domain.Services;
using Schgakko.src.Security.Domain.Model.Entities;
using Schgakko.src.Security.Domain.Model.ValueObjects;
using Schgakko.src.Security.Domain.Repositories;
using Schgakko.src.Shared.Domain.Repositories;

namespace Schgakko.src.Product.Infraestructure.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository itemRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IUnitOfWork unitOfWork;

        public ItemService(IItemRepository itemRepository, IUnitOfWork unitOfWork, ICompanyRepository companyRepository)
        {
            this.itemRepository = itemRepository;
            this.unitOfWork = unitOfWork;
            this.companyRepository = companyRepository;
        }

        public async Task<ItemResult> Create(Item request)
        {
            CompanyId companyId = new CompanyId(request.CompanyId);
            Company company = await companyRepository.FindById(companyId);

            if (company is null)
                return new ItemResult("Company not found");

            try
            {
                await itemRepository.Create(request);
                await unitOfWork.CompleteAsync();
                return new ItemResult(request);
            }
            catch (Exception e)
            {
                return new ItemResult($"Error ocurred while creating item: {e.Message}");
            }
        }

        public async Task<IEnumerable<Item>> FindAll()
        {
            return await itemRepository.FindAll();
        }

        public async Task<IEnumerable<Item>> FindByHighAndLowPrice(double hight, double low)
        {
            return await itemRepository.FindByHighAndLowPrice(hight, low);
        }

        public async Task<ItemResult> FindById(int id)
        {
            ItemId itemId = new ItemId(id);
            Item item = await itemRepository.FindById(itemId);

            if (item is null)
                return new ItemResult("Item not found");

            return new ItemResult(item);
        }

        public async Task<ItemResult> Remove(int vitemId, int vcompanyId)
        {
            ItemId itemId = new ItemId(vitemId);
            Item item = await itemRepository.FindById(itemId);
            if (item is null)
                return new ItemResult("Item not found");
            if (item.CompanyId.Equals(vcompanyId))
                return new ItemResult("Invalid credentials");
            try
            {
                itemRepository.Remove(item);
                await unitOfWork.CompleteAsync();
                return new ItemResult(item);
            }
            catch (Exception e)
            {
                return new ItemResult($"Error ocurred while removing item: {e.Message}");
            }
        }

        public async Task<ItemResult> Update(Item request, int _itemId)
        {
            ItemId itemId = new ItemId(_itemId);
            Item item = await itemRepository.FindById(itemId);
            if (item is null)
                return new ItemResult("Item not found");
            if (item.CompanyId.Equals(request.CompanyId))
                return new ItemResult("Invalid credentials");

            item.Update(request);

            try
            {
                itemRepository.Update(item);
                await unitOfWork.CompleteAsync();
                return new ItemResult(item);
            }
            catch (Exception e)
            {
                return new ItemResult($"Error ocurred while updating item: {e.Message}");
            }
        }
    }
}