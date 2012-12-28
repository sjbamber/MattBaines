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
                workILikeObject = _db.GetWorkILikeObjectByID(ID)
            };
            return PartialView("_Details", view_model);
            //return View(view_model);
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

        [Authorize]
        public ActionResult Edit(Guid ID)
        {
            WorkILike wil = _db.GetWorkILikeObjectByID(ID);
            return View("Edit", wil);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(WorkILike wil)
        {
            if (ModelState.IsValid)
            {
                wil.UpdatedDate = DateTime.Now;
                if (_db.UpdateWorkILike(wil))
                {
                    TempData["Notice"] = "Article Updated Successfully";
                    return RedirectToAction("Details", "WorkILike", new { ID = wil.Id });
                }
                else
                {
                    TempData["Notice"] = "Article Update Failed";
                }
            }
            return View("Edit", wil);
        }
    }
}
