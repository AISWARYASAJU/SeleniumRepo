using Assignment;
using NUnit.Framework;

//AmazonTests a = new AmazonTests();
//a.InitializeChromeDriver();
//try
//{
//    a.TitleTest();
//    a.OrganizationTypeTest();

//}

//catch (AssertionException)
//{
//    Console.WriteLine("Fail");
//}

//a.Destruct();

AmazonTests a = new AmazonTests();
a.InitializeChromeDriver();
try
{
    a.TitleTest();
    a.OrganizationTypeTest();

}

catch (AssertionException)
{
    Console.WriteLine("Fail");
}

a.Destruct();

