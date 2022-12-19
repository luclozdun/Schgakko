using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Shared.Domain.Result
{
    public abstract class BaseResult<T>
    {
        public bool Success { get; }
        public T Resource { get; }
        public string Message { get; }

        public BaseResult(T resource)
        {
            Resource = resource;
            Success = true;
        }

        public BaseResult(string message)
        {
            Message = message;
            Success = false;
        }

    }
}