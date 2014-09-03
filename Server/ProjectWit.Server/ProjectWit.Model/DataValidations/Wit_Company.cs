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
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyNumber { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}
