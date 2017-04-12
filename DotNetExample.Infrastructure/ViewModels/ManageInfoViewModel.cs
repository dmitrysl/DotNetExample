using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExample.Infrastructure.ViewModels
{
    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }
        public string Email { get; set; }
        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
        public List<UserLoginInfoViewModel> Logins { get; set; }
    }
}
