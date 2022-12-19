using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Shared.Application.Abstractions
{
    public interface IJwtProvider
    {
        string Genereate(int id, string name, string email, string role);
    }
}