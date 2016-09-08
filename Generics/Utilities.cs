using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Generics
{
    class Utilities<T>
    {
      public bool Compare(T i, T y)
        {
            if (i.Equals(y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
