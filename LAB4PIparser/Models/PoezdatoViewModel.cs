using LAB4PIparser.Entity;
using LAB4PIparser.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LAB4PIparser.Models
{
    public class PoezdatoViewModel
    {
        public static List<Train> GetTrains(string where, string when)
        {
            List<Train> res = null;
            try
            {
                string content = GetContent(where, when);
                res = PoezdatoParser.Parse(content);
            }
            catch (ArgumentException e)
            {
            }

            return res;
        }

        private static string GetContent(string where, string when)
        {
            string sURL;
            if (when != null) {
                sURL = "http://poezdato.net/raspisanie-po-stancyi/"
					+ HttpUtility.UrlEncode(Translit.ToTranslit(where, "h"), Encoding.UTF8) + "/poezda/"
					+ HttpUtility.UrlEncode(when, Encoding.UTF8);
            }
            else
            {
                sURL = "http://poezdato.net/raspisanie-po-stancyi/" 
                    + HttpUtility.UrlEncode(Translit.ToTranslit(where, "h"), Encoding.UTF8) + "/poezda/";
            }
            try
            {
                return Util.GetContentFromUrl(sURL);
            }
            catch (IOException e)
            {
                e.StackTrace.ToString();
            }
            return null;
        }
    }
}
