using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWit.Model
{
    public abstract class WitDbContextBase<TWitEntity> where TWitEntity : class
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

        protected async Task<TWitEntity> dbFindByIdAsync(Guid? id)
        {
            return await db.Set<TWitEntity>().FindAsync(id);
        }
        protected async Task<List<TWitEntity>> dbGetAllAsync()
        {
            return await db.Set<TWitEntity>().ToListAsync();
        }
        protected async Task dbUpdateAsync(TWitEntity entity, string modifiedBy)
        {
            db.ModifiedBy = modifiedBy;
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
        protected async Task<TWitEntity> dbCreateAsync(TWitEntity entity, string modifiedBy)
        {
            db.ModifiedBy = modifiedBy;
            db.Set<TWitEntity>().Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }
        protected async Task dbRemoveAsync(Guid? id)
        {
            db.SetTrackingAndProxy(false);

            var _entity = db.Set<TWitEntity>().Find(id);
            if (_entity != null)
            {
                db.Set<TWitEntity>().Remove(_entity);
                await db.SaveChangesAsync();
            }
        }
    }
}
