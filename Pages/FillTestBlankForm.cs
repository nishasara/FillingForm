using NUnit.Framework;
using OpenQA.Selenium;


namespace FormTesting.Pages
{
    public class FillTestBlankForm
    {

        public void FillFormTestBlank(IWebDriver driver, FormWebelements textboxes)
        {
            //Identify the FirstName textbox
            IWebElement frstName = driver.FindElement(By.Id("wpforms-16-field_0"));

            //Identify the LastName textbox
            IWebElement LstName = driver.FindElement(By.Id("wpforms-16-field_0-last"));

            //Identify the Email textbox
            IWebElement Email = driver.FindElement(By.Id("wpforms-16-field_1"));

            //Identify the Message textbox
            IWebElement Message = driver.FindElement(By.Id("wpforms-16-field_2"));

            //Populate the FirstName field with the value passed
            frstName.SendKeys(textboxes.FirstName);

            //Populate the LastName field with the value passed
            LstName.SendKeys(textboxes.LastName);

            //Populate the Email field with the value passed
            Email.SendKeys(textboxes.Email);

            //Populate the Message field with the value passed
            Message.SendKeys(textboxes.Message);

            //Idenitfy the submit button and click to submit the details
            IWebElement submit = driver.FindElement(By.Id("wpforms-submit-16"));
            submit.Click();

            IWebElement submitMessage = driver.FindElement(By.Id("wpforms-confirmation-16"));

            //Validate if the details are registered successfully
            if (submitMessage.Text == "Thanks for contacting us! We will be in touch with you shortly.")
                Assert.Pass("The test blank form has been submitted succesfully");
            else
                Assert.Fail("The test blank form has not been submitted succesfully");

        }
    }
}
