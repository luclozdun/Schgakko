using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Shared.Domain.Model.Entities
{
    public abstract class Entity
    {
        public int Id { get; private set; }

        protected Entity()
        {
        }
    }
}