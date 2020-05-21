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
            naslovna.GoToPage();
        }

        [TearDown]
        public void TearDown()
        {
            this.driver.Close();
        }
    }
}
