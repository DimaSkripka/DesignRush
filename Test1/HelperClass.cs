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

        Random rnd = new Random();

        public HelperClass(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        public string typeRandomData()
        {
            int rndValue = rnd.Next(1000000);
            var someRandomData = "someData" + rndValue;
            return someRandomData;
        }

        public void SelectRandomLi(string dropDownLocator, string liLocator)
        {
            List<IWebElement> li = new List<IWebElement>(driver.FindElement(By.ClassName(dropDownLocator)).FindElements(By.TagName(liLocator)));
            int rndValue = rnd.Next(0, li.Count);
            li[rndValue].Click();
        }


        public void TinyMCEFillContent(string txtPath, IWebElement tinyMCEframeLocator, IWebElement tinyMCEtextAreaBodyLocator)
        {
            StreamReader streamReader = new StreamReader(txtPath);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            driver.SwitchTo().Frame(tinyMCEframeLocator);
            js.ExecuteScript("arguments[0].innerHTML = \"" + streamReader.ReadToEnd() + "\";", tinyMCEtextAreaBodyLocator);
            driver.SwitchTo().DefaultContent();
        }


        public void uploadPicture(string filePath, IWebElement uploadArea)
        {
            uploadArea.Clear();
            uploadArea.SendKeys(filePath);
        }


    }
}
