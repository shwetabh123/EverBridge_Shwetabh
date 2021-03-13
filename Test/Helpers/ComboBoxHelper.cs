using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Test.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Helpers
{
    public class ComboBoxHelper
    {



        private static SelectElement select;
   
       

        public static void SelectElementByText(IWebElement element, string visibletext)
        {
            select = new SelectElement(element);
            select.SelectByText(visibletext);
        }


        public static void SelectElementByText(By locator, string visibletext)
        {
            var dropdown = new SelectElement(DriverContext.GetDriver<IWebDriver>().FindElement(locator));
            dropdown.SelectByText(visibletext);
        }

        public static string SelectInDropDownByText(IWebElement element, string visibletext)
        {
            var dropdown = new SelectElement(element);
            dropdown.SelectByText(visibletext);

            return visibletext;
        }

        //public static void SelectElementByValue(By locator, string valueTexts)
        //{
        //    select = new SelectElement(GenericHelper.GetElement(locator));
        //    select.SelectByValue(valueTexts);
        //}


        public static void SelectElementByValue(By locator, string valueTexts)
        {
            select = new SelectElement(DriverContext.GetDriver<IWebDriver>().FindElement(locator));
            select.SelectByValue(valueTexts);
        }
        public static void SelectElementByValue(IWebElement element, string visibletext)
        {
            select = new SelectElement(element);
            select.SelectByValue(visibletext);
        }

    
       


    }
}
