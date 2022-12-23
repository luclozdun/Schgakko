using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Schgakko.src.Order.Application.Dto;
using Schgakko.src.Order.Domain.Model.Entities;
using Schgakko.src.Order.Domain.Model.Enums;
using Schgakko.src.Order.Domain.Repositories;
using Schgakko.src.Order.Domain.Result;
using Schgakko.src.Order.Domain.Services;
using Schgakko.src.Product.Domain.Model.Entities;
using Schgakko.src.Product.Domain.Model.ValueObjects;
using Schgakko.src.Product.Domain.Repositories;
using Schgakko.src.Security.Domain.Model.ValueObjects;
using Schgakko.src.Shared.Domain.Repositories;

namespace Schgakko.src.Order.Infraestructure.Services
{
    public class InvoiceItemService : IInvoiceItemService
    {
        private readonly IInvoiceItemRepository invoiceItemRepository;
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IItemRepository itemRepository;
        private readonly IUnitOfWork unitOfWork;

        public InvoiceItemService(IInvoiceItemRepository invoiceItemRepository, IUnitOfWork unitOfWork, IInvoiceRepository invoiceRepository, IItemRepository itemRepository)
        {
            this.invoiceItemRepository = invoiceItemRepository;
            this.unitOfWork = unitOfWork;
            this.invoiceRepository = invoiceRepository;
            this.itemRepository = itemRepository;
        }

        public async Task<InvoiceItemResult> Create(InvoiceItemRequest request)
        {
            using (IDbContextTransaction transaction = unitOfWork.Transaction())
            {
                try
                {
                    Stack<InvoiceItemDetailResponse> stackResponse = new Stack<InvoiceItemDetailResponse>();

                    CompanyId companyId = new CompanyId(request.CompanyId);
                    CustomerId customerId = new CustomerId(request.CustomerId);
                    Invoice invoice = Invoice.Create(companyId, customerId);

                    await invoiceRepository.Create(invoice);
                    await unitOfWork.CompleteAsync();

                    InvoiceId invoiceId = new InvoiceId(invoice.Id);

                    List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
                    double total = 0;

                    Stack<InvoiceItemDetail> details = request.Details;

                    while (details.Count != 0)
                    {
                        InvoiceItemDetail detail = details.Pop();

                        ItemId itemId = new ItemId(detail.ItemId);
                        Item item = await itemRepository.FindById(itemId);

                        if (item.Quantity < detail.Quantity)
                            return new InvoiceItemResult("Invalid quantify");
                        if (item.CompanyId != request.CompanyId)
                            return new InvoiceItemResult("Invalid request company id");

                        item.UpdateQuantify(detail.Quantity);
                        InvoiceItem invoiceItem = InvoiceItem.Create(invoice.Id, itemId.Id, item.Price, item.Title, detail.Quantity);
                        total = total + item.Price;

                        invoiceItems.Add(invoiceItem);

                        InvoiceItemDetailResponse invoiceResponse = new InvoiceItemDetailResponse(itemId, item.Title, item.Price, detail.Quantity);
                        stackResponse.Push(invoiceResponse);

                        itemRepository.Update(item);
                        await unitOfWork.CompleteAsync();
                    }
                    invoice.UpdatePrice(total);
                    invoiceRepository.Update(invoice);
                    await unitOfWork.CompleteAsync();

                    await invoiceItemRepository.Create(invoiceItems);
                    await unitOfWork.CompleteAsync();
                    transaction.Commit();
                    InvoiceItemResponse response = new InvoiceItemResponse(invoiceId, companyId, customerId, total, invoice.CreatedAt, stackResponse);
                    return new InvoiceItemResult(response);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return new InvoiceItemResult($"Error occurred while processing the purchase: {e.Message}");
                }
            }

        }

        public Task<IEnumerable<InvoiceItem>> FindAll()
        {
            return invoiceItemRepository.FindAll();
        }

        public Task<IEnumerable<InvoiceItem>> FindAllByInvoiceId(int invoiceId)
        {
            InvoiceId id = new InvoiceId(invoiceId);
            return invoiceItemRepository.FindAllByInvoiceId(id);
        }

        public Task<IEnumerable<InvoiceItem>> FindAllByItemId(int itemId)
        {
            ItemId id = new ItemId(itemId);
            return invoiceItemRepository.FindAllByItemId(id);
        }
    }
}