using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Security.Domain.Result;

namespace Schgakko.src.Security.Domain.Services
{
    public interface IAuthenticateService
    {
        Task<TokenResult> AuthenticationCustomer(string email, string password);
        Task<TokenResult> AuthenticationCompany(string email, string password);
    }
}