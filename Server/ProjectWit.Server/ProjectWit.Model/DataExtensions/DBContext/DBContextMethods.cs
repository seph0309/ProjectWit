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

                UpdateRole(usersViewModel.User_UID.ToString().ToUpper(), usersViewModel.AspNetRole);
                this.SaveChanges();
                return true;
            }
            else
                return false;
        }
        private void UpdateRole(string userId, List<AspNetRole> aspNetRole)
        {
            using (var tran = this.Database.BeginTransaction())
            {
                try
                {
                    this.Database.ExecuteSqlCommand("DELETE FROM AspNetUserRoles WHERE UserId={0}", userId);
                    foreach (AspNetRole role in aspNetRole)
                    {
                        if (role.IsSelected)
                            this.Database.ExecuteSqlCommand("INSERT INTO AspNetUserRoles (RoleId,UserId) VALUES ({0},{1})", role.Id, userId);
                    }
                    tran.Commit();
                }
                catch(Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }
        
        public UsersViewModel GetUserDetail(Guid? userID)
        {
            UsersViewModel usersViewModel = this.UsersViewModels.Find(userID);
            
            if (usersViewModel == null) return null;
            
            usersViewModel.AspNetRole = GetRoles(userID.ToString());
            return usersViewModel;
        }

        private List<AspNetRole> GetRoles(string UserID)
        {
            //Get Roles from user
            List<AspNetRole> aspNetRole = new List<AspNetRole>();

            //Get all Roles
            using (WITEntities db = new WITEntities())
            {
                var allRoles = db.AspNetRoles.ToList();
                var identityUserRole = db.AspNetRoles.Where(m => m.AspNetUsers.Any(user => user.Id == UserID)).ToList();

                foreach (AspNetRole role in allRoles)
                {
                    var isSelected = from x in identityUserRole
                                     where x.Id == role.Id
                                     select x;

                    aspNetRole.Add(new AspNetRole
                    {
                        Id = role.Id.ToString(),
                        Name = role.Name.ToString(),
                        IsSelected = (isSelected.Count() > 0)
                    });
                }
            }
            return aspNetRole;
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
