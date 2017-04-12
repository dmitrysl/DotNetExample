using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DotNetExample.Common.Utils.Attributes;

namespace DotNetExample.Domain.Models.Owin
{
    public class ApplicationUser: IdentityUser<int, UserLogin, UserRole, UserClaim>, IEntity<int>
    {
        public string ConfirmationToken { get; set; }

        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime? ConfirmationSentAt { get; set; }

        [JsonIgnore, DefaultValue(false)]
        public bool IsDisabled { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
