using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Order.Application.Dto;
using Schgakko.src.Order.Domain.Model.Entities;
using Schgakko.src.Order.Domain.Repositories;
using Schgakko.src.Order.Domain.Result;
using Schgakko.src.Order.Domain.Services;
using Schgakko.src.Security.Domain.Model.ValueObjects;
using Schgakko.src.Shared.Domain.Repositories;

namespace Schgakko.src.Order.Infraestructure.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IUnitOfWork unitOfWork;

        public InvoiceService(IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork)
        {
            this.invoiceRepository = invoiceRepository;
            this.unitOfWork = unitOfWork;
        }

        public Task<InvoiceResult> Create(InvoiceRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Invoice>> FindAll()
        {
            return await invoiceRepository.FindAll();
        }

        public async Task<IEnumerable<Invoice>> FindAllByCompanyId(int companyId)
        {
            CompanyId id = new CompanyId(companyId);
            return await invoiceRepository.FindAllByCompanyId(id);
        }

        public async Task<IEnumerable<Invoice>> FindAllByCustomerId(int customerId)
        {
            CustomerId id = new CustomerId(customerId);
            return await invoiceRepository.FindAllByCustomerId(id);
        }
    }
}