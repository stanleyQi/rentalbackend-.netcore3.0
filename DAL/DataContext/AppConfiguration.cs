using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAL.DataContext
{
    class AppConfiguration
    {
        public string sqlConnectionString { get; set; }

        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            var root = configBuilder.AddJsonFile(path, false).Build();

            sqlConnectionString = root.GetSection("ConnectionStrings:DefaultConnection").Value;

        }
    }
}
