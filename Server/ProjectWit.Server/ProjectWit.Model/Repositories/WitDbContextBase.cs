using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWit.Model
{
    public class WitDbContextBase<T> where T : class
    {
        private WitDbContext _db;
        protected WitDbContext db
        {
            get
            {
                if (_db == null)
                    _db = new WitDbContext();

                return _db;
            }
            set { _db=value;}
        }

        protected async Task<T> dbFindByIdAsync(Guid? id)
        {
            return await db.Set<T>().FindAsync(id);
        }
        protected async Task<List<T>> dbGetAllAsync()
        {
            return await db.Set<T>().ToListAsync();
        }
        protected async Task dbUpdateAsync(T entity, string modifiedBy)
        {
            db.ModifiedBy = modifiedBy;
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
        protected async Task<T> dbCreateAsync(T entity, string modifiedBy)
        {
            db.ModifiedBy = modifiedBy;
            db.Set<T>().Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }
        protected async Task dbRemoveAsync(Guid? id)
        {
            db.SetTrackingAndProxy(false);

            var _entity = db.Set<T>().Find(id);
            if (_entity != null)
            {
                db.Set<T>().Remove(_entity);
                await db.SaveChangesAsync();
            }
        }
    }
}
