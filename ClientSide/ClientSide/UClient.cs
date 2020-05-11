using System;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class UClient
{
	private string ip = "127.0.0.1";
	private Byte[] bytes = new Byte[256];
	private string instruction = @"COMMAND{\";
	UdpClient client = null;

	public UClient()
	{
		Connect();
	}

	public void Connect()
	{
		client = new UdpClient(13001);
		try
		{

			client.Connect(ip, 13000);

			//Byte[] sendBytes = Encoding.ASCII.GetBytes("Client connected");


			//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"EXCEL\";\"OPEN\";\"c:/log/testfile.xlsx\";}");
			//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"WEB\";\"OPEN\";\"https://youtube.com\";}") ;
			//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"WEB\";\"ENTERTEXT\";\"https://facebook.com\";\"siyabulela.yawa.9@facebook.com\";\"siyayawa\";}") ;

			//public int SendMail(string fromAddress, string toAddress, string subject, string messageBody, string username, string password)

			//Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"MAIL\";\"SEND\";\"siyayawa32@gmail.com\";\"siyayawa32@gmail.com\";\"siyayawa32@gmail.com\";\"siyayawa32@gmail.com\";\"siyayawa32@gmail.com\";\"Mehlulwa2010*\"}") ;

			Byte[] sendBytes = Encoding.ASCII.GetBytes("COMMAND{\"MAIL\";\"SEND\";\"odwakatywa1@gmail.com\";\"odwakatywa1@gmail.com\";\"Subject\";\"Body\";\"odwakatywa1@gmail.com\";\"odwa200196*\"}");


			client.Send(sendBytes, sendBytes.Length);

			IPEndPoint recv = new IPEndPoint(IPAddress.Any, 13001);

			/*
			Byte[] receiveBytes = client.Receive(ref recv);

			string returnData = Encoding.ASCII.GetString(receiveBytes);

			Console.WriteLine("Result: " + returnData.ToString());

			Console.WriteLine("Result sent from : " + recv.Address.ToString()
				+ " on their port number " + recv.Port.ToString());
				*/
		}
		catch (Exception e)
		{
			Console.WriteLine("Exception: {0}", e.ToString());
		}
		mainMenu();

	}

	public void mainMenu()
	{

		Console.WriteLine("Main Menu");
		Console.WriteLine("");

		int choice;


		Console.WriteLine("1. EXCEL");
		Console.WriteLine("2. WEB");
		Console.WriteLine("3. PDF");
		Console.WriteLine("4. MAIL");
		Console.WriteLine("5. EXIT");

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
				pdfMenu();
				break;
			case 4:
				instruction += "\\\"MAIL\\\";";
				mailMenu();
				break;
			case 5:
				return;
				//break;
		}

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

		client.Send(sendBytes, sendBytes.Length);



	}

	private void mailMenu()
	{
		Console.WriteLine("1. SEND");
		int choice = int.Parse(Console.ReadLine());

		switch (choice)
		{
			case 1:
				instruction += "\\\"SEND\\\";";
				sendMail();
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
		Console.ReadLine();

		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length);
	}

	private void pdfMenu()
	{
	}

	private void webMenu()
	{
		Console.WriteLine("1. OPEN");
		Console.WriteLine("2. ENTERTEXT");
		Console.WriteLine("3. READTEXT");
		Console.WriteLine("4. CLICK");
		Console.WriteLine("5. close");
		Console.WriteLine("6. CLICK");
		Console.WriteLine("7. CLICK");

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


		}

	}
	private void entertextWeb()
	{
<<<<<<< HEAD
		
		Console.WriteLine("Enter Url");
		string url = Console.ReadLine();
		Console.WriteLine("Enter Control ID");
		string id = Console.ReadLine();
		Console.WriteLine("Enter text");
		string text = Console.ReadLine();
=======
>>>>>>> 593ea747e51996017bf350686de4e64cae3f8f76

	}
	private void readtextWeb()
	{

		Console.WriteLine("Enter Url");
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
		Console.WriteLine("4. EXIT");


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
			default:
				Console.WriteLine("Unknown action quitting");
				return;
				//break;
		}

	}

	private void saveSpreadsheet()
	{
		createSpreadsheet();
	}

	private void openSpreadsheet()
	{
		createSpreadsheet();
	}

	private void createSpreadsheet()
	{
		Console.WriteLine("Enter the path you would like to create the file in: ");
		string path = Console.ReadLine();
		Console.WriteLine("Enter the name of the file you want to create: ");
		string filename = Console.ReadLine();
		instruction += "\\" + path + filename;
		instruction += "\";}";
		Console.WriteLine(instruction);
		Console.ReadLine();

		Byte[] sendBytes = Encoding.ASCII.GetBytes(instruction);

		client.Send(sendBytes, sendBytes.Length);

		//string command = 
	}

	private String excelCommandParser(string path, string filename)
	{

		//"COMMAND{\"EXCEL\";\"CREATE\";\"c:/log/testfile.xlsx\";}"
		return "COMMAND";
	}
}
