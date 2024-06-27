using Project1DotNet.Menu;
using Serilog;
using static System.Formats.Asn1.AsnWriter;

namespace Project1DotNet
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("./../../../logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            MenuManagement.RunMenu();
            
        }
    }
}

