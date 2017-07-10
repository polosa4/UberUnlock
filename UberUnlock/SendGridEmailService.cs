using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SendGrid.Helpers.Mail;
using System.Text.RegularExpressions;
using SendGrid;
using SendGridMessage = SendGrid.Helpers.Mail.SendGridMessage;

namespace CodingTemple.CodingCookware.Web
{
    public class SendGridEmailService : IIdentityMessageService
    {
        private ISendGridClient _client;

        public SendGridEmailService(string apiKey)
        {
            _client = new SendGridClient(apiKey);
        }

        public SendGridEmailService(ISendGridClient client)
        {
            _client = client;
        }

        public Task SendAsync(IdentityMessage message)
        {
            EmailAddress from = new EmailAddress("polosa4@gmail.com", "Coding Cookware Administrator");
            EmailAddress to = new EmailAddress(message.Destination);
            SendGridMessage sendGridMessage = MailHelper.CreateSingleEmail(from, to, message.Subject, Regex.Replace(message.Body, @"<(.|\n)*?>", ""), message.Body);
            return _client.SendEmailAsync(sendGridMessage);
        }
    }
}