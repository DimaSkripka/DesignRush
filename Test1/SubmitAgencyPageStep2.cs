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
        public IWebElement saveButton { get; set; }
    }
}
