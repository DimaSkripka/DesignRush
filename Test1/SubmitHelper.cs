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


        [TestMethod]
        public void SubmitStep1()
        {
            var jSDriver = new PhantomJSDriver();
            SumbitAgencyPage submitAgency = new SumbitAgencyPage(this.driver);
            submitAgency.Navigate();
            submitAgency.Submit("Test", "Test", "test@test.com", @"+380932967718", @"Qwerty123!", @"Qwerty123!");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("alertify-button"))).Click();

            Thread.Sleep(4000);

            SubmitAgencyPageStep1 step1 = new SubmitAgencyPageStep1(this.driver);
            step1.SaveAndContinue("Test",@"https://qwdqwd.com","test@test.com","1231231233","1850","77", @"https://www.facebook.com/dmitriy.skripka.3", @"https://twitter.com/dmitry_skripka", @"https://www.linkedin.com/in/dmitry-skripka-a4852b124/", @"https://plus.google.com/u/1/117367210483517711675", @"https://www.instagram.com/angrydmitry/", @"https://www.youtube.com/channel/UCTL3HvVv-q5eRi_6rLnv1Bw?view_as=subscriber");

            Thread.Sleep(4000);

            SubmitAgencyPageStep2 step2 = new SubmitAgencyPageStep2(this.driver);
            step2.uploadLogo(@"C:/Users/skripka/Desktop/New folder (2)/testupload.jpg");
            //step2.test();

            jSDriver.ExecutePhantomJS("alert('kama pul9')");
            jSDriver.ExecutePhantomJS("tinyMCE.activeEditor.save();");

            //driver.FindElement
            step2.fillClient("client1","client2","client3");
            step2.uploadContent("C:/Users/skripka/Desktop/New folder (2)/New folder/test1.jpg", "C:/Users/skripka/Desktop/New folder (2)/New folder/test2.jpg", "C:/Users/skripka/Desktop/New folder (2)/New folder/test3.jpg");
            step2.tinyMCE();


            //driver.FindElement(By.Id("agency-step-submit-btn")).Click();
            
            
        }
    }
}
