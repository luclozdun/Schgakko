using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Security.Domain.Model.Entities;
using Schgakko.src.Security.Domain.Model.ValueObjects;
using Schgakko.src.Security.Domain.Result;

namespace Schgakko.src.Security.Domain.Services
{
    public interface ICustomerService
    {
        Task<CustomerResult> Add(Customer customer);
        Task<CustomerResult> FindById(CustomerId customerId);
        Task<CustomerResult> Update(Customer request, CustomerId customerId);
        Task<CustomerResult> Remove(CustomerId customerId);
    }
}