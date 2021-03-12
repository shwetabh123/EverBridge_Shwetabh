using System;
using System.Configuration;
using System.Xml.XPath;
using System.IO;
namespace Test.Config
{
    public class ConfigReader
    {
        public static string logFilePath = ConfigurationManager.AppSettings["logFilePath"].ToString();
        public static string downloadFilepath = ConfigurationManager.AppSettings["downloadFilepath"].ToString();
        public static string TestDataFilepath = ConfigurationManager.AppSettings["TestDataFilepath"].ToString();
        public static int srow = Int32.Parse(ConfigurationManager.AppSettings["srow"].ToString());
        public static int erow = Int32.Parse( ConfigurationManager.AppSettings["erow"].ToString());
        public static string GetUrl = ConfigurationManager.AppSettings["Url"].ToString();
        public static string GetBrowser = ConfigurationManager.AppSettings["Browser"].ToString();
     
        public static string GetDBPassword = ConfigurationManager.AppSettings["DBPassword"].ToString();
        public static string GetDBUserName = ConfigurationManager.AppSettings["DBUserName"].ToString();
        public static int GetElementLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings["ElementLoadTimeout"].ToString();
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }
        public static int GetPageLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings["PageLoadTimeout"].ToString();
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }
    
    }
}
