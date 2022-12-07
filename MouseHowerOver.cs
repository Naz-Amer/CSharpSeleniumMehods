using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;

namespace SeleniumLearning
{
    public  class MouseHowerOver
    {

        IWebDriver driver;

        [SetUp]

        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/#/index";

        }

        [Test]

        public void test_Actions()
        {
            Actions ac = new Actions(driver);
            ac.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
            driver.FindElement(By.XPath("//a[contains(text(),'About us')]")).Click();
            //ac.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a"))).Click().Perform();





        }


















        //[TearDown]
        //public void CloseBrowser()
        //{
        //    driver.Close();
        //}























    }
}
