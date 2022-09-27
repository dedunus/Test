using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysPlanITTest.Pages
{
    public class ShoppingCartPage : BasePage
    {
        public By table = By.CssSelector(".cart-items");
        public By tableRow = By.CssSelector("tbody > tr");
        public By itemName = By.CssSelector("td:nth-child(1)");
        public By itemPrice = By.CssSelector("td:nth-child(2)");
        public By itemQty = By.CssSelector("td:nth-child(3) > input.input-mini");
        public By itemSubTotal = By.CssSelector("td:nth-child(4)");
        public By total = By.CssSelector(".total");

        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        public IList<IWebElement> GetShoppingCartTable()
        {
            IWebElement tbl = FindElement(table);
            IList<IWebElement> items = tbl.FindElements(tableRow);
            return items;
        }
        public double GetTotal()
        {
            double totalValue = Convert.ToDouble(FindElement(total).Text.Substring(6));
            return totalValue;
        }
    }
}
