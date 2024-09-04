namespace Spenny_Wise.WebAPI.Domain.DTOs
{
    public class MailSendDTO
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; } = "";
    }
}
