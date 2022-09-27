using JupiterToysPlanITTest.Configurations;
using JupiterToysPlanITTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JupiterToysPlanITTest.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Settings.BaseURL);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        protected T PageLoad<T>()
        {
            Type classType = typeof(T);
            ConstructorInfo ctor = classType.GetConstructor(new[] { typeof(IWebDriver) });
            object instance = ctor.Invoke(new IWebDriver[] { driver });
            return (T)instance;  
        }

    }
}
