using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Data.Entity;

    [MetadataType(typeof(Wit_TransactionMetaData))]
    public partial class Wit_Transaction : WitDbContextBase<Wit_Transaction>, IWit_Transaction
    {
        public static Wit_Transaction ToSerializable(Wit_Transaction _wit_Transaction)
        {
            return new Wit_Transaction
            {
                Transaction_UID = _wit_Transaction.Transaction_UID,
                Table_UID = _wit_Transaction.Table_UID,
                Status = _wit_Transaction.Status,
                ModifiedDate = _wit_Transaction.ModifiedDate,
                ModifiedBy = _wit_Transaction.ModifiedBy
            };
        }
        public async Task<Wit_Transaction> GetByIdAsync(Guid? id)
        {
            db.Configuration.LazyLoadingEnabled = true;
            return await db.Wit_Transaction.Where(m => m.Transaction_UID == id).FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            GC.Collect();
            db.Dispose();
        }
    }

    public class Wit_TransactionMetaData
    {
        public System.Guid Transaction_UID { get; set; }
        [Required]
        [Display(Name="Table")]
        public System.Guid Table_UID { get; set; }
        [Display(Name = "Number of Guest")]
        public Nullable<int> NumberOfGuest { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
   
    }
}
