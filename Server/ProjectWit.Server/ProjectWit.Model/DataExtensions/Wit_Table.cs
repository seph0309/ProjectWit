using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;

    [MetadataType(typeof(Wit_TableMetaData))]
    public partial class Wit_Table 
    {
        public Wit_Table(Wit_Table _wit_Table)
        {
            Table_UID = _wit_Table.Table_UID;
            TableName = _wit_Table.TableName;
            TableDescription=_wit_Table.TableDescription;
            Company_UID = _wit_Table.Company_UID;
            ModifiedBy = _wit_Table.ModifiedBy;
            ModifiedDate = _wit_Table.ModifiedDate;
        }
    }

    public class Wit_TableMetaData
    {
        public System.Guid Table_UID { get; set; }
        [Required]
        [Display(Name="Company")]
        public System.Guid Company_UID { get; set; }
        [Display(Name = "Table")]
        public string TableName { get; set; }
        [Display(Name = "Description")]
        public string TableDescription { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}
