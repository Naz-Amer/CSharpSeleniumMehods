using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    internal class HIframe
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

        public void HandlingIframe()
        {
            // scroll to element
            IWebElement frameScroll = driver.FindElement(By.Id("courses-iframe"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", frameScroll);

            // click iframe with id,name,index
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.LinkText("All Access Plan")).Click();
            //TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);

            // switch out to parent page 
            driver.SwitchTo().DefaultContent();
            //TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
        }








    }
}
