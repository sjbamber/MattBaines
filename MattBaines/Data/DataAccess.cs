using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MattBaines.Data
{
    public class DataAccess
    { 
        private DataContext _db;

        public DataAccess()
        {
            _db = new DataContext();
        }

        /* Advertising Creative Category
         * ----------------------------- */

        // Read
        public List<AdvertisingCreativeCategory> GetAllAdvertisingCreativeCategories()
        {
            var categories = (from c in _db.AdvertisingCreativeCategories
                            orderby c.CreatedDate ascending
                            select c).ToList();
            return categories;
        }

        public AdvertisingCreativeCategory GetAdvertisingCreativeCategoryByID(Guid ID)
        {
            AdvertisingCreativeCategory ACcategory = (from c in _db.AdvertisingCreativeCategories
                                                  where c.Id == ID
                                                  select c).FirstOrDefault();
            return ACcategory;
        }

        // Write
        public bool AddAdvertisingCreativeCategory(AdvertisingCreativeCategory category)
        {
            try
            {
                _db.AdvertisingCreativeCategories.Add(category);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAdvertisingCreativeCategory(AdvertisingCreativeCategory ACcategory)
        {
            try
            {
                AdvertisingCreativeCategory ACcategoryToUpdate = _db.AdvertisingCreativeCategories.Find(ACcategory.Id);
                _db.Entry(ACcategoryToUpdate).CurrentValues.SetValues(ACcategory);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAdvertisingCreativeCategory(Guid ID)
        {
            try
            {
                AdvertisingCreativeCategory acc = _db.AdvertisingCreativeCategories.Find(ID);
                if (acc.Objects.Any())
                    return false;
                
                _db.AdvertisingCreativeCategories.Remove(acc);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /* Advertising Creative Object
         * ----------------------------- */

        // Read
        public List<AdvertisingCreativeObject> GetAllAdvertisingCreativeObjects()
        {
            var objects = (from o in _db.AdvertisingCreativeObjects
                            orderby o.CreatedDate ascending
                            select o).ToList();
            return objects;
        }

        public AdvertisingCreativeObject GetAdvertisingCreativeObjectByID(Guid ID)
        {
            AdvertisingCreativeObject ACobject = (from o in _db.AdvertisingCreativeObjects
                                                  where o.Id == ID
                                                  select o).FirstOrDefault();
            return ACobject;
        }

        // Write
        public bool AddAdvertisingCreativeObject(AdvertisingCreativeObject ACobject)
        {
            try
            {
                _db.AdvertisingCreativeObjects.Add(ACobject);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAdvertisingCreativeObject(AdvertisingCreativeObject ACobject)
        {
            try
            {
                AdvertisingCreativeObject ACobjectToUpdate = _db.AdvertisingCreativeObjects.Find(ACobject.Id);
                _db.Entry(ACobjectToUpdate).CurrentValues.SetValues(ACobject);
                ACobjectToUpdate.Category = ACobject.Category;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAdvertisingCreativeObjectByID(Guid ID)
        {
            try
            {
                AdvertisingCreativeObject ACobjectToDelete = _db.AdvertisingCreativeObjects.Find(ID);
                _db.AdvertisingCreativeObjects.Remove(ACobjectToDelete);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /* Work I Like
         * ----------------------------- */

        // Read
        public List<WorkILike> GetAllWorkILikeObjects()
        {
            var objects = (from o in _db.WorkILikeEntries
                           orderby o.CreatedDate ascending
                           select o).ToList();
            return objects;
        }

        public WorkILike GetWorkILikeObjectByID(Guid ID)
        {
            WorkILike WILobject = (from o in _db.WorkILikeEntries
                                                  where o.Id == ID
                                                  select o).FirstOrDefault();
            return WILobject;
        }
        // Write
        public bool AddWorkILike(WorkILike workILike)
        {
            try
            {
                _db.WorkILikeEntries.Add(workILike);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateWorkILike(WorkILike wil)
        {
            try
            {
                WorkILike wiltoupdate = _db.WorkILikeEntries.Find(wil.Id);
                _db.Entry(wiltoupdate).CurrentValues.SetValues(wil);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}