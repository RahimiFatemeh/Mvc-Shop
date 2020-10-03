using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ariochoob1.Models.Repositories
{
    public class OrderRepository : IDisposable
    {
        private Ariochoob1.Models.DomainModels.AriochoobDBEntities1 db = null;

        public OrderRepository()
        {
            db = new DomainModels.AriochoobDBEntities1();
        }

        public bool Add(Ariochoob1.Models.DomainModels.Order entity, bool autoSave = true)
        {
            try
            {
                db.Orders.Add(entity);
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

        public bool Update(Ariochoob1.Models.DomainModels.Order entity, bool autoSave = true)
        {
            try
            {
                db.Orders.Attach(entity);
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

        public bool Delete(Ariochoob1.Models.DomainModels.Order entity, bool autoSave = true)
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
                var entity = db.Orders.Find(id);
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

        public Ariochoob1.Models.DomainModels.Order Find(int id)
        {
            try
            {
                return db.Orders.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Ariochoob1.Models.DomainModels.Order> Where(System.Linq.Expressions.Expression<Func<Ariochoob1.Models.DomainModels.Order, bool>> predicate)
        {
            try
            {
                return db.Orders.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Ariochoob1.Models.DomainModels.Order> Select()
        {
            try
            {
                return db.Orders.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Ariochoob1.Models.DomainModels.Order, TResult>> selector)
        {
            try
            {
                return db.Orders.Select(selector);
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
                if (db.Orders.Any())
                    return db.Orders.OrderByDescending(p => p.OrderId).First().OrderId;
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

        ~OrderRepository()
        {
            Dispose(false);
        }
    }
}