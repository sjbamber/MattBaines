using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MattBaines.Data;

namespace MattBaines.Controllers
{
    public class AdvertisingCreativeObjectController : Controller
    {
        private DataAccess _db;
        public AdvertisingCreativeObjectController()
        {
            _db = new DataAccess();
        }

        [Authorize]
        public ActionResult Index()
        {
            var acobjects = _db.GetAllAdvertisingCreativeObjects();
            return View(acobjects);
        }

        [Authorize]
        public ActionResult Create()
        {
            AdvertisingCreativeObject acobject = new AdvertisingCreativeObject();

            // Get List of users for the dropdown box
            acobject.CategoryList = _db.GetAllAdvertisingCreativeCategories();
            return View("Create", acobject);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(AdvertisingCreativeObject acobject)
        {
            if (ModelState.IsValid)
            {
                acobject.Category = _db.GetAdvertisingCreativeCategoryByID(acobject.CategoryId);
                if (_db.AddAdvertisingCreativeObject(acobject)) {
                    TempData["Notice"] = "Article Created Successfully";
                    return RedirectToAction("Details", "AdvertisingCreative", new { ID = acobject.Id });
                }
                else
                {
                    TempData["Notice"] = "Article Creation Failed";
                }
            }
            acobject.CategoryList = _db.GetAllAdvertisingCreativeCategories();
            return View(acobject);
        }

        [Authorize]
        public ActionResult Edit(Guid ID)
        {
            AdvertisingCreativeObject acobject = _db.GetAdvertisingCreativeObjectByID(ID);

            // Get List of users for the dropdown box
            acobject.CategoryList = _db.GetAllAdvertisingCreativeCategories();
            return View("Edit", acobject);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(AdvertisingCreativeObject acobject)
        {
            if (ModelState.IsValid)
            {
                acobject.UpdatedDate = DateTime.Now;
                acobject.Category = _db.GetAdvertisingCreativeCategoryByID(acobject.CategoryId);
                if (_db.UpdateAdvertisingCreativeObject(acobject))
                {
                    TempData["Notice"] = "Article Updated Successfully";
                    return RedirectToAction("Details", "AdvertisingCreative", new { ID = acobject.Id });
                }
                else
                {
                    TempData["Notice"] = "Article Update Failed";
                }
            }
            acobject.CategoryList = _db.GetAllAdvertisingCreativeCategories();
            return View(acobject);
        }

        [Authorize]
        public ActionResult Delete(Guid ID)
        {
            if (_db.DeleteAdvertisingCreativeObjectByID(ID))
            {
                TempData["Notice"] = "Article Deleted Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Notice"] = "Article Delete Failed";
                return View("Index");
            }
        }

    }
}
