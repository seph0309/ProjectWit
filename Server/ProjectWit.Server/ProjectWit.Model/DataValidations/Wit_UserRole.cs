using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;

    [MetadataType(typeof(Wit_UserRoleMetaData))]
    public partial class Wit_UserRole { }

    public class Wit_UserRoleMetaData
    {
        public System.Guid UserRole_UID { get; set; }
        public System.Guid Role_UID { get; set; }
        public System.Guid User_UID { get; set; }
    
    }
}
