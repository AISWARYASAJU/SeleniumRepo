using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitAss
{
    [TestFixture]
   
    internal class NaaptolTests: CoreCode
    {
        [Test]
        [Description("Check for search box")]
        public void SearchBoxTest()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";




            driver.FindElement(By.ClassName("srchInput header_search_text ui-autocomplete-input"));
            IWebElement searchInput = fluentWait.Until(driv => driv.FindElement(By.ClassName("Pke_EE")));



            searchInput.SendKeys("eye wear");
            searchInput.SendKeys(Keys.Enter);
        }


    }
}
