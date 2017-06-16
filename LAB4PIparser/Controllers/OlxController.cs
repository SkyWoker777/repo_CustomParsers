using LAB4PIparser.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB4PIparser.Controllers
{
    public class OlxController : Controller
    {
        // GET: Olx
        public ActionResult List()
        {
            string what = Request.Params.Get("what");
            string where = Request.Params.Get("where");
            if (what == null || where == null || what == "" || where == "")
            {
                ViewBag.Error = "Error, Parameters can not be empty!";
            }
            else
            {
                try
                {
                    List<Advertisement> ads = Models.OlxViewModel.GetAds(what, where);
                    if (ads == null)
                    {
                        ViewBag.Error = "Error, Something goes wrong! No ads";
                    }
                    else
                    {
                        // go to ads page
                        return View(ads);
                    }
                }
                catch (ArgumentException e)
                {
                    // error page
                    ViewBag.Error = e.Message;
                    return Redirect("/Shared/Error");
                }
            }
            return View();
        }

    }
}
