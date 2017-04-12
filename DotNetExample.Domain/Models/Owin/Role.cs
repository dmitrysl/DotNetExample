using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExample.Domain.Models.Owin
{
    public class Role: IdentityRole<int, UserRole>
    {
        public static readonly Role Admin = new Role() { Id = 1, Name = "Admin" };
    }
}
