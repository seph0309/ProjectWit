namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class WitDbContext
    {
        public string ModifiedBy { get; set; }
        
        public override System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            SetProperties();
            return base.SaveChangesAsync();
        }
        public override int SaveChanges()
        {
            SetProperties();
            return base.SaveChanges();
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
