using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace SeleniumGameShopQA.Helpers
{
    public class Messages
    {
        static IConfigurationRoot configuration = ConfigurationHelper.GetValidationRules(TestContext.CurrentContext.TestDirectory);

        public static string ActivateAccess { get { return configuration.GetValue(typeof(string), "Messages:ActivateAccess").ToString(); } }
        public static string UnlockActivateAccess { get { return configuration.GetValue(typeof(string), "Messages:UnlockActivateAccess").ToString(); } }
    }
}