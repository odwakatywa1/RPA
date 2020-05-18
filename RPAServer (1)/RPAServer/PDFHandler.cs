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

            //System.Diagnostics.Process.Start(path);


            //Console.WriteLine("ID Added : " + id.ToString());

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
        //public string mergeDocuments(string path1, string path2)
        //{
        //    PdfDocument document1 = null;
        //    PdfDocument document2 = null;

        //    document1 = PdfDocument.FromFile(path1);
        //    document2 = PdfDocument.FromFile(path2);

        //    GlobalObject global = GlobalObject.Instance;

        //    Guid id = Guid.NewGuid();

        //    List<PdfDocument> pdfs = new List<PdfDocument>();

        //    pdfs.Add(document1);
        //    pdfs.Add(document2);

        //    PdfDocument mergedDoc = PdfDocument.Merge(pdfs);

        //    global.fileIndex.Add(id.ToString(), mergedDoc);

        //    return id.ToString();
        //}

        public string mergeDocuments(string id1, string id2)
        {

            GlobalObject global = GlobalObject.Instance;


            PdfDocument document1 = null;
            PdfDocument document2 = null;


            Object tempDoc1;
            Object tempDoc2;


            //Guid id = new Guid();



            global.fileIndex.TryGetValue(id1, out tempDoc1);
            global.fileIndex.TryGetValue(id2, out tempDoc2);


            if((tempDoc1 is PdfDocument) && (tempDoc2 is PdfDocument))
            {
                document1 = (PdfDocument)tempDoc1;
                document2 = (PdfDocument)tempDoc2;
            }




            PdfDocument mergedDoc = PdfDocument.Merge(document1, document2);

            //global.fileIndex.Add(id.ToString(), mergedDoc);

            //return id.ToString();

            Console.WriteLine("Page Count on Document 1: " + document1.PageCount);
            Console.WriteLine("Page Count on Document 2: " + document2.PageCount);

            Console.WriteLine("Page Count on Document Resulting from the Merge: " + mergedDoc.PageCount);

            return "SUCCESS";
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

            return document.ExtractTextFromPage(page - 1);
        }

        
    }
}
