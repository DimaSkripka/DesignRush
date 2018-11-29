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


        //random generators 
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
        //random generators 



        public void selectElementWithScroll(IList<IWebElement> listWithLi)
        {
            int randomInt = rnd.Next(0, listWithLi.Count());

            bool isElementClicked = true;
            while (isElementClicked)
            {
                try
                {
                    listWithLi[randomInt].Click();
                    isElementClicked = false;
                }
                catch (Exception ex)
                {
                    Thread.Sleep(100);
                    driver.FindElement(By.ClassName("mCSB_buttonDown")).Click();
                }
            }
        }

        public void setLocation(IWebElement spanValueField)
        {

            spanValueField.Click();

            IList<IWebElement> li = driver
                .FindElement(By.ClassName("select2-results"))
                .FindElements(By.TagName("li"));

            selectElementWithScroll(li);


            List<IWebElement> list = new List<IWebElement>(driver.FindElements(By.ClassName("select2-selection__rendered")));
            for (int i = 0; i < list.Count; i++)
            {
                string spanValue = spanValueField.Text;
                if (spanValue != "Select")
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        public void getFieldsWithDynamicName()
        {
            IList<IWebElement> inputs = driver.FindElements(By.TagName("input"));

            IList<IWebElement> tt = new List<IWebElement>();

            foreach (var item in inputs)
            {
                if (item.GetAttribute("name").EndsWith("[address_1]"))
                {
                    tt.Add(item);
                    //var s = item;
                }
                else if (item.GetAttribute("name").EndsWith("[city]"))
                {
                    tt.Add(item);
                }
                else if (item.GetAttribute("name").EndsWith("[zip]"))
                {
                    tt.Add(item);
                }
                else if (item.GetAttribute("name").EndsWith("[email]"))
                {
                    tt.Add(item);
                }
            }
            tt[0].SendKeys("Gotcha!");
        }


        /*found element with specified tag by end part of element name*/

        public IWebElement getElementWithDynamicName(string tagName, string attributeName, string nameToFind)
        {
            IList<IWebElement> tagElements = driver.FindElements(By.TagName(tagName));

            foreach (var element in tagElements)
            {
                if (element.GetAttribute(attributeName).EndsWith(nameToFind))
                {
                   IWebElement newElement = element;
                    return newElement;
                }
            }
            return null;
        }
    }
}
