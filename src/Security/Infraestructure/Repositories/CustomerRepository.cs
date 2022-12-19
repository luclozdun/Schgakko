using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Schgakko.src.Security.Domain.Model.Entities;
using Schgakko.src.Security.Domain.Model.ValueObjects;
using Schgakko.src.Security.Domain.Repositories;
using Schgakko.src.Shared.Infraestructure;

namespace Schgakko.src.Security.Infraestructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataBaseContext context;

        public CustomerRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task Add(Customer customer)
        {
            await context.Customers.AddAsync(customer);
        }

        public async Task<Customer> FindByDNI(string dni)
        {
            return await context.Customers.Where(x => x.DNI == dni).FirstOrDefaultAsync();
        }

        public async Task<Customer> FindByEmail(string email)
        {
            return await context.Customers.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<Customer> FindById(CustomerId id)
        {
            return await context.Customers.Where(x => x.Id == (int)id).FirstOrDefaultAsync();
        }

        public async Task<Customer> FindByNumber(int number)
        {
            return await context.Customers.Where(x => x.Number == number).FirstOrDefaultAsync();
        }

        public void Remove(Customer customer)
        {
            context.Customers.Remove(customer);
        }

        public void Update(Customer customer)
        {
            context.Customers.Update(customer);
        }
    }
}