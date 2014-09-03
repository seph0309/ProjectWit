 using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;

    [MetadataType(typeof(Wit_CompanyMetaData))]
    public partial class Wit_Company { }

    public class Wit_CompanyMetaData
    {
    
        public System.Guid Company_UID { get; set; }
        [Required]
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        [Display(Name = "Address")]
        public string CompanyAddress { get; set; }
        [Display(Name = "Phone Number")]
        public string CompanyNumber { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}
