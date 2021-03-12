using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Base;
using Test.Helpers;
namespace Test.Pages
{
    public class Women
    {
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement womenlink { get; set; }
 
        public Women()
        {
            PageFactory.InitElements(DriverContext.GetDriver<IWebDriver>(), this);
        }
       



    }
}
