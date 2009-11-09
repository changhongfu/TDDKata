using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientApp.MyService;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var proxy = new CalculationServiceClient())
            {
                Console.WriteLine(proxy.Add(1, 2));
                Console.ReadLine();
            }
        }
    }
}
