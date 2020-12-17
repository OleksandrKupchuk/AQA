using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;


namespace SeleniumWebdriver
{
    public class BrowserFactory
    {
        private static IWebDriver driver;

        public static IWebDriver Driver(string browserName)
        {
            if(driver == null)
            {
                switch (browserName)
                {
                    case "Chrome":
                        driver = new ChromeDriver();
                        return driver;

                    case "FireFox":
                        driver = new FirefoxDriver();
                        return driver;

                    case "IE":
                        driver = new InternetExplorerDriver();
                        return driver;
                }
            }

            return null;
        }
    }

    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        public void ActionOnBBC(IWebDriver browser)
        {
            browser.Url = "https://www.google.com.ua/";

            browser.FindElement(By.Name("q")).SendKeys("www.bbc.com" + Keys.Enter);
            Thread.Sleep(2000);

            var buttonBBC = browser.FindElement(By.CssSelector(".LC20lb.DKV0Md"));
            buttonBBC.Click();

            var buttonMaybeLater = browser.FindElement(By.ClassName("sign_in-exit"));
            buttonMaybeLater.Click();

            var search = browser.FindElement(By.Id("orb-search-q"));
            search.SendKeys("Travels" + Keys.Enter);

            var firstLink = browser.FindElement(By.CssSelector(".css-vh7bxp-PromoLink.e1f5wbog6"));
            firstLink.Click();

            browser.Quit();
        }

        [Ignore("Тест успішний")]
        [Test]
        [Obsolete]
        public void Browser_Chrome()
        {
            ActionOnBBC(BrowserFactory.Driver("Chrome"));
        }

        //[Ignore("Не вводить текст у поле")]
        [Test]
        [Obsolete]
        public void Browser_IE()
        {
            ActionOnBBC(BrowserFactory.Driver("IE"));
        }

        [Ignore("Тест успішний")]
        [Test]
        [Obsolete]
        public void Browser_FireFox()
        {
            ActionOnBBC(BrowserFactory.Driver("FireFox"));
        }
    }
}