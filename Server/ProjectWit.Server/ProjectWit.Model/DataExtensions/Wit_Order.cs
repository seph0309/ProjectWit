using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Data.Entity;

    [MetadataType(typeof(Wit_OrderMetaData))]
    public partial class Wit_Order : WitDbContextBase<Wit_Order>, IWit_Order
    {
        public static Wit_Order ToSerializable(Wit_Order _wit_Order)
        {
            return new Wit_Order
            {
                Order_UID = _wit_Order.Order_UID,
                Transaction_UID = _wit_Order.Transaction_UID,
                Item_UID = _wit_Order.Item_UID,
                Quantity = _wit_Order.Quantity,
                ModifiedDate = _wit_Order.ModifiedDate,
                ModifiedBy = _wit_Order.ModifiedBy
            };
        }

        public async Task<Wit_Order> GetByIdAsync(Guid? id)
        {
            db.Configuration.LazyLoadingEnabled = true;
            return await db.Wit_Order.Where(m => m.Order_UID == id).FirstOrDefaultAsync();
        }

        public List<Wit_Order> GetOrders(string transactionID)
        {
            return db.Wit_Order.Where(m => m.Transaction_UID == new Guid(transactionID)).ToList();
        }

        public Wit_Order SetOrderStatus(string orderID, string status)
        {
            try
            {
                var order = FindByIdAsync(new Guid(orderID)).Result;
                Wit_Status witStatus = new Wit_Status();
                if (order == null || witStatus.IsStatusValid(status)) return order;
                order.OrderStatus = status;
                UpdateAsync(order, string.Empty).Wait();
                return order;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Wit_Order SetOrderQuantity(string orderID, int quantity)
        {
            try
            {
                var order = GetByIdAsync(new Guid(orderID)).Result;
                if (order == null) return order;
                order.Quantity = quantity;
                UpdateAsync(order, string.Empty).Wait();
                return order;
            }
            catch (Exception ex)
            {
                LogMsg(ex.Message);
                throw ex;
            }
        }
        public void Dispose()
        {
            GC.Collect();
            db.Dispose();
        }
    }

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
