using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Security.Domain.Model.Entities;
using Schgakko.src.Shared.Domain.Result;

namespace Schgakko.src.Security.Domain.Result
{
    public class CustomerResult : BaseResult<Customer>
    {
        public CustomerResult(Customer resource) : base(resource)
        {
        }

        public CustomerResult(string message) : base(message)
        {
        }
    }
}