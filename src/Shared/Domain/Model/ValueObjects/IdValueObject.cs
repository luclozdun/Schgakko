using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Shared.Domain.Model.ValueObjects
{
    public abstract class IdValueObject
    {
        public int Id { get; private set; }

        protected IdValueObject(int id)
        {
            Id = id;
        }

        public static implicit operator int(IdValueObject idValueObject)
        {
            return idValueObject.Id;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            IdValueObject intValidateValueObject = (IdValueObject)obj;
            return Id == intValidateValueObject.Id;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

    }
}