using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace GONIS.Core.Helper
{
    public class ConfigurationHelper
    {
        private static IConfiguration _configuration { get; set; }
        public static IConfiguration Configuration
        {
            get
            {
                return _configuration?? BuildConfiguration();
            }
            set
            {
                _configuration = value;
            }
        }

        private static IConfiguration BuildConfiguration()
        { 
            return _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Debug.json", optional: true)
                .Build();
        }

        public static string GetConnectionString(string key)
        {
            ValueHelper.CheckObjectEqualNull(key);
            var conStr = Configuration.GetSection("connectionStrings")
                .GetChildren()
                .Where(x => x.Key == key)
                .FirstOrDefault()?.Value;
            ValueHelper.CheckObjectEqualNull(conStr);
            return conStr;
        }

        public static string GetAppSetting(string key)
        {
            ValueHelper.CheckObjectEqualNull(key);
            var value= Configuration.GetSection("appSettings")
                .GetChildren()
                .Where(x => x.Key == key)
                .FirstOrDefault()?.Value;
            ValueHelper.CheckObjectEqualNull(value);
            return value;
        }


    }
}
