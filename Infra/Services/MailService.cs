using System.Net;
using System.Net.Mail;

namespace MailSenderAPI.Infra.Services
{
    public class MailService : IMailService
    {
        public void AddEmailsToMailMessage(MailMessage mailMessage, string[] emails)
        {
            foreach(var email in emails)
            {
                mailMessage.To.Add(email);
            }
        }

        public bool SendMail(string[] sendTo, string subject, string body, bool isHtml = false)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress("murilo.cardoso@americarental.com.br");
                AddEmailsToMailMessage(mailMessage, sendTo);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = isHtml;

                using (SmtpClient smtp = new SmtpClient("smtp.americarental.com.br", 587))
                {
                    try
                    {
                        smtp.EnableSsl = false;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("murilo.cardoso@americarental.com.br", "Nic999Ame888*L");
                        smtp.Host = "smtp.americarental.com.br";
                        smtp.Send(mailMessage);
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"erro -> {e}");
                        return false;
                    }
                }
            }
        }
    }
}
