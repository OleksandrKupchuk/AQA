using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using Selenium.Community.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using NUnit.Framework;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace SeleniumWebdriver
{
    class PageEelements
    {
        private IWebDriver driver;
        private string url = "https://www.google.com.ua/";
        private WebDriverWait wait;

        public PageEelements(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement ElementSearchText { get; set; }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        public void Search(string textToType)
        {
            ElementSearchText.Clear();
            ElementSearchText.SendKeys(textToType + Keys.Enter);
        }
    }
}
