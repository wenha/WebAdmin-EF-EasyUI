using App.Entity;
using APP.IDAL.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Sys
{
    public class SampleRepository : ISampleRepository, IDisposable
    {
        public int Create(SysSample entity)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                db.SysSample.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                var entity = db.SysSample.SingleOrDefault(s => s.Id == id);
                db.SysSample.Remove(entity);
                return db.SaveChanges();
            }
        }

        public void Dispose()
        {
        }

        public int Edit(SysSample entity)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                db.SysSample.Attach(entity);
                db.Entry<SysSample>(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public SysSample GetById(string id)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                return db.SysSample.SingleOrDefault(s => s.Id == id);
            }
        }

        public IQueryable<SysSample> GetList(AppsDBEntities db)
        {
            return db.SysSample.AsQueryable();
        }

        public bool IsExist(string id)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                var entity = GetById(id);
                if(entity == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
