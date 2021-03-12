using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Base;
using Test.Config;
using Test.Pages;
namespace Test.TestClasses
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class TestContactUs : BaseClass
    {
        public TestContactUs() : base(BrowserType.Chrome)
        {
        }
        //Nunit
        [Test, Category("Smoke"), Order(1)]
        public void SubmitFormwithMessage()
        {
            int srow = ConfigReader.srow;
            int erow = ConfigReader.erow;
            for (int i = srow; i <= erow; i++)
            {
                try
                {
                    DriverContext.InitDriver(_browsertype);
                    ContactUs c = new ContactUs();
                    c.FillFormwithMessage(i);
                    Thread.Sleep(5000);
                    DriverContext.CloseDriver();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }
        [Test, Category("Smoke"), Order(2)]
        public void SubmitFormwithoutMessage()
        {
            int srow = ConfigReader.srow;
            int erow = ConfigReader.erow;
            for (int i = srow; i <= erow; i++)
            {
                try
                {
                    DriverContext.InitDriver(_browsertype);
                    ContactUs c = new ContactUs();
                    c.FillFormwithoutMessage(i);
                    Thread.Sleep(5000);
                    DriverContext.CloseDriver();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }
    }
}
