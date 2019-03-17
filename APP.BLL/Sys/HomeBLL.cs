using App.Entity;
using APP.IBLL.Sys;
using APP.IDAL.Sys;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.BLL.Sys
{
    public class HomeBLL : IHomeBLL
    {
        [Dependency]
        public IHomeRepository HomeRepository { get; set; }

        public List<SysModule> GetMenuByPersonalId(string moduleId)
        {
            return HomeRepository.GetMenuByPersonalId(moduleId);
        }
    }
}
