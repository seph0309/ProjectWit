using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;

    [MetadataType(typeof(Wit_ItemMetaData))]
    public partial class Wit_Item {

        public Wit_Item(Wit_Item _wit_Item)
        {
            Item_UID = _wit_Item.Item_UID;
            Category_UID = _wit_Item.Category_UID;
            ItemName = _wit_Item.ItemName;
            ItemDescription = _wit_Item.ItemDescription;
            ImageURL = _wit_Item.ImageURL;
            OnStock = _wit_Item.OnStock;
            SpiceLevel = _wit_Item.SpiceLevel;
            Likes = _wit_Item.Likes;
            FoodMark = _wit_Item.FoodMark;
            Amount = _wit_Item.Amount;
            DiscountedPrice = _wit_Item.DiscountedPrice;
            IsBestSeller = _wit_Item.IsBestSeller;
            ModifiedDate = _wit_Item.ModifiedDate;
            ModifiedBy = _wit_Item.ModifiedBy;
        }
    }

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
