using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using System.Collections;

namespace SeleniumLearning
{
    public  class SortWebTables
    {

        IWebDriver driver;

        [SetUp]

        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";

        }

        [Test]

        public void sortWebTablesScenario()
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByValue("20");

            // step1 - Get all vegie names into arrayList

            ArrayList aList = new ArrayList();

            IList<IWebElement> veggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement veggieEl in veggies)
            {
                aList.Add(veggieEl.Text);
                
            }

            // step2 - sort arrayList - A

            foreach (String vegiEl in aList)
            {
                // before sort 
                TestContext.Progress.WriteLine(vegiEl);
            }

            aList.Sort();
            foreach (String vegiEl in aList)
            {
                // after sort 
                TestContext.Progress.WriteLine(vegiEl);
            }


            // step3 - click on column list 
            //-- css element th[aria-label*='fruit name']
            //-- xpath element  //th[contains(@aria-label,'fruit name')]
            driver.FindElement(By.CssSelector("th[aria-label*='fruit name']")).Click();

            // step4 - get all vagie names into arrays list - B 

            ArrayList blist = new ArrayList();

            IList<IWebElement> sveggie = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach(IWebElement sveggieEl in sveggie)
            {
                blist.Add(sveggieEl.Text);
            }

            // step5 - make compare A - B 
             Assert.AreEqual(aList,blist);






        }

        //[TearDown]
        //public void CloseBrowser()
        //{
        //    driver.Close();
        //}
























    }
}
