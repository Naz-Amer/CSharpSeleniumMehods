using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace SeleniumLearning
{
    internal class AutoSuggestedDropdown
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

        public void autoSuggestDropDown()
        {


            driver.FindElement(By.Id("autocomplete")).SendKeys("us");
            Thread.Sleep(10);

            IList<IWebElement> contlist = driver.FindElements(By.CssSelector(".ui-menu-item div"));

            foreach (IWebElement element in contlist)
            {
                if (element.Text.Equals("United States (USA)")){

                    element.Click();
                }

            }

           TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));


            //driver.FindElement(By.Id("dropdown-class-example")).Click();
            //IWebElement dropdown = driver.FindElement(By.Id("dropdown-class-example"))
            //SelectElement delement = new SelectElement(dropdown);
            //delement.SelectByValue("option1");
           


        }





        //[TearDown]
        //public void CloseBrowser()
        //{
        //    driver.Close();
        //}




















    }
}
