using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Resources;

namespace Cas31SeleniumTests.PageObjects
{
    class ResultPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public UInt64 NumberOfResults
        {
            get
            {
                UInt64 num = 0;
                try
                {
                    IWebElement searchResult = this.driver.FindElement(By.Id("result-stats"));
                    string numberofResults = Regex.Replace(searchResult.Text, "[^0-9]", "");
                    num = Convert.ToUInt64(numberofResults);
                }catch(Exception)
                {
                    
                }
                return num;
            }
        }
    }
}
