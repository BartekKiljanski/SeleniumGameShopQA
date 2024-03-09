using OpenQA.Selenium;
using PercyIO.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumGameShopQA.TestSupport
{
	public class PercyManager
	{
		private IWebDriver driver;
		private Percy percyInstance;

		public PercyManager(IWebDriver driver)
		{
			this.driver = driver;
			percyInstance = new Percy(driver);
			percyInstance.Initialize();
		}

		public void TakeSnapshot(string snapshotName)
		{
			percyInstance.Snapshot(snapshotName);
		}
	}
}
