using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4PIparser.Entity
{
    public class Train
    {
        private string number;
        private string url;
        private string from;
        private string to;

        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        public string From
        {
            get { return from; }
            set { from = value; }
        }
        public string TO
        {
            get { return to; }
            set { to = value; }
        }
    }
}
