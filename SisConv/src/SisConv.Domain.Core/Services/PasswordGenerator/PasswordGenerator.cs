using System;
using System.Text;

namespace SisConv.Domain.Core.Services.PasswordGenerator
{
	public class PasswordGenerator : IPasswordGenerator
	{
		private const string ValidCharacters = "abcdefghijklmnopqrstuvwxyz1234567890@#!?";
		

		public string GetPassword()
		{
			const int size = 8; //Convert.ToInt32(WebConfigurationManager.AppSettings["NumerosCaracteresSenha"]); TODO: ALterar essa linha para pegar esse valor no webconfig

			var maxValue = ValidCharacters.Length;
			var random = new Random(DateTime.Now.Millisecond);
			var password = new StringBuilder(size);

			for (var i = 0; i < size; i++)
				password.Append(ValidCharacters[random.Next(0, maxValue)]);

			return password.ToString();
		}
	}
}