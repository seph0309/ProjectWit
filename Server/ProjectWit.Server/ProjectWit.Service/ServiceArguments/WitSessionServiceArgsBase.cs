﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Model;
using System.Runtime.Serialization;

namespace ProjectWit.Service
{
    [DataContract]
    public abstract class WitSessionServiceArgsBase
    {
        [DataMember(Order = 0)]
        public Guid? SessionID { get; set; }
        [DataMember(Order = 1)]
        public bool IsAuthenticated { get; set; }
        [DataMember(Order = 2)]
        public List<string> LogMessage { get; set; }
        [DataMember(Order = 3)]
        public string DeviceType { get; set; }
        [DataMember(Order = 4)]
        public string Browser { get; set; }

        internal string _userUID;
        internal string _companyUID;

        internal WitSessionServiceArgsBase()
        {
            LogMessage = new List<string>();
        }
        internal bool AuthenticateSession(string sessionUID)
        {
            if (!Wit_Commons.IsStringGUID(sessionUID))
            {
                LogMessage.Add("Invalid Session");
                return false;
            }
            using(WITEntities db = new WITEntities())
            {

                var _getSession = (from col in db.Wit_Session
                                   where col.Session_UID == new Guid(sessionUID)
                                   select new { Session_UID = col.Session_UID, UserUID = col.User_UID }).ToList();

                if (_getSession.Count == 0) return false;
                else
                {
                    InitializeSession(_getSession[0].Session_UID, _getSession[0].UserUID.ToString());
                }
            }
            return true;
        }
        internal void GenerateSession(string userUID)
        {
            using (WITEntities db = new WITEntities())
            {
                Wit_Session session = new Wit_Session { User_UID = new Guid(userUID), Browser = Browser, DeviceType = DeviceType };
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
            using (WITEntities db = new WITEntities())
            {
                string _sql;
                _sql = string.Format("DELETE FROM Wit_Session WHERE Session_UID = '{0}'", sessionID);
                rowsAffected = db.Database.ExecuteSqlCommand(_sql);
                return rowsAffected;
            }
        }
    }
}