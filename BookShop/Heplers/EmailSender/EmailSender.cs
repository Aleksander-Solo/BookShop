using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BookShop.Heplers.EmailSender
{
    public class EmailSender
    {
        private SmtpClient _smtpClient;
        private MailMessage _mail;

        private string _hostSmpt;
        private bool _enableSsl;
        private int _port;
        private string _senderEmail;
        private string _senderEmailPassword;
        private string _senderName;

        public EmailSender(EmailParams emailParams)
        {
            _hostSmpt = emailParams.HostSmpt;
            _enableSsl = emailParams.EnableSsl;
            _port = emailParams.Port;
            _senderEmail = emailParams.SenderEmail;
            _senderEmailPassword = emailParams.SenderEmailPassword;
            _senderName = emailParams.SenderName;
        }

        public async Task Send(string to, string subject, string body)
        {
            _mail = new MailMessage();
            _mail.From = new MailAddress(_senderEmail, _senderName);
            _mail.To.Add(new MailAddress(to));

            _mail.Subject = subject;
            _mail.BodyEncoding = System.Text.Encoding.UTF8;
            _mail.SubjectEncoding = System.Text.Encoding.UTF8;
            _mail.Body = body;

            _smtpClient = new SmtpClient()
            {
                Host = _hostSmpt,
                EnableSsl = _enableSsl,
                Port = _port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_senderEmail, _senderEmailPassword)
            };

            _smtpClient.SendCompleted += OnSendCompleted;
            await _smtpClient.SendMailAsync(_mail);
        }

        private void OnSendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            _smtpClient.Dispose();
            _mail.Dispose();
        }
    }
}
