using App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.IBLL.Sys
{
    public interface IHomeBLL
    {
        List<SysModule> GetMenuByPersonalId(string moduleId);
    }
}
