using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Data.Entity;

    [MetadataType(typeof(Wit_TableMetaData))]
    public partial class Wit_Table : WitDbContextBase<Wit_Table>, IWit_Table
    {
        public static Wit_Table ToSerializable(Wit_Table _wit_Table)
        {
            return new Wit_Table
            {
                Table_UID = _wit_Table.Table_UID,
                TableName = _wit_Table.TableName,
                TableDescription = _wit_Table.TableDescription,
                Company_UID = _wit_Table.Company_UID,
                ModifiedBy = _wit_Table.ModifiedBy,
                ModifiedDate = _wit_Table.ModifiedDate
            };
        }
        public async Task<Wit_Table> GetByIdAsync(Guid? id)
        {
            db.Configuration.LazyLoadingEnabled = true;
            return await db.Wit_Table.Where(m => m.Table_UID == id).FirstOrDefaultAsync();
        }
        public void Dispose()
        {
            GC.Collect();
            db.Dispose();
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
