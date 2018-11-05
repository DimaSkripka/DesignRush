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

        Random random = new Random();

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

        [FindsBy(How = How.Name, Using = "social_networks_fb")]
        public IWebElement agencySoialFB { get; set; }

        [FindsBy(How = How.Name, Using = "social_networks_tw")]
        public IWebElement agencySoialTW { get; set; }

        [FindsBy(How = How.Name, Using = "social_networks_in")]
        public IWebElement agencySoialIN { get; set; }

        [FindsBy(How = How.Name, Using = "social_networks_gplus")]
        public IWebElement agencySoialGPlus { get; set; }

        [FindsBy(How = How.Name, Using = "social_networks_instagram")]
        public IWebElement agencySoialInst { get; set; }

        [FindsBy(How = How.Name, Using = "social_networks_youtube")]
        public IWebElement agencySoialYouTb { get; set; }

        [FindsBy(How = How.Id, Using = "agency-step-submit-btn")]
        public IWebElement saveBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "select2-selection__arrow")]
        public IList<IWebElement> spanElements { get; set; }


        public void FillGeneralInformation(string agencyName, string agencyWebsite, string agencyEmail,string agencyPhone, string agencyYearFounded, string hourlyRate, string facebook, string twitter, string linkedIn, string googlePlus, string instagram, string youTube)
        {
            HelperClass helper = new HelperClass(this.driver);

            this.agencyNameField.Clear();
            this.agencyNameField.SendKeys(agencyName+random.Next(1000000));

            this.agencyWebsiteField.Clear();
            this.agencyWebsiteField.SendKeys(agencyWebsite);

            this.agencyEmailField.Clear();
            this.agencyEmailField.SendKeys(random.Next(10000000) + agencyEmail);

            spanElements[0].Click();
            helper.GetRandomLi("select2-results__options", "li");

            this.agencyPhoneField.Clear();
            this.agencyPhoneField.SendKeys(agencyPhone);

            this.agencyYearFoundedField.Clear();
            this.agencyYearFoundedField.SendKeys(agencyYearFounded);

            this.agencyHourlyRate.Clear();
            this.agencyHourlyRate.SendKeys(hourlyRate);

            spanElements[1].Click();
            helper.GetRandomLi("select2-results__options", "li");

            spanElements[2].Click();
            helper.GetRandomLi("select2-results__options", "li");

            this.agencySoialFB.Clear();
            this.agencySoialFB.SendKeys(facebook);

            this.agencySoialTW.Clear();
            this.agencySoialTW.SendKeys(twitter);

            this.agencySoialIN.Clear();
            this.agencySoialIN.SendKeys(linkedIn);

            this.agencySoialGPlus.Clear();
            this.agencySoialGPlus.SendKeys(googlePlus);

            this.agencySoialInst.Clear();
            this.agencySoialInst.SendKeys(instagram);

            this.agencySoialYouTb.Clear();
            this.agencySoialYouTb.SendKeys(youTube);
        }

        public void SubmitStep()
        {
            saveBtn.Click();
        }
    }
}
