using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWit.Model
{
    /// <summary>
    /// All Wit Entities goes here
    /// </summary>
    public interface IWit_Session : IReadable<Wit_Session>, IWritable<Wit_Session>, ILogger, IDisposable
    {
        List<Wit_Session> GetSession(string userUID);
    }
    public interface IWit_Category : IReadable<Wit_Category>, IWritable<Wit_Category>, ILogger, IDisposable
    {
    }
    public interface IWit_Company : IReadable<Wit_Company>, IWritable<Wit_Company>, ILogger, IDisposable
    {
    }
    public interface IWit_Table : IReadable<Wit_Table>, IWritable<Wit_Table>, ILogger, IDisposable
    {
    }
    public interface IWit_Order : IReadable<Wit_Order>, IWritable<Wit_Order>, ILogger, IDisposable
    {
        List<Wit_Order> GetOrders(string transactionID);
        Wit_Order SetOrderStatus(string orderID, string status);
        Wit_Order SetOrderQuantity(string orderID, int quantity);
    }
    public interface IWit_Transaction : IReadable<Wit_Transaction>, IWritable<Wit_Transaction>, ILogger, IDisposable
    {
        Wit_Transaction SetTable(string transactionID, string tableID);
        Wit_Transaction SetGuestCount(string transactionID, int count);
        Wit_Transaction SetTransactionStatus(string transactionID, string status);
    }
    public interface IWit_User : IReadable<Wit_User>, IWritable<Wit_User>, ILogger, IDisposable
    {
        //Most of the business logic were moved to IUsersViewModel interface
    }
    public interface IAspNetRole : IReadable<AspNetRole>, IWritable<AspNetRole>, ILogger, IDisposable
    {
        List<AspNetRole> GetRoles(string UserID);
        void UpdateRole(string userId, List<AspNetRole> aspNetRole);
    }
    public interface IWit_Item : IReadable<Wit_Item>, IWritable<Wit_Item>, ILogger, IDisposable
    {
    }
    public interface IUsersViewModel : IReadable<UsersViewModel>, IWritable<UsersViewModel>, ILogger, IDisposable
    {
        UsersViewModel GetUserDetail(Guid? userID);
        bool UpdateUser(UsersViewModel usersViewModel, string modifiedBy);
    }
    public interface IWit_NavBar : IDisposable
    {
        List<Wit_NavBar> GetNavBar(string userUID);
    }
}
