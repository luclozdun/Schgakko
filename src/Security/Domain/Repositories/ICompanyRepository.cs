using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Security.Domain.Model.Entities;
using Schgakko.src.Security.Domain.Model.ValueObjects;

namespace Schgakko.src.Security.Domain.Repositories
{
    public interface ICompanyRepository
    {
        Task Add(Company company);

        Task<Company> FindById(CompanyId id);

        Task<Company> FindByName(string name);

        Task<Company> FindByEmail(string email);

        Task<Company> FindByRUC(string ruc);

        Task<Company> FindByNumber(string number);

        void Remove(Company company);

        void Update(Company company);
    }
}