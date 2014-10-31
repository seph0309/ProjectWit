﻿namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class WitDbContext
    {
        public string User_UID { get; set; }

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
                if (dbEntityEntry.State == EntityState.Added)
                {
                    ////Remove GUID's value when saving
                    //if (dbEntityEntry.Entity.GetType() == typeof(ProjectWit.Model.Wit_Category))
                    //    dbEntityEntry.Property("Category_UID").CurrentValue = null;
                }
                    

                dbEntityEntry.Property("ModifiedDate").CurrentValue = DateTime.Now;
                dbEntityEntry.Property("ModifiedBy").CurrentValue = User_UID;
            }
        }

    }
}