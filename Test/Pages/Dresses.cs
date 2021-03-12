using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Base;
using Test.Config;
using Test.Helpers;
namespace Test.Pages
{
    public class Dresses
    {
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement Dresseslink { get; set; }
        public Dresses()
        {
            PageFactory.InitElements(DriverContext.GetDriver<IWebDriver>(), this);
        }
 
     
         
        }
    }

