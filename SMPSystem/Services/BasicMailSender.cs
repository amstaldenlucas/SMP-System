using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SMPSystem.Services
{
    internal class BasicMailSender : IEmailSender
    {
        private readonly string EmailSmtpUri;
        private readonly string EmailUser;
        private readonly string EmailPassword;

        public BasicMailSender(string emailSmtpUri, string emailUser, string emailPassword)
        {
            EmailSmtpUri = emailSmtpUri;
            EmailUser = emailUser;
            EmailPassword = emailPassword;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpClient = new SmtpClient(EmailSmtpUri)
            {
                Port = 587,
                Credentials = new NetworkCredential(EmailUser, EmailPassword),
                EnableSsl = true,
            };

            FileLog(email, subject, htmlMessage);
            return smtpClient.SendMailAsync(EmailUser, email, subject, htmlMessage);
        }
        private void FileLog(params string[] args)
        {
            string LogHtmlBreak = "<br><br><hr><br>";
            string LogFileName = "BasicMailSender_log.html";

            var lines = new string[args.Length + 2];
            args.CopyTo(lines, 0);
            lines[^2] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            lines[^1] = LogHtmlBreak;
            File.AppendAllLines(LogFileName, lines);
        }
    }
}
