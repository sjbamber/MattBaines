using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MattBaines.Data;

namespace MattBaines.Controllers
{
    public class AdvertisingCreativeCategoryController : Controller
    {
        private DataAccess _db;
        public AdvertisingCreativeCategoryController()
        {
            _db = new DataAccess();
        }

        [Authorize]
        public ActionResult Index()
        {
            var accategories = _db.GetAllAdvertisingCreativeCategories();
            return View(accategories);
        }

        [Authorize]
        public ActionResult Create()
        {
            AdvertisingCreativeCategory accategory = new AdvertisingCreativeCategory();
            return View("Create", accategory);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(AdvertisingCreativeCategory accategory)
        {
            if (ModelState.IsValid)
            {
                if (_db.AddAdvertisingCreativeCategory(accategory)) {
                    TempData["Notice"] = "Category Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Notice"] = "Category Creation Failed";
                }
            }
            return View(accategory);
        }

        [Authorize]
        public ActionResult Edit(Guid ID)
        {
            AdvertisingCreativeCategory accategory = _db.GetAdvertisingCreativeCategoryByID(ID);
            return View("Edit", accategory);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(AdvertisingCreativeCategory accategory)
        {
            if (ModelState.IsValid)
            {
                accategory.UpdatedDate = DateTime.Now;
                if (_db.UpdateAdvertisingCreativeCategory(accategory))
                {
                    TempData["Notice"] = "Category Updated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Notice"] = "Category Update Failed";
                }
            }
            return View(accategory);
        }

        [Authorize]
        public ActionResult Delete(Guid ID)
        {
            if (_db.DeleteAdvertisingCreativeCategory(ID))
            {
                TempData["Notice"] = "Category Deleted Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Notice"] = "Category Delete Failed<br/><br/>Ensure that the are no articles associated with this category to delete it.";
                return RedirectToAction("Index");
            }
        }

    }
}
