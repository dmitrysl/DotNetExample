using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExample.Domain.Models.Owin
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual Role Role { get; set; }
    }
}
