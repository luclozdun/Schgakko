using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko.src.Security.Domain.Model.Enum
{
    public class Role
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
        public const string Company = "Company";

        public static string Roles(string role1, string role2)
        {
            return role1 + "," + role2;
        }
    }
}