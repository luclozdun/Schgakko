using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}