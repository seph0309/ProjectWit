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
    
    public partial class Wit_Transaction
    {
        public Wit_Transaction()
        {
            this.Wit_Order = new HashSet<Wit_Order>();
        }
    
        public System.Guid Transaction_UID { get; set; }
        public System.Guid Table_UID { get; set; }
        public Nullable<int> NumberOfGuest { get; set; }
        public System.Guid Status_UID { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    
        public virtual ICollection<Wit_Order> Wit_Order { get; set; }
        public virtual Wit_Status Wit_Status { get; set; }
        public virtual Wit_Table Wit_Table { get; set; }
    }
}