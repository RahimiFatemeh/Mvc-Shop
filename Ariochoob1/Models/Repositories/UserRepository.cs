using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ariochoob1.Models.Repositories
{
    public class UserRepository : IDisposable
    {
        private Ariochoob1.Models.DomainModels.AriochoobDBEntities1 db = null;

        public UserRepository()
        {
            db = new DomainModels.AriochoobDBEntities1();
        }

        public bool Add(Ariochoob1.Models.DomainModels.User entity, bool autoSave = true)
        {
            try
            {
                db.Users.Add(entity);
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Exist(string username, string password) 
        {
            try
            {
                return db.Users.Where(p => p.Username == username && p.Password == password).Any() ;
            }
            catch
            {

                return false;
            }
        }

        public bool Update(Ariochoob1.Models.DomainModels.User entity, bool autoSave = true)
        {
            try
            {
                db.Users.Attach(entity);
                db.Entry(entity).State = System.Data.EntityState.Modified;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Ariochoob1.Models.DomainModels.User entity, bool autoSave = true)
        {
            try
            {
                db.Entry(entity).State = System.Data.EntityState.Deleted;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id, bool autoSave = true)
        {
            try
            {
                var entity = db.Users.Find(id);
                db.Entry(entity).State = System.Data.EntityState.Deleted;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public Ariochoob1.Models.DomainModels.User Find(int id)
        {
            try
            {
                return db.Users.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Ariochoob1.Models.DomainModels.User> Where(System.Linq.Expressions.Expression<Func<Ariochoob1.Models.DomainModels.User, bool>> predicate)
        {
            try
            {
                return db.Users.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Ariochoob1.Models.DomainModels.User> Select()
        {
            try
            {
                return db.Users.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Ariochoob1.Models.DomainModels.User, TResult>> selector)
        {
            try
            {
                return db.Users.Select(selector);
            }
            catch
            {
                return null;
            }
        }

        public int GetLastIdentity()
        {
            try
            {
                if (db.Users.Any())
                    return db.Users.OrderByDescending(p => p.UserId).First().UserId;
                else
                    return 0;
            }
            catch
            {
                return -1;
            }
        }

        public int Save()
        {
            try
            {
                return db.SaveChanges();
            }
            catch
            {
                return -1;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }

        ~UserRepository()
        {
            Dispose(false);
        }
    }
}