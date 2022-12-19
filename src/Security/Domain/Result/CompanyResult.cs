using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Security.Domain.Model.Entities;
using Schgakko.src.Shared.Domain.Result;

namespace Schgakko.src.Security.Domain.Result
{
    public class CompanyResult : BaseResult<Company>
    {
        public CompanyResult(Company resource) : base(resource)
        {
        }

        public CompanyResult(string message) : base(message)
        {
        }
    }
}