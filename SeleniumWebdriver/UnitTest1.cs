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
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        public void ActionOnBBC(IWebDriver driver)
        {
            driver.Url = "https://www.google.com.ua/";

            driver.FindElement(By.Name("q")).SendKeys("www.bbc.com" + Keys.Enter);
            Thread.Sleep(2000);

            var buttonBBC = driver.FindElement(By.CssSelector(".LC20lb.DKV0Md"));
            buttonBBC.Click();

            var buttonMaybeLater = driver.FindElement(By.ClassName("sign_in-exit"));
            buttonMaybeLater.Click();

            var search = driver.FindElement(By.Id("orb-search-q"));
            search.SendKeys("Travels" + Keys.Enter);

            var firstLink = driver.FindElement(By.CssSelector(".css-vh7bxp-PromoLink.e1f5wbog6"));
            firstLink.Click();

            driver.Quit();
        }

        [Ignore("Тест успішний")]
        [Test]
        [Obsolete]
        public void Browser_Chrome()
        {
            ActionOnBBC(BrowserFactory.Driver("Chrome"));
        }

        [Ignore("Не вводить текст у поле")]
        [Test]
        [Obsolete]
        public void Browser_IE()
        {
            //цей код необхідний для того щоб тест запустився в IE
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            var driver = new InternetExplorerDriver(options);

            driver.Url = "https://www.google.com.ua/";

            driver.FindElement(By.Name("q")).SendKeys("www.bbc.com" + Keys.Enter);
            Thread.Sleep(2000);

            var buttonBBC = driver.FindElement(By.CssSelector(".LC20lb.DKV0Md"));
            buttonBBC.Click();

            var buttonMaybeLater = driver.FindElement(By.ClassName("sign_in-exit"));
            buttonMaybeLater.Click();

            var search = driver.FindElement(By.Id("orb-search-q"));
            search.SendKeys("Travels" + Keys.Enter);

            var firstLink = driver.FindElement(By.CssSelector(".css-vh7bxp-PromoLink.e1f5wbog6"));
            firstLink.Click();

            driver.Quit();
        }

        [Ignore("Тест успішний")]
        [Test]
        [Obsolete]
        public void Browser_FireFox()
        {
            ActionOnBBC(BrowserFactory.Driver("FireFox"));
        }

        [Test]
        [Obsolete]
        public void Test4()
        {
            PageEelements pageEelements = new PageEelements(BrowserFactory.Driver("Chrome"));
            pageEelements.Navigate();
            pageEelements.Search("www.bbc.com");
        }
    }
}