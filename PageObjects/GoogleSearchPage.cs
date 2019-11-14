using BoDi;
using GoogleSearch.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoogleSearch
{
    public class GoogleSearchPage
    {
        private readonly IWebDriver driver;

        private readonly By txtSearch = By.Name("q");
        private readonly By expectedResult = By.XPath("//h3[contains(text(),LC20lb)]");
        private readonly By expectedMessage = By.XPath("//h1[@class='inline-block page-title-big']");

        public GoogleSearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToGooglePage(string url)
        {
            driver.Url = url;
        }

        public IWebElement GetTxtSearch()
        {
            return driver.FindElement(txtSearch);
        }

        public IWebElement GetExpectedResult()
        {
            IList<IWebElement> listItem = driver.FindElements(expectedResult);

            foreach (IWebElement item in listItem)
            {
                if (item.Text.Contains("C# Online Test"))
                {
                    item.Click();
                    return item;
                }
            }

            return (IWebElement)listItem;

        }

        public void FillTxtSearch(string search)
        {
            GetTxtSearch().SendKeys(search);
        }

        public void Search()
        {
            GetTxtSearch().Submit();
        }

        public IWebElement GetMsgResultSite()
        {
            return driver.FindElement(expectedMessage);
        }

        public string SeeResultSiteTitle()
        {
            return GetMsgResultSite().Text;
        }
    }
}

