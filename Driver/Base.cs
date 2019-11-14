using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoogleSearch.Driver
{
    [Binding]
    public class Base
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        private readonly IObjectContainer container;

        public Base(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void Setup()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                // Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                container.RegisterInstanceAs<IWebDriver>(driver);
            }
            
        }

        [AfterScenario]
        public void TearDown()
        {
            var driver = container.Resolve<IWebDriver>();
            
            driver?.Close();
            driver?.Quit();
        }

        public void Webdriverwait()
        {
            if (wait == null)
            {
                this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            }

        }

    }
}
