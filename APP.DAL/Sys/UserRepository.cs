using App.Entity;
using APP.IDAL.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Sys
{
    public class UserRepository : IUserRepository, IDisposable
    {
        public int Create(SysUser entity)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                db.SysUser.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(int id)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                var entity = db.SysUser.SingleOrDefault(s => s.Id == id);
                db.SysUser.Remove(entity);
                return db.SaveChanges();
            }
        }

        public void Dispose()
        {
        }

        public int Edit(SysUser entity)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                db.SysUser.Attach(entity);
                db.Entry<SysUser>(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public SysUser GetById(int id)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                return db.SysUser.SingleOrDefault(s => s.Id == id);
            }
        }

        public IQueryable<SysUser> GetList(AppsDBEntities db)
        {
            return db.SysUser.AsQueryable();
        }

        public bool IsExist(int id)
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
