using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Security.Domain.Model.ValueObjects
{
    public class Token
    {
        public Token(string token)
        {
            this.token = token;
        }

        public string token { get; set; }
    }
}