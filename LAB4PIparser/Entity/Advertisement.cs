using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4PIparser.Entity
{
    public class Advertisement
    {
        private string title;
        private string price;
        private string url;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Price
        {
            get {return price; }
            set {price = value; }
        }
        public string Url
        {
            get {return url; }
            set {url = value; }
        }

        //public override string ToString()
        //{
        //    return "Advertisement [title=" + title + ", price=" + price + ", url=" + url + "]";
        //}
    }
}
