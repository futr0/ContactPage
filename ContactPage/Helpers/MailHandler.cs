using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ContactPage.Helpers
{
    public class MailHandler : IMailHandler
    {
        #region Variables
        public string ReceiverEmailAddress { get; set; }
        public string ReceiverDisplayName { get; set; }
        public string ReceiverEmailPassword { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        #endregion

        public MailHandler()
        {

        }

        public void Configure(string emailAddress, string displayName, string emailPassword, string host, string port)
        {
            ReceiverEmailAddress = emailAddress;
            ReceiverDisplayName = displayName;
            ReceiverEmailPassword = emailPassword;
            Host = host;
            Port = port;
        }

        public async Task SendEmail(string senderName, string senderSurname, string senderEmail,
            string senderPhone, string subject, string message)
        {
            var sender = new MailAddress(senderEmail, senderName);
            var receiverEmail = new MailAddress(ReceiverEmailAddress, ReceiverDisplayName);
            var body = FormatBody(senderName, senderSurname, senderPhone, message, senderEmail);
            var smtp = GetSmtpClient();
            var mess = GenerateMailMessage(sender, receiverEmail, subject, body);
            try
            {
                using (smtp)
                {
                    await smtp.SendMailAsync(mess);
                    mess.Dispose();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private static MailMessage GenerateMailMessage(MailAddress address, MailAddress reciever, 
                                                string subject, string body)
        {
            return new MailMessage(address, reciever)
            {
                Subject = subject,
                Body = body
            };
        }

        private SmtpClient GetSmtpClient()
        {
            var smtp = new SmtpClient
            {
                Host = Host,
                Port = int.Parse(Port),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(ReceiverEmailAddress, ReceiverEmailPassword)
            };
            return smtp;
        }

        private string FormatBody(string senderName, string senderSurname, string senderPhone,
            string message, string senderEmail)
        {
            return
                $"Message from: {senderName} {senderSurname}\n Text: {message} \n Contact: e-mail: {senderEmail}, phone number: {senderPhone}";
        }
    }
}
