using App.Entity;
using APP.DAL.Sys;
using APP.IBLL.Sys;
using APP.IDAL.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.BLL.Sys
{
    public class UserBLL : IUserBLL
    {
        AppsDBEntities db = new AppsDBEntities();

        IUserRepository UserRepository = new UserRepository();

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Create(SysUser model)
        {
            try
            {
                if (UserRepository.Create(model) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                if (UserRepository.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="deleteCollection"></param>
        /// <returns></returns>
        public bool Delete(string[] deleteCollection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit(SysUser model)
        {
            try
            {
                if (UserRepository.Edit(model) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 根据Id获取单条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysUser GetById(int id)
        {
            if (IsExist(id))
            {
                var entity = UserRepository.GetById(id);
                return entity;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="queryStr"></param>
        /// <returns></returns>
        public List<SysUser> GetList(string queryStr)
        {
            return UserRepository.GetList(db).ToList();
        }

        /// <summary>
        /// 根据Id判断是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsExist(int id)
        {
            return UserRepository.IsExist(id);
        }
    }
}
