using App.Entity;
using APP.IDAL.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Sys
{
    public class HomeRepository : IHomeRepository, IDisposable
    {
        public void Dispose()
        {
        }

        /// <summary>
        /// 根据人员Id获取菜单
        /// </summary>
        /// <param name="personalId"></param>
        /// <returns></returns>
        public List<SysModule> GetMenuByPersonalId(string personalId)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                var menus = (from m in db.SysModule
                             where m.ParentCode == personalId
                             where m.Code != "0"
                             select m).Distinct().OrderBy(a => a.Sort).ToList();

                return menus;
            }
        }
    }
}
