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

        [Authorize]
        public ActionResult List()
        {
            var wilobjects = _db.GetAllWorkILikeObjects();
            return View(wilobjects);
        }

        [Authorize]
        public ActionResult Create()
        {
            WorkILike wilobject = new WorkILike();
            return View("Create", wilobject);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(WorkILike wilobject)
        {
            if (ModelState.IsValid)
            {
                if (_db.AddWorkILike(wilobject))
                {
                    TempData["Notice"] = "Article Created Successfully";
                    return RedirectToAction("Details", "WorkILike", new { ID = wilobject.Id });
                }
                else
                {
                    TempData["Notice"] = "Article Creation Failed";
                }
            }
            return View(wilobject);
        }
    }
}
