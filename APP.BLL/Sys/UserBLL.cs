using App.Entity;
using APP.Common;
using APP.DAL.Sys;
using APP.IBLL.Sys;
using APP.IDAL.Sys;
using APP.Model.Sys;
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
        public bool Create(UserModel model)
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
        public bool Edit(UserModel model)
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
        /// <param name="pager"></param>
        /// <returns></returns>
        public List<UserModel> GetList(ref GridPager pager)
        {
            var queryData = UserRepository.GetList(db);

            //排序
            if(pager.order == "desc")
            {
                switch (pager.order)
                {
                    case "CreateTime":
                        queryData = queryData.OrderByDescending(c => c.CreateTime);
                        break;
                    case "Name":
                        queryData = queryData.OrderByDescending(c => c.Name);
                        break;
                    default:
                        queryData = queryData.OrderByDescending(c => c.CreateTime);
                        break;
                }
            }
            else
            {
                switch (pager.order)
                {
                    case "CreateTime":
                        queryData = queryData.OrderBy(c => c.CreateTime);
                        break;
                    case "Name":
                        queryData = queryData.OrderBy(c => c.Name);
                        break;
                    default:
                        queryData = queryData.OrderBy(c => c.CreateTime);
                        break;
                }
            }

            return CreateModelList(ref pager, ref queryData);
        }

        private List<UserModel> CreateModelList(ref GridPager pager, ref IQueryable<SysUser> queryData)
        {
            pager.totalRows = queryData.Count();

            if(pager.totalRows > 0)
            {
                if(pager.page <= 1)
                {
                    queryData = queryData.Take(pager.rows);
                }
                else
                {
                    queryData = queryData.Skip((pager.page - 1) * pager.rows).Take(pager.rows);
                }
            }

            var modelList = (from r in queryData
                             select new UserModel
                             {
                                 Id = r.Id,
                                 Name = r.Name,
                                 Age = r.Age,
                                 Bir = r.Bir,
                                 Photo = r.Photo,
                                 Note = r.Note,
                                 CreateTime = r.CreateTime
                             }).ToList();
            return modelList;
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
