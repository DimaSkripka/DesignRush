using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SubmitAgencyPageObject
{
    [TestClass]
    public class TestExecuteClass
    {
        
        public IWebDriver driver { get; set; }
        public WebDriverWait wait { get; set; }

        [TestInitialize]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
        }


        [TestMethod]
        public void SubmitAgency()
        {
            HelperClass helper = new HelperClass(this.driver);

            Scenario testscenario = new Scenario(this.driver);
            SubmitAgencyPage submitAgency = new SubmitAgencyPage(this.driver);
            submitAgency.Navigate();
            testscenario.SubmitAgency(@"+380932967718", @"Qwerty123!", @"Qwerty123!");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("alertify-button"))).Click();

            Thread.Sleep(2000);

            submitAgency.check();
            SubmitAgencyPageStep1 step1 = new SubmitAgencyPageStep1(this.driver);
            testscenario.SubmitStep1("1231231233","1850","77", @"https://www.facebook.com/dmitriy.skripka.3", @"https://twitter.com/dmitry_skripka", @"https://www.linkedin.com/in/dmitry-skripka-a4852b124/", @"https://plus.google.com/u/1/117367210483517711675", @"https://www.instagram.com/angrydmitry/", @"https://www.youtube.com/channel/UCTL3HvVv-q5eRi_6rLnv1Bw?view_as=subscriber");
            Thread.Sleep(2000);


            SubmitAgencyPageStep2 step2 = new SubmitAgencyPageStep2(this.driver);
            testscenario.SubmitStep2();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("agency-step-submit-btn")).Click();
            Thread.Sleep(3000);

            SubmitAgencyPageStep3 step3 = new SubmitAgencyPageStep3(this.driver);
            helper.setLocation(step3.spanElementField);
        }
    }
}
