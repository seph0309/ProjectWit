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
    
    public partial class Wit_User
    {
        public Wit_User()
        {
            this.Wit_Session = new HashSet<Wit_Session>();
        }
    
        public System.Guid User_UID { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public System.Guid Company_UID { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    
        public virtual Wit_Company Wit_Company { get; set; }
        public virtual ICollection<Wit_Session> Wit_Session { get; set; }
    }
}
