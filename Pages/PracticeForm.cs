using OpenQA.Selenium;


namespace FormTesting.Pages
{
    class PracticeForm
    {
        public void BlankForm(IWebDriver driver)
        {
            //Identify the testBlankForm and click
            IWebElement testBlankForm = driver.FindElement(By.XPath("//*[@id='post-35']/div/p/a[1]"));
            testBlankForm.Click();

            //Idenitfy the password text box and key in the password
            IWebElement Pswrd = driver.FindElement(By.XPath("//*[@id='wpforms-locked-16-field_form_locker_password']"));
            Pswrd.SendKeys("Testing");

            //Identify the submit button and click
            IWebElement submitButton = driver.FindElement(By.Name("wpforms[submit]"));
            submitButton.Click();
        }
    }
}
