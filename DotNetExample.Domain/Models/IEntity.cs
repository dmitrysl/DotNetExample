using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExample.Domain.Models
{
    public interface IEntity : IEntity<int>
    {
        new int Id { get; set; }
    }

    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
