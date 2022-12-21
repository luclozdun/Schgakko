using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Product.Domain.Model.Entities;
using Schgakko.src.Shared.Domain.Result;

namespace Schgakko.src.Product.Domain.Result
{
    public class ItemResult : BaseResult<Item>
    {
        public ItemResult(Item resource) : base(resource)
        {
        }

        public ItemResult(string message) : base(message)
        {
        }
    }
}