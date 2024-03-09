using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using SeleniumGameShopQA.PageObjectLibrary;
using SeleniumGameShopQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SeleniumGameShopQA.StepDefinitions
{
    [Binding]
    public class SystemAdminLoginStepDefinitions
    {

        public AdminLoginPO adminLoginPO = new AdminLoginPO();

        [AfterScenario]
        public void AfterScenario()
        {
            adminLoginPO.CleanUp();
		
		}

        [Given(@"otwieram stronę logowania do panelu administracyjnego")]
        public void GivenOtwieramStroneLogowaniaDoPaneluAdministracyjnego()
        {
            adminLoginPO.GoToApp();
        }
        [When(@"wybieram opcję Zaloguj")]
        public void WhenWybieramOpcjeZaloguj()
        {
            adminLoginPO.GoToLogin();
        }


		[When(@"widzę formularz do logowania")]
		public void WhenWidzeFormularzDoLogowania()
		{
        
		}

		[When(@"wpisuję email administratora")]
        public void WhenWpisujeEmailAdministratora()
        {
            adminLoginPO.EnterEmail();
        }

        [When(@"wpisuję hasło administratora")]
        public void WhenWpisujeHasloAdministratora()
        {
            adminLoginPO.EnterPassword();
        }

        [When(@"zatwierdzam formularz logowania")]
        public void WhenZatwierdzamFormularzLogowania()
        {
            adminLoginPO.GoToLoginSubmit();
        }

        [Then(@"jestem zalogowany do systemu jako administrator")]
        public void ThenJestemZalogowanyDoSystemuJakoAdministrator()
        {
            adminLoginPO.FindLogoutButtonAfterLogging();
        }

        
    }
}
