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
    
    [MetadataType(typeof(WitSessionMetaData))]
    public partial class Wit_Session
    {
    }

    public class WitSessionMetaData
    {
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
