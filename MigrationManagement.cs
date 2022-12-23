using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schgakko.src.Shared.Infraestructure;

namespace Schgakko
{
    public static class MigrationManagement
    {
        public static IHost MigrateDataBase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            using (var appContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>())
            {
                try
                {
                    appContext.Database.EnsureCreated();
                }
                catch (Exception e)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError($"Any : {e.Message}");
                }
            }
            return host;
        }
    }
}