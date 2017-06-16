using LAB4PIparser.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LAB4PIparser.Parsers
{
    public class PoezdatoParser
    {
        public static List<Train> Parse(string doc)
        {
            List<Train> res = new List<Train>();

            //URL 
            //string pattern = @"<td class=""num {sorter: 'integer'}""><a href=""(.+)"">";

            //URL + Num
            //string pattern = @"<td class=""num {sorter: 'integer'}""><a href=""(.+)"">(.+)</a>";

            //string pattern = @"<td class=""num {sorter: 'integer'}""><a href=""(.+)"">(.+)</a>\s+</td>\s+<td class=""dir"">\s+";

            //Url + Num + From
            string pattern = @"<td class=""num {sorter: 'integer'}""><a href=""(.+)"">(.+)</a>\s+</td>\s+<td class=""dir"">\s+<a href="".+"">\s+(.+)\s+</a>";

            //All
            //string pattern = @"<td class=""num {sorter: 'integer'}""><a href=""(.+)"">(.+)</a>\s+</td>\s+<td class=""dir"">\s+<a href="".+"">\s+(.+)\s+</a>\s+>\s+";

            //string pattern = @"<td class=""num {sorter: 'integer'}""><a href=""(.+)"">(.+)</a>\s+</td>\s+<td class=""dir"">\s+<a href="".+"">\s+(.+)\s+</a>\s+>?\s+";

            //string pattern = @"\s+>\s+";

            Train train = null;
            foreach (Match m in Regex.Matches(doc, pattern, RegexOptions.IgnoreCase))
            {
                train = new Train();
                train.Url = m.Groups[1].Value;
                train.Number = m.Groups[2].Value;
                train.From = m.Groups[3].Value;
                train.TO = m.Groups[4].Value;
                res.Add(train);

            }
            return res;
        }
    }
}
