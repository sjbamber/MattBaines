using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MattBaines.Data;
using MattBaines.Models;

namespace MattBaines.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return RedirectToAction("Index", "AdvertisingCreative");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult WorkILike()
        {
            return View();
        }
    }
}
