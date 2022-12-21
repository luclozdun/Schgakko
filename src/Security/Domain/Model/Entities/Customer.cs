using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Security.Domain.Result;
using Schgakko.src.Shared.Domain.Model.Entities;
using Schgakko.src.Shared.Domain.Model.ValueObjects;

namespace Schgakko.src.Security.Domain.Model.Entities
{
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string DNI { get; private set; }
        public int Number { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Customer()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(Customer customer)
        {
            Name = customer.Name;
            LastName = customer.LastName;
            DNI = customer.DNI;
            Number = customer.Number;
            Email = customer.Email;
            Password = BCrypt.Net.BCrypt.HashPassword(customer.Password);
        }

        public class CustomerBuilder
        {
            Customer customer = new Customer();

            public CustomerBuilder WithName(string name)
            {
                customer.Name = name;
                return this;
            }

            public CustomerBuilder WithLastName(string lastName)
            {
                customer.LastName = lastName;
                return this;
            }

            public CustomerBuilder WithDNI(string dni)
            {
                customer.DNI = dni;
                return this;
            }

            public CustomerBuilder WithNumber(int number)
            {
                customer.Number = number;
                return this;
            }

            public CustomerBuilder WithEmail(string email)
            {
                customer.Email = email;
                return this;
            }

            public CustomerBuilder WithPassword(string password)
            {
                customer.Password = BCrypt.Net.BCrypt.HashPassword(password);
                return this;
            }

            public Customer Build()
            {
                return customer;
            }
        }
    }
}