using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ariochoob1.Models.Repositories
{
    public class SaleFactorRepository : IDisposable
    {
        private Ariochoob1.Models.DomainModels.AriochoobDBEntities1 db = null;

        public SaleFactorRepository()
        {
            db = new DomainModels.AriochoobDBEntities1();
        }

        public bool Add(Ariochoob1.Models.DomainModels.SaleFactor entity, bool autoSave = true)
        {
            try
            {
                db.SaleFactors.Add(entity);
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

        public bool Update(Ariochoob1.Models.DomainModels.SaleFactor entity, bool autoSave = true)
        {
            try
            {
                db.SaleFactors.Attach(entity);
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

        public bool Delete(Ariochoob1.Models.DomainModels.SaleFactor entity, bool autoSave = true)
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
                var entity = db.SaleFactors.Find(id);
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

        public Ariochoob1.Models.DomainModels.SaleFactor Find(int id)
        {
            try
            {
                return db.SaleFactors.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Ariochoob1.Models.DomainModels.SaleFactor> Where(System.Linq.Expressions.Expression<Func<Ariochoob1.Models.DomainModels.SaleFactor, bool>> predicate)
        {
            try
            {
                return db.SaleFactors.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Ariochoob1.Models.DomainModels.SaleFactor> Select()
        {
            try
            {
                return db.SaleFactors.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Ariochoob1.Models.DomainModels.SaleFactor, TResult>> selector)
        {
            try
            {
                return db.SaleFactors.Select(selector);
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
                if (db.SaleFactors.Any())
                    return db.SaleFactors.OrderByDescending(p => p.SaleFactorId).First().SaleFactorId;
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

        ~SaleFactorRepository()
        {
            Dispose(false);
        }
    }
}