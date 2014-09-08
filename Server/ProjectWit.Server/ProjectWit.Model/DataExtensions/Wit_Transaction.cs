using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;

    [MetadataType(typeof(Wit_TransactionMetaData))]
    public partial class Wit_Transaction { }

    public class Wit_TransactionMetaData
    {
        public System.Guid Transaction_UID { get; set; }
        [Required]
        [Display(Name="Table")]
        public System.Guid Table_UID { get; set; }
        [Display(Name = "Number of Guest")]
        public Nullable<int> NumberOfGuest { get; set; }
        [Display(Name = "Status")]
        public System.Guid Status_UID { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
   
    }
}
