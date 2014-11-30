using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Model;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Ninject;

namespace ProjectWit.Service.ServiceArguments
{
    [DataContract]
    public class OrderServiceArgs : WitSessionServiceArgs
    {
        [DataMember(Order = 0)]
        public Wit_Order Order = new Wit_Order();
        [DataMember(Order = 1)]
        public List<Wit_Order> Orders = new List<Wit_Order>();
        
        private IWit_Order IOrder;

        public OrderServiceArgs(string sessionID)
            : base(sessionID)
        {
            IOrder = kernel.Get<IWit_Order>();
            IOrder.SetDbContext(new WitServiceDBContext(SessionID.ToString()), LogMessage);
        }

        public void GetOrders(string transactionID)
        {
            Orders = IOrder.GetOrders(transactionID);
        }

        public void NewOrder(string transactionID, string itemID, int quantity, string status)
        {
            Order.Transaction_UID = new Guid(transactionID);
            Order.Item_UID = new Guid(itemID);
            Order.Quantity = quantity;
            Order.OrderStatus = status;
            IOrder.CreateAsync(Order, string.Empty);
        }

        public void SetOrderStatus(string orderID, string orderStatus)
        {
            IOrder.SetOrderStatus(orderID, orderStatus);
        }

        public void SetOrderQuantity(string orderID, int quantity)
        {
            IOrder.SetOrderQuantity(orderID, quantity);
        }
    }
}