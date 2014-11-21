using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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

        public void SetDbContext(DbContext db)
        {
            if (_db == null)
                _db = (WitDbContext)db;
        }
        public virtual async Task<TWitEntity> FindByIdAsync(Guid? id)
        {
            return await db.Set<TWitEntity>().FindAsync(id);
        }
        public virtual async Task<List<TWitEntity>> GetAllAsync()
        {
            return await db.Set<TWitEntity>().ToListAsync();
        }
        public virtual async Task UpdateAsync(TWitEntity entity, string modifiedBy)
        {
            if (String.IsNullOrEmpty(db.ModifiedBy))
                db.ModifiedBy = modifiedBy;

            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
        public virtual async Task<TWitEntity> CreateAsync(TWitEntity entity, string modifiedBy)
        {
            if (String.IsNullOrEmpty(db.ModifiedBy))
                db.ModifiedBy = modifiedBy;

            db.Set<TWitEntity>().Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }
        public virtual async Task RemoveAsync(Guid? id)
        {
            db.SetTrackingAndProxy(false);

            var _entity = db.Set<TWitEntity>().Find(id);
            if (_entity != null)
            {
                db.Set<TWitEntity>().Remove(_entity);
                try
                {
                    await db.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    //Workaround for the meantime. Refactor this
                    if (ex.InnerException.InnerException is SqlException)
                    {
                        switch (((SqlException)ex.InnerException.InnerException).Number)
                        {
                            case 547:
                                throw new Exception("You cannot delete this row because it's being used by others");
                        }
                    }
                }
            }
        }
    }
}
