using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MattBaines.Models;
using MattBaines.Data;

namespace MattBaines.Controllers
{
    public class AdvertisingCreativeController : Controller
    {
        private DataAccess _db;
        public AdvertisingCreativeController()
        {
            _db = new DataAccess();
        }

        public ActionResult Index()
        {
            AdvertisingCreativeModel view_model = new AdvertisingCreativeModel()
            {
                Categories = _db.GetAllAdvertisingCreativeCategories(),
                Objects = _db.GetAllAdvertisingCreativeObjects()
            };
            return View(view_model);
        }

        public ActionResult Details(Guid ID)
        {
            AdvertisingCreativeModel view_model = new AdvertisingCreativeModel()
            {
                Categories = _db.GetAllAdvertisingCreativeCategories(),
                Objects = _db.GetAllAdvertisingCreativeObjects(),
                ACObject = _db.GetAdvertisingCreativeObjectByID(ID)
            };
            return View(view_model);
        }

    }
}
