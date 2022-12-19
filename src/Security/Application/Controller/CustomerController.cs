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
using static Schgakko.src.Security.Domain.Model.Entities.Customer;

namespace Schgakko.src.Security.Application.Controller
{
    [Route("/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [Authorize(Policy = Role.Customer)]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById([FromRoute] int id)
        {
            CustomerResult result = await customerService.FindById(new CustomerId(id));
            return result.Success ? Ok(new CustomerResponse(result.Resource)) : BadRequest(result.Message);
        }

        [Authorize(Policy = Role.Customer)]
        [HttpGet("info/{id}")]
        public async Task<IActionResult> FindByIdInfo([FromRoute] int id)
        {
            CustomerResult result = await customerService.FindById(new CustomerId(id));
            return result.Success ? Ok(new CustomerInfoResponse(result.Resource)) : BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerRequest request)
        {
            Customer customer = new CustomerBuilder().WithDNI(request.DNI)
                                                    .WithEmail(request.Email)
                                                    .WithLastName(request.LastName)
                                                    .WithName(request.Name)
                                                    .WithNumber(request.Number)
                                                    .WithPassword(request.Password)
                                                    .Build();
            CustomerResult result = await customerService.Add(customer);
            return result.Success ? Ok(new CustomerResponse(result.Resource)) : BadRequest(result.Message);
        }

        [Authorize(Policy = Role.Customer)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CustomerRequest request, [FromRoute] int id)
        {
            Customer customer = new CustomerBuilder().WithDNI(request.DNI)
                                                    .WithEmail(request.Email)
                                                    .WithLastName(request.LastName)
                                                    .WithName(request.Name)
                                                    .WithNumber(request.Number)
                                                    .WithPassword(request.Password)
                                                    .Build();
            CustomerResult result = await customerService.Update(customer, new CustomerId(id));
            return result.Success ? Ok(new CustomerResponse(result.Resource)) : BadRequest(result.Message);
        }

        [Authorize(Policy = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            CustomerResult result = await customerService.Remove(new CustomerId(id));
            return result.Success ? Ok(new CustomerResponse(result.Resource)) : BadRequest(result.Message);
        }
    }
}