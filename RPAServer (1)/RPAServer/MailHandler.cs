using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Security;
using MimeKit;

namespace CoreServer
{
    class MailHandler
    {

        public int SendMail(string fromAddress, string toAddress, string subject, string messageBody, string username, string password)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(fromAddress));
            message.To.Add(new MailboxAddress(toAddress));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = messageBody
            };

            var client = new SmtpClient();

            client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);

            client.Authenticate(username, password);

            client.Send(message);

            client.Disconnect(true);

            return Result.OK;
        }
    }
}
