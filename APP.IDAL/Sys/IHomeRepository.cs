using App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.IDAL.Sys
{
    public interface IHomeRepository
    {
        /// <summary>
        /// 根据人员Id获取菜单
        /// </summary>
        /// <param name="personalId"></param>
        /// <returns></returns>
        List<SysModule> GetMenuByPersonalId(string personalId);
    }
}
