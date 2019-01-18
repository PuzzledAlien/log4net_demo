using System;
using System.Diagnostics;
using MyLogManager;

namespace DotNetCoreConsole_V3
{
    class Program
    {
        static void Main(string[] args)
        {
            TestNullLogManager();

            Console.WriteLine("Hello World!");
        }

        static void TestNullLogManager()
        {
            var log = NullLogManager.GetMyLog(typeof(Program));

            const int numberOfCycles = 20000;

            var sw = Stopwatch.StartNew();
            for (var i = 0; i < numberOfCycles; i++)
            {
                log.InfoFormat("testNum: {0} ", i);
            }
            sw.Stop();

            Console.WriteLine();
            Console.WriteLine("Ellapsed: {0}, numPerSec: {1}", sw.ElapsedMilliseconds, numberOfCycles / (sw.ElapsedMilliseconds / (double)1000));
            Console.ReadKey();
        }
    }
}
