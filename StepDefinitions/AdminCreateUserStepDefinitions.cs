using NUnit.Framework;
using SeleniumGameShopQA.PageObjectLibrary;
using SeleniumGameShopQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumGameShopQA.StepDefinitions
{
    [Binding]
    public class AdminCreateUserStepDefinitions
    {
        public AdminManagementPO adminManagementPO = new AdminManagementPO();
        public AdminLoginPO adminLoginPO = new AdminLoginPO();
        [When(@"wybieram zakładkę Utwórz użytkownika")]
        public void WhenWybieramZakladkeUtworzUzytkownika()
        {
            adminManagementPO.GoToContentManagement();
            adminManagementPO.GoToAccountItem();
        }

        [When(@"wypełniam formularz danymi nowego konta")]
        public void WhenWypelniamFormularzDanymiNowegoKonta()
        {
            adminManagementPO.CreateNewAccount();
        }

        [When(@"wybieram opcję Rejestruj")]
        public void WhenWybieramOpcjeRejestruj()
        {
            adminManagementPO.GoToRegisterAccountt();
            
        }

        [Then(@"nowe konto zostaje dodane do bazy danych")]
        public void ThenNoweKontoZostajeDodaneDoBazyDanych()
        {
            
            string categoryName = adminManagementPO.SearchInDatabase("AspNetUsers", "Email", "adres12@gmail.com", "ID");

            // Asercja, że znaleziono rekord
            Assert.IsNotNull(categoryName, "Nie znaleziono emaila 'adres12@gmail.com w bazie danych.");
        }
       

        [When(@"wpisuję email utworzonego konta")]
        public void WhenWpisujeEmailUtworzonegoKonta()
        {
            adminManagementPO.EnterAccountEmail();
        }

        [When(@"wpisuję hasło utworzonego konta")]
        public void WhenWpisujeHasloUtworzonegoKonta()
        {
            adminManagementPO.EnterAccountPassword();
        }

        [Then(@"jestem zalogowany do systemu jako nowy użytkownik")]
        public void ThenJestemZalogowanyDoSystemuJakoNowyUzytkownik()
        {
            adminLoginPO.FindLogoutButtonAfterLogging();
        }

        [Then(@"usuwam konto z bazy danych")]
        public void ThenUsuwamKontoZBazyDanych()
        {

            Utils.Wait(1);
            string emailToDelete = "adres12@gmail.com";

            // Sprawdzenie, czy konto istnieje przed usunięciem
            string existingAccount = adminManagementPO.SearchInDatabase("AspNetUsers", "Email", emailToDelete, "Id");
            Assert.IsNotNull(existingAccount, "Nie znaleziono emaila 'adres12@gmail.com' w bazie danych przed usunięciem.");

            // Usuwanie konta
            adminManagementPO.DeleteFromDatabase("AspNetUsers", "Email", emailToDelete);

            // Sprawdzenie, czy konto zostało usunięte
            existingAccount = adminManagementPO.SearchInDatabase("AspNetUsers", "Email", emailToDelete, "Id");
            Assert.IsNull(existingAccount, "Konto 'adres12@gmail.com' nadal istnieje w bazie danych po usunięciu.");
        }

    }
}
