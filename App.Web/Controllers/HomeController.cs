using APP.IBLL.Sys;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Web.Controllers
{
    public class HomeController : BaseController
    {
        [Dependency]
        public  IHomeBLL HomeBLL { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTree(string id)
        {
            var menus = HomeBLL.GetMenuByPersonalId(id);

            var data = (from m in menus
                        select new
                        {
                            id = m.Code,
                            text = m.Name,
                            value = m.Url,
                            showCheck = false,
                            compute = false,
                            isExpend = false,
                            checkState = 0,
                            hasChildren = m.IsLast ? false : true,
                            icon = m.Iconic
                        }).ToArray();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        
    }
}