using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace SisConv.Infra.CrossCutting.Identity.Configuration
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Habilitar o envio de e-mail
            if (true)
            {
                var text = HttpUtility.HtmlEncode(message.Body);

                var msg = new MailMessage {From = new MailAddress("alesilver.si@gmail.com", "Admin do Portal")};

                //msg.To.Add(new MailAddress(message.Destination));
                msg.To.Add(new MailAddress("alesilver.si@gmail.com"));
                msg.Subject = message.Subject;
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Html));

                var smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
                var credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailFrom"],
                    ConfigurationManager.AppSettings["PasswordEmail"]);
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);
            }

            return Task.FromResult(0);
        }
    }
}