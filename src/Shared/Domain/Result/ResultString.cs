using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Shared.Domain.Result
{
    public class ResultString : BaseResult<string>
    {
        public ResultString(string resource, bool any) : base(resource)
        {
        }

        public ResultString(string message) : base(message)
        {
        }
    }
}