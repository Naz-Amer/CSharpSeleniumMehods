using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class HandleAlertPopUp
    {
        IWebDriver driver;

        [SetUp]

        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";

        }

        [Test]

        public void HendlePopUp()
        {
            String name = "Test";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);
            driver.FindElement(By.CssSelector("#confirmbtn")).Click();
            String alert = driver.SwitchTo().Alert().Text;
            TestContext.Progress.WriteLine(alert);
            //driver.SwitchTo().Alert().Dismiss();
            driver.SwitchTo().Alert().Accept();

            StringAssert.Contains(name,alert);


           







        }

        //[TearDown]
        //public void CloseBrowser()
        //{
        //    driver.Close();
        //}





























    }
}
