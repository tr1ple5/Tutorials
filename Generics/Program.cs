using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities<int> intUtil = new Utilities<int>();
            Utilities<string> stringUtil = new Utilities<string>();

            bool result = intUtil.Compare(5, 5);
            Console.WriteLine(result.ToString());

            var result1 = stringUtil.Compare("Derrick", "Ejan");
            Console.WriteLine(result1.ToString());

            Console.Read();
        }
    }
}
