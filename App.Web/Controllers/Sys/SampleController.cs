using APP.IBLL.Sys;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Web.Controllers.Sys
{
    public class SampleController : Controller
    {
        #region 公共对象

        [Dependency]
        public ISampleBLL SampleBLL { get; set; }

        #endregion

        public ActionResult Index()
        {
            var list = SampleBLL.GetList("");

            return View(list);
        }
    }
}