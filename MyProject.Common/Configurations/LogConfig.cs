using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.Configurations
{
    public static class LogConfig
    {
        public const string LOG_CONNECTION = @"Data Source=.; Database=MyProjectDb; User Id=sa; Password=123;";
        public const string LOG_TABLE_NAME = "Logs";
        public const string LOG_SCHEMA_NAME = "dbo";
    }
}
