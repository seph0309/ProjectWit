using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Model;
using System.Runtime.Serialization;
using System.ServiceModel.Web;

namespace ProjectWit.Service.ServiceArguments
{
    [DataContract]
    public class WitSessionServiceArgs : WitServiceArgs
    {
        [DataMember(Order = 0)]
        public Guid? SessionID { get; set; }
        [DataMember(Order = 1)]
        public bool IsAuthenticated { get; set; }
        
        
        protected WitSessionServiceArgs()
        {
        }

        protected WitSessionServiceArgs(string sessionID) :this()
        {
            if (!AuthenticateSession(sessionID))
                throw new WebFaultException<string>("Invalid Session",System.Net.HttpStatusCode.Forbidden);
            SessionID = new Guid(sessionID);
        }

        internal bool AuthenticateSession(string sessionUID)
        {
            if (!Wit_Commons.IsStringGUID(sessionUID))
            {
                LogMsg("Invalid Session");
                return false;
            }
            using(WitServiceDBContext db = new WitServiceDBContext())
            {

                var _getSession = (from col in db.Wit_Session
                                   where col.Session_UID == new Guid(sessionUID)
                                   select new { Session_UID = col.Session_UID, UserUID = col.User_UID }).ToList();

                if (_getSession.Count == 0)
                {
                    LogMsg("Invalid session.");
                    return false;
                }
                else
                {
                    InitializeSession(_getSession[0].Session_UID, _getSession[0].UserUID.ToString());
                }
            }
            return true;
        }
        internal void GenerateSession(string userUID)
        {
            using (WitServiceDBContext db = new WitServiceDBContext())
            {
                Wit_Session session = new Wit_Session { User_UID = new Guid(userUID), Browser = _browser, 
                    DeviceType = _deviceType, IP = _iP, 
                    Location = _location };

                db.Wit_Session.Add(session);
                db.SaveChanges();
                InitializeSession(session.Session_UID, userUID); 
            }
        }
        private void InitializeSession(Guid sessionUID, string userUID)
        {
            IsAuthenticated = true;
            SessionID = sessionUID;
            _userUID = userUID;
        }

        internal int TerminateSessionID(string sessionID)
        {
            int rowsAffected =0;
            using (WitServiceDBContext db = new WitServiceDBContext())
            {
                string _sql;
                _sql = string.Format("DELETE FROM Wit_Session WHERE Session_UID = '{0}'", sessionID);
                rowsAffected = db.Database.ExecuteSqlCommand(_sql);
                return rowsAffected;
            }
        }

       
    }
}