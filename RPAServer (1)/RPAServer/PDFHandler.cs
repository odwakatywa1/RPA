/*using IronPdf;
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

            return id.ToString();
        }

        public int ClosePDF(string id)
        {
            GlobalObject global = GlobalObject.Instance;

            PdfDocument document = null;

            Object tempObject;

            global.fileIndex.TryGetValue(id, out tempObject);

            if (tempObject is PdfDocument)
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

            if (tempObject is PdfDocument)
            {
                document = (PdfDocument)tempObject;
            }
            else
            {
                return "";
            }

            return document.ExtractTextFromPage(0);
        }

    }
}*/
