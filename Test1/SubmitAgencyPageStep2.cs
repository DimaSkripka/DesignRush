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
        public IWebElement agencyLogoUpload { get; set; }

        [FindsBy(How = How.Id, Using = "agency_description_ifr")]
        public IWebElement agencyDescription { get; set; }

        public void uploadLogo(string filePath)
        {
            this.agencyLogoUpload.Clear();
            this.agencyLogoUpload.SendKeys(filePath);
        }

        public void fillDesc(string description)
        {
            this.agencyDescription.Clear();
            this.agencyDescription.SendKeys(description);
        }
    }
}
