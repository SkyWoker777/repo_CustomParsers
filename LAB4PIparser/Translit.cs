using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4PIparser
{
    public class Translit
    {
        private static Dictionary<string, string> letters = new Dictionary<string, string>();

        public static void FillLetters()
        {
            letters.Add("а", "a");
            letters.Add("б", "b");
            letters.Add("в", "v");
            letters.Add("г", "g");
            letters.Add("д", "d");
            letters.Add("е", "e");
            letters.Add("ё", "e");
            letters.Add("ж", "zh");
            letters.Add("з", "z");
            letters.Add("и", "i");
            letters.Add("й", "i");
            letters.Add("к", "k");
            letters.Add("л", "l");
            letters.Add("м", "m");
            letters.Add("н", "n");
            letters.Add("о", "o");
            letters.Add("п", "p");
            letters.Add("р", "r");
            letters.Add("с", "s");
            letters.Add("т", "t");
            letters.Add("у", "u");
            letters.Add("ф", "f");
            letters.Add("ц", "ts");
            letters.Add("ч", "ch");
            letters.Add("ш", "sh");
            letters.Add("щ", "sh");
            letters.Add("ь", "");
            letters.Add("ъ", "'");
            letters.Add("ы", "y");
            letters.Add("э", "e");
            letters.Add("ю", "u");
            letters.Add("я", "ya");
        }

        public static string ToTranslit(string text, string option)
        {
            FillLetters();
            string input = text.ToLower().Replace("х", option);
            StringBuilder sb = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                string l = input.Substring(i, 1).ToLower();
                string value = "";
                if (letters.ContainsKey(l))
                {
                    letters.TryGetValue(l, out value);
                    sb.Append(value);
                }
                else
                {
                    sb.Append(l);
                }
            }
            return sb.ToString();
        }
    }
}
