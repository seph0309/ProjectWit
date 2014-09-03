using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;

    [MetadataType(typeof(Wit_TableMetaData))]
    public partial class Wit_Table { }

    public class Wit_TableMetaData
    {
        public System.Guid Table_UID { get; set; }
        public System.Guid Company_UID { get; set; }
        public string TableName { get; set; }
        public string TableDescription { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}
