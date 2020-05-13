using IronPdf;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreServer
{
    class PDFHandler
    {
        public string OpenPDF(string path)
        {
            PdfDocument document = null;

            document = PdfDocument.FromFile(path);
            
            GlobalObject global = GlobalObject.Instance;

            Guid id = Guid.NewGuid();

            global.fileIndex.Add(id.ToString(), document);

            System.Diagnostics.Process.Start(path);


            //Console.WriteLine("ID Added : " + id.ToString());

            return id.ToString();
            
        }

        public int ClosePDF(string id)
        {
            GlobalObject global = GlobalObject.Instance;

            PdfDocument document = null;

            Object tempObject;

            global.fileIndex.TryGetValue(id, out tempObject);

            //if (tempObject is PdfDocument)
            if(id.Substring(id.Length-3, 3).Equals("pdf")) //Check the extension
            {
                document = (PdfDocument)tempObject;
            }
            else
            {
                return Result.NOK;
            }

            document = null;

            global.fileIndex.Remove(id);

            return Result.OK;
        }

        public string ReadTextFromPage(string id, int page)
        {
            GlobalObject global = GlobalObject.Instance;

            PdfDocument document = null;

            Object tempObject;

            global.fileIndex.TryGetValue(id, out tempObject);

            if(tempObject == null)
            {
                Console.WriteLine("The object is NULL");
            }


            //if(id.Substring(id.Length-3, 3).Equals("pdf")) //Check the extension
            if (tempObject is PdfDocument)
            {
                document = (PdfDocument)tempObject;
            }
            else
            {
                return "";
            }

            //return document.ExtractTextFromPage(0);
            return document.ExtractTextFromPage(page - 1);
        }

    }
}
