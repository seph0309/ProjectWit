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
    
    public partial class Wit_Table
    {
        public Wit_Table()
        {
            this.Wit_Transaction = new HashSet<Wit_Transaction>();
        }
    
        public System.Guid Table_UID { get; set; }
        public System.Guid Company_UID { get; set; }
        public string TableName { get; set; }
        public string TableDescription { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    
        public virtual Wit_Company Wit_Company { get; set; }
        public virtual ICollection<Wit_Transaction> Wit_Transaction { get; set; }
    }
}
