using Newsletter.Models;
using System.Net;
using System.Net.Mail;

namespace Newsletter.Services
{
    public class EmailSenderService
    {
        private readonly EmailSettings _emailSettings;

        public EmailSenderService(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public void SendMail(string email, News news)
        {
            SmtpClient client = new SmtpClient(_emailSettings.Host, _emailSettings.Port);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password);
            client.EnableSsl = true;

            client.Send(_emailSettings.Email, email, news.NewsTittle, news.NewsContent);
        }
    }
}
