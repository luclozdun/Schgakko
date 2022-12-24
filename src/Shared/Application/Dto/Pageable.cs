using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Shared.Application.Dto
{
    public class Pageable<T>
    {
        public IEnumerable<T> Resource { get; private set; }
        public int Page { get; private set; }
        public int Size { get; private set; }

        public Pageable(IEnumerable<T> resource, int page, int size)
        {
            decimal max = resource.Count() / size;
            int round = (int)Math.Round(max);

            if (max > round)
                round = round + 1;

            if (page < 1)
                page = 1;

            if (page > round)
                page = round;

            int skip = (page - 1) * size;

            Resource = resource.Skip(skip).Take(size).ToList();
            Page = page;
            Size = size;
        }
    }
}