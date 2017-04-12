using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExample.Infrastructure.ViewModels
{
    public class RemoveLoginBindingModel
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
}
