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


namespace SubmitAgencyPageObject
{
    public class SubmitAgencyPageStep1
    {
        private readonly IWebDriver driver;
        public WebDriverWait wait;

        public SubmitAgencyPageStep1(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }


        [FindsBy(How = How.Name, Using = "name")]
        public IWebElement agencyNameField { get; set; }

        [FindsBy(How = How.Name, Using = "website")]
        public IWebElement agencyWebsiteField { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement agencyEmailField { get; set; }

        [FindsBy(How = How.Name, Using = "phone")]
        public IWebElement agencyPhoneField { get; set; }

        [FindsBy(How = How.Name, Using = "founded")]
        public IWebElement agencyYearFoundedField { get; set; }

        [FindsBy(How = How.Name, Using = "hourly_rate")]
        public IWebElement agencyHourlyRate { get; set; }

        [FindsBy(How = How.Name, Using = "social_networks[facebook]")]
        public IWebElement agencySoialFB { get; set; }

        [FindsBy(How = How.Name, Using = "social_networks[twitter]")]
        public IWebElement agencySoialTW { get; set; }

        [FindsBy(How = How.Name, Using = "social_networks[linkedin]")]
        public IWebElement agencySoialIN { get; set; }

        [FindsBy(How = How.Name, Using = "social_networks[google_plus]")]
        public IWebElement agencySoialGPlus { get; set; }

        [FindsBy(How = How.Name, Using = "social_networks[instagram]")]
        public IWebElement agencySoialInst { get; set; }

        [FindsBy(How = How.Name, Using = "social_networks[youtube]")]
        public IWebElement agencySoialYouTb { get; set; }

        [FindsBy(How = How.Id, Using = "agency-step-submit-btn")]
        public IWebElement saveButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "select2-selection__arrow")]
        public IList<IWebElement> allSpaners { get; set; }

        [FindsBy(How = How.ClassName, Using = "select2-dropdown")]
        public IList<IWebElement> spanResultList { get; set; }

    }
}
