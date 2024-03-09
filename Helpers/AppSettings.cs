using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;

namespace SeleniumGameShopQA.Helpers
{
    public class AppSettings
    {
        private static IConfigurationRoot Configuration { get; set; }

        static AppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public static string WebSitePage => Configuration["AppSettings:WebSitePage"];
        public static string Driver => Configuration["AppSettings:Driver"];
        public static string DefaultConnection => Configuration["AppSettings:DefaultConnection"];
        public static string AdminName => Configuration["AppSettings:AdminName"];
        public static string AdminPassword => Configuration["AppSettings:AdminPassword"];
     
    }
}
