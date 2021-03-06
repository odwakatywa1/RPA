﻿using CoreServer;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

class Server
{
    TcpListener server = null;
    GlobalObject global = GlobalObject.Instance;

    public Server(string ip, int port)
    {
        //IPAddress localAddr = IPAddress.Parse(ip);
        //server = new TcpListener(localAddr, port);
        //server.Start();
        StartListener();
    }

    public void StartListener()
    {
        try
        {
            /*while (true)
            {
                //Console.WriteLine("Waiting for a connection...");
                //TcpClient client = server.AcceptTcpClient();
                //client.NoDelay = true;
                //client.SendBufferSize = 0;

                //Console.WriteLine("Connected!");

                //Thread t = new Thread(new ParameterizedThreadStart(CommandListener));
                //t.Start(client);
                
            }*/

            Thread t = new Thread(new ThreadStart(CommandListener));
            t.Start();
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
            //server.Stop();
        }
    }

    public string CommandHandler(string command)
    {
        // "COMMAND{\"EXCEL\";\"CREATE\";\"c:/log/testfile.xlsx\";}"

        string resultString = "RESULT{1}";

        string instruction = command.Substring(0, command.IndexOf("{"));

        if (instruction.Equals("COMMAND"))
        {
            // Now find out which program

            string tmpString = command.Substring(command.IndexOf("{"), command.Length - command.IndexOf("{"));
            string[] parameters = tmpString.Split(';');

            switch (Regex.Replace(parameters[0], "[^A-Za-z0-9 ]", ""))
            {

                case "EXCEL":

                    switch (Regex.Replace(parameters[1], "[^A-Za-z0-9 ]", ""))
                    {

                        case "CREATE":

                            ExcelHandler exh = new ExcelHandler();
                            string path = parameters[2].Substring(1, parameters[2].Length - 2);
                            string fileId = exh.CreateExcelDocument(path);


                            // resultString = "RESULT{" + res + ";\"" + fileId + "\";}";
                            resultString = fileId;
                            break;

                        case "OPEN":
                            ExcelHandler exh2 = new ExcelHandler();
                            string id = parameters[2].Substring(2, parameters[2].Length - 4);
                            string res2 = exh2.OpenExcelDocument(id);


                            // resultString = "RESULT{" + res2 + ";}";
                            resultString = res2;
                            break;

                        case "WRITE":
                            ExcelHandler write = new ExcelHandler();
                            string writePath = parameters[2].Substring(2, parameters[2].Length - 4);
                            string writeCell = parameters[3].Substring(2, parameters[3].Length - 4);
                            string writeValue = parameters[4].Substring(2, parameters[4].Length - 4);
                            int writeRes = write.writeExcelDocument(writePath, writeCell, writeValue);


                            resultString = "RESULT{" + writeRes + ";}";

                            break;

                        case "READ":
                            ExcelHandler read = new ExcelHandler();
                            string readPath = parameters[2].Substring(2, parameters[2].Length - 4);
                            string readCell = parameters[3].Substring(2, parameters[3].Length - 4);
                            string readRes = read.ReadDataExcelDocument(readPath, readCell);


                            resultString = "RESULT{" + readRes + ";}";

                            break;

                        case "SAVE":
                            ExcelHandler exh3 = new ExcelHandler();
                            string Excelpath = parameters[2].Substring(2, parameters[2].Length - 4);
                            int res3 = exh3.SaveExcelDocument(Excelpath);


                            resultString = "RESULT{" + res3 + ";}";
                            break;

                        default:
                            break;

                    }

                    break;

                case "WEB":

                    switch (Regex.Replace(parameters[1], "[^A-Za-z0-9 ]", ""))
                    {
                        case "OPEN":

                            WebHandler web = new WebHandler();
                            string url = parameters[2].Substring(1, parameters[2].Length - 2);
                            string webId = web.OpenURL(url);

                            // resultString = "RESULT{0;\"" + webId + "\";}";
                            resultString = webId;
                            break;

                        case "ENTERTEXT":

                            web = new WebHandler();
                            // int res = web.EnterText(parameters[2].Substring(1, 36), Regex.Replace(parameters[3], "[^A-Za-z0-9 ]", ""), Regex.Replace(parameters[4], "[^A-Za-z0-9 ]", ""));
                            int res = web.EnterText(parameters[2].Substring(2, parameters[2].Length - 4), parameters[3].Substring(2, parameters[3].Length - 4), parameters[4].Substring(2, parameters[4].Length - 4));

                            resultString = "RESULT{" + res + ";}";

                            break;

                        case "READTEXT":

                            web = new WebHandler();
                            string text = web.ReadText(parameters[2].Substring(2, parameters[2].Length - 4), parameters[3].Substring(2, parameters[3].Length - 4));

                            if (text.Equals(""))
                            {
                                resultString = "RESULT{1;\"ERROR\"}";
                            }
                            else
                            {
                                resultString = "RESULT{0;\"" + text + "\";}";
                            }

                            break;

                        case "CLICK":

                            web = new WebHandler();
                            res = web.ClickButton(parameters[2].Substring(2, parameters[2].Length - 4), parameters[3].Substring(2, parameters[3].Length - 4));

                            resultString = "RESULT{" + res + ";}";

                            break;

                        case "CLOSE":

                            web = new WebHandler();
                            res = web.CloseBrowser(parameters[2].Substring(1, 36));

                            resultString = "RESULT{" + res + ";}";

                            break;

                        default:
                            break;

                    }

                    break;

                case "PDF":

                    switch (Regex.Replace(parameters[1], "[^A-Za-z0-9 ]", ""))
                    {
                        case "OPEN":

                            PDFHandler pdf = new PDFHandler();
                            string path = parameters[2].Substring(1, parameters[2].Length - 2);
                            string pdfId = pdf.OpenPDF(path);
                            //resultString = "RESULT{0;\"" + pdfId + "\";}";
                            resultString = pdfId;

                            break;


                        case "MERGEDOCUMENTS":
                            pdf = new PDFHandler();
                            string id1 = parameters[2].Substring(1, parameters[2].Length - 2);
                            string id2 = parameters[3].Substring(1, parameters[3].Length - 1);
                            pdfId = pdf.mergeDocuments(id1, id2);
                            resultString = "RESULT{0;\"" + pdfId + "\";}";

                            break;

                        case "READTEXTFROMPAGE":

                            pdf = new PDFHandler();
                            pdfId = parameters[2].Substring(1, parameters[2].Length - 2);
                            //pdfId = pdf.OpenPDF(path);
                            //Console.WriteLine("The ID to match : " + pdfId);
                            //string text = pdf.ReadTextFromPage(parameters[2].Substring(1, 36), Int32.Parse(Regex.Replace(parameters[3], "[^-A-Za-z0-9 ]", "")));
                            string text = pdf.ReadTextFromPage(pdfId, Int32.Parse(Regex.Replace(parameters[3], "[^-A-Za-z0-9 ]", "")));
                            if (text.Equals(""))
                            {
                                resultString = "RESULT{1;\"ERROR\"}";
                            }
                            else
                            {
                                //resultString = "RESULT{0;\"" + text + "\";}";
                                resultString = text;
                            }

                            break;

                        case "CLOSE":

                            pdf = new PDFHandler();
                            int res = pdf.ClosePDF(parameters[2].Substring(1, parameters[2].Length - 2));

                            resultString = "RESULT{" + res + ";}";

                            break;

                        default:
                            break;

                    }

                    break;

                case "MAIL":

                    switch (Regex.Replace(parameters[1], "[^A-Za-z0-9 ]", ""))
                    {

                        case "SEND":

                            MailHandler mail = new MailHandler();

                            int res = mail.SendMail(Regex.Replace(parameters[2], "[^A-Za-z0-9@. ]", ""), Regex.Replace(parameters[3], "[^A-Za-z0-9@. ]", ""),
                                Regex.Replace(parameters[4], "[^A-Za-z0-9 ]", ""), Regex.Replace(parameters[5], "[^A-Za-z0-9,. ]", ""),
                                Regex.Replace(parameters[6], "[^A-Za-z0-9@. ]", ""), Regex.Replace(parameters[7], "[^A-Za-z0-9 ]", ""));

                            resultString = "RESULT{" + res + ";}";

                            break;

                        case "SENDWITHATTACHMENTS":

                            MailHandler mail2 = new MailHandler();

                            int res2 = mail2.SendMailWithAttachements(Regex.Replace(parameters[2], "[^A-Za-z0-9@. ]", ""), Regex.Replace(parameters[3], "[^A-Za-z0-9@. ]", ""),
                                Regex.Replace(parameters[4], "[^A-Za-z0-9 ]", ""), Regex.Replace(parameters[5], "[^A-Za-z0-9,. ]", ""),
                                Regex.Replace(parameters[6], "[^A-Za-z0-9@. ]", ""), Regex.Replace(parameters[7], "[^A-Za-z0-9 ]", ""), parameters[8].Substring(2, parameters[8].Length - 4));

                            resultString = "RESULT{" + res2 + ";}";

                            break;

                        default:
                            break;

                    }

                    break;


                case "OCR":
                    switch (Regex.Replace(parameters[1], "[^A-Za-z0-9 ]", ""))
                    {

                        case "READTEXTFROMIMAGE":
                            OCRHandler ocr = new OCRHandler();

                            string path = parameters[2].Substring(1, parameters[2].Length - 2);
                            string res = ocr.getTextFromImage(path);

                            resultString = "RESULT{" + res + ";}";

                            break;

                        case "READGERMANTEXTFROMIMAGE":
                            ocr = new OCRHandler();

                            path = parameters[2].Substring(1, parameters[2].Length - 2);
                            res = ocr.readGermanText(path);

                            resultString = "RESULT{" + res + ";}";

                            break;

                        default:
                            break;

                    }

                    break;

                default:
                    break;
            }

        }



        return resultString;
    }

    //public void CommandListener(Object obj)
    public void CommandListener()
    {
        //TcpClient client = (TcpClient)obj;     

        UdpClient server = new UdpClient(13000);

        Byte[] bytes = new Byte[256];

        server.Client.ReceiveTimeout = 0;
        server.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 0);

        Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        IPEndPoint recv = new IPEndPoint(IPAddress.Any, 13000);
        IPEndPoint send = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);

        //var stream = client.GetStream();
        string imei = String.Empty;
        string data = null;
        //Byte[] bytes = new Byte[256];
        //int i;

        while (true)
        {
            try
            {
                bytes = server.Receive(ref recv);

                Console.WriteLine("Connected!");

                string hex = BitConverter.ToString(bytes);
                data = Encoding.ASCII.GetString(bytes);
                Console.WriteLine("{1}: Received: {0}", data, Thread.CurrentThread.ManagedThreadId);

                /*while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    string hex = BitConverter.ToString(bytes);
                    data = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("{1}: Received: {0}", data, Thread.CurrentThread.ManagedThreadId);




                    string resultString = CommandHandler(data);


                    Byte[] reply = System.Text.Encoding.ASCII.GetBytes(resultString);
                    stream.Write(reply, 0, reply.Length);
                    Console.WriteLine("{1}: Sent: {0}", resultString, Thread.CurrentThread.ManagedThreadId);
                }*/

                string resultString = CommandHandler(data);

                Byte[] reply = System.Text.Encoding.ASCII.GetBytes(resultString);

                //server.Send(reply, reply.Length) Non-connected socket!

                sender.SendTo(reply, send);
                Console.WriteLine("{1}: Sent: {0}", resultString, Thread.CurrentThread.ManagedThreadId);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                //client.Close();
            }

        }
    }
}