using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysPlanITTest.Pages
{
    public class HomePage : BasePage 
    {
        public By contactMenu = By.CssSelector("#nav-contact a");
        public By contactOption = By.LinkText("Contact");
        public By startShoppingButton = By.Id("nav-shop");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        public ContactPage ClickContactMenuOption()
        {
            FindElement(contactMenu).Click();
            return new ContactPage(driver);
        }

        public ShopPage ClickStartShoppingButton()
        {
            FindElement(startShoppingButton).Click();
            return new ShopPage(driver);
        }
    }
}
