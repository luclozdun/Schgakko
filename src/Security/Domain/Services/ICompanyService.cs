using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Security.Domain.Model.Entities;
using Schgakko.src.Security.Domain.Model.ValueObjects;
using Schgakko.src.Security.Domain.Result;

namespace Schgakko.src.Security.Domain.Services
{
    public interface ICompanyService
    {
        Task<CompanyResult> Add(Company company);
        Task<CompanyResult> FindById(CompanyId companyId);
        Task<CompanyResult> Update(Company request, CompanyId companyId);
        Task<CompanyResult> Remove(CompanyId companyId);
    }
}