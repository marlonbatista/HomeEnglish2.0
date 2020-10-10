
using System.Net.Mail;
using HomeEnglish.Domain.Services;

namespace HomeEnglish.Infra.StoreContext.Services
{
    public class EmailService : IEmailService
    {
        public MailMessage createMail(string to, string from, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress(from, from);
            mail.From = new MailAddress(from, from);
            mail.To.Add(new MailAddress(to));
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            return mail;
        }

        public void Send(string to, string from, string subject, string body)
        {
            try
            {
                System.Net.Mail.SmtpClient smp = new System.Net.Mail.SmtpClient();
                smp.Host = "smtp.gmail.com";
                smp.EnableSsl = true;
                smp.Credentials = new System.Net.NetworkCredential("your e-mail from google", "your password");
                MailMessage mail = this.createMail(to, from, subject, body);
                smp.Send(mail);
            }
            catch (System.Exception ex)
            {
                string erro = ex.InnerException.ToString();
            }
        }
    }
}