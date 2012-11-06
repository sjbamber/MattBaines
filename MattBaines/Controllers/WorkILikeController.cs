using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MattBaines.Models;
using MattBaines.Data;

namespace MattBaines.Controllers
{
    public class WorkILikeController : Controller
    {
        private DataAccess _db;
        public WorkILikeController()
        {
            _db = new DataAccess();
        }

        public ActionResult Index()
        {
            List<WorkILike> view_model = _db.GetAllWorkILikeObjects();
            return View(view_model);
        }

        public ActionResult Details(Guid ID)
        {
            WorkILikeModel view_model = new WorkILikeModel()
            {
                workILikeObject = _db.GetWorkILikeObjectByID(ID),
                WorkILikeEntries = _db.GetAllWorkILikeObjects()
            };
            return View(view_model);
        }

    }
}
