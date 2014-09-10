namespace ProjectWit.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public partial class WITEntities : DbContext
    {
        string User_UID = string.Empty;
        public WITEntities(string userID) 
        {
            User_UID = userID;
        }
        public override System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            var modifiedEntries = this.ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var dbEntityEntry in modifiedEntries)
            {
                dbEntityEntry.Property("ModifiedDate").CurrentValue = DateTime.UtcNow;
            }


            return base.SaveChangesAsync();
        }

        public override int SaveChanges()
        {
            var changeSet = ChangeTracker.Entries();


            return base.SaveChanges();
        }

    }
}
