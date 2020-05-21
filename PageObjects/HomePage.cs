using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Cas31SeleniumTests.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void GoToPage()
        {
            this.driver.Navigate().GoToUrl("https://www.google.com/");
        }

        public IWebElement SearchInput
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.Name("q"));
                }catch(Exception)
                {
                    element = null;
                }
                return element;
            }
        }

        public ResultPage SearchFor(string search)
        {
            this.SearchInput?.SendKeys(search);
            this.SearchInput?.Submit();
            wait.Until(EC.ElementIsVisible(By.Id("result-stats")));
            return new ResultPage(this.driver);
        }

        public IWebElement PrivacyLink
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.XPath("//div[@class='fbar']/span[@id='fsr']/a[@class='Fx4vi'][1]"));
                }catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }
        public void ClickOnPrivacy()
        {
            this.PrivacyLink?.Click();
        }
    }
}
