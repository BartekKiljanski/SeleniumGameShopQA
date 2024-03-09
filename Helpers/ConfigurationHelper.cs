using Microsoft.Extensions.Configuration;

namespace SeleniumGameShopQA.Helpers
{
    

        public class ConfigurationHelper
        {
            // Definicje właściwości dla ustawień
            public string WebSitePage { get; set; }
            public string Driver { get; set; }
            public string DefaultConnection { get; set; }
            public string AdminName { get; set; }
            public string AdminPassword { get; set; }
            public string UserNewPassword { get; set; }

            private static IConfigurationRoot _configurationRoot;

            static ConfigurationHelper()
            {
                _configurationRoot = GetIConfigurationRoot(Directory.GetCurrentDirectory());
            }

            public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
            {
                return new ConfigurationBuilder()
                    .SetBasePath(outputPath)
                    .AddJsonFile("appsettings.json", optional: true)
                    .AddJsonFile("TestData/errorMessages.json", optional: true) // Poprawiona ścieżka
                    .Build();
            }

            public static ConfigurationHelper GetApplicationConfiguration()
            {
                var configuration = new ConfigurationHelper();
                _configurationRoot
                    .GetSection("AppSettings")
                    .Bind(configuration);
                return configuration;
            }

            // Uzyskaj reguły walidacji błędów
            public static ConfigurationHelper GetValidationRules()
            {
                var configuration = new ConfigurationHelper();
                _configurationRoot
                    .GetSection("Messages")
                    .GetSection("ErrorMessages")
                    .Bind(configuration);
                return configuration;
            }
        }
    }
