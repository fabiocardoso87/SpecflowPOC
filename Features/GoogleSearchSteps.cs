using GoogleSearch.Driver;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace GoogleSearch
{
    [Binding]
    public class GoogleSearchSteps
    {
        public GoogleSearchPage googlePage;

        public GoogleSearchSteps(IWebDriver driver)
        {
            googlePage = new GoogleSearchPage(driver);
        }

        [Given(@"I open google page")]
        public void GivenIOpenGooglePage()
        {
            googlePage.GoToGooglePage("http://www.google.com");
        }

        [When(@"I search for something interesting")]
        public void WhenISearchForSomethingInteresting()
        {
            googlePage.FillTxtSearch("C# test");
            googlePage.Search();
        }

        [Then(@"I found results I was searching for")]
        public void ThenIFoundResultsIWasSearchingFor()
        {
            googlePage.GetExpectedResult();
            GoogleSearchPageAsserter.GoogleSearchReturnsCorrectResponse(googlePage);
        }

    }
}
