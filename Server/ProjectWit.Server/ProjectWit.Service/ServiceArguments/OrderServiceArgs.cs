using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Model;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ProjectWit.Service.ServiceArguments
{
    [DataContract]
    public class OrderServiceArgs : WitSessionServiceArgs
    {
        [DataMember(Order = 0)]
        List<Wit_Order> Orders;

        public OrderServiceArgs()
        { }
    }
}