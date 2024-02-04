using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;

namespace SeleniumGameShopQA.Helpers
{
    public class AppSettings
    {
        /// <summary>
        /// Obiekt danych z sekcji appSettings z pliku konfiguracyjnego.
        /// </summary>
        static IConfigurationRoot configuration = ConfigurationHelper.GetApplicationConfiguration(TestContext.CurrentContext.TestDirectory);

        /// <summary>
        /// Adres strony WebSite-a.
        /// </summary>
        public static string WebSitePage { get { return configuration.GetValue(typeof(string), "AppSettings:WebSitePage").ToString(); } }
        public static string Driver { get { return configuration.GetValue(typeof(string), "AppSettings:Driver").ToString(); } }
        /// <summary>
        /// Parametry połączenia z bazą Eskoku.
        /// </summary>
        public static string EskokDBConnectionString { get { return configuration.GetValue(typeof(string), "AppSettings:EskokDBConnectionString").ToString(); } }
        /// <summary>
        /// Numer użytkownika panelu nadzorcy.
        /// </summary>
        public static string UserName { get { return configuration.GetValue(typeof(string), "AppSettings:UserName").ToString(); } }
        /// <summary>
        /// Hasło użytkownika panelu nadzorcy.
        /// </summary>
        public static string UserPassword { get { return configuration.GetValue(typeof(string), "AppSettings:UserPassword").ToString(); } }
        /// <summary>
        /// Nowe hasło użytkownika eskok.
        /// </summary>
        public static string UserNewPassword { get { return configuration.GetValue(typeof(string), "AppSettings:UserNewPassword").ToString(); } }
        /// <summary>
        /// TimeOut na usługach
        /// </summary>
        public static int Timeout {get { return Int32.Parse(configuration.GetValue(typeof(string), "AppSettings:TimeOutService").ToString()); } }
        /// <summary>
        /// Adres kolekcji usług
        /// </summary>
        public static string UrlService {get { return configuration.GetValue(typeof(string), "AppSettings:UrlService").ToString(); } }

    }
}
