using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Shared.Domain.Result
{
    public class PageableResult<T>
    {
        public IEnumerable<T> Resources { get; private set; }
        public int Page { get; private set; }
        public int PageSize { get; private set; }

        public PageableResult(IEnumerable<T> resources, int page, int pageSize)
        {
            Resources = resources;
            Page = page;
            PageSize = pageSize;
        }
    }
}