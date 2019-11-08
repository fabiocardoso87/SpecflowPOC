using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSearch
{
    public static class GoogleSearchPageAsserter
    {
        public static void GoogleSearchReturnsCorrectResponse(this GoogleSearchPage page)
        {
            // Assert.Equals(page.ExpectedResult(), "C# Online Test");
            Assert.IsTrue(page.SeeResultSiteTitle().Contains("C# Online Test"));
            // Assert.AreEqual(page.SeeResultSiteTitle(), "C# Online Test");
        }

    }
}


