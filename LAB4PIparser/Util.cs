using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LAB4PIparser
{
    public class Util
    {
        public static string GetContentFromUrl(string sURL)
        {
            Uri uri = new Uri(sURL);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException("Error 404: Not found");
            }
            StreamReader sr = new StreamReader(response.GetResponseStream());
            StringBuilder output = new StringBuilder();
            output.Append(sr.ReadToEnd());

            response.Close();

            return output.ToString();
        }
    }
}
