namespace SisConv.Domain.Interfaces.Services
{
	public interface IEmailBuilder
	{
		string GetFrom();
		string GetTo();
		string GetCc();
		string GetBcc();
		string GetSubject();
		string GetBody();
		string GetSmtpServer();
		string GetBodyFormat();
		string GetPort();
	}
}
