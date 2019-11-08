﻿using BoDi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoogleSearch
{
    [Binding]
    public class Hooks
    {
        public static IWebDriver Driver { get; private set; }

        //protected IWebDriver driver;

        [BeforeFeature]
        public static void BeforeScenario()
        {
           // Driver = null;

            //using (Driver = new ChromeDriver())
            //{
            //}
            try
            {
                
                Driver = new ChromeDriver();
                // Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)

                //Driver.Url = "blabla";
            }
            catch (DriverServiceNotFoundException erro)
            {
                Console.WriteLine(erro.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro genérico");
                throw e;
            }
            //finally
            //{
            //    Driver.Quit();
            //}
        }

        [AfterFeature]
        public static void AfterScenario()
        {
            if (Driver != null)
            {
                Driver.Close();
                Driver.Dispose();
            }
        }

    }
}