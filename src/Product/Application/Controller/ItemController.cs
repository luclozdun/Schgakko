using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schgakko.src.Product.Application.Dto;
using Schgakko.src.Product.Domain.Model.Entities;
using Schgakko.src.Product.Domain.Result;
using Schgakko.src.Product.Domain.Services;
using Schgakko.src.Security.Domain.Model.Enum;
using Schgakko.src.Shared.Application.Dto;
using static Schgakko.src.Product.Domain.Model.Entities.Item;

namespace Schgakko.src.Product.Application.Controller
{
    [Route("/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet("/page/{page}/size/{size}")]
        public async Task<IActionResult> FindAll([FromRoute] int page, [FromRoute] int size)
        {
            IEnumerable<Item> data = await itemService.FindAll();
            Pageable<Item> response = new Pageable<Item>(data, page, size);
            return Ok(response);
        }

        [HttpGet("/page/{page}/size/{size}/price/{high}/{low}")]
        public async Task<IActionResult> FindByHighAndLowPrice([FromRoute] int page, [FromRoute] int size, [FromRoute] int high, [FromRoute] int low)
        {
            IEnumerable<Item> data = await itemService.FindByHighAndLowPrice(high, low);
            Pageable<Item> response = new Pageable<Item>(data, page, size);
            return Ok(response);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> FindById([FromRoute] int id)
        {
            ItemResult result = await itemService.FindById(id);
            return result.Success ? Ok(new ItemResponse(result.Resource)) : BadRequest(result.Message);
        }

        [Authorize(Policy = Role.Company)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ItemRequest request)
        {
            Item item = new ItemBuilder()
                            .WithCompanyId(request.CompanyId)
                            .WithDescount(request.Descount)
                            .WithDescription(request.Description)
                            .WithQuantify(request.Quantity)
                            .WithImage(request.Image)
                            .WithPrice(request.Price)
                            .WithSubtitle(request.Subtitle)
                            .WithTitle(request.Title)
                            .Build();
            ItemResult result = await itemService.Create(item);
            return result.Success ? Ok(new ItemResponse(result.Resource)) : BadRequest(result.Message);
        }

        [Authorize(Policy = Role.Company)]
        [HttpPut("/{itemId}")]
        public async Task<IActionResult> Update([FromBody] ItemRequest request, [FromRoute] int itemId)
        {
            Item item = new ItemBuilder()
                            .WithCompanyId(request.CompanyId)
                            .WithDescount(request.Descount)
                            .WithDescription(request.Description)
                            .WithQuantify(request.Quantity)
                            .WithImage(request.Image)
                            .WithPrice(request.Price)
                            .WithSubtitle(request.Subtitle)
                            .WithTitle(request.Title)
                            .Build();
            ItemResult result = await itemService.Create(item);
            return result.Success ? Ok(new ItemResponse(result.Resource)) : BadRequest(result.Message);
        }

        [Authorize(Policy = Role.Company)]
        [HttpDelete("/{itemId}/company/{companyId}")]
        public async Task<IActionResult> Remove([FromRoute] int itemId, [FromRoute] int companyId)
        {
            ItemResult result = await itemService.Remove(itemId, companyId);
            return result.Success ? Ok(new ItemResponse(result.Resource)) : BadRequest(result.Message);
        }
    }
}