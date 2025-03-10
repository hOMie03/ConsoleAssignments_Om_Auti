using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PolicyKirana.Utility
{
    static class DBConnUtil
    {
        static IConfiguration _iConfiguration; // Private type
        static DBConnUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder() // Used to build configuration object from Datasource
                            .SetBasePath(Directory.GetCurrentDirectory()) // Setting the path to application's current directory
                            .AddJsonFile("appsettings.json"); // Load the configuration setting from this JSON file
            _iConfiguration = builder.Build(); // Compiling configuration into Iconfiguration
        }
        public static string GetConnectionString()
        {
            return _iConfiguration.GetConnectionString("LocalConnString");
        }
    }
}
