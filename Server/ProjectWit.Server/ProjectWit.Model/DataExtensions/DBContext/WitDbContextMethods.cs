namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class WitDbContext
    {
        public bool DeleteUser(Guid? guid)
        {
            Wit_User wit_user = this.Wit_User.Find(guid);
            AspNetUser aspnetuser = this.AspNetUsers.Find(guid.ToString());

            this.Wit_User.Remove(wit_user);
            this.AspNetUsers.Remove(aspnetuser);
            this.SaveChangesAsync();
            return true;
        }
       
       
       
      
        public List<Wit_NavBar> GetNavBar(string userUID)
        {
            //Initial Get
            var navBar = Wit_NavBar.Where(m => m.Menu == Wit_Menu.MyProfile);

            List<AspNetRole> roles = AspNetRoles.Where(m => m.AspNetUsers.Any(user => user.Id == userUID)).ToList();


            foreach (AspNetRole role in roles)
            {
                if (!role.IsGuest())
                {
                    if (role.IsPowerUser())
                    {
                        navBar = navBar.Union(
                                Wit_NavBar.Where(m => m.Menu == Wit_Menu.AdminMaintenance));
                    }
                    navBar = navBar.Union(
                        Wit_NavBar.Where(m => m.Menu == Wit_Menu.MobileAdministrator));
                }
            }

            return navBar.ToList();
        }
        public void SetTrackingAndProxy(bool value)
        {
            Configuration.ProxyCreationEnabled = value;
            Configuration.AutoDetectChangesEnabled = value;
        }
     
    }
}
