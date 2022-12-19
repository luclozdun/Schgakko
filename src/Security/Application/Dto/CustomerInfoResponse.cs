using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Security.Domain.Model.Entities;

namespace Schgakko.src.Security.Application.Dto
{
    public class CustomerInfoResponse
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string DNI { get; private set; }
        public int Number { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public CustomerInfoResponse(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            LastName = customer.LastName;
            DNI = customer.DNI;
            Number = customer.Number;
            Email = customer.Email;
            Password = customer.Password;
            CreatedAt = customer.CreatedAt;
        }
    }
}