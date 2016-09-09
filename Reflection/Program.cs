using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var assembly = Assembly.GetExecutingAssembly();

            Console.WriteLine(assembly.FullName);
           

            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine("Type: " + type.Name + " Base Type: " + type.BaseType.Name);

                var props = type.GetProperties();
                foreach (var prop in props)
                {
                    Console.WriteLine("Property: " + prop.Name + " Property Type: " + prop.PropertyType.Name);
                }

                var fields = type.GetFields();
                foreach (var field in fields)
                {
                    Console.WriteLine("Fields: " + field.Name);
                }

                var methods = type.GetMethods();
                foreach (var method in methods)
                {
                    Console.WriteLine("Methods: " + method.Name);
                }
            }

            var sample = new Sample { Name = "Derrick", Age = 35 };
            var sampleType = typeof(Sample); // sample.GetType();

            //var nameProperty = sampleType.GetProperty("Name");
            //Console.WriteLine("Property: " + nameProperty.GetValue(sample));

            var myMethod = sampleType.GetMethod("MyMethod");

            myMethod.Invoke(sample, null);
            */

            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes().Where(t => t.GetCustomAttributes<MyClassAttribute>().Count() > 0);

            foreach (var type in types)
            {
                Console.WriteLine(type.Name);
                var methods = type.GetMethods().Where(x => x.GetCustomAttributes<MyMethodAttribute>().Count() > 0);

                foreach (var method in methods)
                {
                    Console.WriteLine(method.Name);
                }

            }

            Console.ReadLine();
        }
    }

    [MyClass]
    public class Sample
    {
        public string Name { get; set; }
        public int Age;

        [MyMethod]
        public void MyMethod()
        {
            Console.WriteLine("Hello from my Method!!!!");
        }


        public void NoAttributeMethod()
        {

        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class MyClassAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Method)]
    public class MyMethodAttribute : Attribute
    {

    }
}
