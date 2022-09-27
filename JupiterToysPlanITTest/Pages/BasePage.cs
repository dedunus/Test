using JupiterToysPlanITTest.Configurations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysPlanITTest.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver { get; set; }

        protected BasePage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public IWebElement FindElement(By element)
        {
           return driver.FindElement(element);
        }

        public IList<IWebElement> FindElements(By element)
        {
            return driver.FindElements(element);
        } 

        public IWebElement WaitForElement(By element)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(Settings.WaitingTime))
                .Until(d => d.FindElement(element));
        }

        public bool IsElementPresent(By element)
        {
            try
            {
                FindElement(element);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
