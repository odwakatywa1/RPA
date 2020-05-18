using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace CoreServer
{
    public class ExcelHandler
    {
        public string CreateExcelDocument(string fileName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var fileInfo = new FileInfo(@fileName);

            var excelFile = new ExcelPackage(fileInfo);

            excelFile.Workbook.Worksheets.Add("Sheet1");

            GlobalObject global = GlobalObject.Instance;

            Guid id = Guid.NewGuid();

            global.fileIndex.Add(id.ToString(), excelFile);
            excelFile.Save();

            return id.ToString();
        }

        public int SaveExcelDocument(string id)
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            GlobalObject global = GlobalObject.Instance;

            ExcelPackage excelFile;


            Object tempObject;

            global.fileIndex.TryGetValue(id, out tempObject);

            if (tempObject is ExcelPackage)
            {
                excelFile = (ExcelPackage)tempObject;
                excelFile.Save();
                return Result.OK;
            }
            else
            {
                return Result.NOK;
            }
        }


        public string OpenExcelDocument(string filename)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            FileInfo fileInfo = new FileInfo(@filename);

            ExcelPackage excelFile = new ExcelPackage(fileInfo);



            GlobalObject global = GlobalObject.Instance;

            Guid id = Guid.NewGuid();

            global.fileIndex.Add(id.ToString(), excelFile);

            return id.ToString();

        }
        public int writeExcelDocument(string id, string cell, string value)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            GlobalObject global = GlobalObject.Instance;

            ExcelPackage excelFile;


            Object tempObject;

            global.fileIndex.TryGetValue(id, out tempObject);

            if (tempObject is ExcelPackage)
            {
                excelFile = (ExcelPackage)tempObject;
                ExcelWorksheet worksheet = excelFile.Workbook.Worksheets["Sheet1"];

                //get worksheet by name
                //ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["Sheet1"];



                worksheet.Cells[cell].Value = value;
                return Result.OK;

                //excelPackage.Save();

            }
            else
            {
                return Result.NOK;
            }


        }
        public string ReadDataExcelDocument(string id, string cell)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            GlobalObject global = GlobalObject.Instance;

            ExcelPackage excelFile;


            Object tempObject;

            global.fileIndex.TryGetValue(id, out tempObject);

            if (tempObject is ExcelPackage)
            {
                excelFile = (ExcelPackage)tempObject;
                try
                {
                    ExcelWorksheet worksheet = excelFile.Workbook.Worksheets["Sheet1"];
                    string valueA1 = worksheet.Cells[cell].Value.ToString();
                    return valueA1;
                }
                catch (Exception e)
                {
                    return "";
                }
                //get worksheet by name
                //ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["Sheet1"];

            }
            else
            {
                return "";
            }


        }


    }
}