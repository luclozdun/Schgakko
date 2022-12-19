using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schgakko.src.Security.Application.Dto;
using Schgakko.src.Security.Domain.Result;
using Schgakko.src.Security.Domain.Services;

namespace Schgakko.src.Security.Application.Controller
{
    [Route("/authenticate")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService authenticateService;

        public AuthenticateController(IAuthenticateService authenticateService)
        {
            this.authenticateService = authenticateService;
        }

        [HttpPost("/customer")]
        public async Task<IActionResult> AuthenticateCustomer([FromBody] AuthenticateRequest request)
        {
            TokenResult result = await authenticateService.AuthenticationCustomer(request.Email, request.Password);
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpPost("/company")]
        public async Task<IActionResult> AuthenticateCompany([FromBody] AuthenticateRequest request)
        {
            TokenResult result = await authenticateService.AuthenticationCompany(request.Email, request.Password);
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }
    }
}