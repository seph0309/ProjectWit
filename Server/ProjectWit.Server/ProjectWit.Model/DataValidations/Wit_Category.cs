using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;

    [MetadataType(typeof(Wit_CategoryMetaData))]
    public partial class Wit_Category { }

    public class Wit_CategoryMetaData
    { 
        public System.Guid Category_UID { get; set; }
        public System.Guid Company_UID { get; set; }
        public string CategoryName { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
