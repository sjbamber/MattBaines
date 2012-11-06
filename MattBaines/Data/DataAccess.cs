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
    }
}