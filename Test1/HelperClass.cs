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
    public class HelperClass
    {
        private readonly IWebDriver driver;
        public WebDriverWait wait;

        public HelperClass(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        public void GetRandomLi(string dropDownLocator, string liLocator)
        {
            List<IWebElement> li = new List<IWebElement>(driver.FindElement(By.ClassName(dropDownLocator)).FindElements(By.TagName(liLocator)));

            Random rnd = new Random();
            int rndValue = rnd.Next(0, li.Count);

            li[rndValue].Click();
        }

    }
}
