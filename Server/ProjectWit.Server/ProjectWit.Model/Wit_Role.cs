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
    
    public partial class Wit_Role
    {
        public Wit_Role()
        {
            this.Wit_UserRole = new HashSet<Wit_UserRole>();
        }
    
        public System.Guid Role_UID { get; set; }
        public string RoleDescription { get; set; }
    
        public virtual ICollection<Wit_UserRole> Wit_UserRole { get; set; }
    }
}