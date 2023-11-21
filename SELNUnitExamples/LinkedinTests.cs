using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELNUnitExamples
{
    [TestFixture]
    internal class LinkedinTests: CoreCodes
    {
        [Test]
        [Author("AISWARYA", "aiswarya.com")]
        [Description("checked for Valid Login")]
        [Category("Regression Testing")]
        public void Login1Test()
        {
            //driver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(3);
            //WebDriverWait wait= new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));
            //driver.FindElement(By.Id("session_key"));
            // IWebElement passwordInput= wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));
            //IWebElement emailInput = wait.Until(driv=> driv.FindElement(By.Id("session_key")));//till 
            //IWebElement passwordInput = wait.Until(driv => driv.FindElement(By.Id("session_password")));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout= TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";




            IWebElement emailInput = fluentWait.Until(driv=> driv.FindElement(By.Id("session_key")));//till 
            IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));



            emailInput.SendKeys("aiswar@ya.com");
            passwordInput.SendKeys("123");

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);// instead of thr.sleep



        }


        //[Test]
        //[Author("AISWARYA", "aiswarya.com")]
        //[Description("checked for inValid Login")]
        //[Category("Smoke Testing")]
        //public void Login2Test()//INVALID
        //{
        ////    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        ////    fluentWait.Timeout = TimeSpan.FromSeconds(5);
        ////    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
        ////    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        ////    fluentWait.Message = "Element Not Found";




        ////    IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));//till 
        ////    IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));



        //    emailInput.SendKeys("aiswar@ya.com");
        //    passwordInput.SendKeys("123");
        //    Thread.Sleep(3000);
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);



        //    emailInput.SendKeys("aiswaasaqar@ya.com");
        //    passwordInput.SendKeys("123123");
        //    Thread.Sleep(3000);
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);

        //    emailInput.SendKeys("aiswaasaqwweqar@ya.com");
        //    passwordInput.SendKeys("123188823");
        //    Thread.Sleep(3000);
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);

        //    Thread.Sleep(3000);


        //}
        void ClearForm(IWebElement element)
        {
            element.Clear();
        }

        //       [Test]
        //        [Author("AA", "AAA.com")]
        //        [Description("checked for InValid Login")]
        //        [Category("Regression Testing")]
        //        [TestCase("aiswar@ya.com","123")]
        //        [TestCase("aiswaasaqar@ya.com", "123")]
        //        [TestCase("123123", "123188823")]

        //        public void LoginWithInvalidCred(string email, string pwd)
        //        {
        //            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        //                fluentWait.Timeout = TimeSpan.FromSeconds(5);
        //                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
        //                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //                fluentWait.Message = "Element Not Found";




        //                IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
        //               IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));

        //            emailInput.SendKeys(email);
        //            passwordInput.SendKeys(pwd);
        //            ClearForm(emailInput);
        //            ClearForm(passwordInput);

        //            Thread.Sleep(TimeSpan.FromSeconds(5));


        //        }
        //    } 
        //}

        [Test]
        [Author("AA", "AAA.com")]
        [Description("checked for InValid Login")]
        [Category("Regression Testing")]
        [TestCaseSource(nameof(InvalidLoginData))]

        public void LoginWithInvalidCred(string email, string pwd)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";




            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));

            emailInput.SendKeys(email);
            passwordInput.SendKeys(pwd);
            TakeScreenshot();// call before clear the form

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", // scrollIntoView To scroll a page
                driver.FindElement(By.XPath("//button[@type='submit']")));

            // ClearForm(emailInput);
            Thread.Sleep(5000);
            js.ExecuteScript("arguments[0].click();",
               driver.FindElement(By.XPath("//button[@type='submit']")));

            ClearForm(emailInput);
            ClearForm(passwordInput);

            //Thread.Sleep(TimeSpan.FromSeconds(5));


        }

        static object[] InvalidLoginData()
        {
            return new object[]
            {
                new object[] {"abc@xyz.com","1234"},
                 new object[] {"abc@xyz.com","1234"},



            };
        }
       /* public void TakeScreenshot()
        {
            ITakesScreenshot iss = (ITakesScreenshot)driver;
            Screenshot ss= iss.GetScreenshot(); //open QA selenium
            string currdir = Directory.GetParent(@"../../../").FullName;
            string filepath = currdir + "/Screenshots/ss_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            ss.SaveAsFile(filepath);


        }*/
    }
}



