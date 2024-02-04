using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumGameShopQA.Selenium
{
    public class Utils
    {
        static IWebDriver driver = null;

        /// <summary>
        /// Uruchamia przeglądarkę zgodną z ustawionym w appsetingsach web driverem.
        /// Przechodzi na url podany w parametrach.
        /// </summary>
        /// <param name="url">Adres strony na którą nastąpi inicjalne przekierowanie</param>
        public static void GoToUrl(string url)
        {
            if (driver != null) CloseWindow();
            driver = DriverFactory.GetDriver();
            // Ustawiam czas oczekiwania (10 sekund) w przypadku, gdy dany element strony nie jest bezpośrednio prezentowany.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            //driver.Manage().Cookies.DeleteAllCookies();
            driver.Url = url;
            
        }

        /// <summary>
        /// Klika w przycisk o danym lokatorze. 
        /// Podejmując próbę co 0.25 sekundy do maksymalnej wartości podanej w drugim parametrze.
        /// </summary>
        /// <param name="xpath">Lokator przycisku</param>
        /// <param name="timeSpan">Maksymalny czas oczekiwania na przycisk</param>
        /// <param name="message">Opcjonalnie:Treść błędu przy niepowodzeniu</param>
        /// <exception cref="Exception"></exception>
        public static void ClickButton(string xpath, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath))).Click();
            }
            catch
            {
                throw new Exception($"Not found element for xpath: {xpath}. {message}");
            }
        }

        /// <summary>
        /// Klika w link wyszukując go po prezentowanym tekście, np. &lt;a href="..."&gt;tekst_do_wyszukania&lt;/a&gt;.
        /// </summary>
        /// <param name="linkText"></param>
        /// <param name="timeSpan"></param>
        /// <param name="message"></param>
        public static void ClickButtonByLinkText(string linkText, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(linkText))).Click();
            }
            catch
            {
                throw new Exception($"Not found element for link text: {linkText}. {message}");
            }
        }
        /// <summary>
        /// Klika w link wyszukując go po części prezentowanego tekście
        /// </summary>
        /// <param name="partiallinkText"></param>
        /// <param name="timeSpan"></param>
        /// <param name="message"></param>
        /// <exception cref="Exception"></exception>
        public static void ClickButtonByPartialLinkText(string partiallinkText, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(partiallinkText))).Click();
            }
            catch
            {
                throw new Exception($"Not found element for link text: {partiallinkText}. {message}");
            }
        }        

        /// <summary>
        /// Wpisuje daną frazę w element o podanym lokatorze. Oczekując maksymalnie na element, określony czas w drugim parametrze.
        /// </summary>
        /// <param name="xpath">Lokator elementu</param>
        /// <param name="timeSpan">Maksymalny czas oczekiwania na element</param>
        /// <param name="keys">Fraza, która ma zostać wpisana</param>
        /// <param name="message">Opcjonalnie:Treść błędu przy niepowodzeniu</param>
        /// <exception cref="Exception"></exception>
        public static void SendKeysByXPath(string xpath, TimeSpan timeSpan, string keys, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath))).SendKeys(keys);
            }
            catch
            {
                throw new Exception($"Not found element for xpath: {xpath}. {message}");
            }
        }
        /// <summary>
        /// Wpisuje daną frazę w element o podanym lokatorze (id). Oczekując maksymalnie na element, określony czas w drugim parametrze
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timeSpan"></param>
        /// <param name="keys"></param>
        /// <param name="message"></param>
        /// <exception cref="Exception"></exception>
        public static void SendKeysById(string id, TimeSpan timeSpan, string keys, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(id))).SendKeys(keys);
            }
            catch
            {
                throw new Exception($"Not found element for xpath: {id}. {message}");
            }
        }
        /// <summary>
        /// Wpisuje daną frazę w element o podanym lokatorze (id). Oczekując maksymalnie na element, określony czas w drugim parametrze jak element nie zostaje znaleziony przechodzi do następnego
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timeSpan"></param>
        /// <param name="keys"></param>
        /// <param name="message"></param>
        /// <exception cref="Exception"></exception>
        public static void SendKeysByIdNext(string id, TimeSpan timeSpan, string keys, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
                if (element.Enabled && element.Displayed)
                {
                    element.SendKeys(keys);
                }
                else
                {
                    Console.WriteLine($"Element with id: {id} is not interactable.");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine($"Element with id: {id} not found. {message}");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"Element with id: {id} not found within the given time. {message}");
            }
        }


        /// <summary>
        /// Sprawdza czy na aktualnej stronie znajduje się element o danym lokatorze.
        /// </summary>
        /// <param name="xpath">Lokator obiektu</param>
        /// <param name="timeSpan">Maksymalny czas oczekiwania na obiekt</param>
        /// <param name="message">Opcjonalnie:Treść błędu przy niepowodzeniu</param>
        /// <exception cref="Exception"></exception>
        public static bool FindVisibleElement(string xpath, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                return true;
            }
            catch
            {
                throw new Exception($"Not found element for xpath: {xpath}. {message}");
            }
        }


        /// <summary>
        /// Sprawdza czy na aktualnej stronie znajduje się element o danym lokatorze. Jeżeli się nie znajduje funkcja przechodzi dalej 
        /// </summary>
        /// <param name="xpath">Lokator obiektu</param>
        /// <param name="timeSpan">Maksymalny czas oczekiwania na obiekt</param>
        /// <param name="message">Opcjonalnie:Treść błędu przy niepowodzeniu</param>
        /// <exception cref="Exception"></exception>

        public static bool IsElementPresent(string xpath, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                return true;
            }
            catch
            {
                if (!string.IsNullOrEmpty(message))
                {
                    Console.WriteLine($"Not found element for xpath: {xpath}. {message}");
                }
                return false;
            }
        }

        /// <summary>
        /// Zwraca tekst elementu zapisany jako wartość atrybutu, np. &lt;element name="tekst" /&gt;
        /// </summary>
        /// <param name="xpath">Lokator obiektu</param>
        /// <param name="timeSpan">Maksymalny czas oczekiwania na obiekt</param>
        /// <param name="message">Opcjonalnie:Treść błędu przy niepowodzeniu</param>
        /// <returns></returns>
        public static string GetAttributeValueFromElement(string xpath, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                if (element != null)
                {
                    return element.GetAttribute("Value");
                }
            }
            catch
            {
                throw new Exception($"Not found element for xpath: {xpath}. {message}");
            }

            return null;
        }

        /// <summary>
        /// Zwraca tekst elementu zapisany pomiędzy znacznikami początku i końca, np. &lt;element&gt;tekst&lt;/element&gt;
        /// </summary>
        /// <param name="xpath">Lokator obiektu</param>
        /// <param name="timeSpan">Maksymalny czas oczekiwania na obiekt</param>
        /// <param name="message">Opcjonalnie:Treść błędu przy niepowodzeniu</param>
        /// <returns></returns>
        public static string GetTextFromVisibleElement(string xpath, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                if (element != null)
                {
                    return element.Text;
                }
            }
            catch
            {
                throw new Exception($"Not found element for xpath: {xpath}. {message}");
            }

            return null;
        }

        /// <summary>
        /// Czyści wartość elementu (np. textbox'a) o podanym lokatorze.
        /// </summary>
        /// <param name="xpath">Lokator obiektu</param>
        /// <param name="timeSpan">Maksymalny czas oczekiwania na obiekt</param>
        /// <param name="message">Opcjonalnie:Treść błędu przy niepowodzeniu</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string Clear(string xpath, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath))).Clear();
            }
            catch
            {
                throw new Exception($"Not found element for xpath: {xpath}. {message}");
            }

            return null;
        }

        /// <summary>
        /// Zamyka okno przeglądarki.
        /// </summary>
        public static void CloseWindow()
        {
            try
            {
                driver.Quit();
            }
            catch { }
        }

        /// <summary>
        /// Zwraca listę wartości elementów o nazwie tagName, dzieci elementu ze ścieżki xpath.
        /// Uwaga! Zwrócone zostają tylko wartości elementów widocznych na formatce (ograniczenie techniczne selenium).
        /// </summary>
        /// <param name="xpath">ścieżka do elementu przeszukiwanego</param>
        /// <param name="tagName">nazwa elementu szukanego</param>
        /// <param name="timeSpan"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static List<string> GetListOfValues(string xpath, string tagName, TimeSpan timeSpan, string message = null)
        {
            List<string> result = new List<string>();

            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                if (element != null)
                {
                    IReadOnlyList<IWebElement> list = element.FindElements(By.TagName(tagName));

                    foreach (IWebElement e in list)
                    {
                        result.Add(e.Text);
                    }
                }
            }
            catch
            {
                throw new Exception($"Not found element for xpath: {xpath}. {message}");
            }

            return result;
        }

        /// <summary>
        /// Czeka, az okno modalne zostanie zamkniete.
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="timeSpan"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool IsModalPopupClosed(string xpath, TimeSpan timeSpan, string message = null)
        {
            bool result = false;
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                result = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(xpath)));
            }
            catch
            {
                throw new Exception($"Not found element for xpath: {xpath}. {message}");
            }
            return result;
        }

        /// <summary>
        /// Odświeża bieżącą stronę.
        /// </summary>
        public static void ReloadSite()
        {
            driver.Navigate().Refresh();
        }

        /// <summary>
        /// Robi pauzę na określoną ilość sekund.
        /// </summary>
        /// <param name="seconds"></param>
        public static void Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        /// <summary>
        /// Zamienia tablicę na słownik.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        /// <summary>
        /// Metoda czyszcząca po testach.
        /// Zamyka przeglądarkę i ubija proces drivera.
        /// </summary>
        public static void CleanUp()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver = null;
            }
        }
    }
}