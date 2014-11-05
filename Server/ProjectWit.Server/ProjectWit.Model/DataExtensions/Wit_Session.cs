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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Threading.Tasks;
    
    [MetadataType(typeof(WitSessionMetaData))]
    public partial class Wit_Session : IWit_Session
    {
        public WitDbContext db;
        public string ShowFullName { get; set; }

        public string helloWorld(string msg)
        {
            return "Hello World!!";
        }

        public List<Wit_Session> GetSession(string userUID)
        {
            db = new WitDbContext();
            db.Configuration.LazyLoadingEnabled = true;
            List<AspNetRole> roles = db.AspNetRoles.Where(m => m.AspNetUsers.Any(user => user.Id == userUID)).ToList();

            foreach (AspNetRole role in roles)
            {
                if (role.IsPowerUser())
                {
                    return db.Wit_Session.ToList();
                }
                else if (role.IsCompanyAdmin())
                {
                    var comp = (from user in db.Wit_User
                                where user.User_UID == new Guid(userUID)
                                select new { CompanyUID = user.Company_UID }).FirstOrDefault();
                    if (comp.CompanyUID != null)
                    {
                        var returnVal = db.Wit_Session.SqlQuery(AspNetRole.GeAdminSessionQuery(comp.CompanyUID.ToString()));
                        return returnVal.ToList();
                    }
                }
            }
            //Return default (per user)
            return db.Wit_Session.Where(m => m.User_UID == new Guid(userUID)).ToList();
        }

        public IList<Wit_Session> GetByID(Guid? id)
        {
            throw new NotImplementedException();
        }

        public List<Wit_Session> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Create(ref Wit_Session entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Wit_Session GetById(Guid? id)
        {
            db = new WitDbContext();
            db.Configuration.LazyLoadingEnabled = true;
            Wit_Session wit_Session = db.Wit_Session.Find(id);
            return wit_Session;
        }

        public Wit_Session FindById(Guid? id)
        {
            db = new WitDbContext();
            db.Configuration.LazyLoadingEnabled = true;
            Wit_Session wit_Session = db.Wit_Session.Find(id);
            return wit_Session;
        }


    } 

    public class WitSessionMetaData
    {
        [Display(Name="Session ID")]
        public System.Guid Session_UID { get; set; }
        public System.Guid User_UID { get; set; }
        public string Browser { get; set; }
        [Display(Name = "Device")]
        public string DeviceType { get; set; }
        [Display(Name = "Last Active")]
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string IP { get; set; }
        public string Location { get; set; }
    
    }
}
