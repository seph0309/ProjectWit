namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Threading.Tasks;
    using ProjectWit.Model.ErrorLogging;

    public partial class WitDbContext
    {
        public string ModifiedBy { get; set; }
        private DBContextErrorLogging errorLog = new DBContextErrorLogging();
        
   
        public override System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            SetProperties();
            try
            {
                return base.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                errorLog.SetErrors(ex.EntityValidationErrors);
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                errorLog.dbContextErrorLogMsg.Add(string.Format("DbUpdateException exception"));
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public override int SaveChanges()
        {
            SetProperties();
            try
            {
                return base.SaveChanges();
            }
                catch (DbEntityValidationException ex)
            {
                errorLog.SetErrors(ex.EntityValidationErrors);
                throw ex;
            }
            catch(DbUpdateException ex)
            {
                errorLog.dbContextErrorLogMsg.Add(string.Format("DbUpdateException exception"));
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SetProperties()
        {
            var modifiedEntries = this.ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var dbEntityEntry in modifiedEntries)
            {
                if (dbEntityEntry.State == EntityState.Added || dbEntityEntry.State == EntityState.Modified)
                {
                    //Strictly track who modified the item
                    if (String.IsNullOrEmpty(ModifiedBy)) throw new Exception("ModifiedBy is required");
                }

                dbEntityEntry.Property("ModifiedDate").CurrentValue = DateTime.Now;
                dbEntityEntry.Property("ModifiedBy").CurrentValue = ModifiedBy;
            }
        }
    }
}
