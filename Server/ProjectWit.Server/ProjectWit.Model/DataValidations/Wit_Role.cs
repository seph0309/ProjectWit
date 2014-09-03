using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;

    [MetadataType(typeof(Wit_RoleMetaData))]
    public partial class Wit_Role { }

    public class Wit_RoleMetaData
    {
        public System.Guid Role_UID { get; set; }
        [Required]
        [Display(Name = "Role Description")]
        public string RoleDescription { get; set; }

    }
}
