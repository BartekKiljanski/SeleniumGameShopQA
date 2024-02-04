using Microsoft.Extensions.Configuration;

namespace SeleniumGameShopQA.Helpers
{
    class ConfigurationHelper
    {

        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile(@"TestData\errorMessages.json", optional: true)
                .Build();

       
        }

        public static IConfigurationRoot GetApplicationConfiguration(string outputPath)
        {
            var configuration = new ConfigurationHelper();

            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig
                .GetSection("AppSettings")
                .Bind(configuration);

            return iConfig;
        }
        public static IConfigurationRoot GetValidationRules(string outputPath)
        {
            var configuration = new ConfigurationHelper();

            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig
                .GetSection("Messages")
                .GetSection("ErrorMessages")
                .Bind(configuration);

            return iConfig;
        }

    }
}
