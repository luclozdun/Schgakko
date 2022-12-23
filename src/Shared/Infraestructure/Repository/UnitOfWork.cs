using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Schgakko.src.Shared.Domain.Repositories;

namespace Schgakko.src.Shared.Infraestructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext context;

        public UnitOfWork(DataBaseContext context)
        {
            this.context = context;
        }

        public IDbContextTransaction Transaction()
        {
            return context.Database.BeginTransaction();
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}