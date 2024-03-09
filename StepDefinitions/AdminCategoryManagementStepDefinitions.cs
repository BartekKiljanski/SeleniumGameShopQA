using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using SeleniumGameShopQA.PageObjectLibrary;
using SeleniumGameShopQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SeleniumGameShopQA.StepDefinitions
{
    [Binding]
    public class AdminCategoryManagementStepDefinitions
    {

        public AdminManagementPO adminManagementPO = new AdminManagementPO();
        public AdminLoginPO adminLoginPO = new AdminLoginPO();

        [When(@"wybieram zakładkę Kategoria")]
        public void WhenWybieramZakladkeKategoria()
        {
            adminManagementPO.GoToContentManagement();
            adminManagementPO.GoToCategoryItem();

        }

        [When(@"wybieram opcję Utwórz nową kategorię")]
        public void WhenWybieramOpcjeUtworzNowaKategorie()
        {
            adminManagementPO.GoToCreateNewCategory();
        }

        [When(@"wypełniam formularz danymi")]
        public void WhenWypelniamFormularzDanymi()
        {
            adminManagementPO.CreateNameCategory();
            adminManagementPO.CreateDisplayOrderCategory();

        }

        [When(@"wybieram opcję Utwórz")]
        public void WhenWybieramOpcjeUtworz()
        {
            adminManagementPO.GoToCreateCategory();
        }

        [Then(@"nowa kategoria zostaje dodana do bazy danych")]
        public void ThenNowaKategoriaZostajeDodanaDoBazyDanych()
        {
            // Wywołanie metody, która szuka kategorii 'Romance' w bazie danych
            string categoryName = adminManagementPO.SearchCategoryInDatabase();

            // Asercja, że znaleziono rekord
            Assert.IsNotNull(categoryName, "Nie znaleziono kategorii 'Romance' w bazie danych.");

            // Asercja, że znaleziono konkretną kategorię 'Romance'
            Assert.AreEqual("Romance", categoryName, "Nazwa kategorii nie zgadza się z oczekiwaną.");
        }
    

        [When(@"wybieram istniejącą kategorię do edycji")]
        public void WhenWybieramIstniejacaKategorieDoEdycji()
        {
            adminManagementPO.GoToEditCategory();
        }

        [When(@"modyfikuję dane w formularzu")]
        public void WhenModyfikujeDaneWFormularzu()
        {
            adminManagementPO.EditNameCategory();
        }

        [When(@"wybieram opcję Edytuj")]
        public void WhenWybieramOpcjeEdytuj()
        {
            adminManagementPO.GoToCreateCategory();
        }

        [Then(@"zmodyfikowana kategoria zostaje zaktualizowana w bazie danych")]
        public void ThenZmodyfikowanaKategoriaZostajeZaktualizowanaWBazieDanych()
        {
            string categoryName = adminManagementPO.SearchEditCategoryInDatabase();

            // Asercja, że znaleziono rekord
            Assert.IsNotNull(categoryName, "Nie znaleziono kategorii 'Horror' w bazie danych.");

            // Asercja, że znaleziono konkretną kategorię 'Romance'
            Assert.AreEqual("Horror", categoryName, "Nazwa kategorii nie zgadza się z oczekiwaną.");
        }

        [When(@"wybieram istniejącą kategorię do usunięcia")]
        public void WhenWybieramIstniejacaKategorieDoUsuniecia()
        {
            adminManagementPO.GoToDeleteCategory();
        }

        [When(@"klikam przycisk Usuń")]
        public void WhenKlikamPrzyciskUsun()
        {
            adminManagementPO.GoToDeleteInCategory();
        }

    

        [Then(@"wybrana kategoria zostaje usunięta z bazy danych")]
        public void ThenWybranaKategoriaZostajeUsunietaZBazyDanych()
        {
            string categoryName = adminManagementPO.SearchEditCategoryInDatabase();

            // Asercja, że znaleziono rekord
            Assert.IsNull(categoryName, "Nie znaleziono kategorii 'Horror' w bazie danych.");
        }


    }
}
