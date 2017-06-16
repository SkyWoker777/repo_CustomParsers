using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LAB4PIparser.Entity;
using System.IO;
using LAB4PIparser.Parsers;
using System.Net;

namespace LAB4PIparser.Models
{
    public class OlxViewModel
    {
        public static List<Advertisement> GetAds(string what, string where)
        {
            List<Advertisement> res = null;
            try
            {
                string content = GetContent(what, where);
                res = OlxParser.Parse(content);
            }
            catch (Exception e)
            {
            }
            return res;
        }

        private static string GetContent(string what, string where)
        {
            string sURL = "http://olx.ua/" + HttpUtility.UrlEncode(Translit.ToTranslit(where, "kh"), Encoding.UTF8) + "/q-"
                + HttpUtility.UrlEncode(what, Encoding.UTF8);
            try
            {
                return Util.GetContentFromUrl(sURL);
            }
            catch (IOException e)
            {
            }
            return null;
        }
    }
}
