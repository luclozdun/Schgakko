using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Security.Domain.Model.Entities;
using Schgakko.src.Security.Domain.Model.ValueObjects;

namespace Schgakko.src.Security.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task Add(Customer customer);

        Task<Customer> FindById(CustomerId id);


        Task<Customer> FindByEmail(string email);

        Task<Customer> FindByDNI(string dni);

        Task<Customer> FindByNumber(int number);

        void Remove(Customer customer);

        void Update(Customer customer);
    }
}