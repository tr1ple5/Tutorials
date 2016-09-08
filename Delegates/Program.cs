using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchProgramming
{
    class Program
    {
        

        static void Main(string[] args)
        {

            Stopwatch sw = Stopwatch.StartNew();

            Task<int> carTask = Task.Factory.StartNew<int>(BookCar);
            Task<int> planeTask = Task.Factory.StartNew<int>(BookPlane);
            Task<int> hotelTask = Task.Factory.StartNew<int>(BookHotel);

            Task hotelFollowUpTask = hotelTask.ContinueWith(
                taskPrev => Console.WriteLine("Adding view note for booking {0}", taskPrev.Result));

            hotelFollowUpTask.Wait();
            //Task.WaitAll(carTask, hotelTask, planeTask);
            Console.WriteLine("Finished booking: carId={0}, hotelId={1}, planeId={2}", carTask.Result, hotelTask.Result,planeTask.Result);

            Console.WriteLine("Finished in {0} sec.", sw.ElapsedMilliseconds / 1000.0);


            /* This is the serial way single thread
            Stopwatch sw = Stopwatch.StartNew();

           int carId = BookCar();
           int hotelId = BookHotel();
           int planeId = BookPlane();

           Console.WriteLine("Finished in {0} sec.", sw.ElapsedMilliseconds / 1000.0);*/
           Console.ReadLine();
        }

        static Random rand = new Random();
        private static int BookPlane()
        {
            Console.WriteLine("booking plane.....");
            Thread.Sleep(5000);
            Console.WriteLine("done with plane");
            return rand.Next(100);
        }

        private static int BookHotel()
        {
            Console.WriteLine("booking hotel.....");
            Thread.Sleep(8000);
            Console.WriteLine("done with hotel");
            return rand.Next(100);
        }

        private static int BookCar()
        {
            Console.WriteLine("booking car.....");
            Thread.Sleep(3000);
            Console.WriteLine("done with car");
            return rand.Next(100);
        }
    }
}
