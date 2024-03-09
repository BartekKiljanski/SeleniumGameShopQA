using SeleniumGameShopQA.Helpers;
using SeleniumGameShopQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumGameShopQA.PageObjectLibrary
{
    public class AdminLoginPO
    {
        private ConfigurationHelper config;
        public string logIn = "//*[@id=\"login\"]";
        public string logInSubmit = "//*[@id=\"login-submit\"]";
        public string email = "Input_Email";
        public string password = "Input_Password";
        public string logOut = "//*[@id=\"logout\"]";


        // i tak dalej dla innych właściwości...
        // var config = ConfigurationHelper.GetApplicationConfiguration();
        //   public string websiteUrl = AppSettings.WebSitePage;

        public void GoToApp()
        {
            var config = ConfigurationHelper.GetApplicationConfiguration();
            Utils.GoToUrl(config.WebSitePage);
        }

        public void GoToLogin()
        {
          //  Utils.Wait(10);
            Utils.ClickButton(logIn, TimeSpan.FromSeconds(15), "Błąd nie znaleziono pola login - nie udało się przejść do formularza ");
        }

        public void CleanUp()
        {
            Utils.CleanUp();
        }

        public void EnterEmail()
        {
            var config = ConfigurationHelper.GetApplicationConfiguration();
            //  Utils.Wait(10);
            Utils.SendKeysById(email, TimeSpan.FromSeconds(15), config.AdminName, "Błąd email - nie udało się wprowadzić emaila");
        }

        public void EnterPassword()
        {
            var config = ConfigurationHelper.GetApplicationConfiguration();
            //  Utils.Wait(10);
            Utils.SendKeysById(password, TimeSpan.FromSeconds(15), config.AdminPassword, "Błąd hasło - nie udało się wprowadzić hasła");
        }

        public void GoToLoginSubmit()
        {
            //  Utils.Wait(10);
            Utils.ClickButton(logInSubmit, TimeSpan.FromSeconds(15), "Błąd nie znaleziono pola login - nie udało się przejść do formularza ");
        }

        public void FindLogoutButtonAfterLogging()
        {
            Utils.FindVisibleElement(logOut, TimeSpan.FromSeconds(15), "Błąd - brak przycisku WYLOGUJ");
        }

    }
}
