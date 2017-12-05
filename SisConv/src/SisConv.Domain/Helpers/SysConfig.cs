using System.Text;
using System.Web;
using System.Web.Configuration;

namespace SisConv.Domain.Helpers
{
	public class SysConfig : ISysConfig
	{
		public string GetHelpFile(string page)
		{
			var ret = "";
			var caminho = WebConfigurationManager.AppSettings["email_path"]; 
			var language = WebConfigurationManager.AppSettings["language"];

			if (page.Equals("")) return ret;
			var helpfile = HttpContext.Current.Request.PhysicalApplicationPath + @"\public\" + page + "." + language + ".htm";
			if (!System.IO.File.Exists(helpfile)) return ret;
			System.IO.StreamReader sr = new System.IO.StreamReader(helpfile, Encoding.Default);
			ret = sr.ReadToEnd();
			sr.Close();
			sr.Dispose();
			return ret;
		}
	}
}