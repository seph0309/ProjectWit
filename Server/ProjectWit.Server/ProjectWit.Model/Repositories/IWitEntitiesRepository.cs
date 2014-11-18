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
    public interface IWit_Session : IReadable<Wit_Session>, IWritable<Wit_Session>, IDisposable
    {
        List<Wit_Session> GetSession(string userUID);
    }
    public interface IWit_Category : IReadable<Wit_Category>, IWritable<Wit_Category>, IDisposable
    {
    }
    public interface IWit_Company : IReadable<Wit_Company>, IWritable<Wit_Company>, IDisposable
    {
    }
    public interface IWit_Table : IReadable<Wit_Table>, IWritable<Wit_Table>, IDisposable
    {
    }
    public interface IWit_Order : IReadable<Wit_Order>, IWritable<Wit_Order>, IDisposable
    {
    }
    public interface IWit_Transaction : IReadable<Wit_Transaction>, IWritable<Wit_Transaction>, IDisposable
    {
    }
    public interface IWit_User : IReadable<Wit_User>, IWritable<Wit_User>, IDisposable
    {
        //Most of the business logic were moved to IUsersViewModel interface
    }
    public interface IAspNetRole : IReadable<AspNetRole>, IWritable<AspNetRole>, IDisposable
    {
        List<AspNetRole> GetRoles(string UserID);
        void UpdateRole(string userId, List<AspNetRole> aspNetRole);
    }
    public interface IWit_Item : IReadable<Wit_Item>, IWritable<Wit_Item>, IDisposable
    {
    }
    public interface IUsersViewModel : IReadable<UsersViewModel>, IWritable<UsersViewModel>, IDisposable
    {
        UsersViewModel GetUserDetail(Guid? userID);
        bool UpdateUser(UsersViewModel usersViewModel, string modifiedBy);
    }
    public interface IWit_NavBar : IDisposable
    {
        List<Wit_NavBar> GetNavBar(string userUID);
    }
}
