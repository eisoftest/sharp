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

            //bool ok = test.CHtestGoogle();
            //Console.WriteLine("CHtestGoogle Replied : " + ok.ToString());

            //string sok = test.CHtestGmail();
            //Console.WriteLine("CHtestGmail Replied : " + sok);

            string sok = test.CHtestOlx();
            Console.WriteLine("CHtestOlx Replied : " + sok);

            Console.ReadLine();

        } // Main



    } // Program



    internal class CHtests
    {

        internal void NewDoingNothing()
        {
            // testing yet another local branch creating scenario
        } // just testing GitHub


        internal void DoingNothing()
        {

        } // just testing GitHub



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

        } // CHtestGoogle



        internal string CHtestGmail()
        {
            string address = "test@gmail.com";
            string pwd = "test";
            string subject = "ChromeMessage";
            string helloText = "Hello from Selenium!";

            bool ok = false;

            using (var driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Url = "https://mail.google.com/";

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("identifier")));
                obj.SendKeys(address);

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[text()='Next']")));
                obj.Click();

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("password")));
                obj.SendKeys(pwd);

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[text()='Next']")));
                obj.Click();

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//div[text()='COMPOSE']")));
                obj.Click();

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("to")));
                obj.SendKeys(address);

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("subjectbox")));
                obj.SendKeys(subject);

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//div[@role='textbox']")));
                obj.SendKeys(helloText);

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[text()='Send']")));
                obj.Click();

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                bool closed = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(".//*[text()='Send']")));

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[starts-with(@title,'Google Account')]")));
                obj.Click();

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Sign out")));
                obj.Click();

                // normally the page for login password is displayed
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                obj = wait.Until(ExpectedConditions.ElementExists(By.Name("password")));

                ok = true;

                driver.Quit();

            } // end using

            return ok.ToString();

        } // CHtestGmail



        internal string CHtestOlx()
        {
            string res = "Search error";
            string searchKey = "ipad";

            using (var driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                var jse = (IJavaScriptExecutor)driver;

                driver.Url = "https://www.olx.ro";

                // closing bottom bar for informing about 
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                var obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//a[starts-with(@class,'cookiesBarClose') and contains(@class,'cfff')]")));
                obj.Click();

                // looking for a link to a list of cities
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                obj = wait.Until(ExpectedConditions.ElementExists(By.XPath(".//a[@title='Harta judetelor']")));
                jse.ExecuteScript("arguments[0].scrollIntoView(true)", obj);
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//a[@title='Harta judetelor']")));
                obj.Click();

                // looking for the link of city Oradea
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                obj = wait.Until(ExpectedConditions.ElementExists(By.XPath(".//a[@title='Anunturi Oradea']")));
                jse.ExecuteScript("arguments[0].scrollIntoView(true)", obj);
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//a[@title='Anunturi Oradea']")));
                obj.Click();

                // looking for the Search autocomplete field
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("search-text")));
                obj.SendKeys(searchKey);
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.TextToBePresentInElementValue(By.Id("search-text"), searchKey));

                // submitting the search
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                obj = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("search-submit")));
                obj.Click();

                // waiting for the results page
                try
                {
                    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    obj = wait.Until(ExpectedConditions.ElementExists(By.XPath(".//div[starts-with(@class, 'dontHasPromoted')]")));
                    obj = driver.FindElement(By.XPath(".//*[starts-with(text(),'Am gasit')]"));
                    res = obj.Text;
                }
                catch
                {
                    obj = driver.FindElement(By.XPath(".//*[starts-with(text(),'Nu am gasit anunturi')]"));
                    res = obj.Text;
                }

                driver.Quit();

            } // end using

            return res;

        } // CHtestOlx



    } // Chtests



} // namespace
