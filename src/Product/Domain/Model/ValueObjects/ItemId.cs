using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Shared.Domain.Model.ValueObjects;

namespace Schgakko.src.Product.Domain.Model.ValueObjects
{
    public class ItemId : IdValueObject
    {
        public ItemId(int id) : base(id)
        {
        }
    }
}