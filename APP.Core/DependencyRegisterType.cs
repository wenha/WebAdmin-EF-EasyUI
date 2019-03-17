using APP.BLL.Sys;
using APP.DAL.Sys;
using APP.IBLL.Sys;
using APP.IDAL.Sys;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core
{
    public class DependencyRegisterType
    {
        public static void Container_Sys(ref UnityContainer container)
        {
            container.RegisterType<IUserBLL, UserBLL>();
            container.RegisterType<IUserRepository, UserRepository>();

            container.RegisterType<IHomeBLL, HomeBLL>();
            container.RegisterType<IHomeRepository, HomeRepository>();
        }
    }
}
