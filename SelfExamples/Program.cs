
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SelfExamples;

//GHTests gHTests = new GHTests();
List<string> drivers = new List<string>();
//drivers.Add("Edge");
drivers.Add("Chrome");

foreach (var d in drivers)
{
    AmazonTests az = new AmazonTests();
    switch (d)
    {

        case "Edge":
            az.InitializeEdgeDriver(); break;
        case "Chrome":
            az.InitializeChromeDriver(); break;
    }


    //            console.writeline("1.edge 2.chrome");
    //            int ch = convert.toint32(console.readline());
    //            switch (ch)
    //            {
    //                case 1:
    //                    ghtests.initializeedgedriver(); break;
    //                case 2:
    //                    ghtests.initializechromedriver(); break;
    ////            }*/
    try
    {

        //az.TitleTest();
        //az.LogoClickTest();
        //Thread.Sleep(2000);
        //az.SearchProductTest();
        //Thread.Sleep(2000);
        //az.ReloadHomePage();
        //az.TodaysDealsTes();
        //az.SignInAccListTest();
        //az.SearchAndFilterProductByBrandTest();
        az.SortBySelectTest();

    }

    catch (AssertionException)
    {
        Console.WriteLine("Fail");
    }
    catch(NoSuchElementException nse)
    {
        Console.WriteLine(nse.Message);
    }




    az.Destruct();
}
