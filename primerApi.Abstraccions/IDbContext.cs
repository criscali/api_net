using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primerApi.Abstraccions
{
    public interface IDbContext<T>: Icrud<T>
    {

    }
}
