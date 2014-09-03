using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;

    [MetadataType(typeof(Wit_ItemMetaData))]
    public partial class Wit_Item { }

    public class Wit_ItemMetaData
    {
        public System.Guid Item_UID { get; set; }
        public System.Guid Category_UID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ImageURL { get; set; }
        public bool OnStock { get; set; }
        public string SpiceLevel { get; set; }
        public Nullable<int> Likes { get; set; }
        public string FoodMark { get; set; }
        public decimal Amount { get; set; }
        public Nullable<decimal> DiscountedPrice { get; set; }
        public Nullable<bool> IsBestSeller { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
     }
}
