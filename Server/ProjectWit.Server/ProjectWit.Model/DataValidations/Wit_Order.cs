using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;

    [MetadataType(typeof(Wit_OrderMetaData))]
    public partial class Wit_Order { }

    public class Wit_OrderMetaData
    {
        public System.Guid Order_UID { get; set; }
        [Required]
        [Display(Name = "Transaction")]
        public System.Guid Transaction_UID { get; set; }
        public System.Guid Item_UID { get; set; }
        public int Quantity { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}
