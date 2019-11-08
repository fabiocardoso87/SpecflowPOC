using System;
using TechTalk.SpecFlow;

namespace GoogleSearch
{
    [Binding]
    public class GoogleSearchSteps
    {
        private GoogleSearchPage googlePage;

        [Given(@"I open google page")]
        public void GivenIOpenGooglePage()
        {
            googlePage = new GoogleSearchPage();
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
            //GoogleSearchPageAsserter.GoogleSearchReturnsCorrectResponse(googlePage);
            googlePage.GetExpectedResult();
            GoogleSearchPageAsserter.GoogleSearchReturnsCorrectResponse(googlePage);
        }
    }
}
