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
    public class SampleBLL : ISampleBLL
    {
        AppsDBEntities db = new AppsDBEntities();

        ISampleRepository SampleRepository = new SampleRepository();

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Create( SysSample model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete( string id)
        {
            throw new NotImplementedException();
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
        public bool Edit(SysSample model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据Id获取单条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysSample GetById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="queryStr"></param>
        /// <returns></returns>
        public List<SysSample> GetList(string queryStr)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据Id判断是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsExist(string id)
        {
            return SampleRepository.IsExist(id);
        }
    }
}
