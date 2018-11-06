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
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SubmitAgencyPageObject
{
    public class SubmitAgencyPageStep2
    {
        private readonly IWebDriver driver;
        public WebDriverWait wait;


        public SubmitAgencyPageStep2(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Name, Using = "agency_logo")]
        public IWebElement agencyLogoUploadSection { get; set; }
      
        [FindsBy(How = How.Id, Using = "agency_description_ifr")]
        public IWebElement tinyMCEFrameArea { get; set; }

        [FindsBy(How = How.Id, Using = "tinymce")]
        public IWebElement tinyMCETextAreaBody { get; set; }

        //переделать, сделать метод для сбора всех полей, метод перебора и заполнения рандомными данными и сохранениями их в переменные для сравнения
        [FindsBy(How = How.Name, Using = "key_clients[0][title]")]
        public IWebElement clientField0 { get; set; }

        [FindsBy(How = How.Name, Using = "key_clients[1][title]")]
        public IWebElement clientField1 { get; set; }

        [FindsBy(How = How.Name, Using = "key_clients[2][title]")]
        public IWebElement clientField2 { get; set; }

        [FindsBy(How = How.Name, Using = "photo_1")]
        public IWebElement companyPhoto0 { get; set; }

        [FindsBy(How = How.Name, Using = "photo_2")]
        public IWebElement companyPhoto1 { get; set; }

        [FindsBy(How = How.Name, Using = "photo_3")]
        public IWebElement companyPhoto2 { get; set; }

        [FindsBy(How = How.Id, Using = "agency-step-submit-btn")]
        public IWebElement saveBtn2 { get; set; }


        public void SubmitStep(string client0, string client1, string client2)
        {
            HelperClass helper = new HelperClass(this.driver);

            this.clientField0.Clear();
            this.clientField0.SendKeys(client0);

            this.clientField1.Clear();
            this.clientField1.SendKeys(client1);

            this.clientField2.Clear();
            this.clientField2.SendKeys(client2);
            
            helper.uploadPicture(@"C:/Users/skripka/Desktop/TestData/testupload.jpg", this.agencyLogoUploadSection);
            helper.uploadPicture(@"C:/Users/skripka/Desktop/TestData/test1.jpg", this.companyPhoto0);
            helper.uploadPicture(@"C:/Users/skripka/Desktop/TestData/test2.jpg", this.companyPhoto1);
            helper.uploadPicture(@"C:/Users/skripka/Desktop/TestData/test3.jpg", this.companyPhoto2);
            helper.TinyMCEFillContent(@"C:/Users/skripka/Desktop/TestData/TestDescription.txt",tinyMCEFrameArea ,tinyMCETextAreaBody);

            this.saveBtn2.Click();
        }
    }
}
