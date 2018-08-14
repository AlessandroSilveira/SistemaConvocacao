using System.IO;
using System.Text;
using System.Web;

namespace SisConv.Domain.Helpers
{
    public class SysConfig : ISysConfig
    {
        public string GetHelpFile(string page)
        {
            var ret = "";

            if (page.Equals("")) return ret;
            var helpfile = HttpContext.Current.Request.PhysicalApplicationPath + @"public\" + page + ".pt.htm";
            if (!File.Exists(helpfile)) return ret;
            var sr = new StreamReader(helpfile, Encoding.Default);
            ret = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
            return ret;
        }
    }
}