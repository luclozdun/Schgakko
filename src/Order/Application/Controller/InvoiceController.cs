using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schgakko.src.Order.Application.Dto;
using Schgakko.src.Order.Domain.Result;
using Schgakko.src.Order.Domain.Services;

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

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            return Ok(await invoiceService.FindAll());
        }

        [HttpGet("/company/{id}")]
        public async Task<IActionResult> FindAllByCompanyId([FromRoute] int id)
        {
            return Ok(await invoiceService.FindAllByCompanyId(id));
        }

        [HttpGet("/customer/{id}")]
        public async Task<IActionResult> FindAllByCustomerId([FromRoute] int id)
        {
            return Ok(await invoiceService.FindAllByCustomerId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoiceRequest request)
        {
            InvoiceResult result = await invoiceService.Create(request);
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }
    }
}