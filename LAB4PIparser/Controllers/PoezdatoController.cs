using LAB4PIparser.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace LAB4PIparser.Controllers
{
    public class PoezdatoController : Controller
    {
        // GET: Poezdato
        public ActionResult List()
        {
            string where = Request.Params.Get("where");
            string when = Request.Params.Get("when");
            if (where == null || where == "")
            {
                ViewBag.Error = "Error, Parameter where can not be empty!";
            }
            else
            {
                if (!CheckDate(when))
                {
                    ViewBag.Error = "Error, Wrong date!";
                }
                else
                {
                    // do work
                    try
                    {
                        List<Train> trains = Models.PoezdatoViewModel.GetTrains(where, when);
                        if (trains == null)
                        {
                            ViewBag.Error = "Error, Something goes wrong! No trains";
                        }
                        else
                        {
                            return View(trains);
                        }
                    }
                    catch (ArgumentException e)
                    {
                        // error page
                        ViewBag.Error = e.Message;
                        return Redirect("/Shared/Error");
                    }
                }
            }

            return View();
        }

        private bool CheckDate(string date)
        {
            string pattern = "(0?[1-9]|[12][0-9]|3[01])\\.(0?[1-9]|1[012]).((19|20)\\d\\d)";
            Regex rx = new Regex(pattern);
            Match matcher = rx.Match(date);
            return matcher.Success;
        }

    }
}
