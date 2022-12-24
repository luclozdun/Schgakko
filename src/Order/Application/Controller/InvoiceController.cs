using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schgakko.src.Order.Application.Dto;
using Schgakko.src.Order.Domain.Model.Entities;
using Schgakko.src.Order.Domain.Result;
using Schgakko.src.Order.Domain.Services;
using Schgakko.src.Security.Domain.Model.Enum;
using Schgakko.src.Shared.Application.Dto;

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
        [HttpGet("/page/{page}/size/{size}")]
        public async Task<IActionResult> FindAll([FromRoute] int page, [FromRoute] int size)
        {
            IEnumerable<Invoice> data = await invoiceService.FindAll();
            Pageable<Invoice> response = new Pageable<Invoice>(data, page, size);
            return Ok(response);
        }

        [Authorize(Policy = Role.Company)]
        [HttpGet("/page/{page}/size/{size}/company/{id}")]
        public async Task<IActionResult> FindAllByCompanyId([FromRoute] int page, [FromRoute] int size, [FromRoute] int id)
        {
            IEnumerable<Invoice> data = await invoiceService.FindAllByCompanyId(id);
            Pageable<Invoice> response = new Pageable<Invoice>(data, page, size);
            return Ok(response);
        }

        [Authorize(Policy = Role.Customer)]
        [HttpGet("/page/{page}/size/{size}/customer/{id}")]
        public async Task<IActionResult> FindAllByCustomerId([FromRoute] int page, [FromRoute] int size, [FromRoute] int id)
        {
            IEnumerable<Invoice> data = await invoiceService.FindAllByCustomerId(id);
            Pageable<Invoice> response = new Pageable<Invoice>(data, page, size);
            return Ok(response);
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