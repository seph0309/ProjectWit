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
        [Required]
        [Display(Name = "Category")]
        public System.Guid Category_UID { get; set; }
        [Required]
        [Display(Name = "Item")]
        public string ItemName { get; set; }
        [Display(Name = "Description")]
        public string ItemDescription { get; set; }
        public string ImageURL { get; set; }
        [Display(Name = "Is on Stock?")]
        public bool OnStock { get; set; }
        [Display(Name = "Spice Level")]
        public string SpiceLevel { get; set; }
        public Nullable<int> Likes { get; set; }
        [Display(Name = "Food Mark")]
        public string FoodMark { get; set; }
        public decimal Amount { get; set; }
        public Nullable<decimal> DiscountedPrice { get; set; }
        public Nullable<bool> IsBestSeller { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
     }
}
