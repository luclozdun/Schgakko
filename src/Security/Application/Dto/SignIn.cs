using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Security.Application.Dto
{
    public class SignIn
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public SignIn(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}