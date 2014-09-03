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
        public System.Guid Table_UID { get; set; }
        public Nullable<int> NumberOfGuest { get; set; }
        public System.Guid Status_UID { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
   
    }
}
