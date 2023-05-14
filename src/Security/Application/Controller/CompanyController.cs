using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schgakko.src.Security.Application.Dto;
using Schgakko.src.Security.Domain.Model.Entities;
using Schgakko.src.Security.Domain.Model.Enum;
using Schgakko.src.Security.Domain.Model.ValueObjects;
using Schgakko.src.Security.Domain.Result;
using Schgakko.src.Security.Domain.Services;
using static Schgakko.src.Security.Domain.Model.Entities.Company;

namespace Schgakko.src.Security.Application.Controller
{
    [Route("/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById([FromRoute] int id)
        {
            CompanyResult result = await companyService.FindById(new CompanyId(id));
            return result.Success ? Ok(new CompanyResponse(result.Resource)) : BadRequest(result.Message);
        }

        [Authorize(Policy = Role.Company)]
        [HttpGet("info/{id}")]
        public async Task<IActionResult> FindByIdInfo([FromRoute] int id)
        {
            CompanyResult result = await companyService.FindById(new CompanyId(id));
            return result.Success ? Ok(new CompanyInfoResponse(result.Resource)) : BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyRequest request)
        {
            Company company = new CompanyBuilder().WithEmail(request.Email)
                                                    .WithImage(request.Image)
                                                    .WithName(request.Name)
                                                    .WithNumber(request.Number)
                                                    .WithPassword(request.Password)
                                                    .WithRUC(request.RUC)
                                                    .Build();
            CompanyResult result = await companyService.Add(company);
            return result.Success ? Ok(new CompanyResponse(result.Resource)) : BadRequest(result.Message);
        }

        [Authorize(Policy = Role.Company)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CompanyRequest request, [FromRoute] int id)
        {
            Company company = new CompanyBuilder().WithEmail(request.Email)
                                                    .WithImage(request.Image)
                                                    .WithName(request.Name)
                                                    .WithNumber(request.Number)
                                                    .WithPassword(request.Password)
                                                    .WithRUC(request.RUC)
                                                    .Build();
            CompanyResult result = await companyService.Update(company, new CompanyId(id));
            return result.Success ? Ok(new CompanyResponse(result.Resource)) : BadRequest(result.Message);
        }

        [Authorize(Policy = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            CompanyResult result = await companyService.Remove(new CompanyId(id));
            return result.Success ? Ok(new CompanyResponse(result.Resource)) : BadRequest(result.Message);
        }
    }
}