using App.Entity;
using APP.IDAL.Sys;
using APP.Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.DAL.Sys
{
    public class UserRepository : IUserRepository, IDisposable
    {
        public int Create(UserModel entity)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                var user = new SysUser();
                user.Name = entity.Name;
                user.Bir = entity.Bir;
                user.Age = entity.Age;
                user.Note = entity.Note;
                user.Photo = entity.Photo;
                user.CreateTime = DateTime.Now;
                db.SysUser.Add(user);
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

        public int Edit(UserModel entity)
        {
            using (AppsDBEntities db = new AppsDBEntities())
            {
                var user = db.SysUser.FirstOrDefault(u => u.Id == entity.Id);
                user.Name = entity.Name;
                user.Bir = entity.Bir;
                user.Age = entity.Age;
                user.Photo = entity.Photo;
                user.Note = entity.Note;
                db.SysUser.Attach(user);
                db.Entry<SysUser>(user).State = System.Data.Entity.EntityState.Modified;
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
                if (entity == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
