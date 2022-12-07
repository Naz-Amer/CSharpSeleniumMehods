using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    internal class HandleChildWindows
    {

        IWebDriver driver;

        [SetUp]

        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }


        [Test]

        public void HandlingChildWindow()
        {
            var parentWindow = driver.CurrentWindowHandle;
            driver.FindElement(By.CssSelector(".blinkingText")).Click();
            // we can handle by using windowhandles method
           var wincount = driver.WindowHandles.Count();
            Assert.AreEqual(2, wincount);

            // switching to 2 window
            String childWindowName = driver.WindowHandles[1];
            driver.SwitchTo().Window(childWindowName);
            var email = "mentor@rahulshettyacademy.com";
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);

            var text = driver.FindElement(By.CssSelector(".red")).Text; // so we need to split the string 
            String[] splittedText = text.Split("at");
            String [] trimmedText = splittedText[1].Trim().Split(" ");
            Assert.AreEqual(email,trimmedText[0]);

            // switch to parent window
            driver.SwitchTo().Window(parentWindow);
            // pasting email from grapped test to parent window login input filed 
            driver.FindElement(By.Id("username")).SendKeys(trimmedText[0]);








        }















    }
}
