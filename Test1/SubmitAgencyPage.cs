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
using System.IO;



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

        public void check()
        {
            StreamWriter streamWriter = new StreamWriter("C:/Users/skripka/Desktop/TestData/Test11.txt");
            try
            {
                var x = driver.FindElement(By.ClassName("form-stasdas22121eps--title"));
                x.ToString();
                x.Text.Contains("General Information");
            }
            catch (Exception ex)
            {
                    streamWriter.WriteLine(ex.ToString());
            }
        }
    }
}
