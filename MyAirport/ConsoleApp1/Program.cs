using System;
using System.Linq;
using MASB.MyAirport.EF;

namespace MASB.MyAirport.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello!");

            using (var context = new MyAirportContext())
            {
                var bagage = context.Bagage.ToList();
            }


        }
    }
}
