using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;

    [MetadataType(typeof(Wit_UserMetaData))]
    public partial class Wit_User { }

    public class Wit_UserMetaData
    {
        public System.Guid User_UID { get; set; }
        public string FirsName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public System.Guid Company_UID { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

    }
}
