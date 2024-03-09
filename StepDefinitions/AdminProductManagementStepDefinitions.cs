using NUnit.Framework;
using SeleniumGameShopQA.PageObjectLibrary;
using SeleniumGameShopQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SeleniumGameShopQA.StepDefinitions
{
    [Binding]
    public class AdminProductManagementStepDefinitions
    {
        public AdminLoginPO adminLoginPO = new AdminLoginPO();
        public AdminManagementPO adminManagementPO = new AdminManagementPO();
        [Given(@"jestem zalogowany jako administrator")]
        public void GivenJestemZalogowanyJakoAdministrator()
        {
            adminLoginPO.FindLogoutButtonAfterLogging();
        }

        [When(@"wybieram zakładkę Produkty")]
        public void WhenWybieramZakladkeProdukty()
        {
            adminManagementPO.GoToContentManagement();
            adminManagementPO.GoToProductItem();
        }

        [When(@"wybieram opcję Utwórz nowy produkt")]
        public void WhenWybieramOpcjeUtworzNowyProdukt()
        {
            adminManagementPO.GoToCreateNewProduct();
        }

        [When(@"wypełniam formularz danymi produktu")]
        public void WhenWypelniamFormularzDanymiProduktu()
        {
            adminManagementPO.CreateNewProduct();
        }

        [When(@"wybieram opcję Utwórz produkt")]
        public void WhenWybieramOpcjeUtworzProdukt()
        {
            adminManagementPO.GoToCreateProduct();
        }


        [Then(@"nowy produkt zostaje dodany do bazy danych")]
        public void ThenNowyProduktZostajeDodanyDoBazyDanych()
        {


            string categoryName = adminManagementPO.SearchProductInDatabase();

            // Asercja, że znaleziono rekord
            Assert.IsNotNull(categoryName, "Nie znaleziono kategorii 'TitleTest' w bazie danych.");
        }

        [Then(@"widzę nowy produkt na liście produktów")]
        public void ThenWidzeNowyProduktNaLiscieProduktow()
        {
            adminManagementPO.FindButtonAfterCreateProduct();
        }

        [When(@"wybieram istniejący produkt do edycji")]
        public void WhenWybieramIstniejacyProduktDoEdycji()
        {
            adminManagementPO.GoToEditProduct();
        }

        [When(@"modyfikuję dane w formularzu produktu")]
        public void WhenModyfikujeDaneWFormularzuProduktu()
        {
            adminManagementPO.GoToEditTitleProduct();
        }

        [When(@"wybieram opcję Zapisz zmiany")]
        public void WhenWybieramOpcjeZapiszZmiany()
        {
            adminManagementPO.SaveEditProduct();
        }

        [Then(@"zmodyfikowany produkt zostaje zaktualizowany w bazie danych")]
        public void ThenZmodyfikowanyProduktZostajeZaktualizowanyWBazieDanych()
        {

            string categoryName = adminManagementPO.SearchEditProductInDatabase();

            // Asercja, że znaleziono rekord
            Assert.IsNotNull(categoryName, "Nie znaleziono kategorii 'TitleTestEdit' w bazie danych.");
        }

        [When(@"wybieram istniejący produkt do usunięcia")]
        public void WhenWybieramIstniejacyProduktDoUsuniecia()
        {
            adminManagementPO.GoToDeleteProduct();
        }


        [When(@"potwierdzam chęć usunięcia produktu")]
        public void WhenPotwierdzamChecUsunieciaProduktu()
        {
            adminManagementPO.GoToAlertDelete();
            Utils.Wait(2);
        }

        [Then(@"wybrany produkt zostaje usunięty z bazy danych")]
        public void ThenWybranyProduktZostajeUsunietyZBazyDanych()
        {
            Utils.Wait(2);
            string categoryName = adminManagementPO.SearchEditProductInDatabase();

            // Asercja, że znaleziono rekord
            Assert.IsNull(categoryName, "Nie znaleziono kategorii 'Horror' w bazie danych.");
        }
    }
}
