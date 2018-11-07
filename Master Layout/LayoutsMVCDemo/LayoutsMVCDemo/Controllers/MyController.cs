using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutsMVCDemo.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AboutUs()
        {
            return View();
        }



        public ActionResult ContactUs()
        {
            return View();
        }


        public ActionResult Facebook()
        {
            return View();
        }


        public ActionResult Twitter()
        {
            return View();
        }
    }
}