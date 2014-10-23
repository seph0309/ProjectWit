using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWit.Model;
using System.Runtime.Serialization;

namespace ProjectWit.Service
{
    [DataContract]
    public abstract class WitSessionServiceBase
    {
        [DataMember]
        public string Browser { get; set; }
        [DataMember]
        public string DeviceType { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public bool IsAuthenticated { get; set; }
        [DataMember]
        public Guid? SessionID { get; set; }

        public WitSessionServiceBase()
        {

        }

        public Guid? GetSession(string userUID, bool saveWhenNoSession)
        {
            using (WITEntities db = new WITEntities())
            {
                var _getSession = (from col in db.Wit_Session
                                   where col.User_UID == new Guid(userUID)
                                   select new { Session_UID = col.Session_UID }).ToList();

                if (_getSession.Count > 0)
                {
                    IsAuthenticated = true;
                    return _getSession[0].Session_UID;
                }
                else
                {
                    if (saveWhenNoSession)
                    {
                        Wit_Session session = new Wit_Session { User_UID = new Guid(userUID), Browser = Browser, DeviceType = DeviceType };
                        db.Wit_Session.Add(session);
                        db.SaveChanges();
                        return session.Session_UID;
                    }
                    else return null;
                }
            }
        }
    }
}