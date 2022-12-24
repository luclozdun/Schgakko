using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Shared.Application.Dto
{
    public class PageableRequest
    {
        public int Page { get; private set; }
        public int PageSize { get; private set; }

        public PageableRequest(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}