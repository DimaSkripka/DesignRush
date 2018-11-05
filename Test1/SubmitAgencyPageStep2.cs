﻿using System.Threading;
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
    public class SubmitAgencyPageStep2
    {
        private readonly IWebDriver driver;
        public WebDriverWait wait;
        //PhantomJSDriver jSDriver = new PhantomJSDriver();
        


        public SubmitAgencyPageStep2(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Name, Using = "agency_logo")]
        public IWebElement agencyLogoUpload { get; set; }

        [FindsBy(How = How.Id, Using = "tinymce")]
        public IWebElement agencyDescriptionContent { get; set; }

        //переделать, сделать метод для сбора всех полей, метод перебора и заполнения рандомными данными и сохранениями их в переменные для сравнения
        [FindsBy(How = How.Name, Using = "key_clients[0][title]")]
        public IWebElement clientField0 { get; set; }

        [FindsBy(How = How.Name, Using = "key_clients[1][title]")]
        public IWebElement clientField1 { get; set; }

        [FindsBy(How = How.Name, Using = "key_clients[2][title]")]
        public IWebElement clientField2 { get; set; }

        [FindsBy(How = How.Name, Using = "photo_1")]
        public IWebElement contentSection0 { get; set; }

        [FindsBy(How = How.Name, Using = "photo_2")]
        public IWebElement contentSection1 { get; set; }

        [FindsBy(How = How.Name, Using = "photo_3")]
        public IWebElement contentSection2 { get; set; }


        public void fillClient(string client0, string client1, string client2)
        {
            this.clientField0.Clear();
            this.clientField0.SendKeys(client0);

            this.clientField1.Clear();
            this.clientField1.SendKeys(client1);

            this.clientField2.Clear();
            this.clientField2.SendKeys(client2);
        }

        public void tinyMCE()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.SwitchTo().Frame("agency_description_ifr");
            js.ExecuteScript("arguments[0].innerHTML = '<h1>CKEditor</h1>Yi Zeng'", agencyDescriptionContent);
        }


        public void uploadLogo(string filePath)
        {
            this.agencyLogoUpload.Clear();
            this.agencyLogoUpload.SendKeys(filePath);
        }

        public void uploadContent (string filePath1, string filePath2, string filePath3)
        {
            this.contentSection0.Clear();
            this.contentSection0.SendKeys(filePath1);
            Thread.Sleep(1000);

            this.contentSection1.Clear();
            this.contentSection1.SendKeys(filePath2);
            Thread.Sleep(1000);

            this.contentSection2.Clear();
            this.contentSection2.SendKeys(filePath2);

        }

        

        //public void test()
        //{
        //    driver.SwitchTo().Frame(0);
        //    driver.FindElement(By.Id("agency_description_ifr")).FindElement(By.Id("tinymce"));
        //    driver.FindElement(By.Name("key_clients[0][title]")).Click();
        //}

        //public void fillDesc(string content)
        //{
        //    this.agencyDescriptionSection.Click();
        //    this.agencyDescriptionContent.Clear();
        //    this.agencyDescriptionContent.SendKeys(content);
        //}
    }
}