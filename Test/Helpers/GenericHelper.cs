using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Test.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workbook = Aspose.Cells.Workbook;
using Worksheet = Aspose.Cells.Worksheet;
using System.Diagnostics;
using Test.Config;
namespace Test.Helpers
{
    public class GenericHelper
    {
        public static SelectElement select;
        public static string clipboardText;
        public static string latestfile = "";
        public static string downloadFilepath;
        public static string logFilePath;
        public static string folder = null;
        public static string filepath;
        public static string partiallogFilePath = "\\" + "Log-" + System.DateTime.Now.ToString("MM-dd-yyyy_HHmmss") +
                                                  "." + "txt";
        public static bool status = false;
        private static string existingWindowHandle;
        public static void Click(IWebDriver driver, string selector)
        {
            driver.FindElement(By.CssSelector(selector)).Click();
        }
        public static void Clickwithcssselector(IWebDriver driver, string selector)
        {
            driver.FindElement(By.CssSelector(selector)).Click();
        }
        public static void ClickwithID(IWebDriver driver, string ID)
        {
            driver.FindElement(By.Id(ID)).Click();
        }
        public static void ClickwithXapth(IWebDriver driver, string Xpath)
        {
            driver.FindElement(By.XPath(String.Format(Xpath))).Click();
        }
        public static void ClickwithXapth(IWebElement element)
        {
            element.Click();
        }
        public static void WaitforElement(IWebDriver driver, string xapth, int wait)
        {
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(wait));
            IWebElement element = w.Until(ExpectedConditions.ElementIsVisible(By.XPath(xapth)));
        }
        //use these 
        public static void WaitforElement(By locator, int wait)
        {
            WebDriverWait w = new WebDriverWait(DriverContext.GetDriver<IWebDriver>(), TimeSpan.FromSeconds(wait));
            IWebElement element = w.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public static void ExplicitWaitforElement(By locator, int wait)
        {
            try
            {
                WebDriverWait explicitwait = new WebDriverWait(DriverContext.GetDriver<IWebDriver>(), TimeSpan.FromSeconds(wait));
                explicitwait.PollingInterval = TimeSpan.FromMilliseconds(500);
                explicitwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                IWebElement element = explicitwait.Until(ExpectedConditions.ElementExists(locator));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
        public static void ExplicitWaitByXpath(By Xpathlocator, int wait)
        {
            try
            {
                WebDriverWait explicitwait = new WebDriverWait(DriverContext.GetDriver<IWebDriver>(), TimeSpan.FromSeconds(wait));
                explicitwait.PollingInterval = TimeSpan.FromMilliseconds(500);
                explicitwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                IWebElement element = explicitwait.Until(ExpectedConditions.ElementExists(Xpathlocator));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
            public static string getExcelSheetName(IWebDriver driver, String filepath, String fileName, String Index)
        {
            String SheetName = null;
            try
            {
                string s = null;
                Workbook wb = new Workbook(filepath + "\\" + fileName);
                int index = Int32.Parse(Index);
                int numberOfSheets = wb.Worksheets.Count;
                foreach (Worksheet worksheet in wb.Worksheets)
                {
                    if (worksheet.Index == (index))
                    {
                        SheetName = worksheet.Name;
                    }
                }
            }
            catch (Exception e)
            {
            }
            return SheetName;
        }
    }
}
