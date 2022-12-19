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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataBaseContext context;

        public CompanyRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task Add(Company company)
        {
            await context.Companies.AddAsync(company);
        }

        public async Task<Company> FindByRUC(string ruc)
        {
            return await context.Companies.Where(x => x.RUC == ruc).FirstOrDefaultAsync();
        }

        public async Task<Company> FindByEmail(string email)
        {
            return await context.Companies.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<Company> FindById(CompanyId id)
        {
            return await context.Companies.Where(x => x.Id == (int)id).FirstOrDefaultAsync();
        }

        public async Task<Company> FindByName(string name)
        {
            return await context.Companies.Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<Company> FindByNumber(string number)
        {
            return await context.Companies.Where(x => x.Number == number).FirstOrDefaultAsync();
        }

        public void Remove(Company company)
        {
            context.Companies.Remove(company);
        }

        public void Update(Company company)
        {
            context.Companies.Update(company);
        }
    }
}