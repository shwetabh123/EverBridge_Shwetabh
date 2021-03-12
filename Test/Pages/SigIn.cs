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
using Test.Config;
using Test.Helpers;
namespace Test.Pages
{
   public class SigIn
    {
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement SigInbutton { get; set; }
    
       


        public SigIn()
        {
            PageFactory.InitElements(DriverContext.GetDriver<IWebDriver>(), this);
        }
     
  

    }
    }
