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
        private DataAccess _db;
        public HomeController()
        {
            _db = new DataAccess();
        }

        public ActionResult Index(bool fetchModels=true)
        {
            if (fetchModels)
            {
                HomeModel view_model = new HomeModel()
                {
                    AdvertisingCreative = new AdvertisingCreativeModel()
                    {
                        Categories = _db.GetAllAdvertisingCreativeCategories(),
                        Objects = _db.GetAllAdvertisingCreativeObjects()
                    },
                    WorkILike = _db.GetAllWorkILikeObjects()
                };
                return View("IndexNoJS", view_model);
            }
            return View();
        }

        public ActionResult AdvertisingCreative()
        {
            var AdvertisingCreative = new AdvertisingCreativeModel()
            {
                Categories = _db.GetAllAdvertisingCreativeCategories(),
                Objects = _db.GetAllAdvertisingCreativeObjects()
            };
            return PartialView("~/Views/AdvertisingCreative/_AdvertisingCreative.cshtml", AdvertisingCreative);
        }

        public ActionResult WorkILike()
        {
            var WorkILike = _db.GetAllWorkILikeObjects();
            return PartialView("~/Views/WorkILike/_WorkILike.cshtml", WorkILike);
        }
    }
}
