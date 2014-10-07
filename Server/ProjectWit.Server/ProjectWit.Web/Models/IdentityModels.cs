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

        public UserManager<ApplicationUser> UserManager { get; private set; }
    }
}