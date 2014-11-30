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
        public override async Task<Wit_Transaction> GetByIdAsync(Guid? id)
        {
            await base.GetByIdAsync(id);
            return await db.Wit_Transaction.Where(m => m.Transaction_UID == id).FirstOrDefaultAsync();
        }
        
        public Wit_Transaction SetTransactionStatus(string transactionID, string status)
        {
            try
            {
                var trans = GetByIdAsync(new Guid(transactionID)).Result;
                if (trans == null) 
                {
                    LogMsg("Transaction does not exist");
                    return trans;
                }

                Wit_Status wit_status = new Wit_Status();
                if (!wit_status.IsStatusValid(status)) return null;

                trans.Status = status;
                UpdateAsync(trans, string.Empty).Wait();
                return trans;
            }
            catch(Exception ex)
            {
                LogMsg(ex.Message);
                throw ex;
            }
        }

        public Wit_Transaction SetTable(string transactionID, string tableID)
        {
            try
            {
                var trans = GetByIdAsync(new Guid(transactionID)).Result;
                if (trans == null) return trans;

                Model.Wit_Table witTable = new Model.Wit_Table();
                trans.Table_UID = new Guid(tableID);
                UpdateAsync(trans, string.Empty).Wait();
                return trans;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Wit_Transaction SetGuestCount(string transactionID, int count)
        {
            try
            {
                var trans = GetByIdAsync(new Guid(transactionID)).Result;
                if (trans == null) return trans;
                trans.NumberOfGuest = count;
                UpdateAsync(trans, string.Empty).Wait();
                return trans;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
