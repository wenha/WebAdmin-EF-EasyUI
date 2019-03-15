using APP.IBLL.Sys;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Web.Controllers.Sys
{
    public class UserController : Controller
    {
        #region 公共对象

        [Dependency]
        public IUserBLL UserBLL { get; set; }

        #endregion

        public ActionResult Index()
        {
            var list = UserBLL.GetList("");

            return View(list);
        }
    }
}