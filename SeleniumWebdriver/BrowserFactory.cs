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
            if (driver == null)
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
}
