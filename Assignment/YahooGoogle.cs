using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class YahooGoogle
    {
        IWebDriver? driver;
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver(); //browser will open automatically
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();
        }

        public void GoogleSearchTest()
        {
            IWebElement searchInputBox = driver.FindElement(By.Id("APjFqb"));
            searchInputBox.SendKeys("yahoo.com"); //to type inside the text box
            Thread.Sleep(5000);
            IWebElement googleSearchButton = driver.FindElement(By.ClassName("gNO89b"));
            //Name("btnK"));
            googleSearchButton.Click();
            Assert.AreEqual("yahoo.com - Google Search", driver.Title);
            Console.WriteLine("GoogleSearchTest - Pass");
            driver.Navigate().Back();
            driver.FindElement(By.LinkText("yahoo.com")).Click();
        }






        public void Destruct()
        {
            driver.Close();

        }

    }
}
