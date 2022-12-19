using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Shared.Domain.Model.ValueObjects;

namespace Schgakko.src.Security.Domain.Model.ValueObjects
{
    public class CustomerId : IdValueObject
    {
        public CustomerId(int id) : base(id)
        {
        }
    }
}