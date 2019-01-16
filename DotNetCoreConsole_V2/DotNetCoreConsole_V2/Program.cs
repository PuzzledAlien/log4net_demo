using System;
using System.Diagnostics;

namespace DotNetCoreConsole_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            TestV1();

            TestV2();

            TestNullLogManager();

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }

        static void TestNullLogManager()
        {
            var log = MyLogManager.NullLogManager.GetMyLog(typeof(Program));

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

        static void TestV1()
        {
            MyLogManager.MyLogManager.StartLogger("DotNetCoreConsole_V2", "log4net.config");

            var log = MyLogManager.MyLogManager.GetMyLog(typeof(Program));

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

        static void TestV2()
        {
            MyLogManager.MyLogManager.StartLogger();

            var log = MyLogManager.MyLogManager.GetMyLog(typeof(Program));

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
