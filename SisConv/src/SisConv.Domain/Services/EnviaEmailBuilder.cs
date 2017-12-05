using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
	public class EnviaEmailBuilder :  IEmailSender
	{
		public string From { get; set; }
		public string To { get; set; }
		public string Cc { get; set; }
		public string Bcc { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public string SmtpServer { get; set; }
		public string BodyFormat { get; set; }
		public string Port { get; set; }

		public void BuildFrom(string from)
		{
			From = from;
		}

		public void BuildTo(string to)
		{
			To = to;
		}

		public void BuildCc(string cc)
		{
			Cc = cc;
		}

		public void BuildBcc(string bcc)
		{
			Bcc = bcc;
		}

		public void BuildSubject(string subject)
		{
			Subject = subject;
		}

		public void BuildBody(string Body)
		{
			this.Body = Body;
		}

		public void BuildSmtpServer(string smtpServer)
		{
			SmtpServer = smtpServer;
		}

		public void BuildPort(string port)
		{
			Port = port;
		}

		public IEmailBuilder GetEmail()
		{
			return new EmailBuilder();
		}
	}
}
