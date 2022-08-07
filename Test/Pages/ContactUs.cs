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
   public  class ContactUs
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='id_contact']")]
        private IWebElement SubjectHeading { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='email']")]
        private IWebElement Emailaddress { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='id_order']")]
        private IWebElement OrderReference { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='submitMessage']/span")]
        private IWebElement Send { get; set; }
        [FindsBy(How = How.XPath, Using = " //*[@id='message']")]
        private IWebElement Message { get; set; }
        [FindsBy(How = How.XPath, Using = " //*[@id='center_column']/p[contains(.,'Your message has been successfully sent to our team.')]")]
        private IWebElement ConfirmationMessage { get; set; }

        [FindsBy(How = How.XPath, Using = " //*[@id='center_column']//li[contains(.,'The message cannot be blank.')]")]
        private IWebElement ErrorMessage { get; set; }

  



        public ContactUs()
        {
            PageFactory.InitElements(DriverContext.GetDriver<IWebDriver>(), this);
        }
        public void FillFormwithMessage(int i)
        {
            var path = Directory.GetCurrentDirectory();
            string fileName = path+ "\\Test\\Data\\TestData.xlsx";
         //   ExcelHelper eat = new ExcelHelper(fileName);
          //  string strWorksheetName = eat.getExcelSheetName(fileName, 1);
           // ComboBoxHelper.SelectInDropDownByText(SubjectHeading, eat.GetCellData(strWorksheetName, "SubjectHeading", i));
            ComboBoxHelper.SelectInDropDownByText(SubjectHeading, "Customer service1");
            Thread.Sleep(5000);
           // TextBoxHelper.ClearandTypeinTextBox(Emailaddress, eat.GetCellData(strWorksheetName, "Email address", i));
            TextBoxHelper.ClearandTypeinTextBox(Emailaddress, "shwetabh.srivastava@gmail.com");
            Thread.Sleep(5000);
            //TextBoxHelper.ClearandTypeinTextBox(OrderReference, eat.GetCellData(strWorksheetName, "Order Reference", i));
            TextBoxHelper.ClearandTypeinTextBox(OrderReference, "AAAA");
            Thread.Sleep(5000);
            TextBoxHelper.ClearandTypeinTextBox(Message, "This is with Reference to My Order");
            Thread.Sleep(5000);
            Send.Click();
            Thread.Sleep(5000);
            string ConfirmationMsg = ConfirmationMessage.Text;
            Thread.Sleep(5000);
            AssertHelper.AreEqual(ConfirmationMsg, "Your message has been successfully sent to our team.");
            Thread.Sleep(5000);
        }
        public void FillFormwithoutMessage(int i)
        {
            var path = Directory.GetCurrentDirectory();
            string fileName = path + "\\Test\\Data\\TestData.xlsx";
          //  ExcelHelper eat = new ExcelHelper(fileName);
          //  string strWorksheetName = eat.getExcelSheetName(fileName, 1);
          //  ComboBoxHelper.SelectInDropDownByText(SubjectHeading, eat.GetCellData(strWorksheetName, "SubjectHeading", i));
            ComboBoxHelper.SelectInDropDownByText(SubjectHeading, "Customer service1");
            Thread.Sleep(5000);
           // TextBoxHelper.ClearandTypeinTextBox(Emailaddress, eat.GetCellData(strWorksheetName, "Email address", i));
            TextBoxHelper.ClearandTypeinTextBox(Emailaddress, "shwetabh.srivastava@gmail.com");
            Thread.Sleep(5000);
          //  TextBoxHelper.ClearandTypeinTextBox(OrderReference, eat.GetCellData(strWorksheetName, "Order Reference", i));
            TextBoxHelper.ClearandTypeinTextBox(OrderReference, "AAAA");
            Thread.Sleep(5000);
            Send.Click();
            Thread.Sleep(5000);
            string ErrorMsg = ErrorMessage.Text;
            Thread.Sleep(5000);
            AssertHelper.AreEqual(ErrorMsg, "The message cannot be blank.");
            Thread.Sleep(5000);


        }
    }
}
