using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Data.Entity;

    [MetadataType(typeof(Wit_UserMetaData))]
    public partial class Wit_User : WitDbContextBase<Wit_User>, IWit_User
    {
        public string ConfirmPassword { get; set; }
        [Display(Name = "User")]
        public string FullName { get { return string.Format("{0}, {1}", LastName, FirstName); } }

        public async Task<Wit_User> GetByIdAsync(Guid? id)
        {
            db.Configuration.LazyLoadingEnabled = true;
            return await db.Wit_User.Where(m => m.User_UID == id).FirstOrDefaultAsync();
        }

        public async Task<Wit_User> FindByIdAsync(Guid? id)
        {
            return await base.dbFindByIdAsync(id);
        }

        public async Task<List<Wit_User>> GetAllAsync()
        {
            return await base.dbGetAllAsync();
        }

        public async Task<Wit_User> CreateAsync(Wit_User entity, string modifiedBy)
        {
            return await base.dbCreateAsync(entity, modifiedBy);
        }

        public async Task RemoveAsync(Guid? id)
        {
            await base.dbRemoveAsync(id);
            //Delete AspNetUser too
            AspNetUser aspnetuser = db.AspNetUsers.Find(id);

            db.AspNetUsers.Remove(aspnetuser);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Wit_User entity, string modifiedBy)
        {
            await base.dbUpdateAsync(entity, modifiedBy);
        }
        public bool UpdateUser(UsersViewModel usersViewModel)
        {
            Wit_User wit_user = new Wit_User();
            wit_user = db.Wit_User.Find(usersViewModel.User_UID);
            if (wit_user != null)
            {
                wit_user.Company_UID = usersViewModel.Company_UID;
                wit_user.User_UID = usersViewModel.User_UID;
                wit_user.FirstName = usersViewModel.FirstName;
                wit_user.MiddleName = usersViewModel.MiddleName;
                wit_user.LastName = usersViewModel.LastName;
                wit_user.EmailAddress = usersViewModel.EmailAddress;

                UpdateRole(usersViewModel.User_UID.ToString().ToUpper(), usersViewModel.AspNetRole);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
               
        private void UpdateRole(string userId, List<AspNetRole> aspNetRole)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM AspNetUserRoles WHERE UserId={0}", userId);
                    foreach (AspNetRole role in aspNetRole)
                    {
                        if (role.IsSelected)
                            db.Database.ExecuteSqlCommand("INSERT INTO AspNetUserRoles (RoleId,UserId) VALUES ({0},{1})", role.Id, userId);
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public void Dispose()
        {
            GC.Collect();
            db.Dispose();
        }
    }

    public class Wit_UserMetaData
    {
        public System.Guid User_UID { get; set; }
        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Company")]
        public System.Guid Company_UID { get; set; }
        [Display(Name = "Email")]
        [EmailAddressAttribute]
        public string EmailAddress { get; set; }
    }
}
