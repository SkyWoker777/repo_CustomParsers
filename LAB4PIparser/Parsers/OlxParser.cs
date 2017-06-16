using LAB4PIparser.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LAB4PIparser.Parsers
{
    public class OlxParser
    {
        public static List<Advertisement> Parse(string doc)
        {
            List<Advertisement> res = new List<Advertisement>();
            Regex rx = new Regex("Не найдено ни одного объявления");
            Match matcher = rx.Match(doc);
            if (matcher.Success)
            {
                return res;
            }

            string pattern = @"h3 class=""x-large lheight20 margintop5\"">\s+<a href=""(.+)"" class.+>\s+<strong>(.+)</strong>[\S\s]+?<p class=""price"">[\S\s]+?<strong>(.+)</strong>";

            Advertisement adv = null;
            foreach (Match m in Regex.Matches(doc, pattern, RegexOptions.IgnoreCase))
            {
                adv = new Advertisement();
                adv.Url = m.Groups[1].Value;
                adv.Title = m.Groups[2].Value;
                adv.Price = m.Groups[3].Value;
                res.Add(adv);

            }
            return res;

        }
    }
}
