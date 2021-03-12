using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Base;
using Test.Config;

namespace Test.Pages
{
   public class TShirts

    {
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement TShirtslink { get; set; }


        public TShirts()
        {

            PageFactory.InitElements(DriverContext.GetDriver<IWebDriver>(), this);



        }


       

    }
}
