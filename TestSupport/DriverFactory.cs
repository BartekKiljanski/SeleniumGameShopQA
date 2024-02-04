using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace SeleniumGameShopQA.Selenium
{
    public static class DriverFactory
	{
		public static IWebDriver GetDriver()
		{
			string driver = Helpers.AppSettings.Driver;
			Enum.TryParse(driver, out DriverName dirverName);
			ChromeOptions chromeOptions = new ChromeOptions();
			chromeOptions.AddArgument("incognito");

            switch (dirverName)
			{
				case DriverName.Chrome:
					return new ChromeDriver(chromeOptions);
				case DriverName.Firefox:
					return new FirefoxDriver();
				case DriverName.Ie:
					return new InternetExplorerDriver();
				default:
					return new ChromeDriver(chromeOptions);
			}
		}
	}

	public enum DriverName
	{
		Chrome, Firefox, Ie
	}

}