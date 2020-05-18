using System;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Security;


//public class UClient
//{
//	private string ip = "127.0.0.1";
//	private Byte[] bytes = new Byte[256];
//	private string instruction = @"COMMAND{\";
//	UdpClient client = null;

//	public UClient()
//	{
//		Connect();
//	}

//	public void Connect()
//	{
//		client = new UdpClient(13001);
//		try
//		{
//			//Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

//			//client.Connect(ip, 13000);

//			//Byte[] sendBytes = Encoding.ASCII.GetBytes("Client connected");


//			//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"EXCEL\";\"OPEN\";\"c:/log/testfile.xlsx\";}");
//			//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"WEB\";\"OPEN\";\"https://youtube.com\";}") ;
//			//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"WEB\";\"ENTERTEXT\";\"https://facebook.com\";\"siyabulela.yawa.9@facebook.com\";\"siyayawa\";}") ;

//			//public int SendMail(string fromAddress, string toAddress, string subject, string messageBody, string username, string password)

//			//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"MAIL\";\"SEND\";\"siyayawa32@gmail.com\";\"odwakatywa1@gmail.com\";\"siyayawa32@gmail.com\";\"siyayawa32@gmail.com\";\"siyayawa32@gmail.com\";\"Mehlulwa2010\"}") ;


//			//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"PDF\";\"OPEN\";\"c:/Users/S4/Downloads/B200301.pdf\";}");
//			Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"PDF\";\"CLOSE\";\"c:/Users/S4/Downloads/B200301.pdf\";}");
//			//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"PDF\";\"READTEXTFROMPAGE\";\"c:/Users/S4/Downloads/B200301.pdf\";\"1\"}");

//			client.Send(sendBytes, sendBytes.Length);

//			IPEndPoint recv = new IPEndPoint(IPAddress.Any, 13001);


//			Byte[] receiveBytes = client.Receive(ref recv);

//			string returnData = Encoding.ASCII.GetString(receiveBytes);

//			Console.WriteLine("Result: " + returnData.ToString());

//			Console.WriteLine("Result sent from : " + recv.Address.ToString()
//				+ " on their port number " + recv.Port.ToString());

//		}
//		catch (Exception e)
//		{
//			Console.WriteLine("Exception: {0}", e.ToString());
//		}
//		mainMenu();

//	}

//	public void mainMenu()
//	{

//		Console.WriteLine("Main Menu");
//		Console.WriteLine("");

//		int choice;


//		Console.WriteLine("1. EXCEL");
//		Console.WriteLine("2. WEB");
//		Console.WriteLine("3. PDF");
//		Console.WriteLine("4. MAIL");
//		Console.WriteLine("5. EXIT");

//		Console.WriteLine("Enter option: ");
//		choice = int.Parse(Console.ReadLine());

//		switch (choice)
//		{
//			case 1:
//				instruction += "\\\"EXCEL\\\";";
//				excelMenu();
//				break;
//			case 2:
//				instruction += "\\\"WEB\\\";";
//				webMenu();
//				break;
//			case 3:
//				instruction += "\\\"PDF\\\";";
//				pdfMenu();
//				break;
//			case 4:
//				instruction += "\\\"MAIL\\\";";
//				mailMenu();
//				break;
//			case 5:
//				return;
//				//break;
//		}

//	}
//	private void openWeb()
//	{
//		Console.WriteLine("Enter url");
//		string url = Console.ReadLine();

//		instruction += "\""+ url;
//		instruction += "\\\";}";
//		Console.WriteLine(instruction);
//		//Console.ReadLine();
//		//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"WEB\";\"OPEN\";\"https://youtube.com\";}") ;
//		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

//		client.Send(sendBytes, sendBytes.Length);



//	}

//	private void mailMenu()
//	{
//		Console.WriteLine("1. SEND");
//		int choice =int.Parse( Console.ReadLine());

//		switch (choice)
//		{
//			case 1:
//				instruction += "\\\"SEND\\\";";
//				sendMail();
//				break;

//		}
//	}
//	private void sendMail()
//	{

//	//	public int SendMail(string fromAddress, string toAddress, string subject, string messageBody, string username, string password)
//		//client.Send(sendBytes, sendBytes.Length);

//		Console.WriteLine("Enter email address to send FROM ");
//		string from = Console.ReadLine();
//		Console.WriteLine("Enter username ");
//		string username = Console.ReadLine();
//		Console.WriteLine("Enter password: ");
//		string password = Console.ReadLine();
//		Console.WriteLine("Enter email address to send TO: ");
//		string to = Console.ReadLine();
//		Console.WriteLine("Enter subject: ");
//		string subject = Console.ReadLine();
//		Console.WriteLine("Enter message body ");
//		string body = Console.ReadLine();
//		instruction += "\\\""+from+"\\\";";
//		instruction += "\\\"" + to + "\\\";";
//		instruction += "\\\"" + subject + "\\\";";
//		instruction += "\\\"" + body + "\\\";";
//		instruction += "\\\"" + username + "\\\";";
//		instruction += "\\\"" + password + "\\\";";
//		Console.WriteLine(instruction);
//		Console.ReadLine();

//		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

//		client.Send(sendBytes, sendBytes.Length);
//	}

//	private void pdfMenu()
//	{
//	}

//	private void webMenu()
//	{
//		Console.WriteLine("1. OPEN");
//		Console.WriteLine("2. ENTERTEXT");
//		Console.WriteLine("3. READTEXT");
//		Console.WriteLine("4. CLICK");
//		Console.WriteLine("5. close");
//		Console.WriteLine("6. CLICK");
//		Console.WriteLine("7. CLICK");

//		int choice = int.Parse(Console.ReadLine());

//		switch (choice)
//		{
//			case 1:
//				instruction += "\\\"OPEN\\\";";
//				openWeb();
//				break;
//			case 2:
//				instruction += "\\\"ENTERTEXT\\\";";
//				entertextWeb();
//				break;


//		}

//	}
//	private void entertextWeb()
//	{

//	}

//	private void excelMenu()
//	{
//		Console.WriteLine("Excel Menu");
//		Console.WriteLine("");

//		int choice;


//		Console.WriteLine("1. Create Excel Spreadsheet");
//		Console.WriteLine("2. Open Excel Spreadsheet");
//		Console.WriteLine("3. Save Excel Spreadsheet");
//		Console.WriteLine("4. EXIT");


//		Console.WriteLine("Enter option: ");
//		choice = int.Parse(Console.ReadLine());

//		switch (choice)
//		{
//			case 1:
//				instruction += "\\\"CREATE\\\";";
//				createSpreadsheet();
//				break;
//			case 2:
//				instruction += "\\\"OPEN\\\";";
//				openSpreadsheet();
//				break;
//			case 3:
//				instruction += "\\\"SAVE\\\";";
//				saveSpreadsheet();
//				break;
//			default :
//				Console.WriteLine("Unknown action quitting");
//				return;
//				//break;
//		}

//	}

//	private void saveSpreadsheet()
//	{
//		createSpreadsheet();
//	}

//	private void openSpreadsheet()
//	{
//		createSpreadsheet();
//	}

//	private void createSpreadsheet()
//	{
//		Console.WriteLine("Enter the path you would like to create the file in: ");
//		string path = Console.ReadLine();
//		Console.WriteLine("Enter the name of the file you want to create: ");
//		string filename = Console.ReadLine();
//		instruction += "\\"+path+filename;
//		instruction += "\";}";
//		Console.WriteLine(instruction);
//		Console.ReadLine();

//		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

//		client.Send(sendBytes, sendBytes.Length);

//		//string command = 
//	}

//	private String excelCommandParser(string path, string filename)
//	{

//		//"COMMAND{\"EXCEL\";\"CREATE\";\"c:/log/testfile.xlsx\";}"
//		return "COMMAND";
//	}
//}
























public class UClient
{
	private string ip = "127.0.0.1";
	private Byte[] bytes = new Byte[256];
	private string instruction = @"COMMAND{\";
	UdpClient client = null;
	string processid = "";
	string webid = "";
	string excelid = "";
	string pdfid = "";
	string pdfMergedid = "";
	IPEndPoint server = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13000);
	IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);
	public UClient()
	{
		Connect();
	}

	public void Connect()
	{
		client = new UdpClient(13001);
		try
		{

			//client.Connect(ip, 13000);

			//Byte[] sendBytes = Encoding.ASCII.GetBytes("Client connected");


			//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"EXCEL\";\"OPEN\";\"c:/log/testfile.xlsx\";}");
			//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"PDF\";\"OPEN\";\"c:/log/TEST.pdf\";}");

			//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"WEB\";\"OPEN\";\"https://youtube.com\";}") ;
			//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"WEB\";\"ENTERTEXT\";\"https://facebook.com\";\"siyabulela.yawa.9@facebook.com\";\"siyayawa\";}") ;

			//public int SendMail(string fromAddress, string toAddress, string subject, string messageBody, string username, string password)

			//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"MAIL\";\"SEND\";\"siyayawa32@gmail.com\";\"siyayawa32@gmail.com\";\"siyayawa32@gmail.com\";\"siyayawa32@gmail.com\";\"siyayawa32@gmail.com\";\"Mehlulwa2010*\"}") ;

			//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"MAIL\";\"SEND\";\"odwakatywa1@gmail.com\";\"odwakatywa1@gmail.com\";\"Subject\";\"Body\";\"odwakatywa1@gmail.com\";\"odwa200196*\"}");


			//client.Send(sendBytes, sendBytes.Length);

			//IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);


			//Byte[] receiveBytes = client.Receive(ref recv);

			//string returnData = Encoding.ASCII.GetString(receiveBytes);

			//Console.WriteLine("Result: " + returnData.ToString());

			//Console.WriteLine("Result sent from : " + recv.Address.ToString()
			//	+ " on their port number " + recv.Port.ToString());/*
			//	*/


			//C:\Users\S4\Downloads\B200404.pdf
		}
		catch (Exception e)
		{
			Console.WriteLine("Exception: {0}", e.ToString());
		}
		mainMenu();

	}

	public void mainMenu()
	{
		while (true)
		{
			instruction = @"COMMAND{\";
			Console.WriteLine("Main Menu");
			Console.WriteLine("");

			int choice;


			Console.WriteLine("1. EXCEL");
			Console.WriteLine("2. WEB");
			Console.WriteLine("3. PDF");
			Console.WriteLine("4. MAIL");
			Console.WriteLine("5. OCR");
			Console.WriteLine("6. EXIT");

			Console.WriteLine("Enter option: ");
			choice = int.Parse(Console.ReadLine());

			switch (choice)
			{
				case 1:
					instruction += "\\\"EXCEL\\\";";
					excelMenu();
					break;
				case 2:
					instruction += "\\\"WEB\\\";";
					webMenu();
					break;
				case 3:
					instruction += "\\\"PDF\\\";";
					pdfMenu();
					break;
				case 4:
					instruction += "\\\"MAIL\\\";";
					mailMenu();
					break;
				case 5:
					instruction += "\\\"OCR\\\";";
					ocrMenu();
					break;
				case 6:
					return;
					//break;
			}
		}

	}

	private void ocrMenu()
	{
		Console.WriteLine("OCR Menu");
		Console.WriteLine("");

		int choice;

		Console.WriteLine("1. Read text from Image");
		Console.WriteLine("2. Read German text from an image");


		Console.WriteLine("3. EXIT");


		Console.WriteLine("Enter option: ");
		choice = int.Parse(Console.ReadLine());

		switch (choice)
		{
			case 1:
				instruction += "\\\"READTEXTFROMIMAGE\\\";";
				getTextFromImage();
				break;

			case 2:
				instruction += "\\\"READGERMANTEXTFROMIMAGE\\\";";
				readGermanTextFromImage();
				break;

			default:
				Console.WriteLine("Unknown action quitting");
				return;
				//break;
		}
	}

	private void readGermanTextFromImage()
	{
		Console.WriteLine("Enter the path of the image: ");
		string path = Console.ReadLine();
		instruction += "\\" + path;
		instruction += "\";}";
		Console.WriteLine(instruction);
		//Console.ReadLine();

		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length, server);

		IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);

		Byte[] receiveBytes = client.Receive(ref recv);

		string returnData = Encoding.ASCII.GetString(receiveBytes);
	}

	private void getTextFromImage()
	{
		Console.WriteLine("Enter the path of the image: ");
		string path = Console.ReadLine();
		instruction += "\\" + path;
		instruction += "\";}";
		Console.WriteLine(instruction);
		//Console.ReadLine();

		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length, server);

		IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);

		Byte[] receiveBytes = client.Receive(ref recv);

		string returnData = Encoding.ASCII.GetString(receiveBytes);
	}

	private void openWeb()
	{
		Console.WriteLine("Enter url");
		string url = Console.ReadLine();

		instruction += "\"" + url;
		instruction += "\\\";}";
		Console.WriteLine(instruction);
		//Console.ReadLine();
		//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"WEB\";\"OPEN\";\"https://youtube.com\";}") ;
		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length, server);
		//client.Send(sendBytes, sendBytes.Length);


		IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);


		Byte[] receiveBytes = client.Receive(ref recv);

		string returnData = Encoding.ASCII.GetString(receiveBytes);
		processid = returnData;
		/*
			Console.WriteLine("Result: " + returnData.ToString());
			Console.WriteLine("Result sent from : " + recv.Address.ToString()
				+ " on their port number " + recv.Port.ToString());
*/
	}

	private void mailMenu()
	{
		Console.WriteLine("1. SEND");
		Console.WriteLine("2. SEND WITH ATTACHMENT");
		int choice = int.Parse(Console.ReadLine());



		switch (choice)
		{
			case 1:
				instruction += "\\\"SEND\\\";";
				sendMail();
				break;
			case 2:
				instruction += "\\\"SENDWITHATTACHMENTS\\\";";
				sendAttachMail();
				break;

		}
	}
	private void sendMail()
	{

		//	public int SendMail(string fromAddress, string toAddress, string subject, string messageBody, string username, string password)
		//client.Send(sendBytes, sendBytes.Length);

		Console.WriteLine("Enter email address to send FROM ");
		string from = Console.ReadLine();
		Console.WriteLine("Enter username ");
		string username = Console.ReadLine();
		Console.WriteLine("Enter password: ");
		string password = Console.ReadLine();
		Console.WriteLine("Enter email address to send TO: ");
		string to = Console.ReadLine();
		Console.WriteLine("Enter subject: ");
		string subject = Console.ReadLine();
		Console.WriteLine("Enter message body ");
		string body = Console.ReadLine();
		instruction += "\\\"" + from + "\\\";";
		instruction += "\\\"" + to + "\\\";";
		instruction += "\\\"" + subject + "\\\";";
		instruction += "\\\"" + body + "\\\";";
		instruction += "\\\"" + username + "\\\";";
		instruction += "\\\"" + password + "\\\";";
		Console.WriteLine(instruction);
		//Console.ReadLine();

		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length, server);
		//client.Send(sendBytes, sendBytes.Length);

		IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);


		Byte[] receiveBytes = client.Receive(ref recv);

		string returnData = Encoding.ASCII.GetString(receiveBytes);
		webid = returnData;
		/*
			Console.WriteLine("Result: " + returnData.ToString());
			Console.WriteLine("Result sent from : " + recv.Address.ToString()
				+ " on their port number " + recv.Port.ToString());
*/
	}
	private void sendAttachMail()
	{

		//	public int SendMail(string fromAddress, string toAddress, string subject, string messageBody, string username, string password)
		//client.Send(sendBytes, sendBytes.Length);

		Console.WriteLine("Enter email address to send FROM ");
		string from = Console.ReadLine();
		Console.WriteLine("Enter username ");
		string username = Console.ReadLine();
		Console.WriteLine("Enter password: ");
		string password = Console.ReadLine();
		Console.WriteLine("Enter email address to send TO: ");
		string to = Console.ReadLine();
		Console.WriteLine("Enter subject: ");
		string subject = Console.ReadLine();
		Console.WriteLine("Enter message body ");
		string body = Console.ReadLine();
		Console.WriteLine("Enter path ");
		string path = Console.ReadLine();
		Console.WriteLine("Enter filename ");
		string name = Console.ReadLine();
		instruction += "\\\"" + from + "\\\";";
		instruction += "\\\"" + to + "\\\";";
		instruction += "\\\"" + subject + "\\\";";
		instruction += "\\\"" + body + "\\\";";
		instruction += "\\\"" + username + "\\\";";
		instruction += "\\\"" + password + "\\\";";
		instruction += "\\\"" + path + "/" + name + "\\\";";
		Console.WriteLine(instruction);
		//Console.ReadLine();

		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length, server);
		//client.Send(sendBytes, sendBytes.Length);

		IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);


		Byte[] receiveBytes = client.Receive(ref recv);

		string returnData = Encoding.ASCII.GetString(receiveBytes);
		webid = returnData;
		/*
			Console.WriteLine("Result: " + returnData.ToString());
			Console.WriteLine("Result sent from : " + recv.Address.ToString()
				+ " on their port number " + recv.Port.ToString());
*/
	}

	private void pdfMenu()
	{
		Console.WriteLine("1. OPEN");
		Console.WriteLine("2. CLOSE");
		Console.WriteLine("3. READTEXTFROMPAGE");
		Console.WriteLine("4. MERGEPDFs");


		int choice = int.Parse(Console.ReadLine());

		switch (choice)
		{
			case 1:
				instruction += "\\\"OPEN\\\";";
				openPDF();
				break;
			case 2:
				instruction += "\\\"CLOSE\\\";";
				closePDF();
				break;
			case 3:
				instruction += "\\\"READTEXTFROMPAGE\\\";";
				readtextFromPDF();
				break;

			case 4:
				instruction += "\\\"MERGEDOCUMENTS\\\";";
				mergePDFs();
				break;
		}

	}

	private void mergePDFs()
	{
		/*Console.WriteLine("Enter the path of the first file: ");
		string path1 = Console.ReadLine();
		Console.WriteLine("Enter the path of the second file: ");
		string path2 = Console.ReadLine();*/

		/*instruction += "\\\"" + path1 + "\\\";";
		instruction += "\\\"" + path2 + "\\\";}";*/


		/*instruction += "\\" + path1 + "\\;";
		instruction += "\\" + path2;*/
		instruction += pdfMergedid;

		instruction += ";}";

		Console.WriteLine(instruction);

		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length, server);

		IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);

		Byte[] receiveBytes = client.Receive(ref recv);

		string returnData = Encoding.ASCII.GetString(receiveBytes);

	}

	private void readtextFromPDF()
	{
		//Console.WriteLine("Enter the path of the file: ");
		//string path = Console.ReadLine();
		Console.WriteLine("Enter the page number: ");
		int page = int.Parse(Console.ReadLine());

		instruction += "\\" + pdfid + "\\;";
		instruction += "\\\"" + page;
		instruction += "\";}";

		Console.WriteLine(instruction);
		//Console.ReadLine();

		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length, server);

		IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);

		Byte[] receiveBytes = client.Receive(ref recv);

		string returnData = Encoding.ASCII.GetString(receiveBytes);
	}

	

	private void openPDF()
	{
		Console.WriteLine("Enter the path of the file: ");
		string path = Console.ReadLine();
		instruction += "\\" + path;
		instruction += "\";}";
		Console.WriteLine(instruction);
		//Console.ReadLine();

		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length, server);

		IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);

		//C:\Users\S4\Downloads\B200404.pdf

		Byte[] receiveBytes = client.Receive(ref recv);

		string returnData = Encoding.ASCII.GetString(receiveBytes);

		pdfid = returnData;
		
		if(pdfMergedid == "")
		{
			pdfMergedid = "\\" + returnData;
		}
		else
		{
			pdfMergedid += "\";";
			pdfMergedid += "\\" + returnData;



			/*instruction += "\\\"" + excelid + "\\\";";
			instruction += "\\\"" + cell + "\\\";";
			instruction += "\\\"" + value + "\\\";";*/
		}
		
		//string command =
	}

	private void closePDF()
	{
		
		instruction += "\\" + pdfid;
		instruction += "\";}";
		Console.WriteLine(instruction);
		//Console.ReadLine();

		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length, server);

		IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);

		//C:\Users\S4\Downloads\B200404.pdf

		Byte[] receiveBytes = client.Receive(ref recv);

		string returnData = Encoding.ASCII.GetString(receiveBytes);

		pdfid = returnData;

	}

	private void webMenu()
	{
		Console.WriteLine("1. OPEN");
		Console.WriteLine("2. ENTERTEXT");
		Console.WriteLine("3. READTEXT");
		Console.WriteLine("4. CLICK");
		Console.WriteLine("5. CLOSE");


		int choice = int.Parse(Console.ReadLine());

		switch (choice)
		{
			case 1:
				instruction += "\\\"OPEN\\\";";
				openWeb();
				break;
			case 2:
				instruction += "\\\"ENTERTEXT\\\";";
				entertextWeb();
				break;
			case 3:
				instruction += "\\\"READTEXT\\\";";
				readtextWeb();
				break;

			case 4:
				instruction += "\\\"CLICK\\\";";
				clickWeb();
				break;

			case 5:
				instruction += "\\\"CLOSE\\\";";
				closeWeb();
				break;
		}

	}

	private void closeWeb()
	{


		//Console.WriteLine("Enter wed id");
		//string url = Console.ReadLine();
		//Console.WriteLine("Enter Control ID");
		//string id = Console.ReadLine();

		instruction += "\\\"" + webid + "\\\";";




		Console.WriteLine(instruction);
		Console.ReadLine();

		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length, server);
		//client.Send(sendBytes, sendBytes.Length);


		IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);


		Byte[] receiveBytes = client.Receive(ref recv);

		string returnData = Encoding.ASCII.GetString(receiveBytes);
		webid = returnData;
		/*
			Console.WriteLine("Result: " + returnData.ToString());
			Console.WriteLine("Result sent from : " + recv.Address.ToString()
				+ " on their port number " + recv.Port.ToString());
*/
	}
	private void entertextWeb()
	{


		Console.WriteLine("Enter web id");
		string url = Console.ReadLine();
		Console.WriteLine("Enter Control ID");
		string id = Console.ReadLine();
		Console.WriteLine("Enter text");
		string text = Console.ReadLine();
		instruction += "\\\"" + url + "\\\";";
		instruction += "\\\"" + id + "\\\";";
		instruction += "\\\"" + text + "\\\";";


		Console.WriteLine(instruction);
		Console.ReadLine();

		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length);
	}
	private void readtextWeb()
	{

		Console.WriteLine("Enter web id");
		string url = Console.ReadLine();
		Console.WriteLine("Enter Control ID");
		string id = Console.ReadLine();



		instruction += "\\\"" + url + "\\\";";
		instruction += "\\\"" + id + "\\\";";


		Console.WriteLine(instruction);
		Console.ReadLine();

		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length);
	}
	private void clickWeb()
	{


		Console.WriteLine("Enter weB id");
		string url = Console.ReadLine();
		Console.WriteLine("Enter Control ID");
		string id = Console.ReadLine();

		instruction += "\\\"" + url + "\\\";";
		instruction += "\\\"" + id + "\\\";";



		Console.WriteLine(instruction);
		Console.ReadLine();

		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length);
	}
	private void excelMenu()
	{
		Console.WriteLine("Excel Menu");
		Console.WriteLine("");

		int choice;


		Console.WriteLine("1. Create Excel Spreadsheet");
		Console.WriteLine("2. Open Excel Spreadsheet");
		Console.WriteLine("3. Save Excel Spreadsheet");
		Console.WriteLine("4. Write to Excel Spreadsheet");
		Console.WriteLine("5. Read from Excel Spreadsheet");

		Console.WriteLine("6. EXIT");


		Console.WriteLine("Enter option: ");
		choice = int.Parse(Console.ReadLine());

		switch (choice)
		{
			case 1:
				instruction += "\\\"CREATE\\\";";
				createSpreadsheet();
				break;
			case 2:
				instruction += "\\\"OPEN\\\";";
				openSpreadsheet();
				break;
			case 3:
				instruction += "\\\"SAVE\\\";";
				saveSpreadsheet();
				break;
			case 4:
				instruction += "\\\"WRITE\\\";";
				writeSpreadsheet();
				break;
			case 5:
				instruction += "\\\"READ\\\";";
				readSpreadsheet();
				break;
			default:
				Console.WriteLine("Unknown action quitting");
				return;
				//break;
		}

	}

	private void writeSpreadsheet()
	{


		Console.WriteLine("Enter cell");
		string cell = Console.ReadLine();
		Console.WriteLine("Enter value");
		string value = Console.ReadLine();


		instruction += "\\\"" + excelid + "\\\";";
		instruction += "\\\"" + cell + "\\\";";
		instruction += "\\\"" + value + "\\\";";


		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length, server);
		//client.Send(sendBytes, sendBytes.Length);


		IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);


		Byte[] receiveBytes = client.Receive(ref recv);

		string returnData = Encoding.ASCII.GetString(receiveBytes);
		//excelid = returnData;

		Console.WriteLine("Result: " + returnData.ToString());

		Console.WriteLine("Result sent from : " + recv.Address.ToString()
			+ " on their port number " + recv.Port.ToString());

	}

	private void readSpreadsheet()
	{

		Console.WriteLine("Enter cell");
		string cell = Console.ReadLine();



		instruction += "\\\"" + excelid + "\\\";";
		instruction += "\\\"" + cell + "\\\";";



		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length, server);
		//client.Send(sendBytes, sendBytes.Length);


		IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);


		Byte[] receiveBytes = client.Receive(ref recv);

		string returnData = Encoding.ASCII.GetString(receiveBytes);
		//excelid = returnData;

		Console.WriteLine("Result: " + returnData.ToString());
		Console.WriteLine("Result sent from : " + recv.Address.ToString()
			+ " on their port number " + recv.Port.ToString());

	}
	private void saveSpreadsheet()
	{


		instruction += "\\\"" + excelid + "\\\";";


		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length, server);
		//client.Send(sendBytes, sendBytes.Length);


		IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);


		Byte[] receiveBytes = client.Receive(ref recv);

		string returnData = Encoding.ASCII.GetString(receiveBytes);
		excelid = returnData;
		/*
			Console.WriteLine("Result: " + returnData.ToString());
			Console.WriteLine("Result sent from : " + recv.Address.ToString()
				+ " on their port number " + recv.Port.ToString());
*/

		//string command = 
	}

	private void openSpreadsheet()
	{
		Console.WriteLine("Enter file path");
		string path = Console.ReadLine();
		Console.WriteLine("Enter file name");
		string filename = Console.ReadLine();

		instruction += "\\\"" + path + "/" + filename + "\\\";";


		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length, server);
		//client.Send(sendBytes, sendBytes.Length);


		IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);


		Byte[] receiveBytes = client.Receive(ref recv);

		string returnData = Encoding.ASCII.GetString(receiveBytes);
		excelid = returnData;
		/*
			Console.WriteLine("Result: " + returnData.ToString());
			Console.WriteLine("Result sent from : " + recv.Address.ToString()
				+ " on their port number " + recv.Port.ToString());
*/
	}

	private void createSpreadsheet()
	{
		Console.WriteLine("Enter the path you would like to create the file in: ");
		string path = Console.ReadLine();
		Console.WriteLine("Enter the name of the file you want to create: ");
		string filename = Console.ReadLine();
		instruction += "\\" + path + "/" + filename;
		instruction += "\";}";
		Console.WriteLine(instruction);
		//Console.ReadLine();

		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length, server);
		//client.Send(sendBytes, sendBytes.Length);


		IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);


		Byte[] receiveBytes = client.Receive(ref recv);

		string returnData = Encoding.ASCII.GetString(receiveBytes);
		excelid = returnData;
		
			Console.WriteLine("Result: " + returnData.ToString());
			Console.WriteLine("Result sent from : " + recv.Address.ToString()
				+ " on their port number " + recv.Port.ToString());


		//string command = 
	}

	private String excelCommandParser(string path, string filename)
	{

		//"COMMAND{\"EXCEL\";\"CREATE\";\"c:/log/testfile.xlsx\";}"
		return "COMMAND";
	}

	private void finish()
	{
		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length, server);
		//client.Send(sendBytes, sendBytes.Length);


		IPEndPoint recv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13001);


		Byte[] receiveBytes = client.Receive(ref recv);

		string returnData = Encoding.ASCII.GetString(receiveBytes);
		excelid = returnData;
		/*
			Console.WriteLine("Result: " + returnData.ToString());
			Console.WriteLine("Result sent from : " + recv.Address.ToString()
				+ " on their port number " + recv.Port.ToString());
*/

	}

}












