using APP.Common;
using APP.IBLL.Sys;
using APP.Model.Sys;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Web.Controllers.Sys
{
    public class UserController : BaseController
    {
        #region 公共对象

        [Dependency]
        public IUserBLL UserBLL { get; set; }

        #endregion

        #region 首页
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(GridPager pager)
        {
            var list = UserBLL.GetList(ref pager);

            return Json(new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new UserModel
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Age = r.Age,
                            Bir = r.Bir,
                            Photo = r.Photo,
                            Note = r.Note,
                            CreateTime = r.CreateTime
                        }).ToArray()
            }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 添加

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            var res = UserBLL.Create(model);

            if (res)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 编辑

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            var res = UserBLL.Edit(model);

            if (res)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        public ActionResult Delete(int id)
        {
            var res = UserBLL.Delete(id);

            if (res)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
    }
}