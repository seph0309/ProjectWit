namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;
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
                dbEntityEntry.Property("ModifiedBy").CurrentValue = "Joseph";
            }
        }

        public List<Wit_User> GetUsers()
        {
            string sql = string.Format("SELECT WIT_USER.User_UID, AspNetUsers.UserName AS UserName,WIT_USER.FirstName, WIT_USER.MiddleName,WIT_USER.LastName,");
            sql += string.Format("Wit_Company.Company_UID,Wit_Company.CompanyName,Wit_User.EmailAddress, WIT_USER.ModifiedDate,WIT_USER.ModifiedBy FROM ");
            sql += string.Format("WIT_USER INNER JOIN AspNetUsers ON Wit_User.User_UID= AspNetUsers.Id INNER JOIN Wit_Company ON Wit_User.Company_UID= Wit_Company.Company_UID ");
            var wit_users = Wit_User.SqlQuery(sql).ToList();
            return wit_users;
        }
    }
}
