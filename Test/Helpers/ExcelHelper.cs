using Aspose.Cells;
using Excel;
using LumenWorks.Framework.IO.Csv;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Test.Config;
using Workbook = Aspose.Cells.Workbook;
using Worksheet = Aspose.Cells.Worksheet;
using xl = Microsoft.Office.Interop.Excel;
namespace Test.Helpers
{
    public class ExcelHelper



    {

        public static string clipboardText;
      
        public static string downloadFilepath;
        public static string logFilePath;
        public static string folder = null;
        public static string filepath;

      


        public static string latestfile = "";
        public string xlFilePath;
        xl.Application xlApp = null;
        xl.Workbooks workbooks = null;
        xl.Workbook workbook = null;
        Hashtable sheets;
        public ExcelHelper(string xlFilePath)
        {
            this.xlFilePath = xlFilePath;
        }
        public void OpenExcel()
        {
            xlApp = new xl.Application();
            workbooks = xlApp.Workbooks;
            workbook = workbooks.Open(xlFilePath);
            sheets = new Hashtable();
            int count = 1;
            // Storing worksheet names in Hashtable.
            foreach (xl.Worksheet sheet in workbook.Sheets)
            {
                sheets[count] = sheet.Name;
                count++;
            }
        }
        public void CloseExcel()
        {
            workbook.Close(false, xlFilePath, null); // Close the connection to workbook
            Marshal.FinalReleaseComObject(workbook); // Release unmanaged object references.
            workbook = null;
            workbooks.Close();
            Marshal.FinalReleaseComObject(workbooks);
            workbooks = null;
            xlApp.Quit();
            Marshal.FinalReleaseComObject(xlApp);
            xlApp = null;
        }
        public string getExcelSheetName(string xlFilePath,int index)
        {
            string strWorksheetName = "";
            try
            {
                xlApp = new xl.Application();
                workbooks = xlApp.Workbooks;
                workbook = workbooks.Open(xlFilePath);
                xl.Sheets sheets = workbook.Worksheets;
                xl.Worksheet worksheet = (xl.Worksheet)sheets.get_Item(index);
                strWorksheetName = worksheet.Name;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return strWorksheetName;
        }
     



        public string GetCellData(string sheetName, string colName, int rowNumber)
        {
            OpenExcel();

            string value = string.Empty;
            int sheetValue = 0;
            int colNumber = 0;

            if (sheets.ContainsValue(sheetName))
            {
                foreach (DictionaryEntry sheet in sheets)
                {
                    if (sheet.Value.Equals(sheetName))
                    {
                        sheetValue = (int)sheet.Key;
                    }
                }
                xl.Worksheet worksheet = null;
                worksheet = workbook.Worksheets[sheetValue] as xl.Worksheet;
                xl.Range range = worksheet.UsedRange;

                for (int i = 1; i <= range.Columns.Count; i++)
                {
                    string colNameValue = Convert.ToString((range.Cells[1, i] as xl.Range).Value2);

                    if (colNameValue.ToLower() == colName.ToLower())
                    {
                        colNumber = i;
                        break;
                    }
                }

                value = Convert.ToString((range.Cells[rowNumber, colNumber] as xl.Range).Value2);
                Marshal.FinalReleaseComObject(worksheet);
                worksheet = null;
            }
            CloseExcel();
            return value;
        }







    }
}



