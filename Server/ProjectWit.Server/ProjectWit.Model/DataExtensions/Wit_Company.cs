 using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Threading.Tasks;

    [MetadataType(typeof(Wit_CompanyMetaData))]
    public partial class Wit_Company : WitDbContextBase<Wit_Company>, IWit_Company
    {

        public async Task<Wit_Company> GetByIdAsync(Guid? id)
        {
            db.Configuration.LazyLoadingEnabled = true;
            return await db.Wit_Company.Where(m => m.Company_UID == id).FirstOrDefaultAsync();
        }

        public async Task<Wit_Company> FindByIdAsync(Guid? id)
        {
            return await base.dbFindByIdAsync(id);
        }

        public async Task<List<Wit_Company>> GetAllAsync()
        {
            return await base.dbGetAllAsync();
        }

        public async Task<Wit_Company> CreateAsync(Wit_Company entity, string modifiedBy)
        {
            return await base.dbCreateAsync(entity, modifiedBy);
        }

        public async Task RemoveAsync(Guid? id)
        {
            await base.dbRemoveAsync(id);
        }

        public async Task UpdateAsync(Wit_Company entity, string modifiedBy)
        {
            await base.dbUpdateAsync(entity, modifiedBy);
        }
        public void Dispose()
        {
            GC.Collect();
            db.Dispose();
        }
    
    }

    public class Wit_CompanyMetaData
    {
    
        public System.Guid Company_UID { get; set; }
        [Required]
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        [Display(Name = "Address")]
        public string CompanyAddress { get; set; }
        [Display(Name = "Phone Number")]
        public string CompanyNumber { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}
