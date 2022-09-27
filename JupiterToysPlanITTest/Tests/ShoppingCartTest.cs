using JupiterToysPlanITTest.Pages;
using JupiterToysPlanITTest.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.ComponentModel;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace JupiterToysPlanITTest
{
    [TestFixture]
    public class ShoppingCartTest: BaseTest
    {

        //Test case 3
        [Test]
        public void PurchasedItems()
        {
           ShopPage shopPage = PageLoad<HomePage>().ClickStartShoppingButton();
            //add 2 Stuffed Frogs, 5 Fluffy Bunnies, 3 Valentine Bears
            shopPage
                 .AddStuffedFrog()
                 .AddStuffedFrog()
                 .AddFluffyBunny()
                 .AddFluffyBunny()
                 .AddFluffyBunny()
                 .AddFluffyBunny()
                 .AddFluffyBunny()
                 .AddValentineBear()
                 .AddValentineBear()
                 .AddValentineBear(); 
            Assert.AreEqual(10, shopPage.CheckCount());

            // Navigate to shopping cart page
            ShoppingCartPage shoppingCartPage = shopPage.ClickOnCart();
            // Verify items in shopping cart
            VerifyItemsInShoppingCart(shoppingCartPage);
        }

        /// <summary>
        /// Verify Item name, Item price, Subtotal and Grand total
        /// </summary>
        /// <param name="shoppingCartPage"></param>
        private void VerifyItemsInShoppingCart(ShoppingCartPage shoppingCartPage)
        {
            var shoppingCartTable = shoppingCartPage.GetShoppingCartTable();
            double grandTotal = 0;

            foreach (var row in shoppingCartTable)
            {
                var itemNameText = row.FindElement(shoppingCartPage.itemName).Text;
                var itemPriceText = Convert.ToDouble(row.FindElement(shoppingCartPage.itemPrice).Text.Substring(1));
                var itemQtyText = Convert.ToInt32(row.FindElement(shoppingCartPage.itemQty).GetAttribute("value"));
                var itemSubTotalText = Convert.ToDouble(row.FindElement(shoppingCartPage.itemSubTotal).Text.Substring(1));

                switch (itemNameText)
                {
                    case "Stuffed Frog":
                        Assert.AreEqual(10.99, itemPriceText);
                        break;
                    case "Fluffy Bunny":
                        Assert.AreEqual(9.99, itemPriceText);
                        break;
                    case "Valentine Bear":
                        Assert.AreEqual(14.99, itemPriceText);
                        break;
                    default:
                        break;
                }

                grandTotal += itemSubTotalText;
                Assert.AreEqual(itemPriceText * itemQtyText, itemSubTotalText);
            }
            Assert.AreEqual(grandTotal, shoppingCartPage.GetTotal());
        }
    }
}