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
    public class SubmitAgencyPage
    {
        private readonly IWebDriver driver;
        public WebDriverWait wait;

        private readonly string url = @"http://designrush.devplatform2.com/submit/agency/step/1";


        public SubmitAgencyPage(IWebDriver browser)
        {
            this.driver = browser;
            this.driver.Manage().Window.Maximize();
            PageFactory.InitElements(browser, this);
        }


        [FindsBy(How = How.Name, Using = "first_name")]
        public IWebElement nameField { get; set; }

        [FindsBy(How = How.Name, Using = "last_name")]
        public IWebElement lastNameField { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement emailField { get; set; }

        [FindsBy(How = How.Name, Using = "phone")]
        public IWebElement phoneField { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement passwordField { get; set; }

        [FindsBy(How = How.Name, Using = "password_confirmation")]
        public IWebElement passwordConfirmationField { get; set; }

        [FindsBy(How = How.ClassName, Using = "step-btn")]
        public IWebElement submitButton { get; set; }


        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }


        public void SubmitStep(string name, string lastname, string email, string phone, string password, string passwordConfirmation)
        {
            HelperClass helper = new HelperClass(this.driver);

            this.nameField.Clear();
            this.nameField.SendKeys(helper.GenerateRandomData());

            this.lastNameField.Clear();
            this.lastNameField.SendKeys(helper.GenerateRandomData());

            this.emailField.Clear();
            this.emailField.SendKeys(helper.GenerateRandomEmail());

            this.phoneField.Clear();
            this.phoneField.SendKeys(phone);

            this.passwordField.Clear();
            this.passwordField.SendKeys(password);

            this.passwordConfirmationField.Clear();
            this.passwordConfirmationField.SendKeys(passwordConfirmation);

            //прописать асерт метод в хелпере
            this.submitButton.Click();
        }
        
    }
}
