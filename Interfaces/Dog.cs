using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Dog : IAnimal
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public void Run()
        {
            Console.WriteLine(String.Format("The {0} {1} is Running", Color, Name));
        }
    }
}
