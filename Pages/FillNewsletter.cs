using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormTesting.Pages
{

    class FillNewsletter
    {
        IWebDriver driver;

        public FillNewsletter(IWebDriver driver)
        {
            this.driver = driver;

        }

        //Identify the FirstName textbox
        IWebElement frstName => driver.FindElement(By.Id("wpforms-34-field_0"));

        //Identify the LastName textbox
        IWebElement LstName => driver.FindElement(By.Id("wpforms-34-field_0-last"));

        //Identify the Email textbox
        IWebElement Email => driver.FindElement(By.Id("wpforms-34-field_1"));

        //Identify the Submit button
        IWebElement submitButton => driver.FindElement(By.Id("wpforms-submit-34"));

        IWebElement message => driver.FindElement(By.Id("wpforms-confirmation-34"));

        //Function to fill out the textboxes with the values passed
        public void FillNewsLetterSignUpForm(FormWebelements testSignUpNewsletterboxes)
        {
            //Populate the FirstName field with the value passed
            frstName.SendKeys(testSignUpNewsletterboxes.FirstName);

            //Populate the LastName field with the value passed
            LstName.SendKeys(testSignUpNewsletterboxes.LastName);

            //Populate the Email field with the value passed
            Email.SendKeys(testSignUpNewsletterboxes.Email);
            submitButton.Click();


            //Validate if the registeration is successfull
            if (message.Text == "Thanks for contacting us! We will be in touch with you shortly.")
                Assert.Pass("The test blank form has been submitted succesfully");
            else
                Assert.Fail("The test blank form has not been submitted succesfully");

        }

        
    }
}
