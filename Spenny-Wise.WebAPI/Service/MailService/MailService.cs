using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Spenny_Wise.WebAPI.Domain.DTOs;

namespace Spenny_Wise.WebAPI.Service.MailService
{
    public class MailService : IMailService
    {
        private readonly AppSettings _settings;
        public MailService(IOptions<AppSettings> settings)
        {

            _settings = settings.Value;

        }
        public void SendRegistrationMail(MailSendDTO mail)
        {
            try
            {
                var message = new MimeMessage
                {
                    To = {MailboxAddress.Parse(mail.Email)},
                    Sender = MailboxAddress.Parse(_settings.SENDER),
                    Subject = mail.Subject,
                    Body = new TextPart(TextFormat.Html)
                    {
                        Text = $"<p>Please verify you account to complete your registration.</p>Here's your verification token <b>{mail.Body}</b>"
                    }
                };

                using var client = new SmtpClient();
                client.Connect(_settings.SERVER, _settings.PORT, SecureSocketOptions.StartTls);
                client.Authenticate(_settings.SENDER, _settings.PASSWORD);
                client.Send(message);
                client.Disconnect(true);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
