namespace MailSenderAPI.Infra.Services
{
    public interface IMailService
    {
        bool SendMail(string[] sendTo, string subject, string body, bool isHtml = false);
    }
}
