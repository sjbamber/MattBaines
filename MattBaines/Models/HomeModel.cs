using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace MattBaines.Models
{
    public class HomeModel
    {
        public AdvertisingCreativeModel AdvertisingCreative { get; set; }
        public List<WorkILike> WorkILike { get; set; }
    }
}
