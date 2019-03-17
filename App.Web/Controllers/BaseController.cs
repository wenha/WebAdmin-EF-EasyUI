using APP.Common;
using APP.IBLL.Sys;
using APP.Model.Sys;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace App.Web.Controllers
{
    public class BaseController : Controller
    {
        public int GetUserId()
        {
            if(Session["Account"] != null)
            {
                AccountModel info = (AccountModel)Session["Account"];
                return info.Id;
            }
            else
            {
                return 0;
            }
        }

        public string GetUserName()
        {
            if (Session["Account"] != null)
            {
                AccountModel info = (AccountModel)Session["Account"];
                return info.Name;
            }
            else
            {
                return "";
            }
        }

        public AccountModel GetAccount()
        {
            if(Session["Account"] != null)
            {
                return (AccountModel)Session["Account"];
            }
            return null;
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new ToJsonResult
            {
                Data = data,
                ContentEncoding = contentEncoding,
                ContentType = contentType,
                JsonRequestBehavior = behavior,
                FormateStr = "yyyy-mm-dd HH:mm:ss"
            };
        }

        protected JsonResult MyJson(object data, JsonRequestBehavior behavior, string format)
        {
            return new ToJsonResult
            {
                Data = data,
                JsonRequestBehavior = behavior,
                FormateStr = format
            };
        }
        /// <summary>
        /// 返回JsonResult42         
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="format">数据格式</param>
        /// <returns>Json</returns>
        protected JsonResult MyJson(object data, string format)
        {
            return new ToJsonResult
            {
                Data = data,
                FormateStr = format
            };
        }
        /// <summary>
        /// 检查SQL语句合法性
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ValidateSQL(string sql, ref string msg)
        {
            if (sql.ToLower().IndexOf("delete") > 0)
            {
                msg = "查询参数中含有非法语句DELETE";
                return false;
            }
            if (sql.ToLower().IndexOf("update") > 0)
            {
                msg = "查询参数中含有非法语句UPDATE";
                return false;
            }

            if (sql.ToLower().IndexOf("insert") > 0)
            {
                msg = "查询参数中含有非法语句INSERT";
                return false;
            }
            return true;
        }
    }
}