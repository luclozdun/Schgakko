using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Shared.Domain.Model.Entities
{
    public class Pageable
    {
        public int Page { get; private set; }
        public int PageSize { get; private set; }

        public Pageable(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}