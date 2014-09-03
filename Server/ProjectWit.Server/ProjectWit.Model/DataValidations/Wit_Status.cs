using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;

    [MetadataType(typeof(Wit_StatusMetaData))]
    public partial class Wit_Status { }

    public class Wit_StatusMetaData
    {
        public System.Guid Status_UID { get; set; }
        public System.Guid Company_UID { get; set; }
        public string SatusDescription { get; set; }

    }
}
