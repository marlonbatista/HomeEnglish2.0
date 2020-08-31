using System.Net.Mail;

namespace HomeEnglish.Domain.Services 
{
    public interface IEmailService
    {
        void Send(string to, string from, string subject, string body);
        MailMessage createMail(string to, string from, string subject, string body);
    }
}