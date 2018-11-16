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

        /*use in cases when page has similar drop-downs on page*/
        public void setRandomForAllDropDowns(IList<IWebElement> spanList)
        {
            foreach (var item in spanList)
            {
                item.Click();
                SelectRandomLi("select2-results__options", "li");
            }
        }

        public string GenerateRandomData()
        {
            int rndValue = rnd.Next(1000000);
            var someRandomData = "someData" + rndValue;
            return someRandomData;
        }

        public string GenerateRandomUrl()
        {
            int rndValue = rnd.Next(1000000);
            string randomUrl = "https://randomUrl" + rndValue + ".com";
            return randomUrl;
        }

        public string GenerateRandomEmail()
        {
            int rndValue = rnd.Next(1000000);
            string randomEmail = "randomemail" + rndValue + "@random.com";
            return randomEmail;
        }

        public void InsertKeys()
        {
            
        }

        public void setLocation(IWebElement spanValueField)
        {
            spanValueField.Click();
            List<IWebElement> li = new List<IWebElement>(driver
                .FindElement(By.ClassName("select2-results"))
                .FindElements(By.TagName("li")));
            li[0].Click();

            List<IWebElement> list = new List<IWebElement>(driver.FindElements(By.ClassName("select2-selection__rendered")));
            for (int i = 0; i < list.Count; i++)
            {
                string spanValue = spanValueField.Text;
                if (spanValue != "Select")
                {
                    list.RemoveAt(i);
                    i --;
                }
            }

            IList<IWebElement> secList = driver.FindElements(By.ClassName("select2-selection"));
            foreach (var item in secList)
            {
                item.Click();
                List<IWebElement> lis = new List<IWebElement>(driver
                .FindElement(By.ClassName("select2-results"))
                .FindElements(By.TagName("li")));
                lis[0].Click();
            }
        }
    }
}
