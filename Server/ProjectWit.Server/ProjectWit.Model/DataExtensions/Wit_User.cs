using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;

    [MetadataType(typeof(Wit_UserMetaData))]
    public partial class Wit_User {

        public string ConfirmPassword { get; set; }
        [Display(Name = "User")]
        public string FullName { get { return string.Format("{0}, {1}", LastName, FirstName); } }
    }

    public class Wit_UserMetaData
    {
        public System.Guid User_UID { get; set; }
        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Company")]
        public System.Guid Company_UID { get; set; }
        [Display(Name = "Email")]
        [EmailAddressAttribute]
        public string EmailAddress { get; set; }
    }
}
