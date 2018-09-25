using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.Events;
using System;


namespace SubmitAgencyPageObject
{
    [TestClass]
    public class SubmitHelper
    {

        public IWebDriver driver { get; set; }
        public WebDriverWait wait { get; set; }

        [TestInitialize]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
        }

        [TestCleanup]
        public void TeardownTest()
        {
            this.driver.Quit();
        }

        [TestMethod]
        public void SubmitStep1()
        {
            SumbitAgencyPageStep1 step1 = new SumbitAgencyPageStep1(this.driver);
            step1.Navigate();
            step1.Submit("DmitryQaTest123", "SkripkaQaTest123", @"dimaskripka1992+qwe123qwe123@gmail.com", @"+380932967718", @"Qwerty123!", @"Qwerty123!");
            driver.FindElements(By.ClassName("alertify-button"));
        }
    }
}
