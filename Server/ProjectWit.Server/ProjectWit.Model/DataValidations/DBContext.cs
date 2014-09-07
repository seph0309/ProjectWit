namespace ProjectWit.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class WITEntities : DbContext
    {
        string User_UID = string.Empty;
        public WITEntities(string userID) 
        {
            User_UID = userID;
        }

        public override int SaveChanges()
        {
            var changeSet = ChangeTracker.Entries();


            return base.SaveChanges();
        }

    }
}
