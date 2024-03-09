using NUnit.Framework;
using SeleniumGameShopQA.PageObjectLibrary;
using System;
using TechTalk.SpecFlow;

namespace SeleniumGameShopQA.StepDefinitions
{
    [Binding]
    public class AdminCompanyManagementStepDefinitions
	{
        public AdminManagementPO adminManagementPO = new AdminManagementPO();
        public AdminLoginPO adminLoginPO = new AdminLoginPO();
        [When(@"wybieram zakładkę Firmy")]
		public void WhenWybieramZakladkeFirmy()
		{
            adminManagementPO.GoToContentManagement();
            adminManagementPO.GoToCompanyItem();

        }

		[When(@"wybieram opcję Utwórz nową firmę")]
		public void WhenWybieramOpcjeUtworzNowaFirme()
		{
			adminManagementPO.GoToCreateNewCompany();

        }

		[When(@"wypełniam formularz danymi firmy")]
		public void WhenWypelniamFormularzDanymiFirmy()
		{
			adminManagementPO.CreateNewCompany();

        }
        [When(@"wybieram opcję Utwórz firmę")]
        public void WhenWybieramOpcjeUtworzFirme()
        {
			adminManagementPO.GoToCreateCompany();
        }

        [Then(@"nowa firma zostaje dodana do bazy danych")]
        public void ThenNowaFirmaZostajeDodanaDoBazyDanych()
        {

			string categoryName = adminManagementPO.SearchInDatabase("Companies", "Name", "FirmaTest", "ID");

            // Asercja, że znaleziono rekord
            Assert.IsNotNull(categoryName, "Nie znaleziono kategorii 'FirmaTest' w bazie danych.");
        }



		[When(@"wybieram istniejącą firmę do edycji")]
		public void WhenWybieramIstniejacaFirmeDoEdycji()
		{
			adminManagementPO.GoToEditCompany();

        }

		[When(@"modyfikuję dane w formularzu firmy")]
		public void WhenModyfikujeDaneWFormularzuFirmy()
		{
			adminManagementPO.EditCompany();

        }

		[Then(@"zmodyfikowana firma zostaje zaktualizowana w bazie danych")]
		public void ThenZmodyfikowanaFirmaZostajeZaktualizowanaWBazieDanych()
		{
            string editCompanyName = adminManagementPO.SearchInDatabase("Companies", "Name", "FirmaEdit", "ID");

            // Asercja, że znaleziono rekord
            Assert.IsNotNull(editCompanyName, "Nie znaleziono kategorii 'FirmaEdit' w bazie danych.");
        }

		[When(@"wybieram istniejącą firmę do usunięcia")]
		public void WhenWybieramIstniejacaFirmeDoUsuniecia()
		{
			adminManagementPO.GoToDeleteCompany();

        }

		[When(@"potwierdzam chęć usunięcia firmy")]
		public void WhenPotwierdzamChecUsunieciaFirmy()
		{
			adminManagementPO.GoToAlertCompanyDelete();

        }

		[Then(@"wybrana firma zostaje usunięta z bazy danych")]
		public void ThenWybranaFirmaZostajeUsunietaZBazyDanych()
		{
            string editCompanyName = adminManagementPO.SearchInDatabase("Companies", "Name", "FirmaEdit", "ID");

            // Asercja, że znaleziono rekord
            Assert.IsNull(editCompanyName, "Znaleziono kategorii 'FirmaEdit' w bazie danych.");
        }

	}
}
