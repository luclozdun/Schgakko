using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schgakko.src.Order.Application.Dto;
using Schgakko.src.Order.Domain.Result;
using Schgakko.src.Order.Domain.Services;
using Schgakko.src.Security.Domain.Model.Enum;

namespace Schgakko.src.Order.Application.Controller
{
    [Route("/invoices")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        [Authorize(Policy = Role.Admin)]
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            return Ok(await invoiceService.FindAll());
        }

        [Authorize(Policy = Role.Company)]
        [HttpGet("/company/{id}")]
        public async Task<IActionResult> FindAllByCompanyId([FromRoute] int id)
        {
            return Ok(await invoiceService.FindAllByCompanyId(id));
        }

        [Authorize(Policy = Role.Customer)]
        [HttpGet("/customer/{id}")]
        public async Task<IActionResult> FindAllByCustomerId([FromRoute] int id)
        {
            return Ok(await invoiceService.FindAllByCustomerId(id));
        }

        [Authorize(Policy = Role.Customer)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoiceRequest request)
        {
            InvoiceResult result = await invoiceService.Create(request);
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }
    }
}