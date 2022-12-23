using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Schgakko.src.Order.Domain.Model.Entities;
using Schgakko.src.Product.Domain.Model.Entities;
using Schgakko.src.Shared.Domain.Model.Entities;

namespace Schgakko.src.Security.Domain.Model.Entities
{
    public class Company : Entity
    {
        public string Name { get; private set; }
        public string Image { get; private set; }
        public string Password { get; private set; }
        public string Number { get; private set; }
        public string Email { get; private set; }
        public string RUC { get; private set; }
        public DateTime CreateAt { get; private set; }

        [JsonIgnore]
        public IEnumerable<Item> Items { get; private set; }

        [JsonIgnore]
        public IEnumerable<Invoice> Invoices { get; private set; }

        private Company()
        {
            CreateAt = DateTime.UtcNow;
        }

        public void Update(Company company)
        {
            Name = company.Name;
            Image = company.Image;
            Password = BCrypt.Net.BCrypt.HashPassword(company.Password);
            Number = company.Number;
            Email = company.Email;
            RUC = company.RUC;
        }

        public class CompanyBuilder
        {

            Company company = new Company();

            public CompanyBuilder WithName(string name)
            {
                company.Name = name;
                return this;
            }

            public CompanyBuilder WithImage(string image)
            {
                company.Image = image;
                return this;
            }

            public CompanyBuilder WithPassword(string password)
            {
                company.Password = BCrypt.Net.BCrypt.HashPassword(password);
                return this;
            }

            public CompanyBuilder WithNumber(string number)
            {
                company.Number = number;
                return this;
            }

            public CompanyBuilder WithEmail(string email)
            {
                company.Email = email;
                return this;
            }

            public CompanyBuilder WithRUC(string ruc)
            {
                company.RUC = ruc;
                return this;
            }

            public Company Build()
            {
                return company;
            }
        }
    }
}