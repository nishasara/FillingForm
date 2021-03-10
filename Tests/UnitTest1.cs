
using NUnit.Framework;
using FormTesting.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections;
using System.IO;
using System;


namespace FormTesting
{
    public class Tests
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://qaauto.co.nz/automation-practice-forms");
            driver.Manage().Window.Maximize();

            PracticeForm formObj = new PracticeForm();
            formObj.BlankForm(driver);
        }

        //Verifies the form with 1 value
        [Test]
        public void TestOneForm()
        {
            FormWebelements elements = new FormWebelements("David", "John", "david.john@ymail.com", "Please register my details");

            FillTestBlankForm fillformObj = new FillTestBlankForm();
            fillformObj.FillFormTestBlank(driver, elements);
        }

        [TestCase("Sam", "George", "sam.george@ymail.com", "Please register my details")]
        [TestCase("john", "thomas", "john.thomas@ymail.com", "Please register my details")]
        [TestCase("Jordan", "thomas", "jordan.thomas@ymail.com", "Please register my details")]
        public void TestForm(string fname, string lname, string mail, string msg)
        {
            FillTestBlankForm fillObj = new FillTestBlankForm();
            FormWebelements elements = new FormWebelements(fname, lname, mail, msg);
            fillObj.FillFormTestBlank(driver, elements);
        }


        [TestCaseSource("TestDataCSV")]
        public void TestMultipleWithCSV(FormWebelements elements)
        {
            FillTestBlankForm blankForm = new FillTestBlankForm();
            blankForm.FillFormTestBlank(driver, elements);

        }


        public static IEnumerable TestDataCSV()
        {
            string filePath = "\\FormTesting\\Data\\Data.csv";
            //reading csv file
            using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + filePath)), true))
            {
                //Iterating csv file
                while (csv.ReadNextRecord())
                {
                    yield return new TestCaseData(new FormWebelements(csv[0], csv[1], csv[2], csv[3])).SetName(csv["testcasename"]);
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}