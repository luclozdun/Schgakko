using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Schgakko.src.Security.Domain.Model.Entities;
using Schgakko.src.Security.Domain.Model.Enum;
using Schgakko.src.Security.Domain.Model.ValueObjects;
using Schgakko.src.Security.Domain.Repositories;
using Schgakko.src.Security.Domain.Result;
using Schgakko.src.Security.Domain.Services;
using Schgakko.src.Shared.Application.Abstractions;

namespace Schgakko.src.Security.Infraestructure.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IJwtProvider jwtProvider;

        public AuthenticateService(IJwtProvider jwtProvider, ICompanyRepository companyRepository, ICustomerRepository customerRepository)
        {
            this.jwtProvider = jwtProvider;
            this.companyRepository = companyRepository;
            this.customerRepository = customerRepository;
        }

        public AuthenticateService(ICompanyRepository companyRepository, ICustomerRepository customerRepository)
        {
            this.companyRepository = companyRepository;
            this.customerRepository = customerRepository;
        }

        public async Task<TokenResult> AuthenticationCompany(string email, string password)
        {
            Company company = await companyRepository.FindByEmail(email);
            if (company is null)
                return new TokenResult("Invalid credentials");

            if (!company.Password.Equals(password))
                return new TokenResult("Invalid credentials");

            string tknstrg = jwtProvider.Genereate(company.Id, company.Name, company.Email, Role.Company);
            Token token = new Token(tknstrg);
            return new TokenResult(token);
        }

        public async Task<TokenResult> AuthenticationCustomer(string email, string password)
        {
            Customer customer = await customerRepository.FindByEmail(email);
            if (customer is null)
                return new TokenResult("Invalid credentials");

            if (!customer.Password.Equals(password))
                return new TokenResult("Invalid credentials");

            string tknstrg = jwtProvider.Genereate(customer.Id, customer.Name, customer.Email, Role.Customer);
            Token token = new Token(tknstrg);
            return new TokenResult(token);
        }
    }
}