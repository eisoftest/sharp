using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace ConsoleSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new CHtests();
            bool ok = test.CHtestGoogle();
            Console.WriteLine("CHtestGoogle Replied : " + ok.ToString());

            Console.ReadLine();

        } // Main



    } // Program



    internal class CHtests
    {
        internal bool CHtestGoogle()
        {
            bool titleOk = false;

            using (var driver = new ChromeDriver())
            {
                string searchKey = "selenium";
                driver.Manage().Window.Maximize();
                driver.Url = "https://www.google.ro";

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("lst-ib")));
                obj.SendKeys(searchKey + Keys.Tab);
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.TextToBePresentInElementValue(By.Id("lst-ib"), searchKey));

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//input[@name='btnK']")));
                obj.Click();

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//h3/a")));
                string url = obj.GetAttribute("href");
                driver.Navigate().GoToUrl(url);

                // checking the page title
                string title = driver.Title;
                titleOk = title.Contains("Selenium");               

                driver.Quit();

            } // end using

            return titleOk;

        } // CHtestGmail


    } // Chtests



} // namespace
