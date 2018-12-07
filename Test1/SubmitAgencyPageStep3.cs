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
    class SubmitAgencyPageStep3
    {
        private readonly IWebDriver driver;
        public WebDriverWait wait;
        

        public SubmitAgencyPageStep3(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Name, Using = "locations[1542303394][address_1]")]
        public IWebElement headquarterField { get; set; }

        [FindsBy(How = How.ClassName, Using = "select2-selection__rendered")]
        public IWebElement spanElementField { get; set; }

        [FindsBy(How = How.ClassName, Using = "select2-selection")]
        public IWebElement dropDownList { get; set; }

        [FindsBy(How = How.ClassName, Using = "select2-selection")]
        public IWebElement dropqweDownList { get; set; }

        //public IWebElement Country()
        //{
        //    HelperClass helper = new HelperClass(this.driver);
        //    return helper.getElementWithDynamicName("select", "name", "[country_id]");
        //}

        public IWebElement Headquarter()
        {
            HelperClass helper = new HelperClass(this.driver);
            return helper.getElementWithDynamicName("input", "name", "[address_1]");
        }

        public IWebElement city()
        {
            HelperClass helper = new HelperClass(this.driver);
            return helper.getElementWithDynamicName("input", "name", "[city]");
        }

        public IWebElement zipCode()
        {
            HelperClass helper = new HelperClass(this.driver);
            return helper.getElementWithDynamicName("input", "name", "[zip]");
        }

    }
}
