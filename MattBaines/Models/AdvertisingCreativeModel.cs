using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MattBaines.Models
{
    public class AdvertisingCreativeModel
    {
        public List<AdvertisingCreativeCategory> Categories { get; set; }
        public List<AdvertisingCreativeObject> Objects { get; set; }
        public AdvertisingCreativeObject ACObject { get; set; }
    }
}