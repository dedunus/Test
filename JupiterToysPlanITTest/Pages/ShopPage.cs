using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysPlanITTest.Pages
{
    public class ShopPage : BasePage
    {
        public By buyStuffedFrog = By.CssSelector("#product-2 >div:nth-child(1) p:nth-child(3) > a.btn.btn-success");
        public By buyFluffyBunny = By.CssSelector("#product-4 >div:nth-child(1) p:nth-child(3) > a.btn.btn-success");
        public By buyValentineBear = By.CssSelector("#product-7 >div:nth-child(1) p:nth-child(3) > a.btn.btn-success");
        public By cart = By.Id("nav-cart");
        public By cartCount = By.CssSelector(".cart-count");

        public ShopPage(IWebDriver driver) : base(driver)
        {
        }

        public ShopPage AddStuffedFrog()
        {
            FindElement(buyStuffedFrog).Click();
            return this;
        }

        public ShopPage AddFluffyBunny()
        {
            FindElement(buyFluffyBunny).Click();
            return this;
        }

        public ShopPage AddValentineBear()
        {
            FindElement(buyValentineBear).Click();
            return this;
        }

        public int CheckCount()
        {
            int count = Convert.ToInt32(FindElement(cartCount).Text);
            return count;
        }

        public ShoppingCartPage ClickOnCart()
        {
            FindElement(cart).Click();
            return new ShoppingCartPage(driver);
        }

    }
}
