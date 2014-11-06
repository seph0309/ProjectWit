
namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Threading.Tasks;


    [MetadataType(typeof(Wit_CategoryMetaData))]
    public partial class Wit_Category : WitDbContextBase<Wit_Category>, IWit_Category
    {
        public static Wit_Category ToSerializable(Wit_Category _wit_Category)
        {
            return new Wit_Category
            {
                Category_UID = _wit_Category.Category_UID,
                CategoryName = _wit_Category.CategoryName,
                Company_UID = _wit_Category.Company_UID,
                ModifiedBy = _wit_Category.ModifiedBy,
                ModifiedDate = _wit_Category.ModifiedDate
            };
        }

        public async Task<Wit_Category> GetByIdAsync(Guid? id)
        {
            db.Configuration.LazyLoadingEnabled = true;
            return await db.Wit_Category.Where(m => m.Category_UID == id).FirstOrDefaultAsync();
        }

        public async Task<Wit_Category> FindByIdAsync(Guid? id)
        {
            return await base.dbFindByIdAsync(id);
        }

        public async Task<List<Wit_Category>> GetAllAsync()
        {
            db.Configuration.LazyLoadingEnabled = true;
            return await base.dbGetAllAsync();
        }

        public async Task<Wit_Category> CreateAsync(Wit_Category entity, string modifiedBy)
        {
            return await base.dbCreateAsync(entity, modifiedBy);
        }

        public async Task RemoveAsync(Guid? id)
        {
            await base.dbRemoveAsync(id);
        }

        public async Task UpdateAsync(Wit_Category entity, string modifiedBy)
        {
            await base.dbUpdateAsync(entity, modifiedBy);
        }
        public void Dispose()
        {
            GC.Collect();
            db.Dispose();
        }
    }

    public class Wit_CategoryMetaData
    { 
        public System.Guid Category_UID { get; set; }
        [Required]
        [Display(Name = "Company")]
        public System.Guid Company_UID { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
