using OpenQA.Selenium;
using SeleniumGameShopQA.Helpers;
using SeleniumGameShopQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumGameShopQA.PageObjectLibrary
{
    public class UserManagementPO
    {
        public AdminManagementPO adminManagementPO = new AdminManagementPO();
        public AdminLoginPO adminLoginPO = new AdminLoginPO();


        public string registerAccount = "//*[@id=\"register\"]";
        public string registerSubmit = "//*[@id=\"registerSubmit\"]";
        public string clickProduct = "//a[contains(@class, 'btn') and contains(text(), 'Szczegóły') and contains(@href, '/Customer/Home/Details?productId=')]\r\n";
        public string countNumber = "Count";
        public string cartSummary = "//a[@href='/Customer/Cart/Summary'][contains(text(), 'Podsumowanie')]\r\n";
        public string submitOrder = "//button[contains(text(), 'Złóż zamówienie')]\r\n";
        public string payEmail = "email";
        public string cardNumber = "cardNumber";
        public string dateCard = "cardExpiry";
        public string cvcCard = "cardCvc";
        public string holderNameCard = "billingName";
        public string finishSummary = "//*[contains(text(), 'Zamówienie zostało pomyślnie złożone!')]\r\n";
        public string paySummary = "//div[contains(@class, 'SubmitButton-IconContainer')]\r\n";


		public void addCardData()
		{
			Utils.ClearAndSendKeysById(payEmail, TimeSpan.FromSeconds(15), "user12@gmail.com", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
			Utils.Wait(1);
			Utils.ClearAndSendKeysById(cardNumber, TimeSpan.FromSeconds(15), "4242424242424242", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
			Utils.Wait(1);
			//Utils.ClearById(AuthorProduct, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
			Utils.ClearAndSendKeysById(dateCard, TimeSpan.FromSeconds(15), "1224", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
			Utils.Wait(1);
			// Utils.ClearById(listPriceProduct, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
			Utils.ClearAndSendKeysById(cvcCard, TimeSpan.FromSeconds(15), "1233", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
			Utils.Wait(1);
			// Utils.ClearById(priceProduct, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
			Utils.ClearAndSendKeysById(holderNameCard, TimeSpan.FromSeconds(15), "Jan Kowalski", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
			Utils.Wait(1);
		
		}



		public void createNewAccount()
        {
            Utils.ClickButton(registerAccount, TimeSpan.FromSeconds(15));
        }
		public void FindFinishSummaryText()
		{
			Utils.FindVisibleElement(finishSummary, TimeSpan.FromSeconds(15), "Błąd - Zamówienie zostało pomyślnie złożone!");
		}
		public void CreateNewAccountRegister()
        {
            Utils.ClearAndSendKeysById(adminManagementPO.emailAccount, TimeSpan.FromSeconds(15), "user12@gmail.com", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");

            Utils.ClearAndSendKeysById(adminManagementPO.nameAccount, TimeSpan.FromSeconds(15), "Jan Kowalski", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
            //Utils.ClearById(AuthorProduct, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
            Utils.ClearAndSendKeysById(adminManagementPO.passwordAccount, TimeSpan.FromSeconds(15), "Tester.240397", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
            // Utils.ClearById(listPriceProduct, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
            Utils.ClearAndSendKeysById(adminManagementPO.confirmPasswordAccount, TimeSpan.FromSeconds(15), "Tester.240397", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
            // Utils.ClearById(priceProduct, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
            Utils.ClearAndSendKeysById(adminManagementPO.phoneNumberAccount, TimeSpan.FromSeconds(15), "222222222", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
            // Utils.ClearById(priceProduct50, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
            Utils.ClearAndSendKeysById(adminManagementPO.streetAccount, TimeSpan.FromSeconds(15), "Ulica", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
            // Utils.ClearById(priceProduct100, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
            Utils.ClearAndSendKeysById(adminManagementPO.cityAccount, TimeSpan.FromSeconds(15), "Miasto", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
            Utils.ClearAndSendKeysById(adminManagementPO.stateAccount, TimeSpan.FromSeconds(15), "Wojewodztwo", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
            Utils.ClearAndSendKeysById(adminManagementPO.postalCodeAccount, TimeSpan.FromSeconds(15), "123123", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");

            Utils.Wait(2);
        }


        public void acceptNewAccount()
        {
            Utils.ScrollToElementAndClick(By.XPath(registerSubmit), TimeSpan.FromSeconds(10));
        }

        public void EnterUserEmail()
        {
           
            //  Utils.Wait(10);
            Utils.SendKeysById(adminLoginPO.email, TimeSpan.FromSeconds(15), "user12@gmail.com", "Błąd email - nie udało się wprowadzić emaila");
        }

        public void EnterUserPassword()
        {
           
            //  Utils.Wait(10);
            Utils.SendKeysById(adminLoginPO.password, TimeSpan.FromSeconds(15), "Tester.240397", "Błąd hasło - nie udało się wprowadzić hasła");
        }


        public void SendCountNumber()
        {

            //  Utils.Wait(10);
            Utils.ClearAndSendKeysById(countNumber, TimeSpan.FromSeconds(15), "2", "Błąd hasło - nie udało się wprowadzić hasła");
        }
        public void AddToCart()
        {
            Utils.ScrollToElementAndClick(By.XPath("//button[contains(text(), 'Dodaj do koszyka')]\r\n"), TimeSpan.FromSeconds(10));
        }

        public void ClickBasket()
        {
            Utils.ScrollToElementAndClick(By.XPath("//a[contains(@class, 'nav-link') and @href='/Customer/Cart']\r\n"), TimeSpan.FromSeconds(10));
        }
        public void clickSummary()
        {
            Utils.ScrollToElementAndClick(By.XPath(cartSummary), TimeSpan.FromSeconds(10));
        }

        public void submitYourOrder()
        {
            Utils.ScrollToElementAndClick(By.XPath(submitOrder), TimeSpan.FromSeconds(10));
        }

		public void payByCard()
		{
			Utils.ScrollToElementAndClick(By.XPath(paySummary), TimeSpan.FromSeconds(10));
		}

		public void GoToProduct()
		{
			Utils.ScrollToElementAndClick(By.XPath(clickProduct), TimeSpan.FromSeconds(10));
		}
		
	}
}
