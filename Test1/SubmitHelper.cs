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

        //[TestCleanup]
        //public void TeardownTest()
        //{
        //    this.driver.Quit();
        //}

        [TestMethod]
        public void SubmitStep1()
        {
            SumbitAgencyPage submitAgency = new SumbitAgencyPage(this.driver);
            submitAgency.Navigate();
            submitAgency.Submit("DmitryQaTest3", "SkripkaQaTest3", "dimaskripka1992+3@gmail.com", @"+380932967718", @"Qwerty123!", @"Qwerty123!");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("alertify-button"))).Click();
            Thread.Sleep(4000);
            SubmitAgencyPageStep1 step1 = new SubmitAgencyPageStep1(this.driver);
            step1.SaveAndContinue();
        }
    }
}
