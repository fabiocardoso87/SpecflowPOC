using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSearch.Driver
{
    public class BrowserFactory
    {
        protected IWebDriver driver;
        public void OpenBrowser(String browser)
        {
            
            switch (browser)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    //Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                    break;
                default:
                    Console.WriteLine("Browser" + browser + "is invalid. Please check available options");
                    break;
            }

        }
    }
}
