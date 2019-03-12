using App.Entity;
using System.Linq;

namespace APP.IDAL.Sys
{
    public interface ISampleRepository
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        IQueryable<SysSample> GetList(AppsDBEntities db);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Create(SysSample entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(string id);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Edit(SysSample entity);

        /// <summary>
        /// 根据id获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SysSample GetById(string id);

        /// <summary>
        /// 根据id判断是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsExist(string id);
    }
}
