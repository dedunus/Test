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
    public class ContactTest : BaseTest
    {

        //Test case 1
        [Test]
        public void VerifyContactPageMandatoryFieldsValidations()
        {
            //Test data 
            string forename = "Dedunu1";
            string email = "dedunu1@test.com";
            string message = "Test message1";

            // Click on submit button without filling mandetory data
            HomePage homePage = PageLoad<HomePage>();
            ContactPage contactPage = homePage
                .ClickContactMenuOption()
                .ClickSubmitButton();

            // Verify Error messages display
            Assert.AreEqual("Forename is required", contactPage.FindForenameError());
            Assert.AreEqual("Email is required", contactPage.FindEmailError());
            Assert.AreEqual("Message is required", contactPage.FindMessageError());
            Assert.AreEqual("We welcome your feedback - but we won't get it unless you complete the form correctly.", contactPage.FindAlertError());

            // Fill mandetory field and click on Submit button
            PopulateContactDetails(homePage, forename, email, message);
            Assert.AreEqual(string.Format("Thanks {0}, we appreciate your feedback.", forename), contactPage.FindSuccessMessage());

            // Verify Error messages not display
            Assert.False(contactPage.IsElementPresent(contactPage.forenameErrorMessage));
            Assert.False(contactPage.IsElementPresent(contactPage.emailErrorMessage));
            Assert.False(contactPage.IsElementPresent(contactPage.messageErrorMessage));
            Assert.False(contactPage.IsElementPresent(contactPage.alertErrorMessage));
        }

        //Test case 2
        [Test]
        public void SubmitConactDetails()
        {
            //Test data 
            string forename = "Dedunu2";
            string email = "dedunu2@test.com";
            string message = "Test message2";

            HomePage homePage = PageLoad<HomePage>();

            // Fill Contact page mandetory fields
            ContactPage contactPage = PopulateContactDetails(homePage, forename, email, message);
            Assert.AreEqual(string.Format("Thanks {0}, we appreciate your feedback.", forename), contactPage.FindSuccessMessage());
        }

     

        public ContactPage PopulateContactDetails(HomePage homePage, string forename, string email, string message)
        {
            ContactPage contactPage = homePage
                .ClickContactMenuOption()
                .ClickSubmitButton()
                .SetForename(forename)
                .SetEmail(email)
                .SetMessage(message)
                .ClickSubmitButton();
            return contactPage;
        }
    }
}