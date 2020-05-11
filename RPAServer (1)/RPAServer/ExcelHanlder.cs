using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
            }
            else
            {
                return Result.NOK;
            }

            excelFile.Save();

            return Result.OK;
        }
    }
}
