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
    public class AdminManagementPO
    { 
        private ConfigurationHelper config;
        public string logIn = "//*[@id=\"login\"]";
        public string logInSubmit = "//*[@id=\"login-submit\"]";
        public string email = "Input_Email";
        public string password = "Input_Password";
        public string logOut = "//*[@id=\"logout\"]";
        public string contentManagement = "//a[contains(text(), 'ZARZĄDZANIE TREŚCIĄ')]";
        public string categoryItem = "//a[@class='dropdown-item' and text()='Kategoria']";
       
        public string createNewCategory = "//a[@class='btn btn-primary']";
        public string nameCategory = "Name";
        public string displayOrderCategory = "DisplayOrder";
        public string create= "//button[@class='btn btn-primary form-control']";
        public string createProduct= "//button[text()='Utwórz']\r\n";

        public string editCategory = "(//div[@class='w-75 btn-group'][@role='group'])[3]/a[contains(@href, 'Edit')]\r\n";
        public string editProduct= "(//div[@class='w-75 btn-group'][@role='group'])[8]/a[contains(@href, 'Edit')]\r\n";
        public string editCompany= "//tr[td[contains(text(),'FirmaTest')]]//a[contains(@href, '/admin/company/upsert')]\r\n";
        public string deleteCategory = "(//a[contains(@href, 'Delete')])[3]\r\n";
        public string deleteInsideCategory = "//button[@type='submit' and contains(@class, 'btn-danger') and contains(text(), 'Usuń')]\r\n";
        public string romance = "Romance";
        public string editRomance = "Horror";
        //product 
        public string produktItem = "//a[@class='dropdown-item' and text()='Produkt']";
        public string titleProduct = "Product_Title";
        public string descriptionProduct = "Product_Description_ifr";
        public string ISBNProduct = "Product_ISBN";
        public string AuthorProduct = "Product_Author";
        public string listPriceProduct = "Product_ListPrice";
        public string priceProduct = "Product_Price";
        public string priceProduct50 = "Product_Price50";
        public string priceProduct100 = "Product_Price100";
        public string categoryProduct = "//select[@id='Product_CategoryId']/option[@value='1']";
        public string deleteButtonXPath = "(//a[contains(@class, 'btn-danger') and contains(@onclick, 'delete')])[8]";

        public string sweetAlertDelete = "//button[contains(@class, 'swal2-confirm') and normalize-space(text())='Tak, usuń to!']\r\n";
        public string sweetAlertDeleteCompany = "//button[contains(@class, 'swal2-confirm') and normalize-space(text())='Tak, usun to!']\r\n";

        //firma 
        public string companyItem = "//a[@class='dropdown-item' and text()='Firma']";
        public string createNewCompany = "//a[@class='btn btn-primary']";
        public string nameCompany = "Name";
        public string phoneCompany = "PhoneNumber";
        public string streetCompany = "StreetAddress";
        public string CityCompany = "City";
        public string StateCompany = "State";
        public string PostalCodeCompany = "PostalCode";
        public string createCompany = "//button[text()='Utwórz']\r\n";
        public string deleteCompany = "//tr[td[contains(text(),'FirmaEdit')]]//a[contains(@onclick, 'Delete')]\r\n";
        // create account 
        public string createAccountItem = "//a[@class='dropdown-item' and text()='Utwórz Użytkownika']";
        public string emailAccount = "Input_Email";
        public string nameAccount = "Input_Name";
        public string passwordAccount = "Input_Password";
        public string confirmPasswordAccount = "Input_ConfirmPassword";
        public string phoneNumberAccount = "Input_PhoneNumber";
        public string streetAccount = "Input_StreetAddress";
        public string cityAccount = "Input_City";
        public string stateAccount = "Input_State";
        public string postalCodeAccount = "Input_PostalCode";
        public string roleAccount = "//select[@id='Input_Role']/option[@value='Employee']\r\n";
        public string registerAccount = "registerSubmit";

        ///logowanie na account
        // public string logOut = 'logout';

        public void EnterAccountEmail()
        {
            var config = ConfigurationHelper.GetApplicationConfiguration();
            //  Utils.Wait(10);
            Utils.SendKeysById(email, TimeSpan.FromSeconds(15), "adres12@gmail.com", "Błąd email - nie udało się wprowadzić emaila");
        }

        public void EnterAccountPassword()
        {
            var config = ConfigurationHelper.GetApplicationConfiguration();
            //  Utils.Wait(10);
            Utils.SendKeysById(password, TimeSpan.FromSeconds(15), "Tester.240397", "Błąd hasło - nie udało się wprowadzić hasła");
        }
        public void logOutAccount()
        {
            Utils.ClickButton(logOut,TimeSpan.FromSeconds(15));
        }


        public void GoToAccountItem()
        {
            Utils.ClickButton(createAccountItem, TimeSpan.FromSeconds(5));
        }

        public void CreateNewAccount()
        {
            Utils.ClearAndSendKeysById(emailAccount, TimeSpan.FromSeconds(15), "adres12@gmail.com", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.ClearAndSendKeysById(nameAccount, TimeSpan.FromSeconds(15), "testtest", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.ClearAndSendKeysById(passwordAccount, TimeSpan.FromSeconds(15), "Tester.240397", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.ClearAndSendKeysById(confirmPasswordAccount, TimeSpan.FromSeconds(15), "Tester.240397", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.ClearAndSendKeysById(phoneNumberAccount, TimeSpan.FromSeconds(15), "113321123", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.ClearAndSendKeysById(streetAccount, TimeSpan.FromSeconds(15), "streettest", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.ClearAndSendKeysById(cityAccount, TimeSpan.FromSeconds(15), "citytest", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.ClearAndSendKeysById(stateAccount, TimeSpan.FromSeconds(15), "pomorskietest", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.ClearAndSendKeysById(postalCodeAccount, TimeSpan.FromSeconds(15), "123321", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.ClickButton(roleAccount, TimeSpan.FromSeconds(5));
        }
      
        public void GoToRegisterAccountt()
        {
            Utils.ScrollToElementAndClick(By.XPath("//*[@id=\"registerSubmit\"]"), TimeSpan.FromSeconds(10));

        }
        public void GoToContentManagement()
        {
            Utils.ClickButton(contentManagement, TimeSpan.FromSeconds(5));

        }

        public void GoToCategoryItem()
        {
            Utils.ClickButton(categoryItem, TimeSpan.FromSeconds(5));
        }

        public void GoToCreateNewCategory()
        {
            Utils.ClickButton(createNewCategory, TimeSpan.FromSeconds(5));
        }
        public void CreateNameCategory()
        {
            Utils.SendKeysById(nameCategory, TimeSpan.FromSeconds(15), romance, "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
          
        }
        public void CreateDisplayOrderCategory()
        {
            Utils.SendKeysById(displayOrderCategory, TimeSpan.FromSeconds(15), "3" , "Błąd nazwy kategorii - nie udało się wprowadzić kategorii") ;

        }
        public void GoToCreateCategory()
        {
            Utils.ClickButton(create, TimeSpan.FromSeconds(5));
        }

        public void GoToEditCategory()
        {
        
            Utils.FindVisibleElement(editCategory, TimeSpan.FromSeconds(15), "Błąd - brak przycisku WYLOGUJ");
            Utils.ClickButton(editCategory, TimeSpan.FromSeconds(15));
        }

        public void EditNameCategory()
        {
            Utils.ClearById(nameCategory, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
            Utils.SendKeysById(nameCategory, TimeSpan.FromSeconds(15), editRomance, "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");

        }
        public void GoToDeleteCategory()
        {

            
            Utils.ClickButton(deleteCategory, TimeSpan.FromSeconds(15));
        }

        public void GoToDeleteInCategory()
        {


            Utils.ClickButton(deleteInsideCategory, TimeSpan.FromSeconds(15));
        }

        //product 
        public void GoToProductItem()
        {
            Utils.ClickButton(produktItem, TimeSpan.FromSeconds(5));
        }

        public void GoToCreateNewProduct()
        {
            Utils.ClickButton(createNewCategory, TimeSpan.FromSeconds(5));
        }
     //   EnterTextIntoTinyMCE(string frameId, string text, TimeSpan timeSpan)
        public void CreateNewProduct()
        {
            Utils.ClearAndSendKeysById(titleProduct, TimeSpan.FromSeconds(15), "TitleTest", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.EnterTextIntoTinyMCE(descriptionProduct,"DescriptionTest", TimeSpan.FromSeconds(15));
           // Utils.ClearAndSendKeysById(ISBNProduct, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
           Utils.SendKeysById(ISBNProduct, TimeSpan.FromSeconds(15), "C1", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
            //Utils.ClearById(AuthorProduct, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
            Utils.ClearAndSendKeysById(AuthorProduct, TimeSpan.FromSeconds(15), "AuthorTest", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
           // Utils.ClearById(listPriceProduct, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
            Utils.ClearAndSendKeysById(listPriceProduct, TimeSpan.FromSeconds(15), "10", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
           // Utils.ClearById(priceProduct, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
            Utils.ClearAndSendKeysById(priceProduct, TimeSpan.FromSeconds(15), "11", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
           // Utils.ClearById(priceProduct50, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
            Utils.ClearAndSendKeysById(priceProduct50, TimeSpan.FromSeconds(15), "11", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
           // Utils.ClearById(priceProduct100, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
            Utils.ClearAndSendKeysById(priceProduct100, TimeSpan.FromSeconds(15), "12", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");

            Utils.Wait(2);
            Utils.ClickButton(categoryProduct, TimeSpan.FromSeconds(5));
            Utils.Wait(2);
        }
        public void GoToCreateProduct()
        {
            Utils.ScrollToElementAndClick(By.XPath("//button[text()='Utwórz']"), TimeSpan.FromSeconds(10));

        }
        public void GoToEditProduct()
        {
            Utils.ScrollToElementAndClick(By.XPath("(//tr[contains(@class,'even') or contains(@class,'odd')]/td/div[@class='w-75 btn-group'][@role='group']/a[contains(@class, 'btn-primary') and contains(@href, 'upsert')])[8]"), TimeSpan.FromSeconds(10));
        }
        public void GoToEditTitleProduct()
        {
            Utils.ClearAndSendKeysById(titleProduct, TimeSpan.FromSeconds(15), "TitleTestEdit", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
        }
        public void SaveEditProduct()
        {
            Utils.ScrollToElementAndClick(By.XPath(create), TimeSpan.FromSeconds(5));
        }

        public void GoToDeleteProduct()
        {
            Utils.ScrollToElementAndClick(By.XPath(deleteButtonXPath), TimeSpan.FromSeconds(10));
        }
        public void GoToAlertDelete()
        {
            Utils.Wait(2);
            Utils.ClickButton(sweetAlertDelete, TimeSpan.FromSeconds(5));
        }
        public void GoToAlertCompanyDelete()
        {
            Utils.Wait(2);
            Utils.ClickButton(sweetAlertDeleteCompany, TimeSpan.FromSeconds(5));
        }
        public void FindButtonAfterCreateProduct()
        {
            Utils.FindVisibleElement(createNewCategory, TimeSpan.FromSeconds(15), "Błąd - brak przycisku WYLOGUJ");
        }
        // firma 


        public void GoToCompanyItem()
        {
            Utils.ClickButton(companyItem, TimeSpan.FromSeconds(5));
        }

        public void GoToCreateNewCompany()
        {
            Utils.ClickButton(createNewCompany, TimeSpan.FromSeconds(5));
        }
        
        public void CreateNewCompany()
        {
            Utils.ClearAndSendKeysById(nameCompany, TimeSpan.FromSeconds(15), "FirmaTest", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
            // Utils.ClearById(listPriceProduct, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
            Utils.ClearAndSendKeysById(phoneCompany, TimeSpan.FromSeconds(15), "123123123", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
            // Utils.ClearById(priceProduct, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
            Utils.ClearAndSendKeysById(streetCompany, TimeSpan.FromSeconds(15), "StretTest", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
            // Utils.ClearById(priceProduct50, TimeSpan.FromSeconds(15), "Nie udało się wyczyścić pola");
            Utils.ClearAndSendKeysById(CityCompany, TimeSpan.FromSeconds(15), "CityTest", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
            Utils.ClearAndSendKeysById(StateCompany, TimeSpan.FromSeconds(15), "WojewodztwoTest", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
            Utils.ClearAndSendKeysById(PostalCodeCompany, TimeSpan.FromSeconds(15), "123123", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);
        }

        public void GoToCreateCompany()
        {
            Utils.ScrollToElementAndClick(By.XPath("//button[text()='Utwórz']"), TimeSpan.FromSeconds(10));

        }
        public void GoToEditCompany()
        {
            Utils.ClickButton(editCompany, TimeSpan.FromSeconds(10));
        }
        public void EditCompany()
        {
            Utils.ClearAndSendKeysById(nameCompany, TimeSpan.FromSeconds(15), "FirmaEdit", "Błąd nazwy kategorii - nie udało się wprowadzić kategorii");
            Utils.Wait(1);

        }

        public void GoToDeleteCompany()
        {
            Utils.ClickButton(deleteCompany, TimeSpan.FromSeconds(10));
        }
        public string SearchCategoryInDatabase()
        {
            string query = @"
        SELECT TOP(1) name
        FROM [ShopBook].[dbo].[Categories]
        WHERE name = 'Romance' order by ID desc";

            SqlHelper sqlHelper = new SqlHelper();

            string categoryName = sqlHelper.sqlSelect<string>(query, null);
            return categoryName;

        }

        public string SearchProductInDatabase()
        {
            string query = @"
        SELECT TOP(1) Title
        FROM [ShopBook].[dbo].[Products]
        WHERE Title = 'TitleTest' order by ID desc";

            SqlHelper sqlHelper = new SqlHelper();

            string categoryName = sqlHelper.sqlSelect<string>(query, null);
            return categoryName;

        }

        public string SearchCompanyInDatabase()
        {
            string query = @"
        SELECT TOP(1) Name
        FROM [ShopBook].[dbo].[Companies]
        WHERE Name = 'FirmaTest' order by ID desc";

            SqlHelper sqlHelper = new SqlHelper();

            string categoryName = sqlHelper.sqlSelect<string>(query, null);
            return categoryName;

        }
        public string SearchEditCategoryInDatabase()
        {
            string query = @"
        SELECT TOP(1) name
        FROM [ShopBook].[dbo].[Categories]
        WHERE name = 'Horror' order by ID desc";

            SqlHelper sqlHelper = new SqlHelper();

            string categoryName = sqlHelper.sqlSelect<string>(query, null);
            return categoryName;

        }
        public string SearchEditProductInDatabase()
        {
            string query = @"
        SELECT TOP(1) Title
        FROM [ShopBook].[dbo].[Products]
        WHERE Title = 'TitleTestEdit' order by ID desc";

            SqlHelper sqlHelper = new SqlHelper();

            string categoryName = sqlHelper.sqlSelect<string>(query, null);
            return categoryName;

        }

        public string SearchEditCompanyInDatabase()
        {
            string query = @"
        SELECT TOP(1) Name
        FROM [ShopBook].[dbo].[Companies]
        WHERE Name = 'FirmaEdit' order by ID desc";

            SqlHelper sqlHelper = new SqlHelper();

            string categoryName = sqlHelper.sqlSelect<string>(query, null);
            return categoryName;

        }

        public string SearchInDatabase(string tableName, string columnName, string value, string orderByColumn)
        {
            string query = $@"
SELECT TOP(1) {columnName}
FROM [ShopBook].[dbo].[{tableName}]
WHERE {columnName} = @value ORDER BY {orderByColumn} DESC";

            // Utworzenie obiektu z parametrami
            var parameters = new { value = value };

            SqlHelper sqlHelper = new SqlHelper();

            // Przekazanie obiektu parameters zamiast null
            string result = sqlHelper.sqlSelect<string>(query, parameters);
            return result;
        }

        public void DeleteFromDatabase(string tableName, string columnName, string emailValue)
        {
            string query = $@"
DELETE FROM [ShopBook].[dbo].[{tableName}]
WHERE {columnName} = @value";

            // Utworzenie obiektu z parametrami
            var parameters = new { value = emailValue };

            SqlHelper sqlHelper = new SqlHelper();

            // Wykonanie zapytania DELETE
            sqlHelper.executeSqlString(query, parameters);
        }



    }
}
