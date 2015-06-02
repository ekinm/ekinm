using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

using PagedList.Mvc;
using blog_deneme.Veritabani;


namespace blog_deneme.Controllers
{
    public class HomeController : Controller
    {

     


        public ActionResult Index()
        {
            return View();
          
        }

        public ActionResult About()
        {
            ViewBag.Message = "Ekin Moral'ın Kişisel Blogu.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}


