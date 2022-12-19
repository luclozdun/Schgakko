using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Security.Domain.Model.Entities;
using Schgakko.src.Security.Domain.Model.ValueObjects;
using Schgakko.src.Security.Domain.Repositories;
using Schgakko.src.Security.Domain.Result;
using Schgakko.src.Security.Domain.Services;
using Schgakko.src.Shared.Domain.Repositories;

namespace Schgakko.src.Security.Infraestructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IUnitOfWork unitOfWork;

        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            this.companyRepository = companyRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CompanyResult> Add(Company company)
        {
            Company existEmail = await companyRepository.FindByEmail(company.Email);
            if (existEmail != null)
                return new CompanyResult("The email is being used");

            Company existName = await companyRepository.FindByName(company.Name);
            if (existName != null)
                return new CompanyResult("The name is being used");

            Company existNumber = await companyRepository.FindByNumber(company.Number);
            if (existNumber != null)
                return new CompanyResult("The number is being used");

            Company existRUC = await companyRepository.FindByRUC(company.RUC);
            if (existRUC != null)
                return new CompanyResult("The RUC is being used");

            try
            {
                await companyRepository.Add(company);
                await unitOfWork.CompleteAsync();
                return new CompanyResult(company);
            }
            catch (Exception e)
            {
                return new CompanyResult($"Error ocurred while creating company: {e.Message}");
            }

        }

        public async Task<CompanyResult> FindById(CompanyId companyId)
        {
            Company company = await companyRepository.FindById(companyId);
            if (company == null)
                return new CompanyResult("Company not found by id");
            return new CompanyResult(company);
        }

        public async Task<CompanyResult> Remove(CompanyId companyId)
        {
            Company company = await companyRepository.FindById(companyId);
            if (company == null)
                return new CompanyResult("Company not found by id");

            try
            {
                companyRepository.Remove(company);
                await unitOfWork.CompleteAsync();
                return new CompanyResult(company);
            }
            catch (Exception e)
            {
                return new CompanyResult($"Error ocurred while removing company: {e.Message}");
            }
        }

        public async Task<CompanyResult> Update(Company request, CompanyId companyId)
        {
            Company company = await companyRepository.FindById(companyId);
            if (company == null)
                return new CompanyResult("Company not found by id");

            if (!company.Email.Equals(request.Email))
            {
                Company existEmail = await companyRepository.FindByEmail(company.Email);
                if (existEmail == null)
                    return new CompanyResult("The email is being used");
            }

            if (!company.Name.Equals(request.Name))
            {
                Company existName = await companyRepository.FindByName(company.Name);
                if (existName == null)
                    return new CompanyResult("The name is being used");
            }

            if (!company.Number.Equals(request.Number))
            {
                Company existNumber = await companyRepository.FindByNumber(company.Number);
                if (existNumber == null)
                    return new CompanyResult("The number is being used");
            }

            if (!company.RUC.Equals(request.RUC))
            {
                Company existRUC = await companyRepository.FindByRUC(company.RUC);
                if (existRUC == null)
                    return new CompanyResult("The RUC is being used");
            }

            company.Update(request);

            try
            {
                companyRepository.Update(company);
                await unitOfWork.CompleteAsync();
                return new CompanyResult(company);
            }
            catch (Exception e)
            {
                return new CompanyResult($"Error ocurred while updating company: {e.Message}");
            }
        }
    }
}