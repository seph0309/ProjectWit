using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Model;
using System.Runtime.Serialization;

namespace ProjectWit.Service.ServiceArguments
{
    [DataContract]
    public class LoginServiceArgs: WitSessionServiceArgs
    {
        [DataMember(Order = 0)]
        public List<Wit_Category> Categories;
        [DataMember(Order = 1)]
        public List<Wit_Item> Items;
        [DataMember(Order = 2)]
        public List<Wit_Table> Tables;
        [DataMember(Order = 3)]
        public List<KeyValuePair<int, string>> Status;

        #region GetData
        private void GetData(string companyUID)
        {
            Categories = new List<Wit_Category>();
            Items = new List<Wit_Item>();
            Tables = new List<Wit_Table>();
            Status = Wit_Status.Status;

            GetCategories(companyUID);
            GetTables(companyUID);
        }
 
        private void GetTables(string companyUID)
        {
            using (WitServiceDBContext db = new WitServiceDBContext())
            { 
                var tables = db.Wit_Table.Where(m => m.Company_UID == new Guid(companyUID)).ToList();
                Tables = tables;
            }
        }
        private void GetCategories(string companyUID)
        {
            using (WitServiceDBContext db = new WitServiceDBContext())
            {
                db.Configuration.LazyLoadingEnabled = true;
                db.Configuration.ProxyCreationEnabled = true;
                var cat = db.Wit_Category.Where(m => m.Company_UID == new Guid(companyUID)).ToList();
                                
                foreach (Wit_Category category in cat)
                {
                    Categories.Add(Wit_Category.ToSerializable(category));
                    AddItem(category);
                }
            }
        }
        private void AddItem(Wit_Category category)
        {
            foreach (Wit_Item item in category.Wit_Item)
            {
                Items.Add(Wit_Item.ToSerializable(item));
            }
        }
        #endregion
        private void InitializeCompanyUID(string UserUID)
        {
            using (WitServiceDBContext db = new WitServiceDBContext())
            {
                var _comp = (from col in db.Wit_User
                              where col.User_UID == new Guid(UserUID)
                              select new { CompanyUID = col.Company_UID }).FirstOrDefault();
                _companyUID = _comp.CompanyUID.ToString();
            }
        }
        #region Constructors
        public LoginServiceArgs()
        {
        }
        public LoginServiceArgs(string sessionID)
        {
            if (!AuthenticateSession(sessionID)) return;
            else
            {
                InitializeCompanyUID(_userUID);
                GetData(_companyUID);
            }
        }
        public LoginServiceArgs(string userName, string password, string browser, string deviceType)
        {
            if (AuthenticateUser(userName, password, browser, deviceType))
                GetData(_companyUID);
        }
        #endregion
        /// <summary>
        /// Checks if session exist in database
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        public bool IsSessionActive(string sessionID)
        {
            AuthenticateSession(sessionID);
            return IsAuthenticated;
        }
        public void TerminateSession(string sessionID)
        {
            if (Wit_Commons.IsStringGUID(sessionID))
            {
                if (TerminateSessionID(sessionID) > 0)
                    LogMsg("Session Deleted");
                else
                    LogMsg("Session does not exist");
            }
            else
                LogMsg("Invalid Session");
        }
        private bool AuthenticateUser(string userName, string password, string browser, string deviceType)
        {
            _browser = browser;
            _deviceType = deviceType;

            if (userName == null) return false;
            using (WitServiceDBContext db = new WitServiceDBContext())
            {
                var user = db.AspNetUsers.Where(m => m.UserName == userName.ToString()).FirstOrDefault();

                if (user != null && !String.IsNullOrEmpty(password))
                {
                    bool authenticatePassword = Wit_Cryptography.VerifyHashedPassword(user.PasswordHash, password);
                    if (authenticatePassword)
                    {
                        InitializeCompanyUID(user.Id);
                        GenerateSession(user.Id);
                        return true;
                    }
                }
                LogMsg("Wrong Username/Password");
                return false;
            }
        }
    }
}