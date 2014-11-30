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

        public override async Task<Wit_Company> GetByIdAsync(Guid? id)
        {
            await base.GetByIdAsync(id);
            return await db.Wit_Company.Where(m => m.Company_UID == id).FirstOrDefaultAsync();
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
