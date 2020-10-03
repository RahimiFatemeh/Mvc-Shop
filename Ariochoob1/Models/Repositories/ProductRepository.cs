using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ariochoob1.Models.Repositories
{
    public class ProductRepository : IDisposable
    {
        private Ariochoob1.Models.DomainModels.AriochoobDBEntities1 db = null;

        public ProductRepository()
        {
            db = new DomainModels.AriochoobDBEntities1();
        }

        public bool Add(Ariochoob1.Models.DomainModels.Product entity, bool autoSave = true)
        {
            try
            {
                db.Products.Add(entity);
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

        public bool Update(Ariochoob1.Models.DomainModels.Product entity, bool autoSave = true)
        {
            try
            {
                db.Products.Attach(entity);
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

        public bool Delete(Ariochoob1.Models.DomainModels.Product entity, bool autoSave = true)
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
                var entity = db.Products.Find(id);
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

        public Ariochoob1.Models.DomainModels.Product Find(int id)
        {
            try
            {
                return db.Products.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Ariochoob1.Models.DomainModels.Product> Where(System.Linq.Expressions.Expression<Func<Ariochoob1.Models.DomainModels.Product, bool>> predicate)
        {
            try
            {
                return db.Products.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Ariochoob1.Models.DomainModels.Product> Select()
        {
            try
            {
                return db.Products.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Ariochoob1.Models.DomainModels.Product, TResult>> selector)
        {
            try
            {
                return db.Products.Select(selector);
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
                if (db.Products.Any())
                    return db.Products.OrderByDescending(p => p.ProductId).First().ProductId;
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

        ~ProductRepository()
        {
            Dispose(false);
        }
    }
}