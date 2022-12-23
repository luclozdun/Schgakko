using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schgakko
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDataBase().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webHost =>
                    {
                        webHost.UseStartup<StartUp>();
                    });
        }
    }
}