using App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.IBLL.Sys
{
    public interface ISampleBLL
    {
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="queryStr"></param>
        /// <returns></returns>
        List<SysSample> GetList(string queryStr);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Create( SysSample model);

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(string id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="deleteCollection"></param>
        /// <returns></returns>
        bool Delete(string[] deleteCollection);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Edit(SysSample model);

        /// <summary>
        /// 根据Id获取单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SysSample GetById(string id);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsExist(string id);
    }
}
