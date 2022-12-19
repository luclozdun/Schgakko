using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Security.Application.Dto
{
    public class CustomerRequest
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string DNI { get; private set; }
        public int Number { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public CustomerRequest(string name, string lastName, string dNI, int number, string email, string password)
        {
            Name = name;
            LastName = lastName;
            DNI = dNI;
            Number = number;
            Email = email;
            Password = password;
        }
    }
}