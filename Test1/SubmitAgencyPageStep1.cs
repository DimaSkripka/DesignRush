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

        [FindsBy(How = How.Id, Using = "select2-phone_country_code-lz-container")]
        public IWebElement countryCodeSpan { get; set; }

        [FindsBy(How = How.Name, Using = "phone")]
        public IWebElement agencyPhoneField { get; set; }

        [FindsBy(How = How.Name, Using = "founded")]
        public IWebElement agencyYearFoundedField { get; set; }

        [FindsBy(How = How.Name, Using = "hourly_rate")]
        public IWebElement agencyHourlyRate { get; set; }

        [FindsBy(How = How.Id, Using = "employee_id")]
        public IWebElement agencyEmployees { get; set; }

        [FindsBy(How = How.Name, Using = "min_budget")]
        public IWebElement agencyMinimumBudget { get; set; }

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


        //public void SaveAndContinue(string agencyName, string agencyWebsite, string agencyEmail, string countryCode, string agencyPhone, string agencyYearFounded, string hourlyRate, string employee, string minimumBudget, string facebook, string twitter, string linkedIn, string googlePlus, string instagram, string youTube)
        //{
        //    this.agencyNameField.Clear();
        //    this.agencyNameField.SendKeys(agencyName);

        //    this.agencyWebsiteField.Clear();
        //    this.agencyWebsiteField.SendKeys(agencyWebsite);

        //    this.agencyEmailField.Clear();
        //    this.agencyEmailField.SendKeys(agencyEmail);

        //    this.countryCodeSpan.Click();
        //    //сделать загрузку всех значений поп-апа в коллекцию, и выбор рандомного элемента


        //    this.agencyPhoneField.Clear();
        //    this.agencyPhoneField.SendKeys(agencyPhone);

        //    this.agencyYearFoundedField.Clear();
        //    this.agencyYearFoundedField.SendKeys(agencyYearFounded);

        //    this.agencyHourlyRate.Clear();
        //    this.agencyHourlyRate.SendKeys(hourlyRate);

        //    this.agencyEmployees.Click();
        //    //сделать загрузку всех значений поп-апа в коллекцию, и выбор рандомного элемента

        //    this.agencyMinimumBudget.Click();
        //    //сделать загрузку всех значений поп-апа в коллекцию, и выбор рандомного элемента

        //    this.agencySoialFB.Clear();
        //    this.agencySoialFB.SendKeys(facebook);

        //    this.agencySoialTW.Clear();
        //    this.agencySoialTW.SendKeys(twitter);

        //    this.agencySoialIN.Clear();
        //    this.agencySoialIN.SendKeys(linkedIn);

        //    this.agencySoialGPlus.Clear();
        //    this.agencySoialGPlus.SendKeys(googlePlus);

        //    this.agencySoialInst.Clear();
        //    this.agencySoialInst.SendKeys(instagram);

        //    this.agencySoialYouTb.Clear();
        //    this.agencySoialYouTb.SendKeys(youTube);


        //    driver.FindElement(By.Id("select2-phone_country_code-lz-container")).Click();
        //    driver.FindElement(By.Id("mCSB_17_container")).FindElements(By.TagName("li"));
        //}
        public void GetCountryCodeLi()
        {

            List<IWebElement> li = new List<IWebElement>(driver.FindElement(By.Id("mCSB_17_container")).FindElements(By.TagName("li")));

            Random rnd = new Random();
            int rndValue = rnd.Next(0, li.Count);

            li[rndValue].Click();

        }

    }


}
