using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
     class FirtstTestCase
    {
        IWebDriver driver;

        [SetUp]

        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new ChromeDriver();
            //driver = new EdgeDriver();
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
           
        }

        [Test]

        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);

        }

        //[TearDown]
        //public void CloseBrowser()
        //{
        //    driver.Close();
        //}



    }
}
