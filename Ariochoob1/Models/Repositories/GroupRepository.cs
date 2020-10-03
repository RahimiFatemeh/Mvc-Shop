using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ariochoob1.Models.Repositories
{
    public class GroupRepository : IDisposable
    {
        private Ariochoob1.Models.DomainModels.AriochoobDBEntities1 db = null;

        public GroupRepository()
        {
            db = new DomainModels.AriochoobDBEntities1();
        }

        public bool Add(Ariochoob1.Models.DomainModels.Group entity, bool autoSave = true)
        {
            try
            {
                db.Groups.Add(entity);
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

        public bool Update(Ariochoob1.Models.DomainModels.Group entity, bool autoSave = true)
        {
            try
            {
                db.Groups.Attach(entity);
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

        public bool Delete(Ariochoob1.Models.DomainModels.Group entity, bool autoSave = true)
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
                var entity = db.Groups.Find(id);
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

        public Ariochoob1.Models.DomainModels.Group Find(int id)
        {
            try
            {
                return db.Groups.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Ariochoob1.Models.DomainModels.Group> Where(System.Linq.Expressions.Expression<Func<Ariochoob1.Models.DomainModels.Group, bool>> predicate)
        {
            try
            {
                return db.Groups.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Ariochoob1.Models.DomainModels.Group> Select()
        {
            try
            {
                return db.Groups.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Ariochoob1.Models.DomainModels.Group, TResult>> selector)
        {
            try
            {
                return db.Groups.Select(selector);
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
                if (db.Groups.Any())
                    return db.Groups.OrderByDescending(p => p.GroupId).First().GroupId;
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

        ~GroupRepository()
        {
            Dispose(false);
        }
    }
}