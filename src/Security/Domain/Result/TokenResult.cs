using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Security.Domain.Model.ValueObjects;
using Schgakko.src.Shared.Domain.Result;

namespace Schgakko.src.Security.Domain.Result
{
    public class TokenResult : BaseResult<Token>
    {
        public TokenResult(Token resource) : base(resource)
        {
        }

        public TokenResult(string message) : base(message)
        {
        }
    }
}