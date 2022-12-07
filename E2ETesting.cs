using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using AngleSharp.Text;
using System.Diagnostics.Metrics;

namespace SeleniumLearning
{
    public class E2ETesting
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

        public void EndtoEndFlow()
        {
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            driver.FindElement(By.Id("signInBtn")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            String[] expectedProducts = {"iphone X" , "Blackberry" };
            String[] actualProducts = new string[2];

            IList<IWebElement> product = driver.FindElements(By.TagName("app-card"));

            foreach(IWebElement productElement in product)
            {
                if (expectedProducts.Contains(productElement.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    // click card 
                    productElement.FindElement(By.CssSelector(".card-footer button")).Click();
                }

                TestContext.Progress.WriteLine(productElement.FindElement(By.CssSelector(".card-title a")).Text);
            }

            driver.FindElement(By.PartialLinkText("Checkout")).Click();

            IList<IWebElement> cartproducts = driver.FindElements(By.CssSelector("h4 a"));

            for(int i = 0; i < cartproducts.Count; i++)
            {
                actualProducts[i] = cartproducts[i].Text;
            }

            Assert.AreEqual(expectedProducts, actualProducts);
            driver.FindElement(By.CssSelector(".btn-success")).Click();
            driver.FindElement(By.Id("country")).SendKeys("united");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("United States of America")));
            driver.FindElement(By.LinkText("United States of America")).Click();
            driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            driver.FindElement(By.CssSelector("[value='Purchase']")).Click();
            var confirmText = driver.FindElement(By.CssSelector(".alert-success")).Text;
            StringAssert.Contains("Success", confirmText);




        }

        //[TearDown]
        //public void CloseBrowser()
        //{
        //    driver.Close();
        //}


















    }
}
