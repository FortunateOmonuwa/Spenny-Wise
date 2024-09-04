using Spenny_Wise.WebAPI.Domain.DTOs;

namespace Spenny_Wise.WebAPI.Service.MailService
{
    public interface IMailService
    {
        void SendRegistrationMail(MailSendDTO mail);
    }
}
