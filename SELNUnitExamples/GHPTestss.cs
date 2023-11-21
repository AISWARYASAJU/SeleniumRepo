using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELNUnitExamples
{
    [TestFixture] //contain more than 1 test inside
    internal class GHPTestss : CoreCodes
    {
        [Ignore("others")]
        [Test]
        [Order(10)]
        public void TitleTest()
        {
            Thread.Sleep(2000); // To wait (10 seconds), only for viewing purpose .Should not include in the final code.
           
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title test - Pass");
        }
        [Ignore("others")]
        [Test]
        [Order(20)]
        public void GoogleSearchTest()
        {
            IWebElement searchInputBox = driver.FindElement(By.Id("APjFqb"));
            searchInputBox.SendKeys("hp laptops"); //to type inside the text box
            Thread.Sleep(5000);
            IWebElement googleSearchButton = driver.FindElement(By.ClassName("gNO89b"));
            //Name("btnK"));
            googleSearchButton.Click();
            Assert.AreEqual("hp laptops - Google Search", driver.Title);
            Console.WriteLine("GoogleSearchTest - Pass");
        }
        [Ignore("others")]
        [Test]
        public void AllLinksStatusTest()
        {
            List<IWebElement> allLinks = driver.FindElements(By.TagName("a")).ToList();
            foreach (var link in allLinks)
            {
              string url  = link.GetAttribute("href");
              if(url == null)
                {
                    Console.WriteLine("Url is null");
                    continue;
                }
                else
                {
                    bool isworking = CheckLinkStatus(url);
                    if (isworking)
                    
                        Console.WriteLine(url + "is working ");
                        else
                        Console.WriteLine(url + "is NOT working ");
                
                }
            }
        }
    }
}
