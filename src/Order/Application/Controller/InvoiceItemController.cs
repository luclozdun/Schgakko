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
    [Route("/invoiceitems")]
    [ApiController]
    public class InvoiceItemController : ControllerBase
    {
        private readonly IInvoiceItemService invoiceItemService;

        public InvoiceItemController(IInvoiceItemService invoiceItemService)
        {
            this.invoiceItemService = invoiceItemService;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            return Ok(await invoiceItemService.FindAll());
        }

        [HttpGet("/item/{id}")]
        public async Task<IActionResult> FindAllByItemId([FromRoute] int id)
        {
            return Ok(await invoiceItemService.FindAllByItemId(id));
        }

        [HttpGet("/invoice/{id}")]
        public async Task<IActionResult> FindAllByInvoiceId([FromRoute] int id)
        {
            return Ok(await invoiceItemService.FindAllByInvoiceId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoiceItemRequest request)
        {
            InvoiceItemResult result = await invoiceItemService.Create(request);
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }
    }
}