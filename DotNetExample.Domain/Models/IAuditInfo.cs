using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetExample.Common.Utils.Attributes;

namespace DotNetExample.Domain.Models
{
    /// <summary>
    /// Need for objects that need audit creating date and modifing date.
    /// </summary>
    public interface IAuditInfo
    {
        [DateTimeKind(DateTimeKind.Utc)]
        DateTime CreatedOn { get; set; }
        [DateTimeKind(DateTimeKind.Utc)]
        DateTime? ModifiedOn { get; set; }
    }
}
