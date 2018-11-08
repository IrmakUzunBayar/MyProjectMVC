using MyProject.Common.Configurations;
using MyProject.Common.Enums;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.Logs
{
    public static class LogLogic
    {
        public static void CreateLog(LogState state)
        {
            var logger =
               new LoggerConfiguration()
                   .WriteTo.MSSqlServer(
                   connectionString: LogConfig.LOG_CONNECTION,
                   tableName: LogConfig.LOG_TABLE_NAME,
                   schemaName: LogConfig.LOG_SCHEMA_NAME
                  ).CreateLogger();

            switch (state)
            {
             case LogState.Information:
                    logger.Information("");
                    break;
            }
   
            logger.Dispose();
        }
    }
}
