using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Security;
using MimeKit;
using System.IO;

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
        public int SendMailWithAttachements(string fromAddress, string toAddress, string subject, string messageBody, string username, string password, string mpath)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(fromAddress));
            message.To.Add(new MailboxAddress(toAddress));
            message.Subject = subject;
            string path = mpath;

            // create our message text, just like before (except don't set it as the message.Body)
            var body = new TextPart("plain")
            {
                Text = messageBody
            };

            // create an image attachment for the file located at path
            var attachment = new MimePart("Image", "png")
            {
                Content = new MimeContent(File.OpenRead(path), ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(path)
            };


            // now create the multipart/mixed container to hold the message text and the
            // image attachment
            var multipart = new Multipart("mixed");
            multipart.Add(body);
            multipart.Add(attachment);

            // now set the multipart/mixed as the message body
            message.Body = multipart;
            var client = new SmtpClient();

            client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);

            client.Authenticate(username, password);

            client.Send(message);


            client.Disconnect(true);

            return Result.OK;
        }

    }
}