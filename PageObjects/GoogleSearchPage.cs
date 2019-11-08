using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    [Binding]
    public class GoogleSearchPage : Hooks
    {
        public string GoToGooglePage(string url)
        {
            return Driver.Url = url;
        }
        private IWebElement GetTxtSearch()
        {
            return Driver.FindElement(By.Name("q"));
        }

        public IWebElement GetExpectedResult()
        {
           IList<IWebElement> listItem = Driver.FindElements(By.XPath("//h3[contains(text(),LC20lb)]"));

            foreach (IWebElement item in listItem)
            {
                if (item.Text.Contains("C# Online Test"))
                {
                    item.Click();
                    return item;
                   // break;
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

        public string ExpectedResult()
        {
            return GetExpectedResult().Text;
        }

        public IWebElement GetMsgResultSite()
        {
            return Driver.FindElement(By.XPath("//h1[@class='inline-block page-title-big']"));
        }

        public string SeeResultSiteTitle()
        {
            return GetMsgResultSite().Text;
        }
    }
}
