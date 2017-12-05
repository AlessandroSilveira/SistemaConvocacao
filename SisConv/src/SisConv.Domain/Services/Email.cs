using System.Diagnostics.CodeAnalysis;

namespace SisConv.Domain.Services
{
	[ExcludeFromCodeCoverage]
	public class Email
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

		public Email(string from,string to, string cc, string bcc, string subject, string body, string smtpServer,string bodyFormat, string port )
		{
			Bcc = bcc;
			Body = body;
			BodyFormat = bodyFormat;
			Cc = cc;
			From = from;
			SmtpServer = smtpServer;
			Subject = subject;
			To = to;
			Port = port;
		}
	}
}