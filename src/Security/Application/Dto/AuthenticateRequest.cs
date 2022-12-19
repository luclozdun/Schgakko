using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Security.Application.Dto
{
    public class AuthenticateRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AuthenticateRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}