using SisConv.Domain.Interfaces.Services;

namespace SisConv.Domain.Services
{
	public class EmailBuilder : IEmailBuilder
	{ 
		public string From { get; }
		public string To { get; }
		public string Cc { get;  }
		public string Bcc { get;  }
		public string Subject { get; }
		public string Body { get;  }
		public string SmtpServer { get; }
		public string BodyFormat { get;  }
		public string Port { get;  }

		public string GetFrom()
		{
			return From;
		}

		public string GetTo()
		{
			return To;
		}

		public string GetCc()
		{
			return Cc;
		}

		public string GetBcc()
		{
			return Bcc;
		}

		public string GetSubject()
		{
			return Subject;
		}

		public string GetBody()
		{
			return Body;
		}

		public string GetSmtpServer()
		{
			return SmtpServer;
		}

		public string GetBodyFormat()
		{
			return BodyFormat;
		}

		public string GetPort()
		{
			return Port;
		}
	}
}
