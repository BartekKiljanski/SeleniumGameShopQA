using SeleniumGameShopQA.PageObjectLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumGameShopQA.StepDefinitions
{
	[Binding]
	public class UserManagementStepDefinitions
    {
        public AdminLoginPO adminLoginPO = new AdminLoginPO();
        public AdminManagementPO adminManagementPO = new AdminManagementPO();
        public UserManagementPO userManagementPO = new UserManagementPO();


		[Given(@"przechodzę na stronę aplikacji")]
		public void GivenPrzechodzeNaStroneAplikacji()
		{
			adminLoginPO.GoToApp();
		}

		[When(@"wybieram zakładkę Zarejestruj")]
		public void WhenWybieramZakladkeZarejestruj()
		{
			userManagementPO.createNewAccount();
		}

		[When(@"Uzupełniam formularz danymi")]
		public void WhenUzupelniamFormularzDanymi()
		{
			userManagementPO.CreateNewAccountRegister();
		}

		[When(@"Wybieram opcję Rejestruj")]
		public void WhenWybieramOpcjeRejestruj()
		{
			userManagementPO.acceptNewAccount();
		}

		[Then(@"jesteśmy zalogowani")]
		public void ThenJestesmyZalogowani()
		{
			adminLoginPO.FindLogoutButtonAfterLogging();
		}

		[When(@"wpisuję email użytkownika")]
		public void WhenWpisujeEmailUzytkownika()
		{
			userManagementPO.EnterUserEmail();
		}

		[When(@"wpisuję hasło użytkownika")]
		public void WhenWpisujeHasloUzytkownika()
		{
			userManagementPO.EnterUserPassword();
		}

		[Then(@"jestem zalogowany do systemu")]
		public void ThenJestemZalogowanyDoSystemu()
		{
			adminLoginPO.FindLogoutButtonAfterLogging();
		}

		[Then(@"wybieram szczegóły wybranego filmu")]
		public void ThenWybieramSzczegolyWybranegoFilmu()
		{
			userManagementPO.GoToProduct();
		}
		[Then(@"wybieram ilość produktów")]
		public void ThenWybieramIloscProduktow()
		{
			userManagementPO.SendCountNumber();
		}

		[Then(@"dodaje do koszyka")]
		public void ThenDodajeDoKoszyka()
		{
			userManagementPO.AddToCart();
		}

		[Then(@"przechodzę do koszyka")]
		public void ThenPrzechodzeDoKoszyka()
		{
			userManagementPO.ClickBasket();
		}

		[Then(@"wybieram podsumowanie")]
		public void ThenWybieramPodsumowanie()
		{
			userManagementPO.clickSummary();
		}

		[Then(@"składam zamówienie")]
		public void ThenSkladamZamowienie()
		{
			userManagementPO.submitYourOrder();
		}

		[Then(@"podaje danę do karty")]
		public void ThenPodajeDaneDoKarty()
		{
			userManagementPO.addCardData();
		}

		[Then(@"wybieram opcję Zapłać")]
		public void ThenWybieramOpcjeZaplac()
		{
			userManagementPO.payByCard();
		}

		[Then(@"Zamówienie zostanie pomyślnie złożone")]
		public void ThenZamowienieZostaniePomyslnieZlozone()
		{
			userManagementPO.FindFinishSummaryText();
		}

	}
}
