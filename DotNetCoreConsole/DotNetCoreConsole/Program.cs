using System;
using System.Diagnostics;
using System.IO;
using log4net;
using log4net.Config;
using log4net.Repository;

namespace DotNetCoreConsole
{
    class Program
    {
        private static ILoggerRepository _loggerRepository;
        static void Main(string[] args)
        {
            _loggerRepository = LogManager.CreateRepository("DotNetCoreConsole");
            XmlConfigurator.ConfigureAndWatch(_loggerRepository, new FileInfo("log4net.config"));
            var log = LogManager.GetLogger(_loggerRepository.Name, typeof(Program));

            const int numberOfCycles = 20000;

            var sw = Stopwatch.StartNew();
            for (var i = 0; i < numberOfCycles; i++)
            {
                log.InfoFormat("testNum: {0} ", i);
            }
            sw.Stop();

            Console.WriteLine();
            Console.WriteLine("Ellapsed: {0}, numPerSec: {1}", sw.ElapsedMilliseconds, numberOfCycles / (sw.ElapsedMilliseconds / (double)1000));

            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
