using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWit.Service.ServiceArguments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectWit.Model;

namespace ProjectWit.Service.ServiceArguments.Tests
{
    [TestClass()]
    public class OrderServiceArgsTests
    {
        Wit_Order order = new Wit_Order();
        WitService witService = new WitService();
        OrderServiceArgs srvcArgs = new OrderServiceArgs("80de087b-346f-e411-989a-0021ccc18cf4");
        const string sessionID = "80de087b-346f-e411-989a-0021ccc18cf4";
        const string itemID = "47DF81BC-D64E-E411-A417-D459F8E9FF23";
        const string status = "Open";

        [TestMethod()]
        public void OrderServiceArgsTest()
        {
            //Call WitService
            order.Transaction_UID = new Guid("F0E2C3DB-3B71-E411-BBC2-0021CCC18CF4");
            order.Quantity = 99;
            order.OrderStatus = "Open";

            //Steps: SaveOrders, Get, Set
            srvcArgs = witService.SaveOrders(sessionID, order.Transaction_UID.ToString(), itemID, order.Quantity, status);
            srvcArgs = witService.SaveOrders(sessionID, order.Transaction_UID.ToString(), itemID, order.Quantity, status);
            srvcArgs = witService.SaveOrders(sessionID, order.Transaction_UID.ToString(), itemID, order.Quantity, status);
            srvcArgs = witService.SaveOrders(sessionID, order.Transaction_UID.ToString(), itemID, order.Quantity, status);
            srvcArgs = witService.GetOrders(sessionID, order.Transaction_UID.ToString());
            
            

        }

    
    }
}
