using App.Entity;
using APP.Model.Sys;
using System.Linq;

namespace APP.IDAL.Sys
{
    public interface IUserRepository
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        IQueryable<SysUser> GetList(AppsDBEntities db);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Create(UserModel entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(int id);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Edit(UserModel entity);

        /// <summary>
        /// 根据id获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SysUser GetById(int id);

        /// <summary>
        /// 根据id判断是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsExist(int id);
    }
}
