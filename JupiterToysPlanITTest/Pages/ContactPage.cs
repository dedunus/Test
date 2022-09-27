using JupiterToysPlanITTest.Configurations;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysPlanITTest.Pages
{
    public class ContactPage : BasePage
    {
        public By submitButton = By.CssSelector(".btn-contact");
        public By forenameErrorMessage = By.Id("forename-err");
        public By emailErrorMessage = By.Id("email-err");
        public By messageErrorMessage = By.Id("message-err");
        public By alertErrorMessage = By.CssSelector(".alert-error");

        public By forename = By.Id("forename");
        public By email = By.Id("email");
        public By message = By.Id("message");
        public By successMessage = By.CssSelector(".alert-success");
        

        public ContactPage(IWebDriver driver) : base(driver)
        {
        }

        public ContactPage ClickSubmitButton()
        {
            FindElement(submitButton).Click();
            return this;
        }

        public string FindForenameError()
        {
            var element = FindElement(forenameErrorMessage);
            return element.Text;
        }

        public string FindEmailError()
        {
            var element = FindElement(emailErrorMessage);
            return element.Text;
        }

        public string FindMessageError()
        {
            var element = FindElement(messageErrorMessage);
            return element.Text;
        }

        public string FindAlertError()
        {
            var element = FindElement(alertErrorMessage);
            return element.Text;
        }

        public string FindSuccessMessage()
        {
            var element = WaitForElement(successMessage);
            return element.Text;
        }

        //set data
        public ContactPage SetForename(string forenameValue)
        {
            FindElement(forename).SendKeys(forenameValue);
            return this;
        }

        public ContactPage SetEmail(string emaileValue)
        {
            FindElement(email).SendKeys(emaileValue);
            return this;
        }

        public ContactPage SetMessage(string messageValue)
        {
            FindElement(message).SendKeys(messageValue);
            return this;
        }


    }
}
