//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Data.Entity;

    [MetadataType(typeof(UsersViewModelMetaData))]
    public partial class UsersViewModel : WitDbContextBase<UsersViewModel>, IUsersViewModel
    {    
        [Display(Name="Roles")]
        public List<AspNetRole> AspNetRole;

        public async Task<UsersViewModel> GetByIdAsync(Guid? id)
        {
            db.Configuration.LazyLoadingEnabled = true;
            return await db.UsersViewModels.Where(m => m.User_UID == id).FirstOrDefaultAsync();
        }
         
        public bool UpdateUser(UsersViewModel usersViewModel, string modifiedBy)
        {
            db.ModifiedBy = modifiedBy;
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

                AspNetRole role = new Model.AspNetRole();
                role.UpdateRole(usersViewModel.User_UID.ToString().ToUpper(), usersViewModel.AspNetRole);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public UsersViewModel GetUserDetail(Guid? userID)
        {
            UsersViewModel usersViewModel = db.UsersViewModels.Find(userID);

            if (usersViewModel == null) return null;

            AspNetRole _role = new AspNetRole();
            usersViewModel.AspNetRole = _role.GetRoles(userID.ToString());
            return usersViewModel;
        } 
        public void Dispose()
        {
            GC.Collect();
            db.Dispose();
        }
    }

    public class UsersViewModelMetaData
    {
        [Key]
        [Display(Name = "User Name")]
        public System.Guid User_UID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage="Company required")]
        [Display(Name = "Company")]
        public System.Guid Company_UID { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage="Email required")]
        [EmailAddressAttribute]
        public string EmailAddress { get; set; }
        [Display(Name = "Date Modified")]
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string UserName { get; set; }
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyNumber { get; set; }

    }
}
