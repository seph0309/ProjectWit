namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Threading.Tasks;

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
            var wit = this.UsersViewModels.Where(w => w.User_UID == new Guid("C200BBF2-A140-487B-992A-5741C9D03C20")).ToList();

            UsersViewModel usersViewModel = this.UsersViewModels.Find(new Guid("C200BBF2-A140-487B-992A-5741C9D03C20"));

            return wit_users;
        }

        public bool UpdateUser(UsersViewModel usersViewModel)
        {
            Wit_User wit_user = new Wit_User();
            wit_user = this.Wit_User.Find(usersViewModel.User_UID);
            if (wit_user != null)
            {
                wit_user.Company_UID = usersViewModel.Company_UID;
                wit_user.User_UID = usersViewModel.User_UID;
                wit_user.FirstName = usersViewModel.FirstName;
                wit_user.MiddleName = usersViewModel.MiddleName;
                wit_user.LastName = usersViewModel.LastName;
                wit_user.EmailAddress = usersViewModel.EmailAddress;
                this.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
        public bool DeleteUser(Guid? guid)
        {
            Wit_User wit_user = this.Wit_User.Find(guid);
            AspNetUser aspnetuser = this.AspNetUsers.Find(guid.ToString());

            this.Wit_User.Remove(wit_user);
            this.AspNetUsers.Remove(aspnetuser);
            this.SaveChangesAsync();
            return true;
        }
    }
}
