using System;
using System.Threading;

namespace DockerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"{DateTime.Now} Working...");
                Thread.Sleep(1000);
            }

            
        }
    }
}
