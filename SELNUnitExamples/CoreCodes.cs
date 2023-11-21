using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Network;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SELNUnitExamples
{
    internal class CoreCodes
    {
        Dictionary<string, string>? properties;
        public IWebDriver driver;


        public void ReadConfigSettings() {
            string currDir = Directory.GetParent(@"../../../").FullName;
            properties = new Dictionary<string, string>();
            string fileName = currDir + "/configsettings/config.properties";
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }
        }
        public bool CheckLinkStatus(string url)
        {
            try
            {
                var request = (System.Net.HttpWebRequest)
                    System.Net.WebRequest.Create(url);
            

            request.Method = "HEAD";
            using (var response = request.GetResponse()) 
            {
                return true;
            } }
           catch{
        return false;
        }}


        [OneTimeSetUp]
        public void InitializwBrowser() 


            {
            ReadConfigSettings();
                if (properties["browser"].ToLower() == "chrome" )
            {
                driver = new ChromeDriver();

            }
            else if (properties["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();

            }
            driver.Url = properties["baseUrl"];
            driver.Manage().Window.Maximize();


        }

        [OneTimeTearDown] 
        public void Cleanup() {
            driver.Quit();

              }

        public void TakeScreenshot()
        {
            ITakesScreenshot iss = (ITakesScreenshot)driver;
            Screenshot ss = iss.GetScreenshot(); //open QA selenium
            string currdir = Directory.GetParent(@"../../../").FullName;
            string filepath = currdir + "/Screenshots/ss_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            ss.SaveAsFile(filepath);


        }
    }
}
