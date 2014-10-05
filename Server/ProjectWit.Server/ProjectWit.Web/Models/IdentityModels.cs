using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectWit.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProjectWit.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public override string Id
        {
            get
            {
                return base.Id.ToUpper();
            }
            set
            {
                base.Id = value.ToUpper();
            }
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this));
        }
        public List<AspNetRole> GetRoles(string UserID)
        {
            //Get Roles from user
            List<AspNetRole> aspNetRole = new List<AspNetRole>();

            //Get all Roles
            using (WITEntities db= new WITEntities())
            {
                var allRoles = db.AspNetRoles.ToList();
                var identityUserRole = db.AspNetRoles.Where(m => m.AspNetUsers.Any(user=>user.Id== UserID)).ToList();
    
                foreach(AspNetRole role in allRoles)
                {
                    var isSelected = from x in identityUserRole
                                     where x.Id == role.Id
                                     select x;
                       
                    aspNetRole.Add(new AspNetRole { 
                        Id = role.Id.ToString(), 
                        Name = role.Name.ToString(),
                        IsSelected = (isSelected.Count() > 0)
                    });
                }
            }
            return aspNetRole;
        }

        public void UpdateRole(string userId, List<AspNetRole> aspNetRole)
        {
            //Clear all roles the add the ones that is selected
            ClearAllRoles(userId);
            foreach (AspNetRole role in aspNetRole)
            {
                if (role.IsSelected)
                    UserManager.AddToRole(userId, role.Name);
            }
        }

        public void ClearAllRoles(string userID)
        {
            using (WITEntities db = new WITEntities())
            {
                //Clear all roles in User
                var aspNetRoles = db.AspNetRoles.Where(m => m.AspNetUsers.Any(user => user.Id == userID)).ToList();

                foreach (AspNetRole role in aspNetRoles)
                {
                    UserManager.RemoveFromRole(userID, role.Name);
                }
            }
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }
    }
}