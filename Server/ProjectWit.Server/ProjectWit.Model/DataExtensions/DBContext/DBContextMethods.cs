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
                this.SaveChanges();
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
