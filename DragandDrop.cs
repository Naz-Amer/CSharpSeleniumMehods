using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    internal class DragandDrop
    {

        IWebDriver driver;

        [SetUp]

        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Url = "https://demoqa.com/droppable/";

        }

        [Test]

        public void test_DragAndDrop()
        {
            Actions drpdrag = new Actions(driver);
            drpdrag.DragAndDrop(driver.FindElement(By.Id("draggable")), driver.FindElement(By.Id("droppable"))).Perform();


                



        }


















        //[TearDown]
        //public void CloseBrowser()
        //{
        //    driver.Close();
        //}















    }
}
