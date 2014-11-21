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
  

        public override async Task RemoveAsync(Guid? id)
        {
            await base.RemoveAsync(id);
            //Delete AspNetUser too
            AspNetUser aspnetuser = db.AspNetUsers.Find(id);

            db.AspNetUsers.Remove(aspnetuser);
            await db.SaveChangesAsync();
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
