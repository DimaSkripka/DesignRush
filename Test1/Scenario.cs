using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading.Tasks;
using System;
using System.IO;



namespace SubmitAgencyPageObject
{
    class Scenario
    {
        private readonly IWebDriver driver;
        public WebDriverWait wait;

        public Scenario(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        public void SubmitAgency(string phone, string password, string passwordConfirmation)
        {
            SubmitAgencyPage submitAgency = new SubmitAgencyPage(this.driver);
            HelperClass helper = new HelperClass(this.driver);

            submitAgency.nameField.Clear();
            submitAgency.nameField.SendKeys(helper.GenerateRandomData());

            submitAgency.lastNameField.Clear();
            submitAgency.lastNameField.SendKeys(helper.GenerateRandomData());

            submitAgency.emailField.Clear();
            submitAgency.emailField.SendKeys(helper.GenerateRandomEmail());

            submitAgency.phoneField.Clear();
            submitAgency.phoneField.SendKeys(phone);

            submitAgency.passwordField.Clear();
            submitAgency.passwordField.SendKeys(password);

            submitAgency.passwordConfirmationField.Clear();
            submitAgency.passwordConfirmationField.SendKeys(passwordConfirmation);

            submitAgency.submitButton.Click();
        }


        public void SubmitStep1(string agencyPhone, string agencyYearFounded, string hourlyRate, string facebook, string twitter, string linkedIn, string googlePlus, string instagram, string youTube)
        {
            HelperClass helper = new HelperClass(this.driver);
            SubmitAgencyPageStep1 submitstep1 = new SubmitAgencyPageStep1(this.driver);


            submitstep1.agencyNameField.Clear();
            submitstep1.agencyNameField.SendKeys(helper.GenerateRandomData());

            submitstep1.agencyWebsiteField.Clear();
            submitstep1.agencyWebsiteField.SendKeys(helper.GenerateRandomUrl());

            submitstep1.agencyEmailField.Clear();
            submitstep1.agencyEmailField.SendKeys(helper.GenerateRandomEmail());

            helper.setRandomForAllDropDowns(submitstep1.allSpaners);
            //submitstep1.spanElement1.Click();
            //helper.selectElementWithScroll(submitstep1.spanList1);

            submitstep1.agencyPhoneField.Clear();
            submitstep1.agencyPhoneField.SendKeys(agencyPhone);

            submitstep1.agencyYearFoundedField.Clear();
            submitstep1.agencyYearFoundedField.SendKeys(agencyYearFounded);

            submitstep1.agencyHourlyRate.Clear();
            submitstep1.agencyHourlyRate.SendKeys(hourlyRate);

            submitstep1.agencySoialFB.Clear();
            submitstep1.agencySoialFB.SendKeys(facebook);

            submitstep1.agencySoialTW.Clear();
            submitstep1.agencySoialTW.SendKeys(twitter);

            submitstep1.agencySoialIN.Clear();
            submitstep1.agencySoialIN.SendKeys(linkedIn);

            submitstep1.agencySoialGPlus.Clear();
            submitstep1.agencySoialGPlus.SendKeys(googlePlus);

            submitstep1.agencySoialInst.Clear();
            submitstep1.agencySoialInst.SendKeys(instagram);

            submitstep1.agencySoialYouTb.Clear();
            submitstep1.agencySoialYouTb.SendKeys(youTube);

            submitstep1.saveButton.Click();

        }

        public void SubmitStep2()
        {
            HelperClass helper = new HelperClass(this.driver);
            SubmitAgencyPageStep2 submitStep2 = new SubmitAgencyPageStep2(this.driver);

            submitStep2.clientField0.Clear();
            submitStep2.clientField0.SendKeys(helper.GenerateRandomData());

            submitStep2.clientField1.Clear();
            submitStep2.clientField1.SendKeys(helper.GenerateRandomData());

            submitStep2.clientField2.Clear();
            submitStep2.clientField2.SendKeys(helper.GenerateRandomData());

            helper.uploadPicture(@"C:/Users/skripka/Desktop/TestData/testupload.jpg", submitStep2.agencyLogoUploadSection);
            helper.uploadPicture(@"C:/Users/skripka/Desktop/TestData/test1.jpg", submitStep2.companyPhoto0);
            helper.uploadPicture(@"C:/Users/skripka/Desktop/TestData/test2.jpg", submitStep2.companyPhoto1);
            helper.uploadPicture(@"C:/Users/skripka/Desktop/TestData/test3.jpg", submitStep2.companyPhoto2);
            helper.TinyMCEFillContent(@"C:/Users/skripka/Desktop/TestData/TestDescription.txt", submitStep2.tinyMCEFrameArea, submitStep2.tinyMCETextAreaBody);

            submitStep2.saveButton.Click();

        }

        public void SubmitStep3()
        {
            HelperClass helper = new HelperClass(this.driver);
            SubmitAgencyPageStep3 submitStep3 = new SubmitAgencyPageStep3(this.driver);

            submitStep3.Headquarter().SendKeys(helper.GenerateRandomData());
            submitStep3.city().SendKeys(helper.GenerateRandomData());
            submitStep3.zipCode().SendKeys(helper.GenerateRandomData());
            helper.setLocation(submitStep3.spanElementField);

        }
    }
}
