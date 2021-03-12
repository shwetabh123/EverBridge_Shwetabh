

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using Test.Config;

namespace Test.Base
{


    [TestFixture]


    public class BaseClass

    {
        public static ExtentReports extent;
        public static ExtentTest test;
        public static ExtentHtmlReporter htmlReporter;
 
        public BrowserType _browsertype;


        //using enumerator
        public BaseClass(BrowserType browser)
        {
            _browsertype = browser;
        }
        //public BaseClass(string browser)
        //{
        //    browser = ConfigReader.GetBrowser;
        //}
        public static FirefoxProfile GetFirefoxptions()
        {
            FirefoxProfile profile = new FirefoxProfile();
            FirefoxProfileManager manager = new FirefoxProfileManager();
            profile = manager.GetProfile("default");
            //  Logger.Info(" Using Firefox Profile ");
            return profile;
        }
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            //option.AddArgument("--headless");
            //option.AddExtension(@"C:\Users\rahul.rathore\Desktop\Cucumber\extension_3_0_12.crx");
            //  Logger.Info(" Using Chrome Options ");
            return option;
        }
        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            options.EnablePersistentHover = true;
            options.EnableNativeEvents = true;
            options.RequireWindowFocus = true;
            options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
            //   Logger.Info(" Using Internet Explorer Options ");
            return options;
        }
  
        public static ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }
        public static InternetExplorerDriver GetIEDriver()
        {
            InternetExplorerDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }

        public static string Capture(string ScreenShotName)
        {
            DateTime dt = DateTime.Now; // Or whatever
            string dateName = dt.ToString("yyyyMMddHHmmss");
            ITakesScreenshot ts = (ITakesScreenshot)DriverContext.GetDriver<IWebDriver>();
            Screenshot Screenshot = ts.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string uptobinpath = path.Substring(0, path.LastIndexOf("bin")) + "Screenshots\\" + ScreenShotName + dateName + ".png";
            //    +DateTime.Now.ToString(“Dd_MMMM_hh_mm_ss_tt”) + “.Png”;
            string localpath = new Uri(uptobinpath).LocalPath;
            Screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }
    

        [SetUp]


        public void BeforeTest()
        {
           
        }



        //MSTest
        // [ClassCleanup]
        //  [AssemblyCleanup]
        //NUnit
        [OneTimeTearDown]

        public static void ExtentClose()
        {

            //Close all connections to extent reports

          //  BaseClass.extent.Flush();


        }
    }
}
