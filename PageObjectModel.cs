using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cas31SeleniumTests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace Cas31SeleniumTests
{
    class PageObjectModel
    {
        private IWebDriver driver;
        
        [SetUp]
        public void SetUp()
        {
            this.driver = new FirefoxDriver();
            this.driver.Manage().Window.Maximize();
        }

       [Test]
        public void TestGoogleSearch()
        {
            HomePage naslovna = new HomePage(this.driver);
            ResultPage results;
            naslovna.GoToPage();
            results = naslovna.SearchFor("C# Selenium PageObject Model");

            Assert.Greater(results.NumberOfResults, 0);

        }

        [Test]
        public void PrivacyLinkCheck()
        {
            HomePage naslovna = new HomePage(this.driver);
            naslovna.GoToPage();
            naslovna.ClickOnPrivacy();
            System.Threading.Thread.Sleep(5000);
        }

        [TearDown]
        public void TearDown()
        {
            this.driver.Close();
        }
    }
}
