using NUnit.Framework;
using FormTesting.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections;
using System.IO;
using System;
using LumenWorks.Framework.IO.Csv;

namespace FormTesting
{
    public class Tests
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            //Initialise the driver
            driver = new ChromeDriver();

            //Navigate to the required URL
            driver.Navigate().GoToUrl("http://qaauto.co.nz/automation-practice-forms");
            driver.Manage().Window.Maximize();

            
        }

        //Verifies the form with 1 value
        [Test]
        public void TestOneForm()
        {
            //Instantiate an object for the class 'PracticeForm'
            PracticeForm formObj = new PracticeForm();

            //Invoke the function to proceed to the Test Blank Form
            formObj.BlankForm(driver);

            //Initialise the object 'elements' with the required field values
            FormWebelements elements = new FormWebelements("David", "John", "david.john@ymail.com", "Please register my details");

            //Invoke the function to fill out the Test Blank Form fields with values of 'elements'
            FillTestBlankForm fillformObj = new FillTestBlankForm();
            fillformObj.FillFormTestBlank(driver, elements);
        }


        //Passing Multiple test values using 'TestCase' attribute
        [TestCase("Sam", "George", "sam.george@ymail.com", "Please register my details")]
        [TestCase("john", "thomas", "john.thomas@ymail.com", "Please register my details")]
        [TestCase("Jordan", "thomas", "jordan.thomas@ymail.com", "Please register my details")]
        public void TestForm(string fname, string lname, string mail, string msg)
        {
            PracticeForm formObj = new PracticeForm();
            formObj.BlankForm(driver);

            FillTestBlankForm fillObj = new FillTestBlankForm();
            FormWebelements elements = new FormWebelements(fname, lname, mail, msg);
            fillObj.FillFormTestBlank(driver, elements);
        }

        //Passing Multiple test values using 'TestCaseSource' attribute
        [TestCaseSource("NUnitTestData")]
        public void testFormMultipleData(FormWebelements elements)
        {
            PracticeForm formObj = new PracticeForm();
            formObj.BlankForm(driver);

            FillTestBlankForm fillObj = new FillTestBlankForm();
            fillObj.FillFormTestBlank(driver, elements);

        }

        public static IEnumerable NUnitTestData
        {
            get
            {
                yield return new TestCaseData(new FormWebelements("Jake", "Thomas", "jake.thomas@ymail.com", "Register my details")).SetName("TC1");
                yield return new TestCaseData(new FormWebelements("Samuel", "Thomas", "samuel.thomas@ymail.com", "Register my details")).SetName("TC2");
               
            }
        }


        //Passing Multiple test values from the CSV file using 'TestCaseSource' attribute
        [TestCaseSource("TestDataCSV")]
        public void TestMultipleWithCSV(FormWebelements elements)
        {
            PracticeForm formObj = new PracticeForm();
            formObj.BlankForm(driver);

            FillTestBlankForm blankForm = new FillTestBlankForm();
            blankForm.FillFormTestBlank(driver, elements);

        }


        public static IEnumerable TestDataCSV()
        {
            string filePath = "\\Data\\Data.csv";
            //reading csv file
            using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + filePath)), true))
            {
                //Iterating csv file
                while (csv.ReadNextRecord())
                {
                    yield return new TestCaseData(new FormWebelements(csv["firstname"], csv["lastname"], csv["email"], csv["message"])).SetName(csv["testcasename"]);
                }
            }

        }

        //This test verifies the NewsLetterSignUp page
        [Test]
        public void TestNewsLetterSignUp()
        {
            PracticeForm newsformObj = new PracticeForm();
            newsformObj.NwsLttrSignUPForm(driver);

            FormWebelements elements = new FormWebelements("Davis", "Davis", "davis.davis@ymail.com");
            FillNewsletter newLetterObj = new FillNewsletter(driver);
            newLetterObj.FillNewsLetterSignUpForm(elements);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}