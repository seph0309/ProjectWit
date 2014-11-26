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
        List<Wit_Order> Orders;

        private IWit_Order IOrder;

        public OrderServiceArgs(string sessionID)
            : base(sessionID)
        {
            IOrder = kernel.Get<IWit_Order>();
            IOrder.SetDbContext(new WitServiceDBContext(SessionID.ToString()));
        }
    }
}