using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Security.Domain.Model.Entities;

namespace Schgakko.src.Security.Application.Dto
{
    public class CompanyInfoResponse
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Image { get; private set; }
        public string Password { get; private set; }
        public string Number { get; private set; }
        public string Email { get; private set; }
        public string RUC { get; private set; }
        public DateTime CreateAt { get; private set; }

        public CompanyInfoResponse(Company company)
        {
            Id = company.Id;
            Name = company.Name;
            Image = company.Image;
            Password = company.Password;
            Number = company.Number;
            Email = company.Email;
            RUC = company.RUC;
            CreateAt = company.CreateAt;
        }
    }
}