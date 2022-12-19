using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Security.Application.Dto
{
    public class CompanyRequest
    {
        public string Name { get; private set; }
        public string Image { get; private set; }
        public string Password { get; private set; }
        public string Number { get; private set; }
        public string Email { get; private set; }
        public string RUC { get; private set; }

        public CompanyRequest(string name, string image, string password, string number, string email, string rUC)
        {
            Name = name;
            Image = image;
            Password = password;
            Number = number;
            Email = email;
            RUC = rUC;
        }
    }
}