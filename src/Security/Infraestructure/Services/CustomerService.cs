using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Security.Domain.Model.Entities;
using Schgakko.src.Security.Domain.Model.ValueObjects;
using Schgakko.src.Security.Domain.Repositories;
using Schgakko.src.Security.Domain.Result;
using Schgakko.src.Security.Domain.Services;
using Schgakko.src.Shared.Domain.Repositories;

namespace Schgakko.src.Security.Infraestructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CustomerResult> Add(Customer customer)
        {
            Customer existEmail = await customerRepository.FindByEmail(customer.Email);
            if (existEmail != null)
                return new CustomerResult("The email is being used");

            Customer existNumber = await customerRepository.FindByNumber(customer.Number);
            if (existNumber != null)
                return new CustomerResult("The number is being used");

            Customer existRUC = await customerRepository.FindByDNI(customer.DNI);
            if (existRUC != null)
                return new CustomerResult("The DNI is being used");


            try
            {
                await customerRepository.Add(customer);
                await unitOfWork.CompleteAsync();
                return new CustomerResult(customer);
            }
            catch (Exception e)
            {
                return new CustomerResult($"Error ocurred while creating company: {e.Message}");
            }
        }

        public async Task<CustomerResult> FindById(CustomerId customerId)
        {
            Customer customer = await customerRepository.FindById(customerId);
            if (customer == null)
                return new CustomerResult("Customer not found");
            return new CustomerResult(customer);
        }

        public async Task<CustomerResult> Remove(CustomerId customerId)
        {
            Customer customer = await customerRepository.FindById(customerId);
            if (customer == null)
                return new CustomerResult("Customer not found");
            try
            {
                customerRepository.Remove(customer);
                await unitOfWork.CompleteAsync();
                return new CustomerResult(customer);
            }
            catch (Exception e)
            {
                return new CustomerResult($"Error ocurred while removing customer: {e.Message}");
            }
        }

        public Task<CustomerResult> Update(Customer request, CustomerId customerId)
        {
            throw new NotImplementedException();
        }
    }
}