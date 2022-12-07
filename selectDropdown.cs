using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class selectDropdown
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

        public void Dropdownhandle()
        {

          IWebElement dropdown =   driver.FindElement(By.CssSelector("select.form-control"));

            SelectElement element = new SelectElement(dropdown);
            element.SelectByText("Teacher");
            element.SelectByValue("consult");
            element.SelectByIndex(0);

            // aviding using index of elements in css using foreach with if condition 

            IList<IWebElement> radio = driver.FindElements(By.CssSelector("input[type='radio']"));

            foreach (IWebElement radioElement in radio)
            {
                if (radioElement.GetAttribute("value").Equals("user")){

                    radioElement.Click();
                }
               
            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.Id("okayBtn")).Click();
            Boolean selecteduser = driver.FindElement(By.Id("usertype")).Selected;
            // for boolen validation we use assert.that 
            Assert.That(selecteduser, Is.False);
            


        }

        //[TearDown]
        //public void CloseBrowser()
        //{
        //    driver.Close();
        //}
















    }
}
