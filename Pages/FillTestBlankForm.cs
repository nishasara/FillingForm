using NUnit.Framework;
using OpenQA.Selenium;


namespace FormTesting.Pages
{
    public class FillTestBlankForm
    {

        public void FillFormTestBlank(IWebDriver driver, FormWebelements textboxes)
        {
            IWebElement frstName = driver.FindElement(By.Id("wpforms-16-field_0"));
            IWebElement LstName = driver.FindElement(By.Id("wpforms-16-field_0-last"));
            IWebElement Email = driver.FindElement(By.Id("wpforms-16-field_1"));
            IWebElement Message = driver.FindElement(By.Id("wpforms-16-field_2"));

            frstName.SendKeys(textboxes.FirstName);
            LstName.SendKeys(textboxes.LastName);
            Email.SendKeys(textboxes.Email);
            Message.SendKeys(textboxes.Message);

            IWebElement submit = driver.FindElement(By.Id("wpforms-submit-16"));
            submit.Click();

            IWebElement message = driver.FindElement(By.Id("wpforms-confirmation-16"));

            if (message.Text == "Thanks for contacting us! We will be in touch with you shortly.")
                Assert.Pass("The test blank form has been submitted succesfully");
            else
                Assert.Fail("The test blank form has not been submitted succesfully");

        }
    }
}
